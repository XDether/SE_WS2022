using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// stop command
/// </summary>
public class Stop : Command
{
    public override void Execute(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
    }
}
