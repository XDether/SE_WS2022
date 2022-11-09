using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{



    [SerializeField] private Transform target; 
    [SerializeField] private float speed, increment, incrementSpeedInSeconds;
    
    private float startTime, passtTime;
    private float camWidth, camHeight; 

    private Rigidbody2D rb2d;



    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        camHeight = camera.orthographicSize * 2;
        camWidth = camera.aspect * camHeight;

        Debug.Log(camHeight + " " + camWidth);

        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
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

        if(target.position.x - this.transform.position.x  < -camWidth/2)
        {
            target.position = new Vector3( camWidth/2 + this.transform.position.x, 0,0);
        }
    }
}
