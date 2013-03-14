using UnityEngine;
using System.Collections;

public class HandGlideMove : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, -1 * Time.deltaTime, 3 * Time.deltaTime);
        if (Input.GetKey("left")) {
            this.transform.Rotate(0, -15 * Time.deltaTime,0);
        }
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, 15 * Time.deltaTime, 0);
        }
	}
}
