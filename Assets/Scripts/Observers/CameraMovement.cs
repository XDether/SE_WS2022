using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Observer
{
    private float speed, increment;
    private GameObject gameObject;

    public CameraMovement(float speed, float increment, GameObject gameObject){
        this.speed = speed;
        this.increment = increment;
        this.gameObject = gameObject;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed,0,0);
    }

    public override void  OnNotify(){
        speed = speed + increment;
        Debug.Log("iam");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed,0,0);
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        camHalfHeight = camera.orthographicSize;
        camHalfWidth = camera.aspect * camHalfHeight;

        Debug.Log(camHalfHeight + " " + camHalfWidth);

        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        startTime = Time.time;
    }*/

    // old update
    /*
    void Update()
    {
        //CameraSpeed
        if(passtTime >= incrementSpeedInSeconds)
        {

            startTime = Time.time;
            passtTime = 0;
        }else
        {
            passtTime =  Time.time - startTime; 

        }
    }*/

    //old fixed update
    /*void FixedUpdate()
    {
        //Left
        if(target.position.x - this.transform.position.x  < -camHalfWidth - 3)
        {
            target.position = new Vector3( camHalfWidth/2 + this.transform.position.x, 0,0);
            //Time.timeScale = 0;
        }

        //Right
        if(target.position.x - this.transform.position.x  > camHalfWidth - 1)
        {
            this.transform.position = new Vector3(target.position.x - (camHalfWidth - 1),this.transform.position.y,this.transform.position.z);
        }

        //Calculation for y postion
        Vector3 newPos = new Vector3(this.transform.position.x, target.position.y, this.transform.position.z);
        transform.position = new Vector3(this.transform.position.x, Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime).y,this.transform.position.z);
    }*/
}