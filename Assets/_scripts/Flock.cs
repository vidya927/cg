using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flock : MonoBehaviour {

    public GameObject goalprefab;
    public GameObject fishPrefab;
    static int numfish = 10;
    public static int tanksize = 20;
    public static GameObject[] allfish = new GameObject[numfish];
    public static Vector3 Targetpos = Vector3.zero;
    public enum TargetType { Food, Danger, Normal } ;
    public static TargetType t;
    public enum positions { p1,p2,p3,p4};
    // Use this for initialization
    void Start () {
		for (int i=0; i<numfish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tanksize, tanksize),Random.Range(-tanksize, tanksize),Random.Range(-tanksize, tanksize));
            allfish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0, 10000) < 50) {
            Targetpos = new Vector3(Random.Range(-tanksize, tanksize), Random.Range(-tanksize, tanksize), Random.Range(-tanksize, tanksize));
            goalprefab.transform.position = Targetpos;
            t = (TargetType)Random.Range(0, 2);
           /* Vector3 pos = Vector3.zero;
            positions p = (positions)Random.Range(0, 3);
            switch (p)
            {
                case positions.p1:
                    pos = new Vector3(-tanksize, -tanksize, -tanksize);
                    break;
                case positions.p2:
                    pos = new Vector3(tanksize, tanksize, tanksize);
                    break;
                case positions.p3:
                    pos = new Vector3(tanksize, 0, tanksize);
                    break;
                case positions.p4:
                    pos = new Vector3(-tanksize, 0, -tanksize);
                    break;
            }
            Targetpos = pos;
            goalprefab.transform.position = Targetpos;
            t = (TargetType)Random.Range(0, 2);*/

        }
    }
}
