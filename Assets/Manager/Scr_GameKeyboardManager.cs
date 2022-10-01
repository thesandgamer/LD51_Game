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
    [SerializeField] private GameObject Prefab_GameKeyParent;
    [SerializeField] private GameObject Prefab_SpaceBar;
    [SerializeField] private float InKeysOffset = 1;
    [SerializeField] private float InRowOffset = 1;
    [SerializeField] private float StartRowOffset = 1;

    public EnterKeyType TypeOfKeyboard = 0;

    public List<GameObject> inGameKeys = new List<GameObject>();

    public Dictionary<Vector2, GameObject> dicMap = new Dictionary<Vector2, GameObject>();
    public GameObject spaceBarObj;

    public Controls controls;

    public bool keyPressed = false;

    private InputAction.CallbackContext currentInput;
    

    private void Awake()
    {
        controls = new Controls();
        SetupInputs();
    }

    private void SetupInputs()
    {
        controls.Keys.A.started += StartPressKeyA;
        controls.Keys.A.canceled += StopPressteKeyA;

        controls.Keys.Z.started += StartPressKeyZ;
        controls.Keys.Z.canceled += StopPressteKeyZ;

        controls.Keys.E.started += StartPressKeyE;
        controls.Keys.E.canceled += StopPressteKeyE;

        controls.Keys.R.started += StartPressKeyR;
        controls.Keys.R.canceled += StopPressteKeyR;

        controls.Keys.T.started += StartPressKeyT;
        controls.Keys.T.canceled += StopPressteKeyT;

        controls.Keys.Y.started += StartPressKeyY;
        controls.Keys.Y.canceled += StopPressteKeyY;

        controls.Keys.U.started += StartPressKeyU;
        controls.Keys.U.canceled += StopPressteKeyU;

        controls.Keys.I.started += StartPressKeyI;
        controls.Keys.I.canceled += StopPressteKeyI;

        controls.Keys.O.started += StartPressKeyO;
        controls.Keys.O.canceled += StopPressteKeyO;

        controls.Keys.P.started += StartPressKeyP;
        controls.Keys.P.canceled += StopPressteKeyP;

        controls.Keys.Circonflexe.started += StartPressKeyCirconflexe;
        controls.Keys.Circonflexe.canceled += StopPressKeyCirconflexe;

        controls.Keys.Dollard.started += StartPressKeyDollard;
        controls.Keys.Dollard.canceled += StopPressKeyDollard;


        controls.Keys.Q.started += StartPressKeyQ;
        controls.Keys.Q.canceled += StopPressKeyQ;

        controls.Keys.S.started += StartPressKeyS;
        controls.Keys.S.canceled += StopPressKeyS;

        controls.Keys.D.started += StartPressKeyD;
        controls.Keys.D.canceled += StopPressKeyD;

        controls.Keys.F.started += StartPressKeyF;
        controls.Keys.F.canceled += StopPressKeyF;

        controls.Keys.G.started += StartPressKeyG;
        controls.Keys.G.canceled += StopPressKeyG;

        controls.Keys.H.started += StartPressKeyH;
        controls.Keys.H.canceled += StopPressKeyH;

        controls.Keys.J.started += StartPressKeyJ;
        controls.Keys.J.canceled += StopPressKeyJ;

        controls.Keys.K.started += StartPressKeyK;
        controls.Keys.K.canceled += StopPressKeyK;

        controls.Keys.L.started += StartPressKeyL;
        controls.Keys.L.canceled += StopPressKeyL;

        controls.Keys.M.started += StartPressKeyM;
        controls.Keys.M.canceled += StopPressKeyM;

        controls.Keys.Percent.started += StartPressKeyPercent;
        controls.Keys.Percent.canceled += StopPressKeyPercent;

        controls.Keys.Star.started += StartPressKeyStar;
        controls.Keys.Star.canceled += StopPressKeyStar;
        
        //---------------
        controls.Keys.W.started += StartPressKeyW;
        controls.Keys.W.canceled += StopPressKeyW;

        controls.Keys.X.started += StartPressKeyX;
        controls.Keys.X.canceled += StopPressKeyX;

        controls.Keys.C.started += StartPressKeyC;
        controls.Keys.C.canceled += StopPressKeyC;

        controls.Keys.V.started += StartPressKeyV;
        controls.Keys.V.canceled += StopPressKeyV;

        controls.Keys.B.started += StartPressKeyB;
        controls.Keys.B.canceled += StopPressKeyB;

        controls.Keys.N.started += StartPressKeyN;
        controls.Keys.N.canceled += StopPressKeyN;

        controls.Keys.Interogation.started += StartPressKeyInterogation;
        controls.Keys.Interogation.canceled += StopPressKeyInterogation;

        controls.Keys.Point.started += StartPressKeyPoint;
        controls.Keys.Point.canceled += StopPressKeyPoint;

        controls.Keys.Slach.started += StartPressKeySlach;
        controls.Keys.Slach.canceled += StopPressKeySlach;

        controls.Keys.Exclamation.started += StartPressKeyExclamation;
        controls.Keys.Exclamation.canceled += StopPressKeyExclamation;
        
        //-----------
        controls.Keys.Space.performed += SpaceBarPressed;


    }

    private void SpaceBarPressed(InputAction.CallbackContext obj)
    {
        spaceBarObj.GetComponent<Scr_SpaceBarManager>().MakeEffect();
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
            CreateKey(i, 1);
        }

        int nbOfKeyInSegondLine = 12;
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
            CreateKey(i, 2);
        }

        for (int i = 0; i < 10; i++)
        {
            CreateKey(i, 3);
        }

        Vector3 spaceBarPos = new Vector3(transform.position.x + (InKeysOffset * 4) + (StartRowOffset * 4),
            transform.position.y,
            transform.position.z - 4 * InRowOffset);
        spaceBarObj = Instantiate(Prefab_SpaceBar, spaceBarPos, quaternion.identity, transform);
        inGameKeys.Add(spaceBarObj);
    }


    private void CreateKey(int keyPos, int keyRow)
    {
        Vector3 newPos = new Vector3(transform.position.x + (InKeysOffset * keyPos) + (StartRowOffset * keyRow),
            transform.position.y,
            transform.position.z - keyRow * InRowOffset);
        GameObject go = Instantiate(Prefab_GameKeyParent, newPos, Quaternion.identity, transform);
        go.name += "_" + keyPos + "_" + keyRow;
        go.GetComponent<Scr_GameKeyManager>().posInKeyboard = new Vector2(keyPos, keyRow - 1);
        go.GetComponent<Scr_GameKeyManager>()._manager = this;
        
        inGameKeys.Add(go);
        dicMap.Add(new Vector2(keyPos, keyRow - 1), go);
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


    public List<GameObject> DetectVoisinOf(Vector2 pos) //Pos = position de l'objet auquel on cherche les voisins 
    {
        List<GameObject> voisins = new List<GameObject>();

        for (int y = -1; y < 2; y++)
        {
            for (int x = -1; x < 2; x++)
            {
                Vector2 voisinPos = new Vector2(pos.x+x, pos.y+y);
                if (voisinPos != pos)
                {
                    if (dicMap.ContainsKey(voisinPos))
                    {
                        voisins.Add(dicMap[voisinPos]);
                    }
                }

            }
        }
        return voisins;
    }

    private void Update()
    {
        if (currentInput.performed)
        {
            keyPressed = true;
        }
        else
        {
            keyPressed = false;
        }
    }

    private void ActivateKey(Vector2 key)
    {
        dicMap[key].GetComponent<Scr_GameKeyManager>().ActivateKey();
    }

    private void PressKey(Vector2 key, InputAction.CallbackContext obj)
    {
        if (keyPressed) return;
        currentInput = obj;
        
        dicMap[key].GetComponent<Scr_GameKeyManager>().PressKey();
    }

    private void ReleaseKey(Vector2 key, InputAction.CallbackContext obj)
    {

        dicMap[key].GetComponent<Scr_GameKeyManager>().ReleaseKey();

    }

    private void ActivateKeyA(InputAction.CallbackContext obj)
    {
        ActivateKey(new Vector2(0, 0));
    }

//--------------------------------------------------
    private void StartPressKeyA(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(0, 0), obj);
    }

    private void StopPressteKeyA(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(0, 0), obj);

    }

//--------------------------------------------------
    private void StartPressKeyZ(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(1, 0), obj);
    }

    private void StopPressteKeyZ(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(1, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyE(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(2, 0), obj);
    }

    private void StopPressteKeyE(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(2, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyR(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(3, 0), obj);
    }

    private void StopPressteKeyR(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(3, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyT(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(4, 0), obj);
    }

    private void StopPressteKeyT(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(4, 0), obj);
    }

    //--------------------------------------------------
    private void StartPressKeyY(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(5, 0), obj);
    }

    private void StopPressteKeyY(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(5, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyU(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(6, 0), obj);
    }

    private void StopPressteKeyU(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(6, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyI(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(7, 0), obj);
    }

    private void StopPressteKeyI(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(7, 0), obj);
    }

    //--------------------------------------------------
    private void StartPressKeyO(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(8, 0), obj);
    }

    private void StopPressteKeyO(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(8, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyP(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(9, 0), obj);
    }

    private void StopPressteKeyP(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(9, 0), obj);
    }

    //--------------------------------------------------
    private void StartPressKeyCirconflexe(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(10, 0), obj);
    }

    private void StopPressKeyCirconflexe(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(10, 0), obj);
    }

//--------------------------------------------------
    private void StartPressKeyDollard(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(11, 0), obj);
    }

    private void StopPressKeyDollard(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(11, 0), obj);
    }


//--------------------------------------------------
    private void StartPressKeyQ(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(0, 1), obj);
    }

    private void StopPressKeyQ(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(0, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyS(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(1, 1), obj);
    }

    private void StopPressKeyS(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(1, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyD(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(2, 1), obj);
    }

    private void StopPressKeyD(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(2, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyF(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(3, 1), obj);
    }

    private void StopPressKeyF(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(3, 1), obj);
    }

    //--------------------------------------------------
    private void StartPressKeyG(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(4, 1), obj);
    }

    private void StopPressKeyG(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(4, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyH(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(5, 1), obj);
    }

    private void StopPressKeyH(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(5, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyJ(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(6, 1), obj);
    }

    private void StopPressKeyJ(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(6, 1), obj);
    }

    //--------------------------------------------------
    private void StartPressKeyK(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(7, 1), obj);
    }

    private void StopPressKeyK(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(7, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyL(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(8, 1), obj);
    }

    private void StopPressKeyL(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(8, 1), obj);
    }

    //--------------------------------------------------
    private void StartPressKeyM(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(9, 1), obj);
    }

    private void StopPressKeyM(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(9, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyPercent(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(10, 1), obj);
    }

    private void StopPressKeyPercent(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(10, 1), obj);
    }

//--------------------------------------------------
    private void StartPressKeyStar(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(11, 1), obj);
    }

    private void StopPressKeyStar(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(11, 1), obj);
    }
    
    
//--------------------------------------------------
    private void StartPressKeyW(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(0, 2), obj);
    }

    private void StopPressKeyW(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(0, 2), obj);
    }
//--------------------------------------------------
    private void StartPressKeyX(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(1, 2), obj);
    }

    private void StopPressKeyX(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(1, 2), obj);
    }
//--------------------------------------------------
    private void StartPressKeyC(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(2, 2), obj);
    }

    private void StopPressKeyC(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(2, 2), obj);
    }
    //--------------------------------------------------
    private void StartPressKeyV(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(3, 2), obj);
    }

    private void StopPressKeyV(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(3, 2), obj);
    }
//--------------------------------------------------
    private void StartPressKeyB(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(4, 2), obj);
    }

    private void StopPressKeyB(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(4, 2), obj);
    }
//--------------------------------------------------
    private void StartPressKeyN(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(5, 2), obj);
    }

    private void StopPressKeyN(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(5, 2), obj);
    }
    //--------------------------------------------------
    private void StartPressKeyInterogation(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(6, 2), obj);
    }

    private void StopPressKeyInterogation(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(6, 2), obj);
    }
    //--------------------------------------------------
    private void StartPressKeyPoint(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(7, 2), obj);
    }

    private void StopPressKeyPoint(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(7, 2), obj);
    }
    //--------------------------------------------------
    private void StartPressKeySlach(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(8, 2), obj);
    }

    private void StopPressKeySlach(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(8, 2), obj);
    }
    //--------------------------------------------------
    private void StartPressKeyExclamation(InputAction.CallbackContext obj)
    {
        PressKey(new Vector2(9, 2), obj);
    }

    private void StopPressKeyExclamation(InputAction.CallbackContext obj)
    {
        ReleaseKey(new Vector2(9, 2), obj);
    }
    
    
}