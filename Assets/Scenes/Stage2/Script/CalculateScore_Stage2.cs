using UnityEngine;
using System.Collections;

/// <summary>
/// Stage2 - �B�z�����Ҧ����Z�A�íp��Ҧ�����
/// </summary>
public class CalculateScore_Stage2 : MonoBehaviour
{
    public Stage2Data StageData_Script;

    public static int PassObstacleCount;    //�q�L��ê����
    public static int TouchObstacleCount;   //�Q��ê��������
    public static int KillFireflyCount;     //�������Ǧ���
    public static int MissFireflyCount;     //���������Ǧ���

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
