using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //private
    private float topBound = 40;
    private float lowerBound = -10;

    //public

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
