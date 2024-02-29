using System.Collections.Generic;
using UnityEngine;

public class AverageTempGetter : MonoBehaviour
{

    [SerializeField] List<float> tempData = new List<float>();
    [SerializeField] int dataLimit;
    M5DataReceiver m5;

    void Update()
    {
        UpdaTemperatureData(ref tempData, m5.sensorInfo.temp, dataLimit);
    }

    /// <summary>
    /// valueListを更新する
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="valueList"></param>
    /// <param name="listLimit"></param>
    void UpdaTemperatureData(ref List<float> valueList, float newValue, int listLimit)
    {
        if (valueList.Count < listLimit)
        {
            valueList.Add(newValue); //データ数が上限未満の場合はそのまま追加
        }
        else
        {
            // データ数が上限になっている場合
            valueList.RemoveAt(0); // 最古の入力値を削除
            valueList.Add(newValue); // 新しい入力値を追加
        }
    }

}
