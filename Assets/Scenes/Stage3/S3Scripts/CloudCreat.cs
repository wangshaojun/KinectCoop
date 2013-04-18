using UnityEngine;
using System.Collections;

public class CloudCreat : MonoBehaviour {
    public GameObject Cloud;
    public float cloudRate;
	// Use this for initialization
	void Start () {
	
	}
    void cloudcreat() {
        int i = Random.Range(0, 3);

        switch (i) { 
            case 0:
                Instantiate(Cloud, this.transform.position + this.transform.TransformDirection(Random.Range(-9,10),Random.Range(-5,2), 20 + Random.Range(-2,10)), this.transform.rotation);
                break;
            case 1:
                Instantiate(Cloud, this.transform.position + this.transform.TransformDirection(Random.Range(-9, 10), Random.Range(-5, 2), 20 + Random.Range(-2, 10)), this.transform.rotation);
                Instantiate(Cloud, this.transform.position + this.transform.TransformDirection(Random.Range(-9, 10), Random.Range(-5, 2), 20 + Random.Range(-2, 10)), this.transform.rotation);
                break;
            case 2:
                Instantiate(Cloud, this.transform.position + this.transform.TransformDirection(Random.Range(-9, 10), Random.Range(-5, 2), 20 + Random.Range(-2, 10)), this.transform.rotation);
                Instantiate(Cloud, this.transform.position + this.transform.TransformDirection(Random.Range(-9, 10), Random.Range(-5, 2), 20 + Random.Range(-2, 10)), this.transform.rotation);
                Instantiate(Cloud, this.transform.position + this.transform.TransformDirection(Random.Range(-9, 10), Random.Range(-5, 2), 20 + Random.Range(-2, 10)), this.transform.rotation);
                break;
          
            default:

                break;
        }
    
    }
	// Update is called once per frame
	void Update () {
        if (!IsInvoking("cloudcreat")) {
            Invoke("cloudcreat", cloudRate);
        }
	}
}
