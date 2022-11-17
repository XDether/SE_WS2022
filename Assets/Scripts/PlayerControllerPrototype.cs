using System;
using UnityEngine;

namespace TeamOne
{
    public class PlayerControllerPrototype : MonoBehaviour
    {
        [Header("General")]
        [Tooltip("Please drag the player's RigidBody2D here.")]
        [SerializeField] private new Rigidbody2D rigidbody2D;
        
        [Header("Forces")]
        [Tooltip("Determines how fast the player can run.")]
        [SerializeField] private float movementForce = 24;
        [Tooltip("Determines how high the player can jump.")]
        [SerializeField] private float jumpForce = 34;

        [Header("Ground Check")]
        [Tooltip("Please drag the childed GroundCheck (GameObject) of the Player here.")]
        [SerializeField] private Transform groundCheck;
        [Tooltip("Please select a LayerMask. Select the same layer that the platforms have.")]
        [SerializeField] private LayerMask groundLayer;
        [Tooltip("Set the size of the collider here.")]
        [SerializeField] private Vector2 groundCheckColliderSize = new Vector2(0.4f, 0.04f);
        [Tooltip("Set the alignment (Vertical / Horizontal) of the collider here.")]
        [SerializeField] private CapsuleDirection2D capsuleDirection;
        [Tooltip("Set the angle of the collider here.")]
        [SerializeField] private float capsuleAngle;
        
        private bool _isFacingRight = true;
        private float _direction;
        private bool _jump;

        private void Update()
        {
            // Press A or leftArrow = [0, -1]. Press D or rightArrow = [0, 1]. No button is pressed = 0.
            _direction = Input.GetAxis("Horizontal");
            
            // When the player is running to the right but facing to the left flip the sprite immediately.
            if (_direction > 0 && !_isFacingRight) Flip();
            // When the player is running to the left but facing to the right flip the sprite immediately.
            if (_direction < 0 && _isFacingRight) Flip();
            
            // A two-dimensional vector takes two values x and y. That values can be positive or negative. 
            // Negative values on the x-axis mean moving to the left. Positive mean moving to the right.
            // The same for the y-axis. Negative for downwards and positive for upwards.
            rigidbody2D.velocity = new Vector2(_direction * movementForce, rigidbody2D.velocity.y);

            // Everytime the Space-Key is pressed and the player is grounded or stands on a platform set the jump
            // variable to true.
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _jump = true;
            }
            
            // Whenever the _jump variable is set to true inside the Update() method, create a new Vector2 with
            // jumpForce as the y-axis to let the player jump in the air. Set the _jump variable to false to prevent
            // jumping continuously.
            if (_jump)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                _jump = false;
            }
            
            // ToDo -> Vertical Gravity & Fall Speed & Variable Jump Height
            // ToDo -> Coyote Time & Jump Buffering & Double Jump & Dash
        }
        
        /// <summary>
        /// First save the local scale to a temporary (currentScale) variable.
        /// Than multiply with -1 to switch between positive and negative result.
        /// After set the local scale to the temporary created local scale.
        /// At the end turn the players' facing to the opposite value.
        /// </summary>
        private void Flip()
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
            _isFacingRight = !_isFacingRight;
        }

        /// <summary>
        /// IsGrounded()
        /// Creates a CapsuleCollider2D on the groundCheck's position, with a specific size, direction, angle and a
        /// specific ground layer.
        /// </summary>
        /// <returns>
        /// Returns true or false whether the CapsuleCollider2D collides with a GameObject with the specific layer.
        /// </returns>
        private bool IsGrounded()
        {
            return Physics2D.OverlapCapsule(groundCheck.position, groundCheckColliderSize,
                capsuleDirection, capsuleAngle, groundLayer);
        }
    }
}
