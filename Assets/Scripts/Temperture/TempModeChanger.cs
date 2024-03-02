using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class TempModeChanger : MonoBehaviour
{
    [SerializeField] MaxTempAverageCalcurator maxTempAverageCalcurator; //最高温度の平均値計算クラスのインスタンス
    public float maxTempAverage; // 最高温度平均

    public string currentMode; //現在のモード
    public List<ModeValueTuple> modeValuePairs; //モードと境界値のリスト

    private void Update()
    {
        maxTempAverage = maxTempAverageCalcurator.maxTempAverage; //最高温度平均を更新
        currentMode = ChangeMode(maxTempAverage, modeValuePairs); //現在のモードを判定
    }

    /// <summary>
    /// 現在の最高温度平均と、設定された境界値を照らしあわあせて
    /// 現在のモードを決定する
    /// </summary>
    /// <param name="maxTempAverage"></param>
    /// <param name="modeValuePairs"></param>
    protected string ChangeMode(float maxTempAverage, List<ModeValueTuple> modeValuePairs)
    {
        List<ModeValueTuple> list = modeValuePairs;
        string currentMode = null;
        foreach (var pair in list)
        {
            float boundaryValue = pair.BoundaryValue;
            if (maxTempAverage >= boundaryValue)
            {
                currentMode = pair.Mode;
                return currentMode;
            }
        }
        return currentMode;
    }

    //Inspectorに複数データを表示するためのクラス
    [System.SerializableAttribute]
    public class ModeValueTuple
    {
        public string Mode;
        public float BoundaryValue;
    }
}
