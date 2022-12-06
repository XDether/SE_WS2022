using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InputHandler : MonoBehaviour
    {
        public GameObject player;
        private Command buttonA, buttonD, buttonSpace, buttonStopAD;

        void Start()
        {
            buttonStopAD = new Stop();
            buttonA = new MoveLeft();
            buttonD = new MoveRight();
            buttonSpace = new Jump();
        }

        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if(Input.GetKey(KeyCode.A))
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

            
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position + new Vector3(-0.6f,0,0) , Vector2.down);
            
            if(Input.GetKey(KeyCode.Space) && hit.distance < 1 && hit.collider != null)
            {
                buttonSpace.Execute(player.GetComponent<Rigidbody2D>());
            }
        }
    }
