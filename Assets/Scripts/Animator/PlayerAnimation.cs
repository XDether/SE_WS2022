using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamOne
{
    public class PlayerAnimation : MonoBehaviour
    {

        private Animator anim;
        private Rigidbody2D rb2D;
        private SpriteRenderer sr;

        void Start()
        {
            anim = this.GetComponent<Animator>();
            rb2D = this.GetComponent<Rigidbody2D>();
            sr = this.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position , Vector2.down);

            if(rb2D.velocity.x<0)
            {
                anim.SetFloat("VelocityX", -rb2D.velocity.x);
            }else
            {
                anim.SetFloat("VelocityX", rb2D.velocity.x);
            }

            anim.SetFloat("VelocityY", rb2D.velocity.y);
            anim.SetBool("onGround", hit.distance < 2 && hit.collider != null);

            if(rb2D.velocity.x > 0.1f)
            {
                sr.flipX = false;
            }
            else if(rb2D.velocity.x < -0.1f)
            {
                sr.flipX = true;
            }
        }
    }
}
