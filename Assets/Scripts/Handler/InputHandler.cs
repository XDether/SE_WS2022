using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handler for user inputs
/// /// </summary>
public class InputHandler : MonoBehaviour
{
    public GameObject player;
    private Command buttonA, buttonD, buttonSpace, buttonStopAD;
    private bool canMove, isPlaySound;
    void Start()
    {
        canMove = true;
        isPlaySound = true;
        buttonStopAD = new Stop();
        buttonA = new MoveLeft();
        buttonD = new MoveRight();
        buttonSpace = new Jump();
    }

    /// <summary>
    /// Code to handle input
    /// </summary>
    public void HandleInput()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                buttonA.Execute(player.GetComponent<Rigidbody2D>());
            }
            else if (Input.GetKey(KeyCode.D))
            {
                buttonD.Execute(player.GetComponent<Rigidbody2D>());
            }
            else
            {
                buttonStopAD.Execute(player.GetComponent<Rigidbody2D>());
            }

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down);

            if (Input.GetKey(KeyCode.Space) && hit.distance < 1.2 && hit.collider != null)
            {

                buttonSpace.Execute(player.GetComponent<Rigidbody2D>());

                if (isPlaySound)
                {
                    GameObject.Find("AudioController").GetComponent<AudioController>().Play("Jump");
                    isPlaySound = false;
                    StartCoroutine(WaitForSound());
                }
            }
        }
        else
        {
            buttonStopAD.Execute(player.GetComponent<Rigidbody2D>());
        }

    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(0.2f);
        isPlaySound = true;
    }

    /// <summary>
    /// Sets the speed of the player
    /// </summary>
    /// <param name="speed">Integer</param>
    public void setSpeed(float speed)
    {
        buttonD.speed = speed;
        buttonA.speed = speed;
    }

    /// <summary>
    ///  Sets if the player cann move
    /// </summary>
    /// <param name="canMove"></param>
    public void setCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
