using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikePositioner : MonoBehaviour
{
    [SerializeField] Transform anchor;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 midPoint = (startPos.position + endPos.position)/2;
        var offset = anchor.position + (transform.position-midPoint);
        transform.position = offset;
    }
}
