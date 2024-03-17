using System.Collections.Generic;
using UnityEngine;

public class TempModeChanger : MonoBehaviour
{
    //MaxTempAverageCalcuratorインスタンス
    [SerializeField] MaxTempAverageCalcurator maxTempAverageCalcurator;
    [SerializeField] float maxTempAverage; // 最高温度平均
    public string currentMode; //現在のモード
    [SerializeField] public List<ModeValuePair> modeValuePairs; //モードと境界値のリスト

    private void Update()
    {
        //最高温度平均を更新
        maxTempAverage = maxTempAverageCalcurator.maxTempAverage;

        //現在のモードを判定
        currentMode = ChangeMode(maxTempAverage, modeValuePairs);
    }

    /// <summary>
    /// 現在の最高温度平均と、設定された境界値を照らしあわあせて、
    /// 現在のモードを決定する
    /// </summary>
    /// <param name="maxTempAverage"></param>
    /// <param name="modeValuePairs"></param>
    protected string ChangeMode(float maxTempAverage, List<ModeValuePair> modeValuePairs)
    {
        List<ModeValuePair> list = modeValuePairs;
        string currentMode = null;

        // 最高温度平均 > 境界値 になった時点で処理が終了する
        // 大きい境界値から判定すると不正な上書き無しで判定できる
        // したがって要素は境界値の大きいモードから降順に並べる
        foreach (var pair in list)
        {
            float boundaryValue = pair.BoundaryValue;
            // 現在の最大温度平均が、判定中モードの境界値より大きければ
            if (maxTempAverage >= boundaryValue)
            {
                // 現在のモードを判定中のモードにする
                currentMode = pair.Mode;
                return currentMode;
            }
        }
        return currentMode;
    }

    //Inspectorに複数データを表示するためのクラス
    [System.SerializableAttribute]
    public class ModeValuePair
    {
        public string Mode; // 現在のモード
        public float BoundaryValue; // そのモードに切り替わる境界値
    }
}
