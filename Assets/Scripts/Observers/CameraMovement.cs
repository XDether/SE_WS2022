using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the Camera Movment
/// </summary>
public class CameraMovement : Observer
{
    private float speed, increment;
    private GameObject gameObject;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="speed">Start Speed of the camera</param>
    /// <param name="increment">Speed Increment for the camera</param>
    /// <param name="gameObject">Targeted Object to follow</param>
    public CameraMovement(float speed, float increment, GameObject gameObject)
    {
        this.speed = speed;
        this.increment = increment;
        this.gameObject = gameObject;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
    }

    /// <summary>
    /// Handles the y position of the camera 
    /// </summary>
    /// <param name="target">Target to follow</param>
    public void yFollow(Transform target)
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                                                            Vector3.Lerp(gameObject.transform.position, target.position + new Vector3(0, -0.5f, 0), Time.deltaTime * 15).y,
                                                            this.gameObject.transform.position.z);
    }

    /// <summary>
    /// Stops the camera
    /// </summary>
    private void Stop()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, this.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
    }

    /// <summary>
    /// Checks for a notification if notification update position of the camera
    /// </summary>
    public override void OnNotify()
    {
        if (GameController.GetGameState() == GameState.OnGoing)
        {
            speed = speed + increment;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
        }
        else
        {
            Stop();
        }
    }
}