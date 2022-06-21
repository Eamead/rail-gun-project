using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleClear : MonoBehaviour
{
    
    [SerializeField] float timeClear = 2f;
    
    void Start()
    {
        Destroy(gameObject, timeClear);
    }

}
