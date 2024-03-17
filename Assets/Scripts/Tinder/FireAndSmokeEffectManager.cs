using UnityEngine;

public class FireAndSmokeEffectManager : MonoBehaviour
{
    [SerializeField] GameObject smoke; // 火種破損時の煙
    [SerializeField] GameObject fire; // 点火完了時の炎
    [SerializeField] Tinder tinder; // 監視対象のTinderインスタンス
    [SerializeField] AudioClip litSound; // 点火時SE

    private void Start()
    {
        smoke.SetActive(false);
        fire.SetActive(false);
    }

    private void FixedUpdate()
    {
        ActivateFireAndSmokeEffect();
    }

    /// <summary>
    /// 火と煙のエフェクト表示をコントロールする 
    /// </summary>
    private void ActivateFireAndSmokeEffect()
    {
        // Tinderの耐久が0になったら
        if (tinder.currentHp <= 0)
        {
            // 煙エフェクトをアクティベートする
            smoke.SetActive(true);
            PlayLitSound();
        }
        // Tinderの温度が最大になったら
        if (tinder.currentTemperature >= tinder.ignitionTemperature)
        {
            // 炎エフェクトをアクティベートする
            fire.SetActive(true);
        }
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
}
