using UnityEngine;
using System.Collections;

public class FeetRayCast : MonoBehaviour
{

    public GameObject Target;
    public FeetMove feetMove;
    public Digletts digletts;
    public SkeletonWrapper skeletonWrapper;
    private bool _kinectisEnable = true;
    

    public float velocity = -2;
    public float GestureCoolDown = 2; //�����P���������N�o�ɶ�
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�}���S���b����a�����W
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 10) == true)
        {
            Target = hit.transform.gameObject;
        }
        else
            Target = null;

        //kinect���}�t��
        Vector3 FootLeft = skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.FootLeft];
        Vector3 FootRight = skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.FootRight];

        if (_kinectisEnable)
        {
            #region ���}�t�קP�w�A�U�����t��
            if (feetMove.FeetType == FeetMove.Feet.Left)
                if (FootLeft.y < velocity)
                {
                    //�p�G���ؼЪ�
                    if (Target && Target.GetComponent<DiglettsReact>().isLive)
                    {
                        Target.SendMessage("isHit");
                        PositiveScoreProcess();
                    }
                    else
                        NegativeScoreProcess();

                    _kinectisEnable = false;
                }
            #endregion
            #region �k�}�t�קP�w�A�U�����t��
            if (feetMove.FeetType == FeetMove.Feet.Right)
                if (FootRight.y < velocity)
                {
                    //�p�G���ؼЪ�
                    if (Target)
                    {
                        Target.SendMessage("isHit");
                        PositiveScoreProcess();
                    }
                    else
                        NegativeScoreProcess();

                    _kinectisEnable = false;
                }
            #endregion
        }
        else
            StartCoroutine(CoolDown(GestureCoolDown, _kinectisEnable));
    }


    //���T�P�[������
    public void PositiveScoreProcess()
    {
        digletts.stageData.CorrectTimes += 1;

        if (digletts.stageData.stageType == DataCollection.StageType.Normal)
            digletts.stageData.PositiveScore += digletts.NormalPositiveScore;
        if (digletts.stageData.stageType == DataCollection.StageType.Hard)
            digletts.stageData.PositiveScore += digletts.HardPositiveScore;
    }

    //���~�P��������
    public void NegativeScoreProcess()
    {
        digletts.stageData.WrongTimes += 1;
        if (digletts.stageData.stageType == DataCollection.StageType.Normal)
            digletts.stageData.NegativeScore += digletts.NormalNegativeScore;
        if (digletts.stageData.stageType == DataCollection.StageType.Hard)
            digletts.stageData.NegativeScore += digletts.HardNegativeScore;
    }





    /// <summary>
    /// �j��N�o�ɶ� (�w��Kinect���s��P�_)
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    IEnumerator CoolDown(float delay,bool trigger)
    {
        yield return new WaitForSeconds(delay);
        trigger = true;
    }


}
