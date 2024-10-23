using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform fledObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(fledObj.position.x, fledObj.position.y - 3, fledObj.position.z);
    }
}
