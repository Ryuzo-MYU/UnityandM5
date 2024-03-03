using UnityEngine;

public class FireStarter : MonoBehaviour
{
    [SerializeField] TempModeChanger tempModeChanger; //動きの激しさ判定機インスタンス
    [SerializeField] string currentMode;
    [SerializeField] ModePowerDamageTable modePowerDamageTable; //モードをキーとした、点火力と火種ダメージのリスト

    private void Update()
    {
        currentMode = tempModeChanger.currentMode; //currentModeを更新
        // Debug.Log("IgnitionPower : " + GetIgnitionPower());
        // Debug.Log("TinderDamage : " + GetTinderDamage());
    }

    /// <summary>
    /// 現在の火起こし器がもつ点火力を返す
    /// </summary>
    /// <returns>現在のmodeにそったignitionPower</returns>
    public float GetIgnitionPower()
    {
        try
        {
            // リストから辞書を取得
            var modePowerDamageDictionary = modePowerDamageTable.GetTable();
            float ignitionPower = modePowerDamageDictionary[currentMode].ignitionPower;
            return ignitionPower;
        }
        catch
        {
            Debug.Log("状態が合致しません");
            return 0;
        }
    }

    /// <summary>
    /// 現在の火起こし器が与えるダメージを返す
    /// </summary>
    /// <returns>現在のmodeにそったtinderDamage</returns>
    public float GetTinderDamage()
    {
        try
        {
            // リストから辞書を取得
            var modePowerDamageDictionary = modePowerDamageTable.GetTable();
            float tinderDamage = modePowerDamageDictionary[currentMode].tinderDamage;
            return tinderDamage;
        }
        catch
        {
            Debug.Log("状態が合致しません");
            return 0;
        }
    }

    /// <summary>
    /// ジェネリックを隠すために継承してしまう
    /// [System.Serializable]を書くのを忘れない
    /// </summary>
    [System.Serializable]
    public class ModePowerDamageTable : Serialize.TableBase<string, PowerDamage, PowerDamagePair> { }

    /// <summary>
    /// ジェネリックを隠すために継承してしまう
    /// [System.Serializable]を書くのを忘れない
    /// </summary>
    [System.Serializable]
    public class PowerDamagePair : Serialize.KeyAndValue<string, PowerDamage>
    {
        public PowerDamagePair(string key, PowerDamage value) : base(key, value) { }
    }

    // モードごとの点火力と火種へのダメージを持つクラス
    // PowerDamagePairで表示できるように表示可能クラスとして定義
    [System.SerializableAttribute]
    public class PowerDamage
    {
        public float ignitionPower;
        public float tinderDamage;
    }
}
