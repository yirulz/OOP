using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketRotate : MonoBehaviour
{

    void OnTriggerEnter2D (Collider2D col)
    {

        Debug.Log("Yes");
        transform.Rotate(0, 360 * Time.deltaTime, 0);

    }

}
