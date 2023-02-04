using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh : MonoBehaviour
{
    public GameObject mesh;
    
    void Awake(){
    
        mesh.SetActive(false);
    }
    void Start()
    {
        
    }
}
