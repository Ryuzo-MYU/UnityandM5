using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCleaUI : MonoBehaviour
{
    [SerializeField] AudioClip GameClearSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameClear()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(GameClearSound);
    }
}
