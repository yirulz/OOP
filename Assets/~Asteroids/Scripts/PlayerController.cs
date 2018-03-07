using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Asteroids
{
    public class PlayerController : MonoBehaviour

    {
        public Moving movement;


        // Update is called once per frame
        void Update()
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
            
        }
    }
}