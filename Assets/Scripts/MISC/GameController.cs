using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failedSound;
    [SerializeField] GameObject gameClearUI;
    [SerializeField] GameObject gameOverUI;

    [SerializeField] bool gameEnd;
    [SerializeField] M5DataReceiver m5;

    private void Update()
    {
        if (gameEnd && m5.sensorInfo.btnATactSwitch == 1)
        {
            Retry();
        }
    }

    public void GameClear()
    {
        PlaySound(successSound);
        gameClearUI.SetActive(true);
        gameEnd = true;
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        PlaySound(failedSound);
        gameOverUI.SetActive(true);
        gameEnd = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// リトライ処理。現在のシーンを再読み込みする
    /// </summary>
    public void Retry()
    {
        // 現在のSceneを取得
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
        gameEnd = false;
    }

    /// <summary>
    /// 火起こし成功時のSEを再生
    /// </summary>
    private void PlaySound(AudioClip sound)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(sound);
        source.mute = true;
    }
}
