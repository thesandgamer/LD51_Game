using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CameraShake : MonoBehaviour
{
    private Camera cam;

    private bool inShake = false;

    private Vector3 initialPos;

    private void Start()
    {
        cam = Camera.main;
        initialPos = cam.transform.position;
    }

    public void StartCameraShake(Vector2 strength)
    {
        if (inShake) return;
        print("Camera shake");
        LeanTween.moveX(cam.gameObject, initialPos.x + strength.x, 0.01f);
        LeanTween.moveY(cam.gameObject, initialPos.y +strength.y, 0.1f).setOnComplete(Deshake);


    }

    void Deshake()
    {
        LeanTween.move(cam.gameObject, initialPos, 0.1f);

    }
    
    
    
}
