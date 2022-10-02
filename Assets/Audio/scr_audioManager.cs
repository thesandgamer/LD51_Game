using UnityEngine.Audio;
using UnityEngine;
using System;
public class scr_audioManager : MonoBehaviour
{
    public scr_sounds[] sounds;

    public static scr_audioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // loop entre les scènes
        foreach (scr_sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("Theme");
    }
   public void Play(string name)
    {
       scr_sounds s = Array.Find(sounds,sounds => sounds.name == name); // pas sur d'ici je me suis peut être embrouillé avec les noms 
       if(s==null)
        {
        Debug.LogWarning("Sound:"+name+"not found !");
        return;
        }
       s.source.Play();
    }
}
