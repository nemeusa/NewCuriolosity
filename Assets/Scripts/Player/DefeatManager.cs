using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatManager : MonoBehaviour
{
    public static DefeatManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private Scene_Manager _scnMng;
    public int deadInScene = 0;
    public int currentScene = 0;

    private void Update()
    {
        GetDeathScene();
    }

    public void GetDeathScene()
    {
        currentScene = _scnMng.GetCurrentScene();
        if (currentScene > 3 && currentScene < 7)
        {
            deadInScene = currentScene;
            Debug.Log("muerto en escena:" + deadInScene);
        }
    }
}
