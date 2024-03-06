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

    /// <summary>
    /// リトライ処理。現在のシーンを再読み込みする
    /// </summary>
    public void Retry()
    {
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
    }
}
