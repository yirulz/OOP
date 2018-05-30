using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketScoring : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void Start()
    {
        scoreText.text = "";
    }

    void Update()
    {
        scoreText.text = "Your score is " + score;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        score++;
    }
   
}
