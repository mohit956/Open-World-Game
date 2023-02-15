using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_movement : MonoBehaviour
{

    public float rotate_speed;
    public Animator anim;
    private float xvertex;
    private float yvertex;
    public float speed;
    public float jump_speed;
    private bool grounded;
    public Rigidbody rb;
    public joystick js;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // anim.SetInteger("Movement",0);
        xvertex = js.inputHorizontal();
        yvertex = js.inputVertical();
        print(yvertex);
        animations();
        if(Input.GetKeyDown(KeyCode.Space)){
            jump();
        }
    }
    void FixedUpdate()
    {
        transform.Translate(xvertex*speed*Time.fixedDeltaTime,0f,yvertex*speed*Time.fixedDeltaTime);
        // transform.Rotate(Vector3.up*rotate_speed*xvertex*Time.fixedDeltaTime);
    }
    
    public void jump(){
        rb.AddForce(new Vector3(0f,jump_speed,0f));
        rb.velocity = new Vector3(rb.velocity.x,jump_speed,rb.velocity.z);
        this.transform.Translate(0f,jump_speed,0f);
    }
    void animations(){
        if(yvertex<.04f && yvertex>-.05f){
            anim.SetInteger("Motion",0);}
        else if(yvertex<.3f && yvertex>.04f)anim.SetInteger("Motion",1);
        else if(yvertex<.1f)anim.SetInteger("Motion",-1);
        else if(yvertex>.3f) anim.SetInteger("Motion",2);
    }
}
