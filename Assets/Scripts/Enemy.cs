using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    Vector3 forceDirection;
    Animator anim;
    

    [SerializeField] GameObject boom;
    [SerializeField] Transform parent;
    [SerializeField] int value = 1;

    bool beenShot = false;
    Points points;
    
    void Start()
    {
        points = FindObjectOfType<Points>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //var boomVisual = boom.GetComponent<ParticleSystem>();
        //boomVisual.Stop();
    }


    void OnParticleCollision(GameObject other) 
    {
        if (anim.enabled == true)
            {
                anim.enabled = false;
            }
        else
            {
                if (beenShot == false)
                {
                    beenShot = true;
                    float forceX = -10f;
                    float forceY = 0;
                    float forceZ = -10f;
                    forceDirection = new Vector3(forceX, forceY, forceZ);

        
                    GameObject explode = Instantiate(boom, transform.position, Quaternion.identity);
                    explode.transform.parent = parent;
                    //var boomVisual = boom.GetComponent<ParticleSystem>();
                    //boomVisual.Play();

                    points.IncreasePoints(value);    

                    rb.useGravity = true;
                    rb.AddRelativeForce(forceDirection, ForceMode.Impulse);
                    Destroy(gameObject, 2);
                }
            }
    }
}