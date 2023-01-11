using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// move left command
    /// </summary>
    public class MoveLeft : Command
    {
        public override void Execute(Rigidbody2D rigidbody2D)
        {
            rigidbody2D.velocity = new Vector2(-1 * speed , rigidbody2D.velocity.y);
        }
    }