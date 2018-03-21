using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{

    public class AsteroidsSpawner : MonoBehaviour
    {
        public GameObject[] asteroidPrefab;
        public float spawnRate = 1.0f;
        public float spawnRadius = 5.0f;
        public float asteroidSpeed = 10.0f;

        private Rigidbody2D rigid;


        void Spawn()
        {
            //Random a position
            Vector3 rand = Random.insideUnitSphere * spawnRadius;

            //Disable z axis when spawning
            rand.z = 0f;

            //Generate a position with rand
            Vector3 position = transform.position + rand;

            //Generate a random index into prefab array
            int randIndex = Random.Range(0, asteroidPrefab.Length);

            //Get random asteroids
            GameObject randAsteroid = asteroidPrefab[randIndex];

            //Clone random asteroids
            GameObject clone = Instantiate(randAsteroid);

            //Set clone position
            clone.transform.position = position;

        }

        void Start()
        {
            //Calls a function a certain amount of times
            InvokeRepeating("Spawn", 0, spawnRate);
            rigid = GetComponent<Rigidbody2D>();
        }

         void Update()
        {
            
        }


        
    }
}