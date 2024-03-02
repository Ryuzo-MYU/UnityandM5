using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaxTempAverageCalcurator : MonoBehaviour
{
    [SerializeField] M5DataReceiver m5;
    [SerializeField] int dataLimit;
    [SerializeField] List<float> tempList = new List<float>();
    [SerializeField] List<float> maxTempList;
    public float maxTempAverage;

    void Update()
    {
        UpdatDataList(ref tempList, m5.sensorInfo.temp, dataLimit);
        float maxTemp = FindMaxValue(tempList);
        UpdatDataList(ref maxTempList, maxTemp, dataLimit);
        maxTempAverage = maxTempList.Average();
    }

    /// <summary>
    /// valueListを更新する
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="valueList"></param>
    /// <param name="listLimit"></param>
    void UpdatDataList(ref List<float> valueList, float newValue, int listLimit)
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

    // List<float>型のリストの最大値を返す関数
    float FindMaxValue(List<float> floatList)
    {
        float maxValue = float.MinValue; // リスト内の最大値を保持する変数を初期化

        // リスト内の各要素をチェックして最大値を見つける
        foreach (float value in floatList)
        {
            if (value > maxValue)
            {
                maxValue = value;
            }
        }

        return maxValue;
    }
}
