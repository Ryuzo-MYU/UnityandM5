using UnityEngine;

public class TinderWathcer : MonoBehaviour
{
    [SerializeField] Tinder tinder; // Tinderインスタンス
    [SerializeField] GameController gameController; //GameControllerインスタンス
    [SerializeField] MonkeyAnimationController monkeyAnimationController; // MonkeyAnimationControllerインスタンス

    private void FixedUpdate()
    {
        if (tinder.currentHp <= 0) { GameOver(); }
        if (tinder.currentTemperature > tinder.ignitionTemperature) { GameClear(); }
    }
    private void GameClear()
    {
        monkeyAnimationController.GameClear();
        gameController.GameClear();
    }

    private void GameOver()
    {
        monkeyAnimationController.GameOver();
        gameController.GameOver();
    }
}
