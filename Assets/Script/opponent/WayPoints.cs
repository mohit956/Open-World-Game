using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    public GameObject previous_way;
    [HideInInspector]public GameObject current_way;
    public WayPoints next_way;
    [SerializeField]GameObject[] next_way2;
    public bool cut,NoBreak;
    // Start is called before the first frame update
    void Start()
    {
        current_way=this.gameObject;
    }
    void OnTriggerEnter(Collider other){
        if(cut && other.gameObject.tag=="Car"){
            print("cut");
            int dir= Random.Range(0,next_way2.Length);
            // next_way=next_way2[dir];
            
        }
    }
}
