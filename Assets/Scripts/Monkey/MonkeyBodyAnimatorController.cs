using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBodyAnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator; // アニメーションコントローラー

    public void AnimatorUpdate(string mode)
    {
        switch (mode)
        {
            case "LOW":
                animator.SetInteger("intensity", 0);
                break;
            case "MIDDLE":
                animator.SetInteger("intensity", 1);
                break;
            case "HIGH":
                animator.SetInteger("intensity", 2);
                break;
            default:
                break;
        }
    }

    public void GameClear()
    {
        animator.SetBool("GameClear", true);
    }

    public void GameOver()
    {
        animator.SetBool("GameOver", true);
    }
}
