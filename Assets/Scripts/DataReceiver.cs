using UnityEngine;

// デバイスの加速度を取得する
public class M5DataReceiver : MonoBehaviour
{
    //先ほど作成したクラス
    public SerialHandler serialHandler;

    // デバイス名
    public string Name { get; private set; }

    // ボタン状態
    // Tactは実ボタンの状態、Toggleは仮想のトグルボタンの状態
    public int BtnATactSwitch { get; private set; }
    public int BtnBTactSwitch { get; private set; }
    public int BtnAToggleSwitch { get; private set; }
    public int BtnBToggleSwitch { get; private set; }

    // 加速度
    public Vector3 Accelaration { get; private set; }

    // ジャイロ
    public Vector3 Gyro { get; private set; }

    // M5StickCの内部温度
    public float Temp { get; private set; }

    //--------------------------------------------------
    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        //文字列を送信
        // serialHandler.Write("hogehoge");
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\t" }, System.StringSplitOptions.None);
        if (data.Length < 2) return;

        try
        {
            Debug.Log(data[0]);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}