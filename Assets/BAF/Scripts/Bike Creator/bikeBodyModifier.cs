using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeHandle;

public class bikeBodyModifier : MonoBehaviour
{
    [SerializeField] public bool addSeats;
    [SerializeField] public Vector2 range;
    [SerializeField] float dist;
    [SerializeField] GameObject seatPrefab;
    [SerializeField] List<GameObject> bikeSeats;
    [SerializeField] GameObject originSeat;
    [SerializeField] GameObject lastSeat;
    [SerializeField] Transform backWheel;
    [SerializeField] scaleToPivots[] backPoles;

    [SerializeField] GameObject seatPolePrefab;
    [SerializeField] List<GameObject> seatPoles;
    [SerializeField] GameObject originPole;
    [SerializeField] scaleToPivots lastPole;
    [SerializeField] Transform poleParent;
    [SerializeField] Transform handle;

    // Start is called before the first frame update
    void Start()
    {
        
        var runtimeHandle = FindObjectOfType<RuntimeTransformHandle>();
        runtimeHandle.transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
            dist = (backWheel.position.z - lastSeat.transform.position.z);
            if (dist > range.x && addSeats)
            {
                var midPoint = lastSeat.transform.position;
                midPoint.z = lastSeat.transform.position.z + (range.x/2);
                midPoint.y = originSeat.transform.position.y;
                midPoint.x = originSeat.transform.position.x;
                var seat = Instantiate(seatPrefab, midPoint, originSeat.transform.rotation, originSeat.transform);
                

                seat.transform.localScale = new Vector3(1,1,1);
                bikeSeats.Add(seat);

                lastSeat = bikeSeats[bikeSeats.Count-1];

                var pole = Instantiate(seatPolePrefab, seat.transform.position, Quaternion.identity, originPole.transform);
                pole.transform.localScale = new Vector3(1,1,1);
                seatPoles.Add(pole);
                lastPole = seatPoles[seatPoles.Count-1].GetComponent<scaleToPivots>();

                //set bike clingy things parents
                UpdatePivots();
            }
            if (dist < range.y && lastSeat != originSeat)
            {
                bikeSeats.Remove(lastSeat);
                Destroy(lastSeat);
                lastSeat = bikeSeats[bikeSeats.Count-1];

                seatPoles.Remove(lastPole.gameObject);
                Destroy(lastPole.gameObject);
                lastPole = seatPoles[seatPoles.Count-1].GetComponent<scaleToPivots>();

                UpdatePivots();
            }



            if(bikeSeats == null)lastSeat = originSeat;
            else lastSeat = bikeSeats[bikeSeats.Count-1];
        
        
    }

    void UpdatePivots()
    {
        backPoles[0].startPos = lastSeat.transform.Find("TopPivot");
        backPoles[1].startPos = lastSeat.transform.Find("TopPivot");
        backPoles[2].startPos = lastSeat.transform.Find("BottomPivot");
        backPoles[3].startPos = lastSeat.transform.Find("BottomPivot");
        backPoles[4].startPos = lastSeat.transform.Find("TopPivot");
        backPoles[5].startPos = lastSeat.transform.Find("BottomPivot");

        lastPole.endPos = lastSeat.transform.Find("Capsule");
        lastPole.startPos = lastSeat.transform.Find("TopPivot");
        lastSeat.transform.Find("Capsule").GetComponent<mouseMover>().transformHandle = handle;
    }

    public void switchSeats()
    {
        addSeats = !addSeats;
    }
}
