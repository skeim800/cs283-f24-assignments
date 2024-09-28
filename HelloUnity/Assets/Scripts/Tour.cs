// Tour of scene using points of interest and Lerp 
// September 27, 2024
// Sarah Keim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour : MonoBehaviour
{
    public float speed;
    public List<Transform> pointsOfInterest;
    private int index = 0;
    private int pointsOfInterestIdx;
    private bool inTransition = false;
    private float transitionDuration;
    private float transitionTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && !inTransition)
        {
            pointsOfInterestIdx = index;
            transitionDuration = Vector3.Distance(Camera.main.transform.position, pointsOfInterest[pointsOfInterestIdx].position) / speed;
            transitionTime = 0f;
            index += 1;
            if (index >= pointsOfInterest.Count)
            {
                index = 0;
            }
            inTransition = true;
        }
        if (inTransition)
        {
            transitionTime += Time.deltaTime;
            float u = Mathf.Clamp(transitionTime / transitionDuration, 0, 1);
            transform.position = Vector3.Lerp(Camera.main.transform.position, pointsOfInterest[pointsOfInterestIdx].position, u);
            transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, pointsOfInterest[pointsOfInterestIdx].rotation, u);
            if (u >= 1f || (Camera.main.transform.position == pointsOfInterest[pointsOfInterestIdx].position && Camera.main.transform.rotation == pointsOfInterest[pointsOfInterestIdx].rotation))
            {
                inTransition = false;
            }
            Debug.Log(u);
        }
        
    }
}
