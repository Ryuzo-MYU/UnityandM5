using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinderWathcer : MonoBehaviour
{
    [SerializeField] Tinder tinder;
    [SerializeField] GameController gameController;

    private void Update()
    {
        if (tinder.currentTemperature > tinder.ignitionTemperture) { GameClear(); }
        if (tinder.hp < 0) { GameOver(); }
    }
    private void GameClear()
    {
        Debug.Log("Tinder was Burnt!!!");
        gameController.GameClear();
    }

    private void GameOver()
    {
        Debug.Log("Tinder was Broken...");
        gameController.GameOver();
    }
}
