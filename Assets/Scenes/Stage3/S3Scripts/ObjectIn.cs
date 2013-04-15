using UnityEngine;
using System.Collections;

public class ObjectIn : MonoBehaviour
{
    public GameObject RedBall, BlackBall;
    public GameObject StageDifficulty;
    public int RedCreat, BlackCreat;
    public float test;
    private StageData Stage3Difficulty;


    // Use this for initialization
    void Start()
    {
        Stage3Difficulty = StageDifficulty.GetComponent<StageData>();
    }
    void RedBallCreat()
    {

        Instantiate(RedBall, this.transform.position + this.transform.TransformDirection(Random.Range(-9, 10), Random.Range(-5, 1), 0),
                    RedBall.transform.rotation);

    }
    void BlackBallCreat()
    {


        int rodom = Random.Range(-9, 10);

        GameObject obj = (GameObject)Instantiate(BlackBall, this.transform.position + this.transform.TransformDirection(rodom, Random.Range(-2, 0), 0),
          this.transform.rotation);

        if (rodom >= 0)
            obj.GetComponent<LightningBugPath>().rotat = LightningBugPath.Rotat.right;
        else
            obj.GetComponent<LightningBugPath>().rotat = LightningBugPath.Rotat.left;
    }
    // Update is called once per frame
    void Update()
    {
        if (Stage3Difficulty.stageType == DataCollection.StageType.Normal)
        {

            if (!IsInvoking("RedBallCreat"))
            {
                Invoke("RedBallCreat", RedCreat);
            }
        }
        if (Stage3Difficulty.stageType == DataCollection.StageType.Hard)
        {

            if (!IsInvoking("RedBallCreat"))
            {
                Invoke("RedBallCreat", RedCreat);
            }
            if (!IsInvoking("BlackBallCreat"))
            {
                Invoke("BlackBallCreat", BlackCreat);
            }
        }

    }
}
