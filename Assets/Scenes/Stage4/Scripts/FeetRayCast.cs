using UnityEngine;
using System.Collections;

public class FeetRayCast : MonoBehaviour
{

    public GameObject Target;
    public FeetMove feetMove;
    public Digletts digletts;
    public SkeletonWrapper skeletonWrapper;
    public bool _kinectisEnable = true;

    public float velocity = -2;
    public float GestureCoolDown = 2; //擊中與未擊中的冷卻時間
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        //腳有沒有在任何地鼠之上
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 10) == true)
        {
            Target = hit.transform.gameObject;
        }
        else
            Target = null;

        //kinect的腳速度
        Vector3 FootLeft = skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.FootLeft];
        Vector3 FootRight = skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.FootRight];

        if (_kinectisEnable)
        {
            #region 左腳速度判定，下壓為負值
            if (feetMove.FeetType == FeetMove.Feet.Left)
                if (FootLeft.y < velocity)
                {
                    iTween.ColorTo(this.gameObject, iTween.Hash("r", 1.0, "g", 0, "b", 0, "time", 0.2));

                    //如果有目標物
                    if (Target)
                    {
                        if (Target.GetComponent<DiglettsReact>().isLive)
                        {
                            Target.SendMessage("isHit");
                            PositiveScoreProcess();
                        }
                        else
                            ; //NegativeScoreProcess();

                    }
                    else
                        ;//NegativeScoreProcess();

                    _kinectisEnable = false;
                    StartCoroutine(ResetColor(0.5F));
                    StartCoroutine(CoolDown(GestureCoolDown));
                }

            #endregion
            #region 右腳速度判定，下壓為負值
            if (feetMove.FeetType == FeetMove.Feet.Right)
                if (FootRight.y < velocity)
                {
                    //如果有目標物///////////
                    iTween.ColorTo(this.gameObject, iTween.Hash("r", 1.0, "g", 0, "b", 0, "time", 0.2));

                    if (Target)
                    {
                        if (Target.GetComponent<DiglettsReact>().isLive)
                        {
                            Target.SendMessage("isHit");
                            PositiveScoreProcess();
                        }
                        else
                            ;//NegativeScoreProcess();
                    }
                    else
                        ;//NegativeScoreProcess();

                    _kinectisEnable = false;
                    StartCoroutine(ResetColor(0.5F));
                    StartCoroutine(CoolDown(GestureCoolDown));
                }
            #endregion
        }


    }


    //正確與加分機制
    public void PositiveScoreProcess()
    {
        digletts.stageData.CorrectTimes += 1;

        if (digletts.stageData.stageType == DataCollection.StageType.Normal)
            digletts.stageData.PositiveScore += digletts.NormalPositiveScore;
        if (digletts.stageData.stageType == DataCollection.StageType.Hard)
            digletts.stageData.PositiveScore += digletts.HardPositiveScore;
    }

    //錯誤與扣分機制
    public void NegativeScoreProcess()
    {
        digletts.stageData.WrongTimes += 1;
        if (digletts.stageData.stageType == DataCollection.StageType.Normal)
            digletts.stageData.NegativeScore += digletts.NormalNegativeScore;
        if (digletts.stageData.stageType == DataCollection.StageType.Hard)
            digletts.stageData.NegativeScore += digletts.HardNegativeScore;
    }

    /// <summary>
    /// 強制冷卻時間 (針對Kinect的連續判斷)
    /// </summary>
    IEnumerator CoolDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        _kinectisEnable = true;
         iTween.ColorTo(this.gameObject, iTween.Hash("r", 1, "g", 1, "b", 1, "time", 0.3));
    }

    IEnumerator ResetColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        iTween.ColorTo(this.gameObject, iTween.Hash("r", 1, "g", 1, "b", 1, "time", 0.3));
    }


}
