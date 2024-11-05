using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [Header ("move")]
    [SerializeField] float speedMov;
    public Rigidbody rb;
    public Transform vista;


    [Header("goat")]
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float acceleration = 5f;
    public static float currentSpeed;
    [SerializeField] private ChangeAnimal changeCode;
    float _baseSpeed = 4f;
    bool goatOn;

    [Header("Rat")]
    public float movSpeed = 5f;
    public float jumpForce = 9f;
    public float fallSpeed = 3.5f;
    public float helicopterTime = 0.8f;
    public float cooldownHelicopter = 0f;
    public int maxPulsaciones = 200;
    private int pulsacionesRestantes;
    private bool puedePlanear = true;

    [Header ("Jump")]
    [SerializeField] float forceJump;
    [Range(0,1)][SerializeField] float jumpTime;
    private float jumpTimeCounter;
    private bool isJump;
    private bool isJumping;
    private bool takeFloor;
    private bool changeLevel;
    public bool plantZone;
    public static bool takeWall;
    public ParticleSystem jumpParticles;
    [SerializeField] string scene;
    
    [SerializeField] float gravityMultiplier;
    [SerializeField] float gravityMultiplierUp;

    [SerializeField] float raycastMaxDistance;
    [SerializeField] LayerMask jumpMask, plantMask, levelMask, wallMask;

    public Scene_Manager sceneManager;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pulsacionesRestantes = maxPulsaciones;
    }


    private void FixedUpdate()
    {
        if (!changeCode.goatTrue) Move();
        else MoveGoat();
        if (!changeCode.ratTrue)
            Jump();
        else
            RatJump();
    }
    private void Update()
    {
        //takeWall = Physics.Raycast(vista.position, Vector3.forward, 0.8f, wallMask);
        plantZone = Physics.Raycast(transform.position, Vector3.down, raycastMaxDistance, plantMask);
        changeLevel = Physics.Raycast(transform.position, Vector3.down, raycastMaxDistance, levelMask);

        if (changeLevel)
        {
            sceneManager.LoadNextScene();
        }

        if (Input.GetButtonDown("Jump") && takeFloor)
        {
            isJump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

    }


    void Move()
    {
        float Dir = Input.GetAxis("Horizontal");

        if (!takeWall)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Dir * speedMov);

        else if (takeWall && Dir > 0 && !takeFloor && isJumping)
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            Debug.Log("ta tocando pared");
        }

        else if (takeWall && Dir < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Dir * speedMov);
            Debug.Log("ta saliendo de la pared");
        }

        if (Dir > 0)
        { 
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //takeWall = Physics.Raycast(vista.position, Vector3.forward, 0.3f, wallMask);
        }
        else if (Dir < 0) 
        { 
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //takeWall = Physics.Raycast(vista.position, Vector3.back, 0.3f, wallMask);
        }

    }

    private void MoveGoat()
    {
        float dir = Input.GetAxis("Horizontal");
        //if (!takeWall)
        //{
            if (dir != 0)
            {
                currentSpeed += acceleration * Time.fixedDeltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, _baseSpeed, maxSpeed);
            }
            else
            {
                currentSpeed = _baseSpeed;
            }
        //}

        if (takeWall && dir > 0 && !takeFloor && isJumping)
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            Debug.Log("ta tocando pared");
        }


        if (dir > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        else if (dir < 0) { transform.rotation = Quaternion.Euler(0, 180, 0); }

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, dir * currentSpeed);
    }

    void Jump()
    {

        takeFloor = Physics.Raycast(transform.position, Vector3.down, raycastMaxDistance, jumpMask);
        

        if (isJump)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            jumpParticles.Play();
            isJump = false;

        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.fixedDeltaTime;
                rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }

        else
        {
            isJumping = false;
        }

        if (rb.velocity.y > 0)
        {
        
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplierUp / 2f), ForceMode.Acceleration);
        }
        else if (rb.velocity.y < 0 && !takeFloor)
        {

            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplier), ForceMode.Acceleration);
        }
    }

    #region rat
    void RatJump()
    {
        takeFloor = Physics.Raycast(transform.position, Vector3.down, raycastMaxDistance, jumpMask);

        if (!takeFloor)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
            pulsacionesRestantes = maxPulsaciones;
            isJump = false;
        }


        if (Input.GetButton("Jump") && !isJump && takeFloor)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJump = true;
        }

        if (Input.GetButton("Jump") && isJumping && puedePlanear && pulsacionesRestantes > 0 && rb.velocity.y <= 0)
        {
            StartCoroutine(Planear());
        }
    }


    IEnumerator Planear()
    {
        pulsacionesRestantes--;

        rb.velocity = new Vector3(rb.velocity.x, -fallSpeed, rb.velocity.z);
        rb.drag = 10f;

        Debug.Log("Rat�n usando su cola como helic�ptero! Pulsaciones restantes: " + pulsacionesRestantes);

        yield return new WaitForSeconds(helicopterTime);

        rb.drag = 0f;


    }
    #endregion


    public void ChangeSpeed(float newSpeed)
    {
        speedMov = newSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawLine(vista.position, vista.position + Vector3.forward * 0.3f);
    }
}
