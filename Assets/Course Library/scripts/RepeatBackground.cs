using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    //private
    private Vector3 startPos;
    private float repeadWidth;
    //public


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeadWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeadWidth)
        {
            transform.position = startPos;
        }
    }
}
