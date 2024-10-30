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
    public bool IsParry;
    GameObject turtle;

    [SerializeField] private AudioManager _audioManager;

    public void TakeDamage(float damage)
    {
        _life -= damage;

        _audioManager.DamageSource.Play();

        if (_life <= 0)
        {
                Die();
        }
        Debug.Log("recibiste " + _life + " de daño");

        _healthBar.fillAmount = _life / 100f;

        void Die()
        {
            StartCoroutine(YouDied());
        }

        IEnumerator YouDied()
        {
            _audioManager.DeathSource.Play();
            _transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(_transitionTime);
            Debug.Log("Moridiste");
            SceneManager.LoadScene(7);
            _transitionAnim.SetTrigger("Start");
        }
    }
}
