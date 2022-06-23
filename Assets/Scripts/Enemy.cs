using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    Vector3 forceDirection;
    Animator anim;
    

    [SerializeField] GameObject boom;
    [SerializeField] GameObject hitFX;
    [SerializeField] AudioClip hitsound;
    [SerializeField] AudioClip juicedie;
    [SerializeField] Transform parent;
    [SerializeField] int value = 1;
    [SerializeField] int health = 1;

    AudioSource audioSource;
    Points points;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        points = FindObjectOfType<Points>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void OnParticleCollision(GameObject other) 
    {
        health -= 1;
        Debug.Log("Enemy Health: " + health);
        increasePoints();
        GameObject hit = Instantiate(hitFX, transform.position, Quaternion.identity);
        hit.transform.parent = parent;
        audioSource.PlayOneShot(hitsound);
    }

    void checkAnimation()    
    {
        if (anim.enabled == true)
        {
            anim.enabled = false;
        }
    }

    void increasePoints()    
    {
        if (health >= 1)
        {
            points.IncreasePoints(value);
        }
        else if (health == 0)
        {                                      
            points.IncreasePoints(value);
            EnemyDeath();              
        }
    }

    void EnemyDeath()
    {
        checkAnimation();
        float forceX = -10f;
        float forceY = 0;
        float forceZ = -10f;
        forceDirection = new Vector3(forceX, forceY, forceZ);


        GameObject explode = Instantiate(boom, transform.position, Quaternion.identity);
        explode.transform.parent = parent;
                    
        rb.useGravity = true;
        rb.AddRelativeForce(forceDirection, ForceMode.Impulse);
        audioSource.PlayOneShot(juicedie);
        Destroy(gameObject, 2);
                    
    }

}