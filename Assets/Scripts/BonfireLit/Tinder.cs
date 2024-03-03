using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinder : MonoBehaviour
{
    [SerializeField] private FireStarter fireStarter; //火おこし器インスタンス
    [SerializeField] public float hp; // 火種の耐久力
    [SerializeField] public float ignitionTemperture; // 火種が点火する温度
    [SerializeField] public float currentTemperature; // 現在の火種の温度
    [SerializeField] private float coolDownDegree; // 火種が冷める温度

    private void Update()
    {
        Warm();
        Damage();
        CoolDown();
    }

    /// <summary>
    /// 火種の温度を下げる。0℃以下なら0℃で止める
    /// </summary>
    private void CoolDown()
    {
        if (currentTemperature - coolDownDegree > 0) { currentTemperature -= coolDownDegree; }
        else { currentTemperature = 0; }
    }

    /// <summary>
    /// 火種の耐久力を減らす
    /// </summary>
    /// <param name="fireStarter"> 着火力を参照する火おこし器インスタンス </param>
    private void Damage()
    {
        float damage = fireStarter.GetTinderDamage();
        if (hp - damage > 0) { hp -= damage; }
        else { hp = 0; }
    }

    /// <summary>
    /// 火種の温度を上げる
    /// </summary>
    private void Warm()
    {
        float ignitionPower = fireStarter.GetIgnitionPower();
        currentTemperature += ignitionPower;
    }
}
