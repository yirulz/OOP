using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public float movementSpeed = 10f;

    private Rigidbody2D rigid2D;
    private Renderer[] renderers;


    // Use this for initialization
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandlePosition()
    {
        rigid2D.velocity = Vector3.left * movementSpeed;
    }

    void HandleBoundary()
    {
        Vector3 transformPos = transform.position;
        //Get the viewport position of where the bucket is
        Vector3 viewportPost = Camera.main.WorldToViewportPoint(transformPos);
        if(IsVisible() == false && viewportPost.x < 0)
        {
            Destroy(gameObject);
        }
    }

    bool IsVisible()
    {
        foreach (var renderer in renderers)
        {
            if(renderer.isVisible)
            {
                return true;
            }

        }
        return false;
    }
}
