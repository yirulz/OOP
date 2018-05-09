using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Breakout
{
    public class Paddle : MonoBehaviour
    {

        public float movementSpeed = 20f;
        public Ball currentBall;
        //Direction array defaults to two values
        public GameObject bricks;
        public Text alertText;
        public int childCount;


        public Vector2[] directions = new Vector2[]
        {
            new Vector2 (-0.5f, 0.5f),
            new Vector2 (0.5f, 0.5f)
        };

        void Start()
        {
            //Grabs currentBall from children of paddle
            currentBall = GetComponentInChildren<Ball>();
        }

        void Fire()
        {
            //Detach as child
            currentBall.transform.SetParent(null);
            //Generate random dir from list of direction
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            //Fire off ball in random Direction
            currentBall.Fire(randomDir);
        }

        void CheckInput()
        {

            if (Input.GetKeyDown(KeyCode.Space) && currentBall.transform.parent != null)
            {
                Fire();
            }

        }

        void Movement()
        {
            //Get input on horizontal axis
            float inputH = Input.GetAxis("Horizontal");
            //Set force to direction (inputH to decide which direction)
            Vector3 force = transform.right * inputH;
            //Apply movement speed to force
            force *= movementSpeed;
            //apply delta time to force
            force *= Time.deltaTime;
            //Add force to position
            transform.position -= force;
        }

        void Update()
        {
            CheckInput();
            Movement();

            childCount = bricks.transform.childCount;

            if (childCount <= 0)
            {
                StartCoroutine(ClearLevel());
            }
        }

        IEnumerator ClearLevel()
        {
            alertText.text = "You Win!";
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Level2");
        }
    }
}