using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    [SerializeField] AudioClip leafer;

    [Header("Leaf Shooting Array")]
    [SerializeField] GameObject[] leaves;

    [Header("Player Speed and Range")]
    [Tooltip("The horizontal speed of the player")]
    // Speed of player movement and range of movement
    [SerializeField] float speedX = 0.1f;
    [Tooltip("The horizontal range of motion of the player on the screen")]
    [SerializeField] float xRange = 1.0f;
    [Tooltip("The vertical speed of the player")]
    [SerializeField] float speedY = 0.1f;
    [Tooltip("The minimum vertical range of motion of the player on the screen")]
    [SerializeField] float minYRange = 1.0f;
    [Tooltip("The maximum vertical range of motion of the player on the screen")]
    [SerializeField] float maxYRange = 2.0f;

    [Header("Player Rotation")]
    // rotation values.
    [Tooltip("The speed of the player's forward rotation")]
    [SerializeField] float positionPitch = -2f;
    [Tooltip("The amount of forward rotation")]
    [SerializeField] float controlPitch = -15f;
    [Tooltip("The speed of the player's sideways rotation")]
    [SerializeField] float positionYaw = 3f;
    [Tooltip("The amount of roll when swerving")]
    [SerializeField] float controlRoll = -15f;

    [SerializeField] private float rotationFactor = 1f;

    //ParticleSystem partStart;

    AudioSource audioSource;
    
    float horizontalSlide;
    float verticalSlide;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //partStart = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    { 
        // Calculate the pitch.
        float pitchPos = transform.localPosition.y * positionPitch;
        float pitchSlide = verticalSlide * controlPitch;

        // Assign position and rotation to the variables.
        float pitch = pitchPos + pitchSlide;
        float yaw = transform.localPosition.x * positionYaw;
        float roll = horizontalSlide * controlRoll;

        // Apply the rotation to the player object.
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
    }

    private void ProcessTranslation()
    {
        horizontalSlide = movement.ReadValue<Vector2>().x;
        verticalSlide = movement.ReadValue<Vector2>().y;
        //float zSlide = movement.ReadValue<Vector2>().z;

        float localx = (horizontalSlide * Time.deltaTime * speedX) + transform.localPosition.x;
        float clampx = Mathf.Clamp(localx, -xRange, xRange);

        float localy = (verticalSlide * Time.deltaTime * speedY) + transform.localPosition.y;
        float clampy = Mathf.Clamp(localy, -minYRange, maxYRange);

        float localz = transform.localPosition.z;

        transform.localPosition = new Vector3(clampx, clampy, localz);
    }

    private void ProcessFiring()
    {
        // If the fire button is held, fire a leaf.
        if (fire.ReadValue<float>() > 0)
        {
            toggleLeafCannon(true);
        }
        else
        {
           toggleLeafCannon(false);
        }
    }

    void toggleLeafCannon(bool isCannoning)
    {
        foreach (GameObject leaf in leaves)
        {
            var emissionModule = leaf.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isCannoning;           
        }
    }
    
    

    
}