using UnityEngine;
using System.Collections;

public class FeetRayCast : MonoBehaviour {

    RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	     if (Physics.Raycast(transform.position,new Vector3(0,0,1),out hit,10) == true)
        {
            print(hit.transform.name);
        }
	}



}
