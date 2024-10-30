using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [Header ("move")]
    [SerializeField] float speedMov;
    public Rigidbody rb;


    [Header("goat")]
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float acceleration = 5f;
    public static float currentSpeed;
    //public GameObject goat;
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
    //[SerializeField] float extraForceJump;
    [Range(0,1)][SerializeField] float jumpTime;
    private float jumpTimeCounter;
    private bool isJump;
    private bool isJumping;
    private bool takeFloor;
    private bool changeLevel;
    public bool plantZone;
    public ParticleSystem jumpParticles;
    [SerializeField] string scene;
    
    [SerializeField] float gravityMultiplier;

    [SerializeField] float raycastMaxDistance;
    [SerializeField] LayerMask jumpMask, plantMask, levelMask;

    public Scene_Manager sceneManager;
    
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private CinemachineVirtualCamera virtualCameraUp;
    [SerializeField] private KeyCode lookDown;
    [SerializeField] private KeyCode lookUp;
    
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

        if (Input.GetKeyDown(lookDown))
        {
            virtualCamera.Priority = 3;
        }
        else if (Input.GetKeyUp(lookDown))
        {
            virtualCamera.Priority = 0;
        }

        if (Input.GetKeyDown(lookUp))
        {
            virtualCameraUp.Priority = 3;
        }
        else if (Input.GetKeyUp(lookUp))
        {
            virtualCameraUp.Priority = 0;
        }
    }


    void Move()
    {
        float Dir = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Dir * speedMov);

        if (Dir > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        else if (Dir < 0) { transform.rotation = Quaternion.Euler(0, 180, 0); }

    }

    private void MoveGoat()
    {
        float dir = Input.GetAxis("Horizontal");

        if (dir != 0)
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, _baseSpeed, maxSpeed);
        }
        else
        {
            currentSpeed = _baseSpeed;
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
            //rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime);
            jumpParticles.Play();
            isJump = false;

        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.fixedDeltaTime;
                rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime, ForceMode.Impulse);
                //rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime);
            }
        } 

        if (!takeFloor && rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplier - 1), ForceMode.Acceleration);
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
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastMaxDistance);
    }
}
