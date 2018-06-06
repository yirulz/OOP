using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketScoring : MonoBehaviour
{
    public static int score = 0;
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
