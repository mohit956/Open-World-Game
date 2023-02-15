using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    
    public SponOpponent RedLightPole;
    public WayPoints previous_way;
    public WayPoints current_way;
    public WayPoints next_way;
    public bool P90, N90, P180,Stop;
    public bool Player_InRange, car_Inrange,RedLight,CrossWay;
    [SerializeField] WayPoints[] next_way2;
    public bool cut, NoBreak;
    // Start is called before the first frame update
    void Start()
    {
        current_way = GetComponent<WayPoints>();
    }
    void Update(){
        if(Stop){
        if(!RedLightPole.Stop){
            RedLight=false;
        }
        else{
            RedLight=true;
        }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (cut && other.gameObject.tag == "Car")
        {
            int dir = Random.Range(0, next_way2.Length);
            next_way = next_way2[dir];
        }
        if (other.gameObject.tag == "Car" || other.gameObject.tag == "CarBack") {
            car_Inrange = true;
            
            }


        if (other.gameObject.tag == "Player") Player_InRange = true;

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") Player_InRange = false;

        if (other.gameObject.tag == "Car") {
            // car_Inrange = false;
            Invoke("inrange",2.5f);
        }
    }
    void inrange(){ 
        car_Inrange = false;}
}
