using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    Vector3 currentPosition;
    Vector3 nextPosition;
    Quaternion posture;

    
	// Use this for initialization
	void Start () {
		
	}
    public Transform target;
    public float speed;
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
//currentPosition = transform.position;
      //  posture = transform.rotation;
        //nextPosition = transform.position + target.position * speed * time;
        //transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);
    }
}
