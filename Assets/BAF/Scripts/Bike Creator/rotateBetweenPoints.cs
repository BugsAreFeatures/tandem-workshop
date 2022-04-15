using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class rotateBetweenPoints : MonoBehaviour
{
    [SerializeField] public Transform startPos;
    [SerializeField] public Transform endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = endPos.position - startPos.position;
        var mid = (dir) / 2.0f + startPos.position;
        transform.position = mid;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        //transform.localScale.y = dir.magnitude * factor;
    }
}
