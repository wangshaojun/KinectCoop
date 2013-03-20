using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {
    public StageData stageData;
    public int NormalCT,HardCT;

    public bool Upload;
    GameObject[] objs;
	// Use this for initialization
	void Start () {
       
	}
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "RedBall(Clone)") {
            stageData.CorrectTimes++;
            stageData.PositiveScore += 5;
            Destroy(other.gameObject);
   
        }
        if (other.gameObject.name == "BlackBall(Clone)")
        {
            stageData.WrongTimes++;
            stageData.NegativeScore -= 8;
            Destroy(other.gameObject);

        }
        
    }
	// Update is called once per frame
	void Update () {
        if (stageData.stageType == DataCollection.StageType.Normal && stageData.CorrectTimes == NormalCT)
        {
           
            Upload = true;

             if (Upload)
             {
                  stageData.UploadData();
                  Upload = false;
             }

             this.objs = GameObject.FindGameObjectsWithTag("Stage3Ball");//把紅球與黑球給予Stage3Ball的Tag，用FindGameObjectsWithTag
                                                                         //抓出所有屬於Stage3Ball的Tag的物件
                foreach (GameObject obj in objs)                         //foreach 是依序抓出陣列裡的東西並命名成 obj(可自行更改)
                  {                                                      //因為objs是GameObject型別所以obj也要是GameObject型別
                      obj.GetComponent<BallDestory>().SelfDestory();     //依序抓出的物件讓他執行他自己的功能
                  }
                stageData.Init();
             stageData.stageType = DataCollection.StageType.Hard;
            
        }
        if (stageData.stageType == DataCollection.StageType.Hard && stageData.CorrectTimes == HardCT)
        {

            Upload = true;

            if (Upload)
            {
                stageData.UploadData();
                Upload = false;
            }

            this.objs = GameObject.FindGameObjectsWithTag("Stage3Ball");//把紅球與黑球給予Stage3Ball的Tag，用FindGameObjectsWithTag
            //抓出所有屬於Stage3Ball的Tag的物件
            foreach (GameObject obj in objs)                         //foreach 是依序抓出陣列裡的東西並命名成 obj(可自行更改)
            {                                                      //因為objs是GameObject型別所以obj也要是GameObject型別
                obj.GetComponent<BallDestory>().SelfDestory();     //依序抓出的物件讓他執行他自己的功能
            }
            stageData.Init();
            stageData.NextStage("Stage3", 2);
        }
	}
}
