using UnityEngine;
using System.Collections;

/// <summary>
/// Stage2 - �B�z�����Ҧ����Z�A�íp��Ҧ�����
/// </summary>
public class CalculateScore_Stage2 : MonoBehaviour
{
    public Stage2Data StageData_Script;

    public int PassObstacleCount;   //�q�L��ê����
    public int TouchObstacleCount;  //�Q��ê��������
    public int KillFireflyCount;    //�������Ǧ���
    public int MissFireflyCount;    //���������Ǧ���


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.StageData_Script.PositiveScore = (this.PassObstacleCount * 10) + (this.KillFireflyCount * 8);
        this.StageData_Script.NegativeScore = (this.TouchObstacleCount * 10) + (this.MissFireflyCount * 8);

        this.StageData_Script.CorrectTimes1 = this.PassObstacleCount;
        this.StageData_Script.CorrectTimes2 = this.KillFireflyCount;
        this.StageData_Script.WrongTimes1 = this.TouchObstacleCount;
        this.StageData_Script.WrongTimes2 = this.MissFireflyCount;
    }
}
