using UnityEngine;
using System.Collections;

public class BallDestory : MonoBehaviour {
    float CountTime;
    public int StageCount,StageCorrectT;
    StageData stageData;
    ScoreCount SCount;
    public float DestoryTime;

	// Use this for initialization
	void Start () {

        CountTime = 0;
        stageData = GameObject.Find("StageData").GetComponent<StageData>();
        SCount = GameObject.Find("Body_Collider").GetComponent<ScoreCount>();
        if (stageData.stageType == DataCollection.StageType.Normal)
        {
            this.StageCount = 1;
      
        }
        if (stageData.stageType == DataCollection.StageType.Hard)
        {
            this.StageCount = 2;
            
        }
	}
    public void SelfDestory() {
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;
        if (CountTime > DestoryTime) Destroy(this.gameObject);
	}
}
