using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponOpponent : MonoBehaviour
{
    public WayPoints[] way;
    public int Quentity,runTimeCar;
    private Mesh mesh;
    public int isrunnung;
    public GameObject parent_point;
    [SerializeField] bool sponing, NextSpon;
    public bool Stop;
    public GameObject[] Car;
    public PlayerSpearCollider spearCollider;

    void Start()
    {
        sponing = true;
        Stop=true;
        mesh = GetComponent<Mesh>();
    }
    void Update()
    {
        // if(mesh.active) StartCoroutine("sponcar");

        if (!sponing && runTimeCar <= Quentity && mesh.active)
        {

            // Invoke("startspon",6);
            int RandPos = Random.Range(0, way.Length);
            var rand = Random.Range(0, Car.Length);
            if (!way[RandPos].Player_InRange && !way[RandPos].car_Inrange)
            {
                // Rotation during Spon
                float digri = 0;
                if (way[RandPos].P180) digri = 180;
                else if (way[RandPos].P90) digri = 90;
                else if (way[RandPos].N90) digri = 270;
                else digri = 0;

                // Spon car
                float x = way[RandPos].transform.position.x;
                float z = way[RandPos].transform.position.z;
                WayPoints way2=way[RandPos];
                Car[rand].GetComponent<AIcarControler>().way=way2;
                Instantiate(Car[rand], new Vector3(x, 3f, z), Quaternion.Euler(0f, digri, 0f), parent_point.transform.parent);
                isrunnung++;
            }
        }
        if (!mesh.active)
        {
            // StopCoroutine("sponcar");
        }
    }
    public void startspon()
    {
        sponing = true;
        if (runTimeCar <= Quentity) StartCoroutine("sponcar");
    }
    public void endspon()
    {
        sponing = false;
        StopCoroutine("sponcar");
    }
    IEnumerator sponcar()
    {
        for (int i = 0; runTimeCar < Quentity; i++)
        {
        NextSpon = false;
        int RandPos = Random.Range(0, way.Length);
        var rand = Random.Range(0, Car.Length);
        if (!way[RandPos].Player_InRange && !way[RandPos].car_Inrange)
        {

            float digri = 0;
            if (way[RandPos].P180) digri = 180;
            else if (way[RandPos].P90) digri = 90;
            else if (way[RandPos].N90) digri = -90;
            else digri = 0;


            float x = way[RandPos].transform.position.x;
            float z = way[RandPos].transform.position.z;
            Instantiate(Car[rand], new Vector3(x, 3, z), Quaternion.Euler(0f, digri, 0f), parent_point.transform.parent);
            
            yield return new WaitForSeconds(6);
            NextSpon = true;
            if ( runTimeCar == Quentity) sponing = false;
        }
        else yield return new WaitForSeconds(1);
        }

    }
}
