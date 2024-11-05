using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatColor : MonoBehaviour
{
    private Color colorOriginal;
    private Renderer objRenderer;

    [SerializeField] private PlayerAudio _playerAudio;

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
        if (GoatController.Destruction)
        {
            _playerAudio.PlaySkillClip();
            CambiarColorRojo();
        }
        else RestaurarColorOriginal();
    }

    void CambiarColorRojo()
    {
        if (objRenderer != null)
        {
            objRenderer.material.color = Color.red;
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
