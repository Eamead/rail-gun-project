using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;

    // Speed of player movement and range of movement
    [SerializeField] float speedX = 0.1f;
    [SerializeField] float xRange = 1.0f;
    [SerializeField] float speedY = 0.1f;
    [SerializeField] float minYRange = 1.0f;
    [SerializeField] float maxYRange = 2.0f;

    // rotation values.
    [SerializeField] float positionPitch = -2f;
    [SerializeField] float controlPitch = -15f;
    [SerializeField] float positionYaw = 3f;
    [SerializeField] float controlRoll = -15f;

    [SerializeField] private float rotationFactor = 1f;

    //ParticleSystem partStart;

    float horizontalSlide;
    float verticalSlide;


    // Start is called before the first frame update
    void Start()
    {
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
        // If the fire button is pressed, fire a leaf.
        if (fire.triggered)
        {
            //partStart.enabled = true;
            Debug.Log("Firing");
        }
    }
}
