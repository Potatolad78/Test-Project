using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LookatFollow : MonoBehaviour
{
    public Transform mTarget;
    float mSpeed = 3.0f;
    const float EPSILON= 4.0f;
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
            health = health - 0.001f;
            GetComponent<AudioSource>().Pause();
            anim.SetBool("isMoving", false);
            Debug.Log(health);
        }
    }
}
