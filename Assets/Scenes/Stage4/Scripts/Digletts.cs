using UnityEngine;
using System.Collections;

public class Digletts: MonoBehaviour {

    public float Interval; //�⦸�X�{�����j�ɶ�
    public float Stay;     //�X�{�᪺���ݮɶ�

    //AudioClips
    public AudioClip Appear;
    public AudioClip Die;
    public StageData stageData;


    public float NormalInterval; //�⦸�X�{�����j�ɶ�
    public float NormalStay;     //�X�{�᪺���ݮɶ�
    public float HardInterval; //�⦸�X�{�����j�ɶ�
    public float HardStay;     //�X�{�᪺���ݮɶ�
    public int NormalPositiveScore = 1; //��¦���d����
    public int NormalNegativeScore = 1; //��¦���d�t��
    public int HardPositiveScore = 2; //�i�����d����
    public int HardNegativeScore = 2; //�i�����d�t��
    public int BossPositiveScore = 2; //�i�����d����
    public int BossNegativeScore = 2; //�i�����d�t��


    #region PRIVATES
    private int oldValue;
    private float addTime;
    #endregion

    // Use this for initialization
	void Start () {
        Interval = NormalInterval;
        Stay = NormalStay;
	}
	
	// Update is called once per frame
	void Update () {

        if (stageData.stageType == DataCollection.StageType.Hard ||
            stageData.stageType == DataCollection.StageType.Boss)
        {
            Interval = HardInterval;
            Stay = HardStay;
        }

        int newValue = RandomValue(oldValue);
        if (newValue >= 0)
        {
            oldValue = newValue;
            transform.GetChild(newValue).SendMessage("AnimationActive");
            transform.GetChild(newValue).audio.PlayOneShot(Appear);
        }
	}


    int RandomValue(int oldValue)
    {
        int newValue;

        addTime += Time.deltaTime;
        if (addTime > Interval)
        {
            addTime = 0;
            do
            {
                newValue = Random.Range(0, 8);
            }
            while (oldValue == newValue); //�ϼƦr������
            return  newValue;
        }
        return -1;
    }
}
