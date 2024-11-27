using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [Header ("move")]
    [SerializeField] float speedMov;
    public Rigidbody rb;


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
    public bool takeWallJump;
    public bool takeWallJumpLeft;
    public bool takeLianasR;
    public bool takeLianasL;
    public ParticleSystem jumpParticles;
    [SerializeField]private bool wallJump;
    [SerializeField]private bool lianasActive;
    public Transform wallJumpRaycast;
    public Transform lianasRaycast;
    [SerializeField] string scene;
    
    [SerializeField] float gravityMultiplier;
    [SerializeField] float gravityMultiplierUp;

    [SerializeField] float raycastMaxDistance;
    [SerializeField] LayerMask jumpMask, plantMask, levelMask, wallMask, lianasMask;

    public Scene_Manager sceneManager;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pulsacionesRestantes = maxPulsaciones;
        
    }


    private void FixedUpdate()
    {
        if (!changeCode.goatTrue && !wallJump && !lianasActive) Move();
        if (changeCode.goatTrue && !takeWall && !changeCode.ratTrue) MoveGoat();
        if (!changeCode.ratTrue && !changeCode.batTrue) Jump();
        else if (changeCode.ratTrue && !changeCode.batTrue) RatJump();
        else if (!changeCode.ratTrue && changeCode.batTrue) Bat();
    }

    private void Update()
    {
        takeWallJump = Physics.Raycast(wallJumpRaycast.position, Vector3.forward, 0.7f, wallMask);
        takeWallJumpLeft = Physics.Raycast(wallJumpRaycast.position, Vector3.back, 0.7f, wallMask);
        takeLianasL = Physics.Raycast(lianasRaycast.position, Vector3.back, 1f, lianasMask);
        takeLianasR = Physics.Raycast(lianasRaycast.position, Vector3.forward, 1f, lianasMask);
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

        if(!takeWall || takeWall && Dir < 0 || takeWall && takeFloor){
            if (!wallJump) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Dir * speedMov);
            //else if (wallJump && takeWallJump) rb.velocity = new Vector3(0,0,0);
        }
        else if (takeWall && Dir > 0 && !takeFloor && isJumping)
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            Debug.Log("ta tocando pared");
        }
        

        if (Dir > 0 && !wallJump || takeWallJumpLeft && wallJump)
        { 
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (Dir < 0 && !wallJump || takeWallJump && wallJump) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    private void MoveGoat()
    {
        float dir = Input.GetAxis("Horizontal");
        if (!takeWall || takeWall && dir < 0)
        {
            if (dir != 0 && !changeCode.ratTrue)
            {
                currentSpeed += acceleration * Time.fixedDeltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, _baseSpeed, maxSpeed);
            }
            else
            {
                currentSpeed = _baseSpeed;
            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, dir * currentSpeed);
        }

        else if (takeWall && dir > 0 && !takeFloor && isJumping)
        {
            Debug.Log("ta tocando pared");
        }

        if (dir > 0 && !takeWallJumpLeft && !wallJump || takeWallJumpLeft && wallJump)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dir < 0 && !takeWallJump && !wallJump || takeWallJump && wallJump)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

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
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.fixedDeltaTime;
                rb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }

        //codigo de gravedad

        else
        {
            isJumping = false;
        }

        if (rb.velocity.y > 0)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplierUp / 2f), ForceMode.Acceleration);
        }
        else if (rb.velocity.y < 0 && !takeFloor && !wallJump && !lianasActive)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplier), ForceMode.Acceleration);
        }
        else if (wallJump && takeWall && rb.velocity.y < 0 && !takeFloor)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravityMultiplier / 2f), ForceMode.Acceleration);
        }

        if (Input.GetKey("w") && (takeLianasR || takeLianasL) && changeCode.monkeyTrue)
        {
            lianasActive = true;
            //rb.useGravity = false;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            //rb.AddForce(Vector3.up * Physics.gravity.y * (-1.6f), ForceMode.Acceleration);
        }
        else if (!takeLianasL && !takeLianasR || Input.GetButtonUp("Jump")) lianasActive = false;

        if (lianasActive)
        {
            if (rb.velocity.y < 0) rb.AddForce(Vector3.up * Physics.gravity.y * -1.2f, ForceMode.Acceleration);


            if (Input.GetButton("Jump"))
            {
                //float jump = Input.GetAxis("Jump");
                //rb.velocity = new Vector3(rb.velocity.x, jump + 5,rb.velocity.z);
                Debug.Log("haciendo lianas jump");
                rb.AddForce(Vector3.up * 1.8f, ForceMode.Impulse);

                if (Input.GetKey("d"))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 6);
                    Debug.Log("salto a la derecha");
                    //transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                else if (!Input.GetKey("a"))
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -6);
                    Debug.Log("salto a la izquierda");
                    //transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }

        //Codigo de wall jump

        if (Input.GetButton("Jump") && (takeWallJump || takeWallJumpLeft) && !takeFloor)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            wallJump = true;
            Debug.Log("se activo wall jump");
        }
        else if (takeFloor)
        {
            wallJump = false;
            //Debug.Log("se desactivo wall jump");
        }

        if (Input.GetButton("Jump") && wallJump && (takeWallJump || takeWallJumpLeft))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            Debug.Log("haciendo wall jump");
            if (takeWallJumpLeft)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 6);
                Debug.Log("salto a la derecha");
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            else if (takeWallJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -6);
                Debug.Log("salto a la izquierda");
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
    private void Bat()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isJumping = true;
            jumpTimeCounter = 0.2f;
            rb.velocity = new Vector3(rb.velocity.x, 6, rb.velocity.z);
        }

        // Continúa el salto mientras se mantiene el botón y haya tiempo de salto
        if (Input.GetButton("Fire1") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 6, rb.velocity.z);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false; // Finaliza el salto cuando se agota el tiempo
            }
        }

        // Detiene el salto al soltar el botón
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
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

        if (Input.GetButton("Jump") && isJumping && puedePlanear && pulsacionesRestantes > 0 && rb.velocity.y <= 0 && !takeFloor)
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
        //Gizmos.DrawLine(wallJumpRaycast.position, wallJumpRaycast.position + Vector3.forward * 0.8f);
        //Gizmos.DrawLine(wallJumpRaycast.position, wallJumpRaycast.position + Vector3.back * 0.8f);
        Gizmos.DrawLine(lianasRaycast.position, lianasRaycast.position + Vector3.back * 1f);
        Gizmos.DrawLine(lianasRaycast.position, lianasRaycast.position + Vector3.forward * 1f);

    }
}
