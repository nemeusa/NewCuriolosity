using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuesConfigs : MonoBehaviour
{
    public GameObject[] Menues;
    public GameObject wActive;

    void Start()
    {
        if (Menues.Length > 0)
        {
            foreach (var item in Menues) item.SetActive(false);

            if (wActive != null) wActive.SetActive(true);
        }
    }

    public void ChangeSceneByNumber(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
