using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    Vector3 forceDirection;

    [SerializeField] GameObject boom;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var boomVisual = boom.GetComponent<ParticleSystem>();
        boomVisual.Stop();
    }

    void OnParticleCollision(GameObject other) 
    {
        float forceX = -10f;
        float forceY = 0;
        float forceZ = -10f;
        forceDirection = new Vector3(forceX, forceY, forceZ);

        var boomVisual = boom.GetComponent<ParticleSystem>();
        boomVisual.Play();

        rb.useGravity = true;
        rb.AddRelativeForce(forceDirection, ForceMode.Impulse);
        Destroy(gameObject);
    }
}