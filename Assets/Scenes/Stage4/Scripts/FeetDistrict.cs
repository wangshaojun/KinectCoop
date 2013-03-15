using UnityEngine;
using System.Collections;

public class FeetDistrict : MonoBehaviour {

    public int limitPX; // ¥¿X
    public int limitPY;
    public int limitNX; // ­tX
    public int limitNY;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.x < limitNX)
            this.transform.localPosition = new Vector3(limitNX, this.transform.localPosition.y, this.transform.localPosition.z);
        if (this.transform.localPosition.y < limitNY)
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, limitNY, this.transform.localPosition.z);


        if (this.transform.localPosition.x > limitPX)
            this.transform.localPosition = new Vector3(limitPX, this.transform.localPosition.y, this.transform.localPosition.z);
        if (this.transform.localPosition.y > limitPY)
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, limitPY, this.transform.localPosition.z);

    }
}
