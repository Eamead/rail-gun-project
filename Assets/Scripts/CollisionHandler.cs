using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        //if (other.gameObject.tag == "Player") 
        //{
            Debug.Log(this.name + "has collided with " + other.gameObject.name);
        //}
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} has triggered {other.gameObject.name}");
    }
}