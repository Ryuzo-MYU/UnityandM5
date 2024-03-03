using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void GameClear()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
