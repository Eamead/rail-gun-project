using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioClip mel;

    AudioSource audioSource;    
    Rigidbody rb;

    void Start()
        {
            rb = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
        }
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") 
        {
            explosion.Play();
            audioSource.PlayOneShot(mel);
            rb.useGravity = true;
            GetComponent<PlayerControls>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            Invoke("DeathorSomethinghahahaarentyoufuckingclever", delay);           
            Debug.Log(this.name + "has collided with " + other.gameObject.name);
        }
    }

    /*void OnParticleCollision(GameObject other) 
    {
        explosion.Play();
        audioSource.PlayOneShot(mel);
        rb.useGravity = true;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        Invoke("DeathorSomethinghahahaarentyoufuckingclever", delay);           
        Debug.Log(this.name + "has collided with " + other.gameObject.name);
    }
    */
    
    void DeathorSomethinghahahaarentyoufuckingclever()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}