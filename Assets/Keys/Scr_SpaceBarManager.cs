using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SpaceBarManager : MonoBehaviour
{
    [SerializeField]private List<GameObject> voisins;
    [SerializeField]private List<GameObject> ressources;


    private void Start()
    {
        Scr_GameKeyboardManager keyboardManager = FindObjectOfType<Scr_GameKeyboardManager>();
        voisins.Add(keyboardManager.dicMap[new Vector2(3,2)]);
        voisins.Add(keyboardManager.dicMap[new Vector2(4,2)]);
        voisins.Add(keyboardManager.dicMap[new Vector2(5,2)]);
        voisins.Add(keyboardManager.dicMap[new Vector2(6,2)]);
        
    }

    public void MakeEffect()
    {
        print("Spacebar activate");
        TakeRessources();
        
    }
    
    
    public void TakeRessources()
    {
        foreach (GameObject voisin in voisins)
        {
            foreach (var res in voisin.GetComponent<Scr_RessourceManager>().linkedRessources)
            {
                ressources.Add(res);
                res.GetComponent<Scr_Ressource>().MoveRessourceTo(gameObject);
            }
            voisin.GetComponent<Scr_RessourceManager>().linkedRessources.Clear();
        }
        Invoke("ForgeRessource",1.5f);
        
        
    }

    void ForgeRessource()
    {
        foreach (var res in ressources)
        {
            Destroy(res);
            //Spawn son + fx
        }
    }
}