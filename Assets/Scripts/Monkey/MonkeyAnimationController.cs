using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyAnimationController : MonoBehaviour
{
    [SerializeField] FireStarter fireStarter; // FireStarterインスタンス
    [SerializeField] string mode; // FireStarterのモード
    [SerializeField] MonkeyArmAnimatorController monkeyArm; // サルの腕
    [SerializeField] MonkeyBodyAnimatorController monkeyBody; // サルの胴

    void FixedUpdate()
    {
        mode = fireStarter.GetCurrentMode();
        MonkeyAnimUpdate();
    }

    private void MonkeyAnimUpdate()
    {
        monkeyArm.AnimatorUpdate(mode);
        monkeyBody.AnimatorUpdate(mode);
    }

    public void GameClear()
    {
        monkeyArm.GameClear();
        monkeyBody.GameClear();
    }

    public void GameOver()
    {
        monkeyArm.GameOver();
        monkeyBody.GameOver();
    }
}
