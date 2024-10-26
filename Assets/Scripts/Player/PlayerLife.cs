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

    public void TakeDamage(float damage)
    {
        //if (gameObject.layer == LayerMask.NameToLayer("Turtle")) IsParry = true;
        if (turtle != null) IsParry = true;

        else
        {
            _life -= damage;

            if (_life <= 0)
            {
                Die();
            }
            Debug.Log("recibiste " + _life + " de daño");
            IsParry = false;
        }

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
            SceneManager.LoadScene(7);
            _transitionAnim.SetTrigger("Start");
        }
    }
}
