using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

// データを送受信する、シリアル通信クラス
public class SerialHandler : MonoBehaviour
{
    // シリアル通信で、データを受け取った時のイベント
    public event Action OnDataReceived;

    [Header("Serial Options")]
    [SerializeField, Tooltip("開かれるポート名")] string openedPortName;
    [SerializeField, Tooltip("開かれるポートのボーレート")] int baudRate;

    SerialPort serialPort;      // シリアルポート

    // thread
    Thread readingThread;       // 読み取り用のスレッド
    bool isThreadRunning;       // スレッド実行中フラグ
    
    string message;             // message
    bool isNewMessageReceived;  // 新しくメッセージを受け取ったかどうか

    //--------------------------------------------------

    // 開始時にポートを開く
    void Awake()
    {
        Open();
    }

    void Update()
    {
        // 受け取ったら、受け取り時の処理を実行
        if (isNewMessageReceived)
        {
            OnDataReceived();
        }

        isNewMessageReceived = false;
    }

    // 終了時にポートを閉じる
    private void OnDestroy()
    {
        Close();
    }

    //--------------------------------------------------

    // シリアルポートを開く
    void Open()
    {
        serialPort = new SerialPort(openedPortName, baudRate, Parity.None, 8, StopBits.One);    // ポートインスタンス作成
        serialPort.Open();  // 作成したポートを開く

        isThreadRunning = true; // 実行中フラグ立てる

        readingThread = new Thread(Read);   // スレッド作成
        readingThread.Start();              // スレッド開始(読み込み)

        print("port was setuped.");
    }

    // シリアルポートを閉じる
    void Close()
    {
        // フラグ降ろす
        isNewMessageReceived = false;
        isThreadRunning = false;

        if (readingThread != null && readingThread.IsAlive)
        {
            // スレッドが終了するまで待機
            print("waiting");

            readingThread.Join(TimeSpan.FromSeconds(.5f));
        }

        // ポートが開いていたら、閉じる
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();     // 閉じる
            serialPort.Dispose();   // リソース開放

            print("port was closed.");
        }
    }

    //--------------------------------------------------

    // シリアルポートに読み込む
    void Read()
    {
        while (isThreadRunning && serialPort != null && serialPort.IsOpen)
        {

            try
            {
                // ポートからのバイト数が0より多かったら、読み込み
                if (serialPort.BytesToRead > 0)
                {
                    message = serialPort.ReadLine();    // データ読み込み
                    isNewMessageReceived = true;        // メッセージ受け取りフラグ立てる
                }
            }

            // 例外
            catch (Exception exception)
            {
                Debug.LogWarning(exception.Message);
            }
        }
    }

    // シリアルポートに書き込む
    public void Write(string message)
    {
        // 書き込み
        try
        {
            serialPort.Write(message);
        }

        // 警告
        catch (Exception exception)
        {
            Debug.LogWarning(exception.Message);
        }
    }

    //--------------------------------------------------

    // コンマで区切られたメッセージを返す
    public string[] GetSplitedData()
    {
        // 受け取ったメッセージを区切る
        return message.Split(",");
    }
}

