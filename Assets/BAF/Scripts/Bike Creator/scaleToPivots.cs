using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class scaleToPivots : MonoBehaviour
{
    [SerializeField] public Transform startPos;
    [SerializeField] public Transform endPos;
    [SerializeField] Vector3 initialScale;
    // Start is called before the first frame update
    void Start()
    {
        //initialScale = transform.localScale;
        UpdateTransformScale();
    }

    // Update is called once per frame
    void Update()
    {
        if(startPos.hasChanged || endPos.hasChanged) UpdateTransformScale();
    }

    void UpdateTransformScale()
    {
        float dist = Vector3.Distance(startPos.position, endPos.position);
        transform.localScale = new Vector3(initialScale.x, dist / initialScale.y, initialScale.z);

        Vector3 midPoint = (startPos.position + endPos.position)/2;
        transform.position = midPoint;

        Vector3 rotationDirection = (endPos.position - startPos.position);
        transform.up = rotationDirection;    
    }
}
