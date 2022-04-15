using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableObject : MonoBehaviour
{
    [SerializeField] public Transform handle;
    [SerializeField] enum Spaces {WORLD, LOCAL}
    [SerializeField] Spaces Space;
    [SerializeField]  enum Axes {X, Y, Z}
    [SerializeField]  Axes Axis;

    customTransformHandle transformHandle;
    // Start is called before the first frame update
    void Start()
    {
        transformHandle = FindObjectOfType<customTransformHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        transformHandle.SwitchTarget(this);
        
        if(Axis == Axes.X) transformHandle.Axis = customTransformHandle.Axes.X;
        else if(Axis == Axes.Y) transformHandle.Axis = customTransformHandle.Axes.Y;
        else if(Axis == Axes.Z) transformHandle.Axis = customTransformHandle.Axes.Z;
    }
}
