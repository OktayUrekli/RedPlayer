using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{ 
    public float bulletDamage,lifeTime;
    
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    
    void Update()
    {
        
    }
}
