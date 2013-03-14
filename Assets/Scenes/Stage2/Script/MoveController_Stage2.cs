using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-Kinect的處理(控制人物前進)
/// </summary>
public class MoveController_Stage2 : MonoBehaviour
{
    private SkeletonInformation skeletonInfo_script;    //Kinect骨架資訊
    public GameObject skeletonInfoObject;

    // Use this for initialization
    void Start()
    {
        this.skeletonInfo_script = this.skeletonInfoObject.GetComponent<SkeletonInformation>();
    }

    // Update is called once per frame
    void Update()
    {

        //確認手是否平舉
        if (Mathf.Abs(this.skeletonInfo_script.HandLeftPos.y - this.skeletonInfo_script.ShoulderLeftPos.y) < 0.1f &&
            Mathf.Abs(this.skeletonInfo_script.HandRightPos.y - this.skeletonInfo_script.ShoulderRightPos.y) < 0.1f)
        {
            //(未完成) Kinect偵測玩家的處理
            //-----------------------------
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            //this.transform.rigidbody.AddForce(new Vector3(0, 0, 10));
            this.transform.Translate(new Vector3(0, 0, 1));
            //this.transform.rigidbody.velocity += this.transform.TransformDirection(new Vector3(0, 0, 1));
        }
    }
}