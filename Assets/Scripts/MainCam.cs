using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followedThing;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = followedThing.position - followedThing.forward * 5;
        transform.rotation = UnityEngine.Quaternion.LookRotation(followedThing.position - transform.position);
    }
}
