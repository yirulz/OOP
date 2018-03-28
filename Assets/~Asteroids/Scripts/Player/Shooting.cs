using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 2.0f;


        public Transform[] spawnPoints;

        //Spawns a new bullet and fires in 'direction' when called
        public void Fire(Vector3 direction)
        {
            //Loop through spawn points

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                //Spawn a bullet for each
                Spawn(direction, spawnPoints[i].position);
            }



        }


        void Spawn(Vector3 direction, Vector3 point)
        {
            // Make an instance of bullet prefab
            GameObject clone = Instantiate(bulletPrefab);

            // Set position of clone to spawn point
            clone.transform.position = point;

            // Get rigidbody from bullet clone
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();

            // Add force in the direction
            rigid.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

            // Rotate bullets 
            float angle = Mathf.Atan2(direction.y, direction.x);
            float deg = angle * Mathf.Rad2Deg;

            rigid.rotation = deg;
        }


    }
}