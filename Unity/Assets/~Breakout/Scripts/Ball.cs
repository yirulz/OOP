using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        //Ball speed
        public float speed = 50f;
        //Velocity of ball
        private Vector3 velocity;
        public int score = 0;
        public Text scoreText;
       


        //Fires off ball in direction
        public void Fire(Vector3 direction)
        {
            //calculate velocity
            velocity = direction * speed;
        }

        //Detect collision
        void OnCollisionEnter2D(Collision2D other)
        {
            //Get contact points
            ContactPoint2D contact = other.contacts[0];
            //Calculate reflection point of the ball using velocity & contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            //Calculate new velocity from reflection multiplier by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
            if (other.gameObject.tag == "Brick")
            {
                Destroy(other.gameObject);
                score++;
                scoreText.text = "Score: " + score;
            }
            if (other.gameObject.tag == "Brick2")
            {
                Destroy(other.gameObject);
                score += 5;
                scoreText.text = "Score: " + score;
            }
        }

        private void Start()
        {
            scoreText.text = "";
        }


        void Update()
        {
            //Moves ball using velocity & deltaTime
            transform.position += velocity * Time.deltaTime;
            
        }


    }
}