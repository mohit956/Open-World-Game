using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour
{
    public float cam_speed;
    public Transform Arms, Body;
    public FixedTouchField tf;
    

    private float xrot,yrot;
    public float jump_cam,jump_cam_speed;

    
    
    private void Start(){
     
    }
    void Update()
    {
        
        float x= tf.TouchDist.x*cam_speed*Time.deltaTime;
        float y = tf.TouchDist.y*cam_speed*Time.deltaTime;
        // float jumpcam= jump_cam*Time.deltaTime;

        xrot -=y;
        xrot= Mathf.Clamp(xrot,-90,90);

        Arms.localRotation= Quaternion.Euler(xrot,0,0);
        Body.Rotate(new Vector3(0f,x,0f));
    //     float x= tf.TouchDist.x;
    //     float y = tf.TouchDist.y;
    //    yrot+=x*cam_speed*senctivity.value*Time.deltaTime;
    //    xrot-=y*cam_speed*senctivity.value*Time.deltaTime;

    //    xrot=Mathf.Clamp(xrot,-90f,90f);
    //    Arms.transform.localRotation=Quaternion.Euler(-xrot,0,-wall.tilt);
    //    Body.transform.rotation=Quaternion.Euler(0,yrot,0);
    }


    
}
