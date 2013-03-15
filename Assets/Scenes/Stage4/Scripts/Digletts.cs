using UnityEngine;
using System.Collections;

public class Digletts: MonoBehaviour {

    public float Interval; //兩次出現的間隔時間
    public float Stay;     //出現後的等待時間

    //AudioClips
    public AudioClip Appear;
    public AudioClip Die;
    public StageData stageData;


    public float NormalInterval; //兩次出現的間隔時間
    public float NormalStay;     //出現後的等待時間
    public float HardInterval; //兩次出現的間隔時間
    public float HardStay;     //出現後的等待時間
    public int NormalPositiveScore = 1; //基礎關卡正分
    public int NormalNegativeScore = 1; //基礎關卡負分
    public int HardPositiveScore = 2; //進階關卡正分
    public int HardNegativeScore = 2; //進階關卡負分


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

        if (stageData.stageType == DataCollection.StageType.Hard)
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
            while (oldValue == newValue);
            return  newValue;
        }
        return -1;
        
    }
}
