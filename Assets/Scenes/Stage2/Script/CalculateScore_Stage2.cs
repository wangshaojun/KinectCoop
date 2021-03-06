using UnityEngine;
using System.Collections;

/// <summary>
/// Stage2 - 處理接收所有成績，並計算所有分數
/// </summary>
public class CalculateScore_Stage2 : MonoBehaviour
{
    public Stage2Data StageData_Script;

    public static int PassObstacleCount;    //通過障礙次數
    public static int TouchObstacleCount;   //被障礙撞擊次數
    public static int KillFireflyCount;     //殺掉火蠅次數
    public static int MissFireflyCount;     //未殺掉火蠅次數

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.StageData_Script.PositiveScore = (PassObstacleCount * 10) + (KillFireflyCount * 8);
        this.StageData_Script.NegativeScore = (TouchObstacleCount * 10) + (MissFireflyCount * 8);

        this.StageData_Script.CorrectTimes1 = PassObstacleCount;
        this.StageData_Script.CorrectTimes2 = KillFireflyCount;
        this.StageData_Script.WrongTimes1 = TouchObstacleCount;
        this.StageData_Script.WrongTimes2 = MissFireflyCount;
    }
}
