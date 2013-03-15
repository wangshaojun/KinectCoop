using UnityEngine;
using System.Collections;

public class StageTypeController : MonoBehaviour {

    public StageData stageData;
    public int HardCorrectTimesThreshold;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (stageData.CorrectTimes == HardCorrectTimesThreshold)
        {
            stageData.UploadData();
            stageData.ChangeStageType();
        }
	}
}
