using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcarControler : MonoBehaviour
{

    public WayPoints way, Previous_Way;
    WayPoints current_way;
    public int max_dis = 50;

    public CarController carController;
    public SponOpponent sponOpponent;
    [SerializeField] bool reached, ObjectAhead;
    void Start()
    {
        sponOpponent = GetComponentInParent<SponOpponent>();
        comands();

    }
    void Update()
    {
        AI();

        if (way.current_way.RedLight)
        {
            Break(5);
        }
    }
    
    void comands()
    {
        sponOpponent.runTimeCar++;
        Invoke("DestroyCar", 10);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Way")
        {
            // print(way.gameObject+" way "+ other.gameObject+" Collide vala");

            // Previous_Way=way.previous_way;
            if (way == null)
            {
                WayPoints waypoint = other.gameObject.GetComponent<WayPoints>();
                way = waypoint.next_way;
                print("1");
            }
            else
            {
                // print("2");
                if (!other.gameObject.GetComponent<WayPoints>().NoBreak)
                {
                    if (other.gameObject == way.gameObject)
                    // if (ObjectAhead)
                    
                    {
                        // print("3");
                        // way=way.next_way.gameObject.GetComponent<WayPoints>();
                        WayPoints waypoint = other.gameObject.GetComponent<WayPoints>();
                        way = waypoint.next_way;
                        current_way = waypoint.current_way;
                        // current_way.GreenLight=true;
                        carController.stear(way.next_way.gameObject);
                        reached = true;
                        Invoke("REC", .5F);
                    }
                    
                }
                else
                    {
                        // print("4");
                        // print(other.gameObject.name +" = "+ way.gameObject.name);
                        if (other.gameObject.name == way.gameObject.name)
                        {
                            // print("5");
                            WayPoints waypoint = other.gameObject.GetComponent<WayPoints>();
                            reached = false;
                            current_way = waypoint.current_way;
                            way = waypoint.next_way;
                            carController.stear(way.next_way.gameObject);
                        }
                    }
            }
        }
        if (other.gameObject.tag == "Player")
        {
            // reached=true;
            CancelInvoke("DestroyCar");
            // Invoke("REC",4);
        }


        if (other.gameObject.tag == "CarBack")
        {
            WheelFrictionCurve frictionCurve0 = carController.wheels[2].Collider.forwardFriction;
            WheelFrictionCurve frictionCurve1 = carController.wheels[3].Collider.forwardFriction;
            frictionCurve0.stiffness = 10f;
            frictionCurve1.stiffness = 10f;
            carController.wheels[2].Collider.forwardFriction = frictionCurve0;
            carController.wheels[3].Collider.forwardFriction = frictionCurve1;

            reached = true;
            Break(50);
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "CarBack")
        {
            WheelFrictionCurve frictionCurve0 = carController.wheels[2].Collider.forwardFriction;
            WheelFrictionCurve frictionCurve1 = carController.wheels[3].Collider.forwardFriction;
            frictionCurve0.stiffness = 2f;
            frictionCurve1.stiffness = 2f;
            carController.wheels[2].Collider.forwardFriction = frictionCurve0;
            carController.wheels[3].Collider.forwardFriction = frictionCurve1;

            reached = false;
            Break(0);
        }
        if (other.gameObject.tag == "Player")
        {
            // reached=false;
            Invoke("DestroyCar", 4);
        }
    }

    void DestroyCar()
    {
        sponOpponent.isrunnung = sponOpponent.isrunnung - 1;
        sponOpponent.runTimeCar = sponOpponent.runTimeCar - 1;
        Destroy(this.gameObject);
    }
    void AI()
    {

        if (!reached)
        {
            Move();
            carController.stear(way.current_way.gameObject);
        }

        else Break(1);

        if (ObjectAhead) Break(1);
    }
    void Move()
    {
        if (!ObjectAhead || !way.RedLight)
            carController.Move(1);
        carController.Break(0);
    }
    void Break(float B)
    {
        carController.Move(0);
        carController.Break(B);
    }
    void REC()
    {
        reached = false;
    }
}
