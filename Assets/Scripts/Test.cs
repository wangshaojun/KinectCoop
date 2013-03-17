using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    //載入當局關卡資料
    public StageData stageData;

    public bool AddCorrectTimes;
    public bool Upload;
    public bool ChangeStageType;
    public bool NextLevel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (AddCorrectTimes)
        {
            stageData.CorrectTimes += 1;
            AddCorrectTimes = false;
        }
        if (Upload)
        {
            stageData.UploadData();
            Upload = false;
        }
        if (ChangeStageType)
        {
            stageData.ChangeStageType();
            ChangeStageType = false;
        }
        if (NextLevel)
        {
            stageData.NextStage("Title", 2.0F);
            NextLevel = false;
        }

        

	}


}
