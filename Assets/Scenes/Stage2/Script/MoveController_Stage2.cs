using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-Kinect的處理(控制人物前進)
/// </summary>
public class MoveController_Stage2 : MonoBehaviour
{
    private SkeletonInformation skeletonInfo_script;    //Kinect骨架資訊
    public GameObject skeletonInfoObject;
    public DetectSkeletonisEnable SkeletonIsEnableScript;
    public float Knne_Hip_Delta = 0.25f;                        //膝蓋與屁股間的差距(質越小，腿需抬越高)
    public float AddSpeed = 5;                                  //每一步增加的速度

    public enum FeetRaiseState
    {
        None, Right, Left
    }
    private FeetRaiseState FeetState { get; set; }

    // Use this for initialization
    void Start()
    {
        this.skeletonInfo_script = this.skeletonInfoObject.GetComponent<SkeletonInformation>();
        this.FeetState = FeetRaiseState.None;
    }

    // Update is called once per frame
    void Update()
    {
        //print("HipLeftPos"+this.skeletonInfo_script.HipLeftPos.y);
        //print("KneeLeftPos" + this.skeletonInfo_script.KneeLeftPos.y);
        //print(this.rigidbody.velocity);
        if (this.SkeletonIsEnableScript.SkeletonIsEnable)
        {
            ////確認手是否平舉
            //if (Mathf.Abs(this.skeletonInfo_script.HandLeftPos.y - this.skeletonInfo_script.ShoulderLeftPos.y) < 0.1f &&
            //    Mathf.Abs(this.skeletonInfo_script.HandRightPos.y - this.skeletonInfo_script.ShoulderRightPos.y) < 0.1f)
            //{
            //    //(未完成) Kinect偵測玩家的處理
            //    //-----------------------------
            //}
            if (this.skeletonInfo_script.HipCenterPos.y > 1)
            {
                if (this.FeetState != FeetRaiseState.Left)
                {
                    //確認腳的動作
                    if (this.skeletonInfo_script.HipLeftPos.y - this.skeletonInfo_script.KneeLeftPos.y < this.Knne_Hip_Delta)
                    {
                        print("Left");
                        this.FeetState = FeetRaiseState.Left;
                        this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                    }
                }
                else if (this.FeetState != FeetRaiseState.Right)
                {
                    //確認腳的動作
                    if (this.skeletonInfo_script.HipRightPos.y - this.skeletonInfo_script.KneeRightPos.y < this.Knne_Hip_Delta)
                    {
                        print("Right");
                        this.FeetState = FeetRaiseState.Right;
                        this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                //this.transform.rigidbody.AddForce(new Vector3(0, 0, 10));
                //this.transform.Translate(new Vector3(0, 0, 1));
                this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
            }
        }
    }
}