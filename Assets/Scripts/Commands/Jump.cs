using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Jump : Command
    {
        public override void Execute(Rigidbody2D rigidbody2D)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce * 1);
        }
    }

