using UnityEngine;
using System.Collections;

public class ClearTextfield : MonoBehaviour {


    public TextField nameTextfield;
	// Use this for initialization
	void Start () {
        nameTextfield.Clear();
        Destroy(this.gameObject);     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
