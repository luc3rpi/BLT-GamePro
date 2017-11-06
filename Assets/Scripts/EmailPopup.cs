using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EmailPopup : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;
    public bool closed = false;
    public GUIText text; //Maybe make into normal text object

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(StartPosition, EndPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        if (closed) {
            Vector3 tempVec = StartPosition;
            StartPosition = EndPosition;
            EndPosition = tempVec;
            distCovered = 0;
        }
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(StartPosition, EndPosition, fracJourney);
    }
}
