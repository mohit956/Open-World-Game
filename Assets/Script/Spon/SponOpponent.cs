using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponOpponent : MonoBehaviour
{
    public GameObject[] Pos;
    public WayPoints way1,way2;
    public WayPoints firstway;
    public bool spon1;
    public int Quentity;
    public int isrunnung;
    public GameObject parent_point;
    bool sponing;
    public GameObject[] Car;
    public PlayerSpearCollider spearCollider;
    void Start()
    {    
        sponing=true;
    }
    void Update()
    {
        if(!sponing && isrunnung<Quentity){
            int RandPos= Random.Range(0,Pos.Length);
            if(RandPos==0)firstway=way1;
            else spon1= firstway=way2;
            float x= Pos[RandPos].transform.position.x;
            float z= Pos[RandPos].transform.position.z;
            var rand= Random.Range(0,Car.Length);
            Instantiate(Car[rand],new Vector3(x,5f,z),Quaternion.identity,parent_point.transform.parent);    
            isrunnung++;
        }
    }
    public void startspon(){
        sponing=true;
        if(isrunnung<=Quentity) StartCoroutine("sponcar");
    }
    public void endspon(){
        sponing=false;
        StopCoroutine("sponcar");
    }
    IEnumerator sponcar(){
        for(int i =0 ;i<=Quentity;i++){
            
            int RandPos= Random.Range(0,Pos.Length);
            if(RandPos==0)firstway=way1;
            else spon1= firstway=way2;
            float x= Pos[RandPos].transform.position.x;
            float z= Pos[RandPos].transform.position.z;
            var rand= Random.Range(0,Car.Length);
            Instantiate(Car[rand],new Vector3(x,5f,z),Quaternion.identity,parent_point.transform.parent);    
            isrunnung++;
            if(i==Quentity)sponing=false;
            yield return new WaitForSeconds(6);
        }

    }
}
