using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customTransformHandle : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] moveableObject target;
    [SerializeField] LayerMask layerMask;
    [SerializeField] public enum Axes {X, Y, Z}
    [SerializeField] public Axes Axis;

    GameObject tempTargetParent;
    
    bool canParent;
    bool isDragging;

    //Target Variables To Be Accessed Once Per Start Move
    Transform targetOriginParent;
    Vector3 targetOriginPos;

    
    void Start()
    {
        cam = Camera.main.transform;
        tempTargetParent = new GameObject();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartDrag();
        if(Input.GetMouseButtonUp(0)) EndDrag();

        if(Input.GetMouseButton(0)) Drag();
    }

    void StartDrag()
    {
        var mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouse, out RaycastHit hitData, Mathf.Infinity, layerMask))
        {
            if(hitData.transform.gameObject.tag == "Handle")
            {
                isDragging = true;
                targetOriginParent = target.transform.parent; //Get targets parent before modifying it
                targetOriginPos = target.transform.position;
            }
            else if (hitData.transform.gameObject.tag == "Drageable")
            {
                isDragging = false;
                targetOriginParent = target.transform.parent; //Get targets parent before modifying it
                targetOriginPos = target.transform.position;
            }
            else 
            {
                RemoveTarget();
            }
        }
    }

    void EndDrag()
    {
        if(target != null)target.transform.SetParent(targetOriginParent); //Reset targets parent after modifying it
        
        canParent = true;
        isDragging = false;
    }

    void Drag()
    {
        var mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouse, out RaycastHit hitData, Mathf.Infinity, layerMask))
        {
            if(isDragging)
            {
                var pos = hitData.point;

                if(Axis != Axes.X) pos.x = targetOriginPos.x;
                if(Axis != Axes.Y) pos.y = targetOriginPos.y;
                if(Axis != Axes.Z) pos.z = targetOriginPos.z;

                if(canParent)tempTargetParent.transform.position = pos; //Set pos once so the offset is correct
                canParent = false; //disable setting the pos for offset correction

                target.transform.SetParent(tempTargetParent.transform);//Parents the target to the modifiable transform (after the transform has already been set to the correct position)
                tempTargetParent.transform.position = pos; // Sets transform position each frame
            }
            
        }
        
    }

    public void SwitchTarget(moveableObject newTarget)
    {
        if(target != null)target.handle.gameObject.SetActive(false);

        target = newTarget;
       
        target.handle.gameObject.SetActive(true);
    }

    public void RemoveTarget()
    {
        if(target != null)target.transform.SetParent(targetOriginParent); //Reset targets parent after modifying it
        if(target != null)target.handle.gameObject.SetActive(false);

        target = null;
    }
}
