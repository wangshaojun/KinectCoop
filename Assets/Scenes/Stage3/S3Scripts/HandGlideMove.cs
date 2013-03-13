using UnityEngine;
using System.Collections;

public class HandGlideMove : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - Time.deltaTime, this.transform.localPosition.z + 3 * Time.deltaTime);
        if (Input.GetKey("left")) {
            this.transform.Rotate(0, -10 * Time.deltaTime,0);
        }
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, 10 * Time.deltaTime, 0);
        }
	}
}
