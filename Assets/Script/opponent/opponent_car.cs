using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponent_car : MonoBehaviour
{
    [Header("car Engine")]
    public float movespeed, turningspeed = 50f, breakspeed = 12f, breakForce;

    [Header("destination var")]
    public Vector3 destination;
    public float currentSpeed;
    float next_Time,brake_time;
    public bool destinationReached;
    public bool ObjectAhead;
    waypoint_opponent_car opp_way;
    private Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
            opp_way = GetComponent<waypoint_opponent_car>();
        
    }

    public void Update()
    {
        Drive();
        Acceleration();
    }
    void Acceleration()
    {
        if (opp_way.DistanceForBreak > 8.5f && !ObjectAhead)
        {
            if (currentSpeed <= movespeed)
            {
                currentSpeed = Mathf.Lerp(0f, movespeed, next_Time);
                next_Time += Time.deltaTime * .1f;
            }
        }
        else
        {
            if(currentSpeed>2f){
                Break(0);
                
            };
            
        }

    }
    float Break(float speed){
        currentSpeed = Mathf.Lerp(currentSpeed, speed, brake_time);
            brake_time+= (Time.deltaTime*breakForce)/10;
            return speed;
    }
    public void Drive()
    {
        if (this.transform.position != destination)
        {
            Vector3 destinationdirection = destination - transform.position;
            destinationdirection.y = 0;
            float destinationdistance = destinationdirection.magnitude;

            if (destinationdistance >= breakspeed)
            {
                destinationReached = false;
                Quaternion targerrotation = Quaternion.LookRotation(destinationdirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                targerrotation, turningspeed * Time.deltaTime);

                
                // rb.AddForce(Vector3.forward*currentSpeed*1000*Time.deltaTime);
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            }
            else
            {
                next_Time = 0;
                currentSpeed = 1;
                brake_time=0;
                destinationReached = true;

            }
        }
    }

    public void Localdestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
        
            ObjectAhead=true;
            currentSpeed=0;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){
            ObjectAhead=false;
        }
    }
}
