using UnityEngine;
using System.Collections;

public class Stage2Data : MonoBehaviour {

    // * StageData �ӧO���d�����
    public DataCollection dataCollection;
    public DataCollection.StageName stageName;
    public DataCollection.StageType stageType;

    public int CorrectTimes1;    //���T����(��ê��)
    public int CorrectTimes2;    //���T����(����)
    public int WrongTimes1;      //���~����(��ê��)
    public int WrongTimes2;      //���~����(����)
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
        DataCollection.StageData newStageData = new DataCollection.StageData(stageType, stageName, CorrectTimes1, WrongTimes1, PositiveScore, NegativeScore, TakeTime, CorrectTimes2, WrongTimes2);
        dataCollection.StageDataList.Add(newStageData); // �[��List
        dataCollection.OutputLog2txt(); //��X�ɮ�
    }

    /// <summary>
    /// �x�s���d��T
    /// </summary>
    public void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "CorrectTimes1", CorrectTimes1);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "WrongTimes1", WrongTimes2);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "CorrectTimes2", CorrectTimes1);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "WrongTimes2", WrongTimes2);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "PositiveScore", PositiveScore);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "NegativeScore", NegativeScore);
        PlayerPrefs.SetInt(stageName.ToString() + stageType.ToString() + "TakeTime", TakeTime);
    }

    /// <summary>
    /// Initialize
    /// </summary>
    public void Init()
    {
        CorrectTimes1 = CorrectTimes2 = 0;
        WrongTimes1 = WrongTimes2 = 0;
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
