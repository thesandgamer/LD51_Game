using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameKeyManager : MonoBehaviour
{
    public Vector2 posInKeyboard;

    private int moveTweenId;

    private float baseY;

    public Scr_GameKeyboardManager _manager;
    private List<GameObject> voisins;

    [SerializeField] private float downDistance = 0.6f;
    [SerializeField] private float hoverdedDistance = 0.3f;
    private float downPos;
    private float hoverdedPos;

    private bool isDown = false;
    
    private void Start()
    {
        if (_manager)
        {
            voisins = _manager.DetectVoisinOf(posInKeyboard);
        }
        baseY = transform.position.y;
        downPos = transform.position.y - downDistance;
        hoverdedPos = transform.position.y - hoverdedDistance;
    }

    public void PressKey()
    {
        LeanTween.moveY(gameObject, downPos, 0.5f).setEaseOutQuint();
        PressVoisins();
        isDown = false;
    }

    public void ReleaseKey()
    {
        LeanTween.cancel(gameObject);
        LeanTween.moveY(gameObject, baseY, 0.5f).setEaseOutElastic();
        ReleaseVoisins();
    }

    private void PressVoisins()
    {
        foreach (var voisin in voisins )
        {
            voisin.GetComponent<Scr_GameKeyManager>().VoisinKeyIsDowning();
            voisin.GetComponent<Scr_GameKeyManager>().isDown = true;
        }
       

    }
    private void ReleaseVoisins()
    {
        foreach (var voisin in voisins )
        {
            voisin.GetComponent<Scr_GameKeyManager>().VoisinKeyIsReleasing();
            voisin.GetComponent<Scr_GameKeyManager>().isDown = false;

        }
    }

    public void VoisinKeyIsDowning()
    {
        //if (isDown) return;

        LeanTween.moveY(gameObject, hoverdedPos, 0.5f).setEaseOutQuint();
    }
    public void VoisinKeyIsReleasing()
    {
        //if (isDown) return;

        LeanTween.cancel(gameObject);
        LeanTween.moveY(gameObject, baseY, 0.5f).setEaseOutElastic();
    }

    public void ActivateKey()
    {
    }
    
}
