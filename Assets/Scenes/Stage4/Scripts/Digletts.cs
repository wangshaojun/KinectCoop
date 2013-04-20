using UnityEngine;
using System.Collections;

public class Digletts: MonoBehaviour {

    public float Interval; //兩次出現的間隔時間
    public float Stay;     //出現後的等待時間

    //AudioClips
    public AudioClip Appear_obake;
    public AudioClip Appear_bomb;
    public StageData stageData;


    public float NormalInterval; //兩次出現的間隔時間
    public float NormalStay;     //出現後的等待時間
    public float HardInterval; //兩次出現的間隔時間
    public float HardStay;     //出現後的等待時間
    public int NormalPositiveScore = 1; //基礎關卡正分
    public int NormalNegativeScore = 1; //基礎關卡負分
    public int HardPositiveScore = 2; //進階關卡正分
    public int HardNegativeScore = 2; //進階關卡負分
    public int BossPositiveScore = 2; //進階關卡正分
    public int BossNegativeScore = 2; //進階關卡負分

    int type;

    #region PRIVATES
    private int oldValue;
    private float addTime;
    #endregion

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (stageData.stageType == DataCollection.StageType.Hard ||
            stageData.stageType == DataCollection.StageType.Boss)
        {
            Interval = HardInterval;
            Stay = HardStay;
        }
        else
        {
            Interval = NormalInterval;
            Stay = NormalStay;
        }

        int newValue = RandomValue(oldValue);
        if (newValue >= 0)
        {
            oldValue = newValue;
            transform.GetChild(newValue).SendMessage("AnimationActive");
            transform.GetChild(newValue).audio.PlayOneShot(Appear_obake);

            //亂數決定該Object為地鼠or地雷
            if(stageData.stageType == DataCollection.StageType.Hard ||
            stageData.stageType == DataCollection.StageType.Boss)
            {
            type = Random.Range(0, 2);
            if (type == 0)
                transform.GetChild(newValue).GetComponent<DiglettsReact>().objectType = DiglettsReact.ObjectType.Diglett;


            if (type == 1)
                transform.GetChild(newValue).GetComponent<DiglettsReact>().objectType = DiglettsReact.ObjectType.Bomb;
            }
           
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
            while (oldValue == newValue); //使數字不重複
            return  newValue;
        }
        return -1;
    }
}
