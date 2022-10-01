using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public enum EnterKeyType
{
    BIG,
    SMALL,
}

public class Scr_GameKeyboardManager : MonoBehaviour
{
    [SerializeField]private GameObject Prefab_GameKeyParent;
    [SerializeField]private GameObject Prefab_SpaceBar;
    [SerializeField]private float InKeysOffset = 1;
    [SerializeField]private float InRowOffset = 1;
    [SerializeField]private float StartRowOffset = 1;
    
    public EnterKeyType TypeOfKeyboard = 0;

    public List<GameObject> inGameKeys = new List<GameObject>();

    public Dictionary<Vector2, GameObject> dicMap = new Dictionary<Vector2, GameObject>();

    public Controls controls;

    private void Awake()
    {
        controls = new Controls();
       SetupInputs();
    }

    private void SetupInputs()
    {
        controls.Keys.A.performed +=  ActivateKeyA;
        
        controls.Keys.A.started +=  StartPressKeyA;
        controls.Keys.A.canceled +=  StopPressteKeyA;
        
        controls.Keys.Z.started +=  StartPressKeyZ;
        controls.Keys.Z.canceled +=  StopPressteKeyZ;
        
        controls.Keys.E.started +=  StartPressKeyE;
        controls.Keys.E.canceled +=  StopPressteKeyE;
        
        controls.Keys.R.started +=  StartPressKeyR;
        controls.Keys.R.canceled +=  StopPressteKeyR;
        
        controls.Keys.T.started +=  StartPressKeyT;
        controls.Keys.T.canceled +=  StopPressteKeyT;
        
        controls.Keys.Y.started +=  StartPressKeyY;
        controls.Keys.Y.canceled +=  StopPressteKeyY;
        
        controls.Keys.U.started +=  StartPressKeyU;
        controls.Keys.U.canceled +=  StopPressteKeyU;
        
        controls.Keys.I.started +=  StartPressKeyI;
        controls.Keys.I.canceled +=  StopPressteKeyI;
        
        controls.Keys.O.started +=  StartPressKeyO;
        controls.Keys.O.canceled +=  StopPressteKeyO;
        
        controls.Keys.P.started +=  StartPressKeyP;
        controls.Keys.P.canceled +=  StopPressteKeyP;
        
        controls.Keys.Circonflexe.started +=  StartPressKeyCirconflexe;
        controls.Keys.Circonflexe.canceled +=  StopPressKeyCirconflexe;
        
        controls.Keys.Dollard.started +=  StartPressKeyDollard;
        controls.Keys.Dollard.canceled +=  StopPressKeyDollard;
    }
    

    #region CreateKeyboard

    private void Start()
    {
        GenerateKeyboard();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void GenerateKeyboard()
    {
        ClearKeys();

        for (int i = 0; i < 12; i++)
        {
            CreateKey(i,1);
        }

        int nbOfKeyInSegondLine= 12;
        switch (TypeOfKeyboard)
        {
            case EnterKeyType.BIG:
                nbOfKeyInSegondLine = 12;
                break;
            case EnterKeyType.SMALL:
                nbOfKeyInSegondLine = 11;
                break;
            default:
                nbOfKeyInSegondLine = 12;
                break;
        }
        
        for (int i = 0; i < nbOfKeyInSegondLine; i++)
        {
            CreateKey(i,2);
        }
        for (int i = 0; i < 10; i++)
        {
            CreateKey(i,3);
        }
        
        Vector3 spaceBarPos = new Vector3(transform.position.x +(InKeysOffset * 4) +(StartRowOffset * 4),
            transform.position.y,
            transform.position.z - 4 * InRowOffset);
        GameObject go = Instantiate(Prefab_SpaceBar, spaceBarPos, quaternion.identity, transform);
        inGameKeys.Add(go);

    }
    
    
    private void CreateKey(int keyPos, int keyRow)
    {
        Vector3 newPos = new Vector3(transform.position.x + (InKeysOffset * keyPos) + (StartRowOffset * keyRow),
            transform.position.y,
            transform.position.z - keyRow * InRowOffset);
        GameObject go = Instantiate(Prefab_GameKeyParent, newPos, Quaternion.identity,transform);
        go.name += "_" + keyPos + "_" + keyRow;
        inGameKeys.Add(go);
        dicMap.Add(new Vector2(keyPos, keyRow-1),go);
        go.GetComponent<Scr_GameKeyManager>().posInKeyboard = new Vector2(keyPos, keyRow-1);


    }


    public void ClearKeys()
    {
        foreach (GameObject inGameKey in inGameKeys)
        {
            DestroyImmediate(inGameKey);
        }
        inGameKeys.Clear();
        dicMap.Clear();
    }
    #endregion

    
    public void DetectVoisin()
    {
        foreach (GameObject inGameKey in inGameKeys)
        {
            Vector2 pos = inGameKey.GetComponent<Scr_GameKeyManager>().posInKeyboard;
        }
    }
    
    private void ActivateKey(Vector2 key)
    {
        dicMap[key].GetComponent<Scr_GameKeyManager>().ActivateKey();

    }
    private void PressKey(Vector2 key)
    {
        dicMap[key].GetComponent<Scr_GameKeyManager>().PressKey();

    }
    private void ReleaseKey(Vector2 key)
    {
        dicMap[key].GetComponent<Scr_GameKeyManager>().ReleaseKey();
    }

    private void ActivateKeyA(InputAction.CallbackContext obj)
    {
       ActivateKey(new Vector2(0,0));
    }
//--------------------------------------------------
    private void StartPressKeyA(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(0,0));
    }
    private void StopPressteKeyA(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(0,0));
    }
//--------------------------------------------------
    private void StartPressKeyZ(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(1,0));
    }
    private void StopPressteKeyZ(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(1,0));
    }
//--------------------------------------------------
    private void StartPressKeyE(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(2,0));
    }
    private void StopPressteKeyE(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(2,0));
    }
//--------------------------------------------------
    private void StartPressKeyR(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(3,0));
    }
    private void StopPressteKeyR(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(3,0));
    }
//--------------------------------------------------
    private void StartPressKeyT(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(4,0));
    }
    private void StopPressteKeyT(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(4,0));
    }
    //--------------------------------------------------
    private void StartPressKeyY(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(5,0));
    }
    private void StopPressteKeyY(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(5,0));
    }
//--------------------------------------------------
    private void StartPressKeyU(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(6,0));
        print("Pressed key U");
    }
    private void StopPressteKeyU(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(6,0));
        print("Release key U");

    }
//--------------------------------------------------
    private void StartPressKeyI(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(7,0));
    }
    private void StopPressteKeyI(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(7,0));
    }
    //--------------------------------------------------
    private void StartPressKeyO(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(8,0));
    }
    private void StopPressteKeyO(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(8,0));
    }
//--------------------------------------------------
    private void StartPressKeyP(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(9,0));
    }
    private void StopPressteKeyP(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(9,0));
    }
    //--------------------------------------------------
    private void StartPressKeyCirconflexe(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(10,0));
    }
    private void StopPressKeyCirconflexe(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(10,0));
    }
//--------------------------------------------------
    private void StartPressKeyDollard(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(11,0));
    }
    private void StopPressKeyDollard(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(11,0));
    }
    
    
}

