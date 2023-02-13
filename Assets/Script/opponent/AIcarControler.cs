using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcarControler : MonoBehaviour
{

    public WayPoints way;
    public CarController carController;
    public SponOpponent sponOpponent;
    [SerializeField]bool reached,ObjectAhead;
    void Start(){
        sponOpponent=GetComponentInParent<SponOpponent>();
        comands();
    }
    void Update(){
        AI();
    }
    void comands(){
            way=sponOpponent.firstway;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Way"){
            if(!other.gameObject.GetComponent<WayPoints>().NoBreak){
            reached=true;
            // way=way.next_way.gameObject.GetComponent<WayPoints>();
            WayPoints waypoint= other.gameObject.GetComponent<WayPoints>();
            way=waypoint.next_way;
            carController.stear(way.next_way.gameObject);
            Invoke("REC",1);
            }
            else{
            // way=way.next_way.gameObject.GetComponent<WayPoints>();
            WayPoints waypoint= other.gameObject.GetComponent<WayPoints>();
            way=waypoint.next_way;
            carController.stear(way.next_way.gameObject);
        }
        }
        if(other.gameObject.tag=="Player"){
            // reached=true;
            CancelInvoke("DestroyCar");
            // Invoke("REC",4);
        }
        

        if(other.gameObject.tag=="Car"){
            
            // ObjectAhead=true;
        }
    }
    void OnTriggerExit(Collider other){

        // if(other.gameObject.tag=="Car"){
        //     ObjectAhead=false;
        //     Move();
        // }
        if(other.gameObject.tag=="Player"){
            reached=false;
            Invoke("DestroyCar",4);
        }
    }
    void DestroyCar(){
        sponOpponent.isrunnung=sponOpponent.isrunnung-1;
        Destroy(this.gameObject);
    }
    void AI(){
        
        if(!reached){
            Move();
            carController.stear(way.current_way);
        }
        
        else Break();

        if(ObjectAhead) Break();
    }
    void Move(){
        if(!ObjectAhead)
        carController.Move(1);
            carController.Break(0);
    }
    void Break(){
        carController.Move(0);
            carController.Break(1);
    }
    void REC(){
        reached=false;
    }
}
