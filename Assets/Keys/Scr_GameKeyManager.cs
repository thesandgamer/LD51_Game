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

    private int id;
    private List<int> leanIds;



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
        id = LeanTween.moveY(gameObject, downPos, 0.5f).setEaseOutQuint().id;
        
        PressVoisins();
    }

    public void ReleaseKey()
    {
        LeanTween.cancel(gameObject);
        //LeanTween.cancelAll();
        //CancelLeantween();
        id = LeanTween.moveY(gameObject, baseY, 0.4f).setEaseOutElastic().id;

        ReleaseVoisins();
    }

    //Fonction qui va presser tout les voisins
    private void PressVoisins()
    {
        foreach (var voisin in voisins )//Pour chaque voisin
        {
            LeanTween.cancel(voisin); //Si il y a un tweening de lancé, on l'arrète

            voisin.GetComponent<Scr_GameKeyManager>().VoisinKeyIsDowning();//Fait en sorte que ça appui sur le voisin
            voisin.GetComponent<Scr_GameKeyManager>().isDown = true;
        }
       

    }
    
    //Fonction qui va relacher de hover les touches voisines de celle ci
    private void ReleaseVoisins()
    {
        foreach (var voisin in voisins )//Pour chaque voisin
        {
            LeanTween.cancel(voisin);

            voisin.GetComponent<Scr_GameKeyManager>().VoisinKeyIsReleasing();   //Fait en sorte que le voisin se relache
            voisin.GetComponent<Scr_GameKeyManager>().isDown = false;//
            

        }
    }


    public void VoisinKeyIsDowning()
    {
        //if (isDown) return;

        id = LeanTween.moveY(gameObject, hoverdedPos, 0.5f).setEaseOutQuint().id;
    }
    public void VoisinKeyIsReleasing()
    {
        //if (isDown) return;

        LeanTween.cancel(gameObject);
        id = LeanTween.moveY(gameObject, baseY, 0.5f).setEaseOutElastic().id;

    }

    public void ActivateKey()
    {
    }


    public void CancelLeantween()
    {
        foreach (var leanId in leanIds)
        {
            LeanTween.cancel(leanId);
        }
        leanIds.Clear();
    }
    
}
