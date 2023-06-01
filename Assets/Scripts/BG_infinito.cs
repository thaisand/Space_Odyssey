using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_infinito : MonoBehaviour
{
     public Transform cameraTransform;
    public Transform background1;
    public Transform background2;
    public float backgroundWidth;

    private void Update()
    {
        if (background1.position.x + backgroundWidth < cameraTransform.position.x)
        {
            background1.position = new Vector3(background2.position.x + backgroundWidth, background1.position.y, background1.position.z);
            SwapBackgrounds();
        }
    }

    private void SwapBackgrounds()
    {
        Transform temp = background1;
        background1 = background2;
        background2 = temp;
    }
}