using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Asteroids
{
    public class PlayerController : MonoBehaviour

    {
        public Moving movement;
        public Shooting shoot;
        public float shootRate = 0.2f; // Rate of fire
        public float shootTimer = 0.0f; // Timer before you can shoot again

        #region Unity Function

        // Update is called once per frame
        void Update()
        {
            shootTimer += Time.deltaTime;

            Shoot();
            Movement();

        }


        #endregion

        #region Custom Functions
        void Shoot()
        {
            if (shootTimer >= shootRate)
            {
                // Check if space is pressed
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Fire!
                    shoot.Fire(transform.up);
                    shootTimer = 0f;
                }
            }

        }
        void Movement()
        {
            float inputV = Input.GetAxis("Vertical");
            float inputH = Input.GetAxis("Horizontal");
            // -1 == A || LeftArrow
            // 0 == Not being pressed
            // 1 == D || RightArrow
            if (inputV > 0)
            {
                movement.Accelerate(transform.up);
            }
            if (inputH < 0)
            {
                movement.RotateLeft();
            }
            if (inputH > 0)
            {
                movement.RotateRight();
            }
            #endregion

        }
    }
}