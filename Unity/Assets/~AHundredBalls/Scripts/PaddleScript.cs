using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isOpened", true);
        }

        else
        {
            anim.SetBool("isOpened", false);
        }

    }
}
