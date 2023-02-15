using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLight : MonoBehaviour
{
    public SponOpponent[] spon;
    public int timelaps=6;
    [SerializeField]int timeToGreen,previous_LIght=0,Light=1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     if(Time.time>=timeToGreen){
        spon[previous_LIght].Stop=false;
        previous_LIght=Light;
        spon[Light].Stop=true;
        timeToGreen+=timelaps;
        if(Light==3){
            Light=0;
        }
        else{
            Light++;
        }
     }  
    }
    // IEnumerator Light(){
    //     for(int i=0;i<5;i++){
    //         print("1");
    //         yield return new WaitForSeconds(2);
    //         print("2");
    //         spon[i].Stop=false;
    //         yield return new WaitForSeconds(8);
    //         print("3");
    //         spon[i].Stop=true;
    //     if(i==4){
    //     i=0;
    // }
    //     }
        
    // }
}
