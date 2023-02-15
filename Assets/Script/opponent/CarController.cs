using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Frount,
        Rear
    }
    [Serializable]
    public struct wheel
    {
        public GameObject Mesh;
        public WheelCollider Collider;
        public Axel axel;
    }

    public float maxAccelaration = 30f;
    public float breakAccelaration = 50f;

    public float TurnSenctivity = 1f;
    public float MaxStearAngle = 30f;

    public Vector3 CenterOfMass;

    public List<wheel> wheels;

    public float moveinput;
    public float steerInput;
    [HideInInspector]public Rigidbody carRB;
    // public GameObject way;
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = CenterOfMass;
    }

    void Update()
    {
        // getinput();
        AnimateWheels();
        // print(carRB.velocity.magnitude);
        // print(Mathf.Round(2*22/7));
        
        // print(Mathf.Asin(this.transform.position,way.transform.position));

    }
    void LateUpdate()
    {
        // Move();
        // stear();
        
        // Break();
    }

    void getinput()
    {
        moveinput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }
    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.Collider.GetWorldPose(out pos, out rot);
            wheel.Mesh.transform.position = pos;
            wheel.Mesh.transform.rotation = rot;
        }
    }

    public int Move(int dir)
    {
        foreach (var wheel in wheels)
        {
            wheel.Collider.motorTorque = dir * 600 * maxAccelaration * Time.deltaTime;
        }
        return 0;
        
    }
    public void stear(GameObject way)
    {
       
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Frount)
            {
                
                // var steeringAngle = steerInput * TurnSenctivity * MaxStearAngle;
                // var steeringAngle = Vector3.Angle(this.transform.position,way.transform.position);
                Vector3 steerVector= transform.InverseTransformPoint(way.transform.position.x,transform.position.y,way.transform.position.z);
                float steeringAngle =MaxStearAngle*(steerVector.x/steerVector.magnitude);
                
                wheel.Collider.steerAngle = Mathf.Lerp(wheel.Collider.steerAngle, steeringAngle, .06f);
            }
        }
    }
    public void Break(float Breakforce)
    {
            foreach (var wheel in wheels)
            {
                if(wheel.axel==Axel.Rear){
                wheel.Collider.brakeTorque = breakAccelaration*Time.deltaTime*500*Breakforce;
                }
            }
    }
}
