using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class bikeColor : MonoBehaviour
{
    [SerializeField] bikeBodyModifier bike;
    [SerializeField] RawImage seatIcon;
    [SerializeField] Texture2D[] sprites;
    [SerializeField] Material mat;
    [SerializeField] Color color;
    [SerializeField] Transform handle;
    [SerializeField] RawImage colorWheel;
    // Start is called before the first frame update
    void Start()
    {
        bike = FindObjectOfType<bikeBodyModifier>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(bike.addSeats)seatIcon.texture = sprites[0];
        else seatIcon.texture = sprites[1];

        Color.RGBToHSV(color, out float hue, out float sat, out float vib);
        if (handle.rotation.z >= 0)hue = handle.rotation.z;
        else hue = -handle.rotation.z;
        color = Color.HSVToRGB(hue, sat, vib);

        mat.color = color;
        colorWheel.color = color;
        
    }

    public void OnDrag()
    {
        var dir = Input.mousePosition - handle.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        handle.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
}
