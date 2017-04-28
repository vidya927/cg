using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {
    public GameObject fish;
    public GameObject food;
    public GameObject danger;
    int tanksize = 50;
    int i = 0;
    bool turn = false;
    float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // i++;
        float step = 1 * Time.deltaTime;
        float nextpositionx = Random.Range(1, 5);
        float nextpositionz = Random.Range(1, 5);
        Vector3 pos = new Vector3();
        pos.Set(0, 0, nextpositionz);
        fish.transform.position = Vector3.MoveTowards(fish.transform.position, fish.transform.position + pos, step);

      /*  if (Vector3.Distance(fish.transform.position, Vector3.zero) >= tanksize)
        {
            turn = true;
        }
        else
        {
            turn = false;
        }
        if (turn)
        {
            Vector3 direction = Vector3.zero - fish.transform.position;
            fish.transform.rotation = Quaternion.Slerp(fish.transform.rotation, Quaternion.LookRotation(direction), 4 * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }
        fish.transform.position = Vector3.MoveTowards(fish.transform.position, -fish.transform.position + pos, step);

        fish.transform.Translate(0, 0, Time.deltaTime * speed);
    
    // fish.transform.position = fish.transform.position + new Vector3(fish.transform.position.x, fish.transform.position.y , fish.transform.position.z);
    //  Vector3 pos = fish.transform.position + new Vector3(fish.transform.position.x, fish.transform.position.y + 10, fish.transform.position.z);
    // Vector3 pos = new Vector3(Random.Range(-tanksize, tanksize), Random.Range(-tanksize, tanksize), Random.Range(-tanksize, tanksize));
    /*    if (i == 5)
        {
            int j = Random.Range(0, 1);
            if (j == 0)
            {
                Instantiate(food, pos, Quaternion.identity);
                
            }else
            {
                Instantiate(danger, pos, Quaternion.identity);
                turn = true;
            }
            
            i = 0;
        }
        if (turn)
        {
            Vector3 direction = Vector3.zero - fish.transform.position;
            fish.transform.rotation = Quaternion.Slerp(fish.transform.rotation, Quaternion.LookRotation(direction), 4 * Time.deltaTime);
            float speed = Random.Range(0.5f, 1);
            transform.Translate(0, 0, Time.deltaTime * speed);
        }*/
}
}
