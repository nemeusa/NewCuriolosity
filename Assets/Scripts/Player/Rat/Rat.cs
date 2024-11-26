using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float movSpeed = 5f;
    public float jumpForce = 9f;
    public float fallSpeed = 3.5f;
    public float helicopterTime = 0.8f;
    public float cooldownHelicopter = 0f;
    public int maxPulsaciones = 200;
    private int pulsacionesRestantes;

    private bool puedePlanear = true;
    private bool enElAire = false;
    private bool saltando = false;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        pulsacionesRestantes = maxPulsaciones;
    }

    void Update()
    {
        float mov = Input.GetAxis("Horizontal") * movSpeed;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, mov);

        if (animator != null)
        {
            animator.SetBool("isRunning", mov != 0);
        }

        if (!IsGrounded())
        {
            enElAire = true;
        }
        else
        {
            enElAire = false;
            pulsacionesRestantes = maxPulsaciones;
            saltando = false;
        }

      
        if (Input.GetKeyDown(KeyCode.Space) && !saltando && IsGrounded())
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            saltando = true;


            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && enElAire && puedePlanear && pulsacionesRestantes > 0 && rb.velocity.y <= 0)
        {
            StartCoroutine(Planear());
        }
    }

    IEnumerator Planear()
    {
        pulsacionesRestantes--;

        rb.velocity = new Vector3(rb.velocity.x, -fallSpeed, rb.velocity.z);
        rb.drag = 10f;

        Debug.Log("Ratón usando su cola como helicóptero! Pulsaciones restantes: " + pulsacionesRestantes);

        yield return new WaitForSeconds(helicopterTime);

        rb.drag = 0f;


    }

    void RecargarHelicoptero()
    {
        puedePlanear = true;
        pulsacionesRestantes = maxPulsaciones;
        Debug.Log("Habilidad de helicóptero recargada");
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f);
    }
}
