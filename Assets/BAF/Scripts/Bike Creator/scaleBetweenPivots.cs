using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleBetweenPivots : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    Vector3 initialScale;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        UpdateTransformScale();
    }

   void Update()
    {
        if(startPos.hasChanged || endPos.hasChanged) UpdateTransformScale();
    }

    void UpdateTransformScale()
    {
        float dist = Vector3.Distance(startPos.position, endPos.position);
        transform.localScale = new Vector3(initialScale.x, dist + initialScale.y, initialScale.z);

        Vector3 midPoint = (startPos.position + endPos.position)/2;
        transform.position = midPoint; 
    }
}
