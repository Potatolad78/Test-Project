using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatFollow : MonoBehaviour
{
    public Transform mTarget;
    float mSpeed = 3.0f;
    const float EPSILON= 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mTarget.position);
        if((transform.position - mTarget.position).magnitude > EPSILON)
        {    transform.Translate(0.0f, 0.0f, mSpeed*Time.deltaTime);
            GetComponent<AudioSource>().Play();
        }
    }
}
