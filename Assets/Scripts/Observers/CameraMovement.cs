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

    public void yFollow(Transform target){
        this.gameObject.transform.position = new Vector3(   this.gameObject.transform.position.x,
                                                            Vector3.Lerp(gameObject.transform.position ,target.position + new Vector3(0,0.5f,0), Time.deltaTime * 15).y,
                                                            this.gameObject.transform.position.z);
    }

    public void Stop(){
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,this.gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
    }
    public override void  OnNotify(){
        if(GameController.GetGameState() == GameState.OnGoing)
        {
            speed = speed + increment;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed,this.gameObject.GetComponent<Rigidbody2D>().velocity.y,0);
        }else
        {
            Stop();
        }
    }
}