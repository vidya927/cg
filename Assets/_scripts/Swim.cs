using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour {

    public float speed = 0.1f;
    float rotationspeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 10.0f;

    bool turn = false;
	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position,Vector3.zero) >= Flock.tanksize)
        {
            turn = true;
        }
        else
        {
            turn = false;
        }
        if (turn)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationspeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }else
        {
            if(Random.Range(0,5) < 1)
                ApplyRules();
        }            
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        GameObject[] g;
        g = Flock.allfish;
        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gspeed = 0.1f;

        Vector3 goalpos = Flock.Targetpos;

        float dist;
        int groupsize = 0;
        foreach (GameObject go in g)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupsize++;
                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + this.transform.position - go.transform.position;
                    }

                    Swim anotherflock = go.GetComponent<Swim>();
                    gspeed = gspeed + anotherflock.speed;
                }
            }
        }
        if (groupsize > 0)
        {
            Vector3 direction;
            Flock.t = Flock.TargetType.Normal;
            switch (Flock.t)
            {
                case Flock.TargetType.Food:
                    vcentre = vcentre / groupsize + (goalpos - this.transform.position);
                    speed = gspeed / groupsize + 5;
                    direction = (vcentre + vavoid) - transform.position;
                    if (direction != Vector3.zero)
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationspeed * Time.deltaTime);
                    break;
                case Flock.TargetType.Danger:

                    vcentre = vcentre / groupsize - (goalpos + this.transform.position);
                    speed = gspeed / groupsize + 2;
                    direction = transform.position-(vcentre + vavoid);
                    if (direction != Vector3.zero)
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationspeed + 3 * Time.deltaTime);

                    break;
                case Flock.TargetType.Normal:
                    vcentre = vcentre / groupsize + (goalpos - this.transform.position);
                    speed = gspeed / groupsize ;
                    direction = (vcentre + vavoid) - transform.position;
                    if (direction != Vector3.zero)
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationspeed * Time.deltaTime);
                    break;
            }
         }
    }
}
