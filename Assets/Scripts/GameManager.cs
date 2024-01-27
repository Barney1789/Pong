using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //The backend's server address
    public static string baseURI = "http://localhost:3000";

    //Do not destroy the target Object when loading a new Scene.
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }



 
}
