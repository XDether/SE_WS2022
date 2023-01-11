using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Abstract class for the command pattern
    /// </summary>
    public abstract class Command
    {
        public float speed = 10, jumpForce = 30f;
        public abstract void Execute(Rigidbody2D rigidbody2D);
    }

