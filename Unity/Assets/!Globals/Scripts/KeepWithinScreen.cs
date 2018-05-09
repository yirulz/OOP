using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach a Renderer to object script is attached to
[RequireComponent(typeof(Renderer))]

public class KeepWithinScreen : MonoBehaviour
{
    private Renderer rend; //Renderer attached to the object
    private Camera cam; //Camera contrainer
    private Bounds camBounds;//camera bounds structure
    private float camWidth, camHeight;


    void Start()
    {
        //Set camera variable to main camera
        cam = Camera.main;
        //Get the renderer component attached to this object
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //Update camera bounds
        UpdateCamBounds();
        //Set the position after checking the bounds
        transform.position = CheckBounds();

    }

    //Updates the camBounds variable with camera value
    void UpdateCamBounds()
    {
        //Calculate camera bounds
        camHeight = 2f * cam.orthographicSize; // height = 2x orthographic size
        camWidth = camHeight * cam.aspect; //width  = height * aspect
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }

    Vector3 CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * 0.5f;
        float halfHeight = size.y * 0.5f;
        float halfCamWidth = camWidth * 0.5f;
        float halfCamHeight = camHeight * 0.5f;
        //Check left
        if(pos.x - halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.min.x + halfWidth;
        }

        //Check Right
        if(pos.x + halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.max.x - halfWidth;
        }

        //Check down
        if(pos.y - halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.min.y + halfHeight;
        }

        //Check up
        if(pos.y + halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.min.y - halfHeight;
        }

        return pos; //Returns adjusted position
    }

  
}
