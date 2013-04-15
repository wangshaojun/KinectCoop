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

    public enum FeetState
    {
        RightRaise, RightDown, LeftRaise, LeftDown
    }
    private FeetState currentfeetState { get; set; }

    // Use this for initialization
    void Start()
    {
        this.skeletonInfo_script = this.skeletonInfoObject.GetComponent<SkeletonInformation>();

        this.currentfeetState = FeetState.LeftDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.SkeletonIsEnableScript.SkeletonIsEnable)
        {
            if (this.skeletonInfo_script.HipCenterPos.y > 1)
            {
                switch (this.currentfeetState)
                {
                    case FeetState.RightRaise:
                        print(Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.y - this.skeletonInfo_script.KneeRightPos.y).ToString() + "," + Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.z - this.skeletonInfo_script.KneeRightPos.z).ToString());
                        if (Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.y - this.skeletonInfo_script.KneeRightPos.y) < 0.05f)
                        {
                            if (Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.z - this.skeletonInfo_script.KneeRightPos.z) < 0.05f)
                            {
                                print("RightDown");
                                this.currentfeetState = FeetState.RightDown;
                                this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                            }
                        }
                        break;

                    case FeetState.RightDown:
                        if (this.skeletonInfo_script.HipLeftPos.y - this.skeletonInfo_script.KneeLeftPos.y < this.Knne_Hip_Delta)
                        {
                            print("LeftRaise");
                            this.currentfeetState = FeetState.LeftRaise;
                            //this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                        }
                        break;

                    case FeetState.LeftRaise:
                        print(Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.y - this.skeletonInfo_script.KneeRightPos.y).ToString() + "," + Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.z - this.skeletonInfo_script.KneeRightPos.z).ToString());

                        if (Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.y - this.skeletonInfo_script.KneeRightPos.y) < 0.05f)
                        {
                            if (Mathf.Abs(this.skeletonInfo_script.KneeLeftPos.z - this.skeletonInfo_script.KneeRightPos.z) < 0.05f)
                            {
                                print("LeftDown");
                                this.currentfeetState = FeetState.LeftDown;
                                this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                            }
                        }
                        break;

                    case FeetState.LeftDown:
                        if (this.skeletonInfo_script.HipRightPos.y - this.skeletonInfo_script.KneeRightPos.y < this.Knne_Hip_Delta)
                        {
                            print("RightRaise");
                            this.currentfeetState = FeetState.RightRaise;
                            //this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
                        }
                        break;
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, this.AddSpeed));
            }
        }
    }
}