using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_movement : MonoBehaviour
{

    public float rotate_speed;
    private float xvertex;
    private float yvertex;
    public float speed;
    public float jump_speed;
    public Rigidbody rb;
    public joystick js;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xvertex = js.inputHorizontal();
        yvertex = js.inputVertical();
    }
    void FixedUpdate()
    {
        transform.Translate(xvertex*speed*Time.fixedDeltaTime,0f,yvertex*speed*Time.fixedDeltaTime);
        // transform.Rotate(Vector3.up*rotate_speed*xvertex*Time.fixedDeltaTime);
    }
    
    public void jump(){
        // rb.AddForce(new Vector3(0f,jump_speed,0f));
        rb.velocity = new Vector3(rb.velocity.x,jump_speed,rb.velocity.z);
        // this.transform.Translate(0f,jump_speed,0f);
    }
}
