using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        public Text scoreText;
        private int score;



        // Use this for initialization
        void Start()
        {
            if(Instance == null)
            {
                //Set instance to this game mananger
                Instance = this;
            }
            else
            {
                //Destroy the new instance of GameManager
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + score.ToString();
        }

        public void AddScore( int scoreToAdd)
        {
            score += scoreToAdd;
        }
    }
}