using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Animator _transitionAnim;
    [SerializeField] float _transitionTime;

    public Image _healthBar;

    [SerializeField] float _life;
    public float life { get { return _life; } }
    public bool IsParry;
    GameObject turtle;

    [SerializeField] private PlayerAudio _playerAudio;

    public void TakeDamage(float damage)
    {
        _life -= damage;

        _playerAudio.PlayLifeClip(_life);

        if (_life <= 0)
        {
            _playerAudio.PlayLifeClip(_life);
            Die();
        }
        Debug.Log("Tienes " + _life + " de vida");

        _healthBar.fillAmount = _life / 100f;

        void Die()
        {
            StartCoroutine(YouDied());
        }

        IEnumerator YouDied()
        {
            _transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(_transitionTime);
            Debug.Log("Moridiste");
            SceneManager.LoadScene(8);  
            _transitionAnim.SetTrigger("Start");
        }
    }
}
