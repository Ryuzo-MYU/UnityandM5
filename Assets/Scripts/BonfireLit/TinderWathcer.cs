using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinderWathcer : MonoBehaviour
{
    [SerializeField] Tinder tinder;
    [SerializeField] GameController gameController;
    [SerializeField] AudioClip litSound;
    [SerializeField] GameObject monkeyArm;
    [SerializeField] GameObject monkeyBody;

    private void FixedUpdate()
    {
        if (tinder.currentHp <= 0) { GameOver(); }
        if (tinder.currentTemperature > tinder.ignitionTemperature) { GameClear(); }
    }
    private void GameClear()
    {
        Debug.Log("Tinder was Burnt!!!");
        PlayLitSound();
        MonkeyGameClearMotion();
        gameController.GameClear();
    }

    private void GameOver()
    {
        Debug.Log("Tinder was Broken...");
        MonkeyGameOverMotion();
        gameController.GameOver();
    }

    /// <summary>
    /// 火起こし成功時のSEを再生
    /// </summary>
    private void PlayLitSound()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(litSound);
        source.mute = true;
    }



    private void MonkeyGameClearMotion()
    {
        MonkeyArmAnimatorController monkeyArmAnimatorController = monkeyArm.GetComponent<MonkeyArmAnimatorController>();
        monkeyArmAnimatorController.GameClear();

        MonkeyBodyAnimatorController monkeyBodyAnimatorController = monkeyBody.GetComponent<MonkeyBodyAnimatorController>();
        monkeyBodyAnimatorController.GameClear();
    }
    private void MonkeyGameOverMotion()
    {
        MonkeyArmAnimatorController monkeyArmAnimatorController = monkeyArm.GetComponent<MonkeyArmAnimatorController>();
        monkeyArmAnimatorController.GameOver();

        MonkeyBodyAnimatorController monkeyBodyAnimatorController = monkeyBody.GetComponent<MonkeyBodyAnimatorController>();
        monkeyBodyAnimatorController.GameOver();
    }
}
