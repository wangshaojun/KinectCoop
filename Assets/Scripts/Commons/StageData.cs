using UnityEngine;
using System.Collections;

public class StageData : MonoBehaviour {

    // * StageData 個別關卡的資料
    public DataCollection dataCollection;
    public DataCollection.StageName stageName;
    public DataCollection.StageType stageType;
    public DataCollection.PassOrNot passOrNot;

    public int CorrectTimes;    //正確次數
    public int WrongTimes;      //錯誤次數
    public int PositiveScore;   //得分分數
    public int NegativeScore;   //扣分分數
    public int TakeTime;        //花費時間

    private float fTime;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("DataCollection"))
            dataCollection = GameObject.Find("DataCollection").GetComponent<DataCollection>();
        else
            Debug.LogWarning("沒有載入 DataCollection");
	}
	
	// Update is called once per frame
	void Update () {
        SetPlayerPrefs();

        fTime += Time.deltaTime;
        TakeTime = (int)fTime;

	}

    /// <summary>
    /// 上傳分數到DataColletion並輸出檔案
    /// </summary>
    public void UploadData()
    {
        DataCollection.StageData newStageData = new DataCollection.StageData(stageType, stageName, passOrNot, CorrectTimes, WrongTimes, PositiveScore, NegativeScore, TakeTime);
        dataCollection.StageDataList.Add(newStageData); // 加到List
        dataCollection.OutputLog2txt(); //輸出檔案
    }

    /// <summary>
    /// 儲存關卡資訊
    /// </summary>
    public void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "CorrectTimes", CorrectTimes);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "WrongTimes", WrongTimes);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "PositiveScore", PositiveScore);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "NegativeScore", NegativeScore);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "TakeTime", TakeTime);
    }

    /// <summary>
    /// Initialize
    /// </summary>
    public void Init()
    {
        CorrectTimes = 0;
        WrongTimes = 0;
        PositiveScore = 0;   
        NegativeScore = 0; 
        TakeTime = 0;
        fTime = 0;
    }

    /// <summary>
    /// 改變關卡難度
    /// </summary>
    public void ChangeStageType()
    {
        stageType = DataCollection.StageType.Hard;
        Init();
    }

    
    /// <summary>
    /// 進入下一關卡
    /// </summary>
    /// <param name="stageName">關卡名稱：例如Stage1</param>
    /// <param name="delayTime">等待時間</param>
    public void NextStage(string stageName, float delayTime)
    {
        StartCoroutine(INextStage(stageName, delayTime));
    }

    IEnumerator INextStage(string stageName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Application.LoadLevel(stageName);
    }
}
