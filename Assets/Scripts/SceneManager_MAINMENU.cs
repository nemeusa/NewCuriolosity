using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager_MAINMENU : MonoBehaviour
{
    [SerializeField] Animator _transitionAnim;
    [SerializeField] float _transitionTime;
    [SerializeField] float _exitTime;

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseOptions;
    [SerializeField] private bool _justOptions;
    [SerializeField] private bool _justPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_justOptions && !_justPause)
        {
            Time.timeScale = 0f;
            _pauseMenu.SetActive(true);
            _justPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _justOptions)
        {
            Time.timeScale = 0f;
            _pauseOptions.SetActive(false);
            _pauseMenu.SetActive(true);
            _justOptions = false;
            _justPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !_justOptions && _justPause)
        {
            Debug.Log("jiadfi1");
            Time.timeScale = 1f;
            _pauseMenu.SetActive(false);
            _justPause = false;
        }
    }
    public void Resume()
    {
        Debug.Log("ToconBotadoxD");
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OptionsPause()
    {
        _pauseOptions.SetActive(true);
        _justOptions = true;
        _pauseMenu.SetActive(false);
    }
    public void QuitOptionsPause()
    {
        _pauseOptions.SetActive(false);
        _justOptions = false;
        _pauseMenu.SetActive(true);
    }



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
    public void Sounds()
    {
        StartCoroutine(LoadLevelSounds());
    }
    public void Jugar()
    {
        StartCoroutine(LoadLevelPlay());
    }
    public void Retry()
    {
        StartCoroutine(LoadLevelRetry());
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
        
        PlayerPrefs.DeleteKey("LastCheckpointID");
        PlayerPrefs.DeleteKey("RespawnX");
        PlayerPrefs.DeleteKey("RespawnY");
        PlayerPrefs.DeleteKey("RespawnZ");

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
        AudioManager.Instance.DisableMMsfx();
        SceneManager.LoadScene(4);
        _transitionAnim.SetTrigger("Start");
        
        
        PlayerPrefs.DeleteKey("LastCheckpointID");
        PlayerPrefs.DeleteKey("RespawnX");
        PlayerPrefs.DeleteKey("RespawnY");
        PlayerPrefs.DeleteKey("RespawnZ");
    }
    IEnumerator LoadLevelRetry()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Gameplay");
        SceneManager.LoadScene(5);
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
    IEnumerator LoadLevelSounds()
    {
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        Debug.Log("Sonidos");
        SceneManager.LoadScene(8);
        _transitionAnim.SetTrigger("Start");
    }
    IEnumerator LoadLevelExit()
    {   
        yield return new WaitForSeconds(_exitTime);
        Debug.Log("Quit");
        Application.Quit();
    }
}
