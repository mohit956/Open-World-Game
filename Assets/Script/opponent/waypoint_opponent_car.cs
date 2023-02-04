using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint_opponent_car : MonoBehaviour
{
    [Header("opponent car")]
    public opponent_car opponentCar;
    public waypoints currentway;
    public float DistanceForBreak;
    public SponOpponent sp;

    public void Awake(){
        opponentCar = GetComponent<opponent_car>();
    }
    public void Start(){
        currentway= sp.way;
        opponentCar.Localdestination(currentway.GetPosition());

    }

    private void Update(){
        DistanceForBreak=Vector3.Distance(transform.position,currentway.transform.position);
        if(opponentCar.destinationReached){
            currentway = currentway.nextway;
            opponentCar.Localdestination(currentway.GetPosition());
        }
    }
}
