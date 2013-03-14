using UnityEngine;
using System.Collections;

public class ObjectIn : MonoBehaviour {
    public GameObject RedBall, BlackBall;
    public GameObject StageDifficulty;
    private StageData Stage3Difficulty;
	// Use this for initialization
	void Start () {
        Stage3Difficulty = StageDifficulty.GetComponent<StageData>();
	}
    void RedBallCreat() {
        Instantiate(RedBall, new Vector3(this.transform.position.x + Random.Range(-10, 10), this.transform.position.y + Random.Range(-3, 3), this.transform.position.z),
                    RedBall.transform.rotation);
        
    }
    void BlackBallCreat() {
        Instantiate(BlackBall, new Vector3(this.transform.position.x + Random.Range(-10, 10), this.transform.position.y + Random.Range(-3, 3), this.transform.position.z),
          BlackBall.transform.rotation);
    }
	// Update is called once per frame
	void Update () {
        if (Stage3Difficulty.stageType == DataCollection.StageType.Normal)
        {

            if (!IsInvoking("RedBallCreat"))
            {
                Invoke("RedBallCreat", 3);
            }
        }
        if (Stage3Difficulty.stageType == DataCollection.StageType.Hard)
        {

            if (!IsInvoking("RedBallCreat"))
            {
                Invoke("RedBallCreat", 3);
            }
            if (!IsInvoking("BlackBallCreat"))
            {
                Invoke("BlackBallCreat", 2);
            }
        }
        
	}
}
