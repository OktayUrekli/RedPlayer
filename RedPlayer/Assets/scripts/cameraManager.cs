using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    //public Transform target;
    //public float camSpeed;
    
    public GameObject target;
    public Vector3 cameraOffset;

    void Start()
    {
        
    }

    
    void Update()
    {
        //transform.position = Vector3.Slerp(transform.position,new Vector3(target.position.x,target.position.y,target.position.z),camSpeed);
     
        // transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    
      transform.position = target.transform.position + cameraOffset;
    
    }
}
