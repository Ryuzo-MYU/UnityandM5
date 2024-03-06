using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tinder : MonoBehaviour
{
    [SerializeField] private FireStarter fireStarter; //火おこし器インスタンス
    [SerializeField] public float hp; // 火種の耐久力
    [SerializeField] public float currentHp; // 現在の耐久力
    [SerializeField] public float ignitionTemperture; // 火種が点火する温度
    [SerializeField] public float currentTemperature; // 現在の火種の温度
    [SerializeField] private float coolDownDegree; // 火種が冷める温度
    [SerializeField] private Slider hpBar; // HPバー
    [SerializeField] private Slider temperatureFBar; // 火種の温度バー
    [SerializeField] private AudioClip litSound;


    private void Update()
    {
        UpTemperature();
        DecreaseHp();
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
    private void DecreaseHp()
    {
        float damage = fireStarter.GetTinderDamage();
        if (currentHp - damage > 0) { currentHp -= damage; }
        else { currentHp = 0; }
        UpdateHpBar(hpBar); // HPバーを更新
    }

    /// <summary>
    /// HPバーの長さを更新
    /// </summary>
    private void UpdateHpBar(Slider hpBar)
    {
        hpBar.value = currentHp / hp;
    }

    /// <summary>
    /// 火種の温度を上げる
    /// </summary>
    private void UpTemperature()
    {
        float ignitionPower = fireStarter.GetIgnitionPower();
        currentTemperature += ignitionPower;
        UpdateTemperatureBar(temperatureFBar);
    }
    /// <summary>
    /// HPバーの長さを更新
    /// </summary>
    private void UpdateTemperatureBar(Slider tempBar)
    {
        tempBar.value = currentTemperature / ignitionTemperture;
    }

    /// <summary>
    /// 火起こし成功時のSEを再生
    /// </summary>
    private void PlayLitSound()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(litSound);
    }
}
