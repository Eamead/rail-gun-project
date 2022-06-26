using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //Prevents music from restarting when scene is reloaded
    void Awake() 
    {
        int musPlayers = FindObjectsOfType<Music>().Length;    
        if (musPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

}
