using UnityEngine;

// データ受信基底クラス
public abstract class DataReceiver_Base:MonoBehaviour
{
    [SerializeField] protected SerialHandler handler;

	//--------------------------------------------------

	/// <summary>
	/// データ受信時の処理
	/// </summary>
	protected abstract void OnReceivedData();

	//--------------------------------------------------

	private void Awake()
	{
		handler.OnDataReceived += OnReceivedData;
	}
}
