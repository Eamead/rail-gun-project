using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;

    [SerializeField] float speedX = 0.1f;
    [SerializeField] float speedY = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
        //fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        //fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSlide = movement.ReadValue<Vector2>().x;
        float verticalSlide = movement.ReadValue<Vector2>().y;
        //float zSlide = movement.ReadValue<Vector2>().z;

        float localx = transform.localPosition.x;
        float localy = transform.localPosition.y;
        float localz = transform.localPosition.z;


        transform.localPosition = new Vector3(localx + horizontalSlide, localy + verticalSlide, localz);
    }
}
