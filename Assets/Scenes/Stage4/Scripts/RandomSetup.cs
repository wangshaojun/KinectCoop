using UnityEngine;
using System.Collections;

public class RandomSetup : MonoBehaviour {

    public GameObject[] digs;
    private int num;
    // Use this for initialization
	void Start () {
	    num = Random.Range(0,6);
	}
	
	// Update is called once per frame
	void Update () {
        digs[num].SetActive(true);
	}
}
