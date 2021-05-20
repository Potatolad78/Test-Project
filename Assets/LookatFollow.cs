using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LookatFollow : MonoBehaviour
{
    float timer = 15.0f;
    float jabTimer = 1.0f;
    public Transform mTarget;
    float mSpeed = 3.0f;
    const float EPSILON= 2.0f;
    public Animator anim;
    float health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = true;
        anim = GetComponent <Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if(((transform.position - mTarget.position).magnitude < EPSILON ))
        {
        anim.SetBool("jabbingDistance", true);    
        if (timer < 0 )
            {
            anim.SetBool("isJabbing", true);
            jabTimer -= Time.deltaTime; 
            if (jabTimer < 0)
                {
                    if((transform.position - mTarget.position).magnitude < EPSILON )
                    {
                        health = health - 5.0f;
                    }
                    timer = 15.0f;
                    anim.SetBool("isJabbing", false);
                    anim.SetBool("jabbingDistance", false);
                }
            }
            if(jabTimer <= 0 && timer > 0)
            {
                jabTimer = 1.0f;
            }
        }
        transform.LookAt(mTarget.position);
        if((transform.position - mTarget.position).magnitude > EPSILON)
        {   
            transform.Translate(0.0f, 0.0f, mSpeed*Time.deltaTime);
            GetComponent<AudioSource>().UnPause();
            //GetComponent<Animator>().Stop(); 
            anim.SetBool("isMoving", true);
        }
        else
        {
            GetComponent<AudioSource>().Pause();
            anim.SetBool("isMoving", false);
        }
    }
}
