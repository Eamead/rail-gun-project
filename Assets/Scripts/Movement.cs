using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;  
    float yMove;
    float coolDown;
    [SerializeField] int moveSpeed = 20;
    [SerializeField] float sensitivity = 1.2f;
    [SerializeField] float upForce;

    AudioSource audioSource;

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
        
        
        yMove = Input.GetAxis("Jump") * Time.deltaTime * 2.5f;
        
        if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 40;
            }
        else
            {
                moveSpeed = 20;
            }

        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;        
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        transform.Translate(xMove,0,zMove);
        
                transform.Rotate(0 ,-Input.GetAxis("Mouse X") * sensitivity, 0);
                transform.Rotate(Input.GetAxis("Mouse Y"), 0 * sensitivity, 0);
                            

    }    


}
