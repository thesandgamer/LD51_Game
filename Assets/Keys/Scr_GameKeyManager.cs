using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameKeyManager : MonoBehaviour
{
    public Vector2 posInKeyboard;

    private int moveTweenId;

    private float baseY;

    private void Start()
    {
        baseY = transform.position.y;
    }

    public void PressKey()
    {
        LeanTween.moveY(gameObject, transform.position.y - 1f, 0.5f).setEaseOutQuint();
    }

    public void ReleaseKey()
    {
        LeanTween.moveY(gameObject, baseY, 0.5f).setEaseOutElastic();
    }

    public void ActivateKey()
    {
    }
}
