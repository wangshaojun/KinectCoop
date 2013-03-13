using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {
    public GameObject[] Stage3Score;
    public GameObject CreatObj;
    private DynamicString2Value CTimes, WTimes, PScore, NScore, TakeTimes;
	// Use this for initialization
	void Start () {
        CTimes = Stage3Score[0].GetComponent<DynamicString2Value>();
        WTimes = Stage3Score[1].GetComponent<DynamicString2Value>();
        PScore = Stage3Score[2].GetComponent<DynamicString2Value>();
        NScore = Stage3Score[3].GetComponent<DynamicString2Value>();
        TakeTimes = Stage3Score[4].GetComponent<DynamicString2Value>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
