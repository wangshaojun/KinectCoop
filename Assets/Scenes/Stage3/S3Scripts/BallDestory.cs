using UnityEngine;
using System.Collections;

public class BallDestory : MonoBehaviour {
    float CountTime;

    public float DestoryTime;

	// Use this for initialization
	void Start () {

        CountTime = 0;
       
	}
    public void SelfDestory() {
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;
        if (CountTime > DestoryTime) Destroy(this.gameObject);
	}
}
