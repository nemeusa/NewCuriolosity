using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleParry : MonoBehaviour
{
    private Color colorOriginal;
    private Renderer objRenderer;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null)
        {
            colorOriginal = objRenderer.material.color;
        }
    }

    private void Update()
    {
        if (TurtleController.isParrying)
        {
            CambiarColorVerde();
        }
        else RestaurarColorOriginal();
    }

    void CambiarColorVerde()
    {
        if (objRenderer != null)
        {
            objRenderer.material.color = Color.green;
        }
    }


    void RestaurarColorOriginal()
    {
        if (objRenderer != null)
        {
            objRenderer.material.color = colorOriginal;
        }
    }
}
