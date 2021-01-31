using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 originalPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {

        // ang original position is 45 - (112.8 / 2) = 
        if (transform.position.x < originalPosition.x - repeatWidth)
        {
            transform.position = originalPosition;
        }
    }
}
