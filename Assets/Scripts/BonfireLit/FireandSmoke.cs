using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireandSmoke : MonoBehaviour
{
    [SerializeField] Sprite fire;
    [SerializeField] Sprite smoke;
    [SerializeField] Tinder tinder;
    private void FixedUpdate()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (tinder.currentHp <= 0)
        {
            spriteRenderer.sprite = smoke;
        }
        if (tinder.currentTemperature >= tinder.ignitionTemperature)
        {
            spriteRenderer.sprite = fire;
        }
    }
}
