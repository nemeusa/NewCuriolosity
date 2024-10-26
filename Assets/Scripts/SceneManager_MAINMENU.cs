using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager_MAINMENU : MonoBehaviour
{
    [SerializeField] Animator _transitionAnim;
    [SerializeField] float _transitionTime;
    public void MM()
    {
        StartCoroutine(LoadLevelMainMenu());
    }
    public void Credits()
    {
        StartCoroutine(LoadLevelCredits());
    }
    public void Options()
    {
        StartCoroutine(LoadLevelOptions());
    }
    public void Jugar()
    {
        StartCoroutine(LoadLevelPlay());
    }
    public void Quit()
    {
        StartCoroutine(LoadLevelQuit());
    }
    public void Exit()
    {
        StartCoroutine(LoadLevelExit());
    }

    IEnumerator LoadLevelMainMenu()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Menu principal");
        SceneManager.LoadScene(0);
        _transitionAnim.SetTrigger("Start");
    }
    IEnumerator LoadLevelOptions()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Opciones");
        SceneManager.LoadScene(1);
        _transitionAnim.SetTrigger("Start");
    }
    IEnumerator LoadLevelCredits()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Creditos");
        SceneManager.LoadScene(2);
        _transitionAnim.SetTrigger("Start");
    }
    IEnumerator LoadLevelPlay()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Gameplay");
        SceneManager.LoadScene(4);
        _transitionAnim.SetTrigger("Start");
    }
    IEnumerator LoadLevelQuit()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Quit");
        SceneManager.LoadScene(3);
        _transitionAnim.SetTrigger("Start");
    }
    IEnumerator LoadLevelExit()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Quit");
        Application.Quit();
    }
}
