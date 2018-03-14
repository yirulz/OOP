using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Asteroids
{
    public class PlayerController : MonoBehaviour

    {
        public Moving movement;
        public Shooting shoot;


        #region Unity Function

        // Update is called once per frame
        void Update()
        {
            Shoot();
            Movement();

        }


        #endregion

        #region Custom Functions
        void Shoot()
        {
            // Check if space is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                   // Fire!
                shoot.Fire(transform.up);
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