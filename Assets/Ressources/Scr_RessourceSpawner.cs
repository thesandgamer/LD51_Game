using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_RessourceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Ressource_Prefab;
    private float spawnTime = 10f;
    private float currentTime;

    [SerializeField] private Scr_GameKeyboardManager _keyboardManager;
    [SerializeField] private GameObject KeyToSpawn;

    private Vector3 posToGo;
    private Vector3 posToSpawn;

    private void Start()
    {
        SetKey();
        currentTime = spawnTime;
    }

    void SetKey()
    {
        Vector2 keyNumber = new Vector2(Random.Range(0, 9), Random.Range(0, 3));
        KeyToSpawn = _keyboardManager.dicMap[keyNumber];
        while (!KeyToSpawn.GetComponent<Scr_GameKeyManager>().Interactible)
        {
            keyNumber = new Vector2(Random.Range(0, 9), Random.Range(0, 3));
        }
        posToGo = KeyToSpawn.transform.GetChild(0).transform.position;
        posToSpawn = posToGo;
        posToSpawn.y += 5;
    }

    private void Update()
    {
        if (currentTime >= spawnTime)
        {
            SpawnRessource();
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    private GameObject objectCreate;

    private void SpawnRessource()
    {
        SetKey();

        objectCreate = Instantiate(Ressource_Prefab, posToSpawn, Quaternion.identity,
            KeyToSpawn.transform.GetChild(0).transform);
        LeanTween.moveLocalY(objectCreate, 0, 0.22f).setOnComplete(ArriveToKey);
    }

    private bool soundPlay = false;

    void ArriveToKey()
    {
        KeyToSpawn.GetComponent<Scr_RessourceManager>().linkedRessources.Add(objectCreate);
        KeyToSpawn.GetComponent<Scr_GameKeyManager>().VoisinKeyIsDowning();

        FindObjectOfType<Scr_CameraShake>().StartCameraShake(new Vector2(0f, 0.1f));

        Invoke("Realease", 0.1f);

        if (!soundPlay)
        {
            FindObjectOfType<scr_audioManager>()?.Play("Theme");
            soundPlay = true;
        }
    }

    void Realease()
    {
        KeyToSpawn.GetComponent<Scr_GameKeyManager>().VoisinKeyIsReleasing();
    }
}