using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeHandle;

public class mouseMover : MonoBehaviour
{
    
    [SerializeField] HandleAxes axes = HandleAxes.XYZ;
    [SerializeField] HandleSpace space = HandleSpace.LOCAL;
    [SerializeField] Vector3 scale;
    RuntimeTransformHandle runtimeHandle;

    [SerializeField] public Transform transformHandle;
    [SerializeField] Vector3 handlePosition;
    [SerializeField] Quaternion handleRotation;
    // Start is called before the first frame update
    void Start()
    {
        runtimeHandle = FindObjectOfType<RuntimeTransformHandle>();
        //transformHandle.transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(runtimeHandle.target == transform)
        {
            var PositionHandles = FindObjectsOfType<PositionAxis>();
            foreach(PositionAxis PosHand in PositionHandles)
            {
                PosHand.transform.localScale = scale;
                PosHand.transform.localPosition = handlePosition;
                ChangeTransformHandles(PosHand);
            }

        }
    }

    void ChangeTransformHandles(PositionAxis Hand)
    {
        foreach (Transform child in Hand.transform)
        {
            if (child != Hand.transform)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
                child.rotation = handleRotation;
                transformHandle.position = child.position;
                transformHandle.rotation = handleRotation;
                transformHandle.gameObject.SetActive(true);
            }
        }
    }

    void OnMouseDown()
    {

        transformHandle.transform.localScale = scale;
        runtimeHandle.axes = axes;
        runtimeHandle.space = space;
        runtimeHandle.target = transform;
        runtimeHandle.transform.localScale = new Vector3(1,1,1);
    }
}
