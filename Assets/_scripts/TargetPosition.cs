using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        float nextpositionx = Random.Range(1,5);
        float nextpositionz = Random.Range(1,5);
        Vector3 pos = new Vector3();
        pos.Set(nextpositionx,1, nextpositionz);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + pos , step);
    }
}
