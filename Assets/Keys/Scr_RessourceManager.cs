using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestionnaire des ressources, 
public class Scr_RessourceManager : MonoBehaviour
{
    public List<GameObject> linkedRessources;



    public void MoveRessources(GameObject moveTo)
    {
        foreach (GameObject ressource in linkedRessources) //Pour chaque ressource sur la case
        {
            ressource.GetComponent<Scr_Ressource>().MoveRessourceTo(moveTo);//On la dit de bouger là où elle doit aller
        }
        linkedRessources.Clear();
    }
    
//----------------
    public void MoveRessourcesToSelf()
    {
        foreach (GameObject ressource in linkedRessources) //Pour chaque ressource sur la case
        {
            ressource.GetComponent<Scr_Ressource>().SelfMove(gameObject);//On la dit de bouger là où elle doit aller
        }
    }



    
    
}
