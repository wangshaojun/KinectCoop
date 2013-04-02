using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-Kinect���B�z(����H���e�i)
/// </summary>
public class MoveController_Stage2 : MonoBehaviour
{
    private SkeletonInformation skeletonInfo_script;    //Kinect���[��T
    public GameObject skeletonInfoObject;
    public DetectSkeletonisEnable SkeletonIsEnableScript;
    public float Knne_Hip_Delta = 0.25f;                        //���\�P���Ѷ����t�Z(��V�p�A�L�ݩ�V��)
    public float AddSpeed = 5;                                  //�C�@�B�W�[���t��

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
            ////�T�{��O�_���|
            //if (Mathf.Abs(this.skeletonInfo_script.HandLeftPos.y - this.skeletonInfo_script.ShoulderLeftPos.y) < 0.1f &&
            //    Mathf.Abs(this.skeletonInfo_script.HandRightPos.y - this.skeletonInfo_script.ShoulderRightPos.y) < 0.1f)
            //{
            //    //(������) Kinect�������a���B�z
            //    //-----------------------------
            //}
            if (this.skeletonInfo_script.HipCenterPos.y > 1)
            {
                if (this.FeetState != FeetRaiseState.Left)
                {
                    //�T�{�}���ʧ@
                    if (this.skeletonInfo_script.HipLeftPos.y - this.skeletonInfo_script.KneeLeftPos.y < this.Knne_Hip_Delta)
                    {
                        print("Left");
                        this.FeetState = FeetRaiseState.Left;
                        this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                    }
                }
                else if (this.FeetState != FeetRaiseState.Right)
                {
                    //�T�{�}���ʧ@
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