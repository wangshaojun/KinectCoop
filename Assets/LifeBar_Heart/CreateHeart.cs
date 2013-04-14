using UnityEngine;
using System.Collections;

public class CreateHeart : MonoBehaviour {

    public GameObject heartPrefab;
    public int heartCount;

    private Vector2 _heartPosition;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < heartCount; i++)
        {
            GameObject newHeartPrefab = (GameObject)Instantiate(heartPrefab, new Vector3(_heartPosition.x, _heartPosition.y, 0), Quaternion.identity);
            newHeartPrefab.transform.parent = this.transform;
            newHeartPrefab.transform.position = new Vector3(0.9F - 0.1F * i, 0.9F, 0);
        }
       
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
