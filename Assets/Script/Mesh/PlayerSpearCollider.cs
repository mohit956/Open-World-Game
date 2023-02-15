using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpearCollider : MonoBehaviour
{
    SpriteRenderer[] rend;
    // [HideInInspector]public bool SmallMesh;
    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag=="SmallBuild"){
            other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(true);
        }
        else if(other.gameObject.tag=="SmallMesh"){
            Mesh mesh= other.gameObject.GetComponentInChildren<Mesh>();
            SponOpponent opp= other.gameObject.GetComponent<SponOpponent>();
            mesh.mesh.gameObject.SetActive(true);
            opp.startspon();
            mesh.active=true;
            // other.gameObject.GetComponentInChildren<Mesh>().mesh.active=true;
        }
        // if(other.gameObject.tag=="Car"){
        //     print("car");
        //     CancelInvoke("carRemove");
        // }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="SmallBuild"){
            other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(false);
            
        }
        else if(other.gameObject.tag=="SmallMesh"){
            Mesh mesh= other.gameObject.GetComponentInChildren<Mesh>();
            SponOpponent opp= other.gameObject.GetComponent<SponOpponent>();
            mesh.mesh.gameObject.SetActive(false);
            opp.endspon();
            mesh.active=false;
            // other.gameObject.GetComponentInChildren<Mesh>().mesh.SetActive(false);
        }
        // if(other.gameObject.tag=="Car"){
        //     int current_cars= other.GetComponent<AIcarControler>().sponOpponent.isrunnung;
        //     Invoke("carRemove",4);
        //     void carRemove(){
        //         print("remove car");
        //         other.GetComponent<AIcarControler>().sponOpponent.isrunnung=current_cars-1;
        //         Destroy(other.gameObject);
        //     } 
        // }
    }
}
