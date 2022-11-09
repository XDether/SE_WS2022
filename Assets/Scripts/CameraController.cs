using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float speed, increment, incrementSpeedInSeconds, followSpeed;
    
    private float startTime, passtTime;
    private float camHalfWidth, camHalfHeight; 

    private Rigidbody2D rb2d;



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
    }

    // Update is called once per frame
    void Update()
    {
        //CameraSpeed
        if(passtTime >= incrementSpeedInSeconds)
        {
            speed = speed + increment;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            startTime = Time.time;
            passtTime = 0;
        }else
        {
            passtTime =  Time.time - startTime; 

        }


    }

    void FixedUpdate()
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
    }
}
