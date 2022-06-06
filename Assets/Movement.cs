using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;  
    float yMove;
    float coolDown;
    [SerializeField] int shiftSpeed = 1;
    [SerializeField] float sensitivity = 4f;
    [SerializeField] int jumpCount;
    [SerializeField] int maxJump = 2;
    [SerializeField] float JumpForce;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip doubleSound;

    AudioSource audioSource;

    float timer = 0;

    void Awake() //Before Start
    {
        rb = this.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame (Literally every frame)
    void Update()
    {
        
        timer += Time.deltaTime;

        if(timer > 0)
        {
        
        yMove = Input.GetAxis("Jump") * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.LeftShift))
            {
                shiftSpeed = 16;
            }
        else
            {
                shiftSpeed = 8;
            }

        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * shiftSpeed;        
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime * shiftSpeed;


        transform.Translate(xMove,0,zMove);
        
                transform.Rotate(0 ,Input.GetAxis("Mouse X") * sensitivity, 0);

        if (Input.GetButtonDown("Jump") && jumpCount > 1)
            {
                coolDown = 0;
                jumpCount--;
                audioSource.PlayOneShot(jumpSound);
                rb.AddRelativeForce(new Vector3(0, 3.8f, 0), ForceMode.VelocityChange);

            }
        else if (Input.GetButtonDown("Jump") && jumpCount == 1)
            {        
                jumpCount--;
                rb.AddRelativeForce(new Vector3(0, 0.5f, 3), ForceMode.VelocityChange); 
                audioSource.PlayOneShot(doubleSound);
 
            }                   
        
            coolDown += Time.deltaTime;

        RaycastHit Hit;

        Debug.DrawRay(transform.position, -Vector3.up * .7f ,Color.white);

        if (Physics.Raycast(transform.position, -Vector3.up, out Hit, .7f) && coolDown > .4f)
        {
            jumpCount = maxJump;
        }

        }

    }

    // Update at 60FPS
    void FixedUpdate()
    {       

    }

}
