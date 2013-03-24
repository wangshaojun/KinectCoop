using UnityEngine;
using System.Collections;

public class StageTypeController : MonoBehaviour {

    public StageData stageData;
    public int HardCorrectTimesThreshold;
    public int NextStageCorrectTimesThreshold;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (stageData.stageType == DataCollection.StageType.Normal &&
            stageData.CorrectTimes == HardCorrectTimesThreshold)
        {
            stageData.UploadData();
            stageData.ChangeStageType();
        }
        if (stageData.stageType == DataCollection.StageType.Hard &&
            stageData.CorrectTimes >= NextStageCorrectTimesThreshold)
        {
            stageData.UploadData();
            stageData.NextStage("Stage5", 2.0F);
        }

	}
}
