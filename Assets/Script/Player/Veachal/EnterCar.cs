using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterCar : MonoBehaviour
{
    [Header ("Car Side")]
    public GameObject CarCamHolder;
    GameObject car;
    

    [Header ("Player side")]
    public GameObject playerCamHolder;
    private GameObject Player;
    GameObject body;
    MeshRenderer mesh;

    public Button car_In;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Player_Body");
        car.gameObject.SetActive(false);
        Player=this.gameObject;
        mesh=Player.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter(Collider other){
        print("1");
        if(other.gameObject.tag=="CarDoor"){
            print("2");
            car= other.gameObject;
        car_In.gameObject.SetActive(true);
        }


    }
    public void parentHolder()
    {
        // player shift
            mesh.enabled=false;
            Player.transform.position=car.transform.position;
            body.SetActive(false);
            // Player.transform.SetParent(null);
        // camera shift
        cam.transform.SetParent(CarCamHolder.transform);
            cam.transform.position=CarCamHolder.transform.position;
    }
}
