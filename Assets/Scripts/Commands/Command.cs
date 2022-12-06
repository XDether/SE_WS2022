using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Command
    {
        public float speed = 1, jumpForce = 30f;
        public abstract void Execute(Rigidbody2D rigidbody2D);

    }

