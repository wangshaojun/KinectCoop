using UnityEngine;
using System.Collections;

public class CubeTrigger : MonoBehaviour {

    bool OnTriggerEnter(Collider col)
    {
        if (col.tag == "Stage1Ball") return FruitCreator.isBallKilled = true;
        return false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
