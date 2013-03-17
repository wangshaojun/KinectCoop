using UnityEngine;
using System.Collections;

public class StageData : MonoBehaviour {

    // * StageData �ӧO���d�����
    public DataCollection dataCollection;
    public DataCollection.StageName stageName;
    public DataCollection.StageType stageType;

    public int CorrectTimes;    //���T����
    public int WrongTimes;      //���~����
    public int PositiveScore;   //�o������
    public int NegativeScore;   //��������
    public int TakeTime;        //��O�ɶ�

    private float fTime;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("DataCollection"))
            dataCollection = GameObject.Find("DataCollection").GetComponent<DataCollection>();
        else
            Debug.LogWarning("�S�����J DataCollection");
	}
	
	// Update is called once per frame
	void Update () {
        SetPlayerPrefs();

        fTime += Time.deltaTime;
        TakeTime = (int)fTime;

	}

    /// <summary>
    /// �W�Ǥ��ƨ�DataColletion�ÿ�X�ɮ�
    /// </summary>
    public void UploadData()
    {
        DataCollection.StageData newStageData = new DataCollection.StageData(stageType, stageName, CorrectTimes,WrongTimes,PositiveScore,NegativeScore,TakeTime);
        dataCollection.StageDataList.Add(newStageData); // �[��List
        dataCollection.OutputLog2txt(); //��X�ɮ�
    }

    /// <summary>
    /// �x�s���d��T
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
    /// �������d����
    /// </summary>
    public void ChangeStageType()
    {
        stageType = DataCollection.StageType.Hard;
        Init();
    }

    
    /// <summary>
    /// �i�J�U�@���d
    /// </summary>
    /// <param name="stageName">���d�W�١G�ҦpStage1</param>
    /// <param name="delayTime">���ݮɶ�</param>
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
