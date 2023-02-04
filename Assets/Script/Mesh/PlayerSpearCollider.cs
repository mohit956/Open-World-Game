using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpearCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SmallBuild"){
            other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(true);
        }
        else if(other.gameObject.tag=="SmallMesh"){
            other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="SmallBuild"){
            other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(false);
            
        }
        else if(other.gameObject.tag=="SmallMesh"){
            other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(false);
        }
    }
    
}
