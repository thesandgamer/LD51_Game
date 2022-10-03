using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Ressource : MonoBehaviour
{
    public Vector2 currentPos;

    private Scr_GameKeyboardManager _manager;

    public AnimationCurve Curve;
    [SerializeField] private float maxHauteur = 1f;

    private bool isMoving = false;
    
    private void Awake()
    {
        _manager = FindObjectOfType<Scr_GameKeyboardManager>();
    }


    private GameObject keyToGo;
    public void MoveRessourceTo(GameObject position)
    {
        if (isMoving) return;   //Si la ressources est déjà en mouvement 
        
        isMoving = true;
       // print("Ressource Move");
        
        if (position.GetComponent<Scr_RessourceManager>())
            position.GetComponent<Scr_RessourceManager>().linkedRessources.Add(gameObject);//On rajoute la ressource dans la liste des ressources de la touche où on va


        transform.parent = position.transform.GetChild(0);
        //transform.position = position.transform.GetChild(0).position;

                //--------Mouvement de la ressources----------
        //LeanTween.moveLocal(gameObject, position.transform.GetChild(0).position, 0.5f);
        LeanTween.moveLocal(gameObject, Vector3.zero, 0.5f).setOnComplete(CanMoveAgain);    //Déplace sur la case où aller 
        LeanTween.moveLocalY(gameObject, 0, 0.5f).setEase(Curve);   //Mouvement pour donner l"effet du launch à l'objets
        keyToGo = position;

    }

    public void SelfMove(GameObject position)
    {
        if (isMoving) return;   //Si la ressources est déjà en mouvement 
        
        isMoving = true;
        
        print("Self movement");

        //LeanTween.moveLocalY(gameObject, 0f, 0.5f).setEase(Curve);
        LeanTween.moveLocalY(gameObject, maxHauteur, 0.25f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.moveLocalY(gameObject, 0f, 0.25f).setEase(LeanTweenType.easeInSine).setDelay(0.25f).setOnComplete(CanMoveAgain);

        keyToGo = position;

    }


    void CanMoveAgain()
    {
        isMoving = false;
        if(keyToGo.GetComponent<Scr_GameKeyManager>())
            keyToGo.GetComponent<Scr_GameKeyManager>().VoisinKeyIsDowning();
        Invoke("Realease",0.1f);
    }

    void Realease()
    {
        if(keyToGo.GetComponent<Scr_GameKeyManager>())
            keyToGo.GetComponent<Scr_GameKeyManager>().VoisinKeyIsReleasing();
        keyToGo = null;

    }


}
