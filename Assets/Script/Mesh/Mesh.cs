using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh : MonoBehaviour
{
    public GameObject mesh;
    [HideInInspector]public bool active;
    // private SponOpponent sponOpponent;
    void Awake(){
        mesh.SetActive(false);
    }
    void Start()
    {
    }
    
}
