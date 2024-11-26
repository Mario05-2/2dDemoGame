using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    //Starting postion of the parallax game object
    UnityEngine.Vector2 startingPosition;

    //Start Z vaule of the parallax game object
    float startingZ;
    
    //Distance that the camera has moved from the starting position of the parallax object
    UnityEngine.Vector2 camMoveSinceStart => (UnityEngine.Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    //The further the object is from the target the more it will move
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        transform.position = new UnityEngine.Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
