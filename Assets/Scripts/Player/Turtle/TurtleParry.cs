using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleParry : MonoBehaviour
{
    private Color colorOriginal;
    private Renderer objRenderer;
    [SerializeField] private GameObject shield;
    [SerializeField] private Animation shieldAnim;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null)
        {
            colorOriginal = objRenderer.material.color;
        }

        shield.SetActive(false);
    }

    private void Update()
    {
        if (TurtleController.isParrying)
        {
            CambiarColorVerde();
            shield.SetActive(true);
            shieldAnim.Play();
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
            shield.SetActive(false);
        }
    }
}
