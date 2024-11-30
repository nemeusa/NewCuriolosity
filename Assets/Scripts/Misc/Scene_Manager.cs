using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class Scene_Manager : MonoBehaviour
{
    public Animator _transitionAnim;
    [SerializeField] private string _startName = "Start";
    [SerializeField] private float _transitionTime = 1.5f;
    public int currentScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadNextScene();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int levelIndex)
    {
        //Play animation
        _transitionAnim.SetTrigger(_startName);

        //Wait
        yield return new WaitForSeconds(_transitionTime);

        //Load Scene
        if (levelIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(levelIndex);
        }
    }

    public int GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        return currentScene;
    }
}
