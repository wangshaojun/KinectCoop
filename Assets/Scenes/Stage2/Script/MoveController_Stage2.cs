using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-Kinect���B�z(����H���e�i)
/// </summary>
public class MoveController_Stage2 : MonoBehaviour
{
    private SkeletonInformation skeletonInfo_script;    //Kinect���[��T
    public GameObject skeletonInfoObject;

    // Use this for initialization
    void Start()
    {
        this.skeletonInfo_script = this.skeletonInfoObject.GetComponent<SkeletonInformation>();
    }

    // Update is called once per frame
    void Update()
    {

        //�T�{��O�_���|
        if (Mathf.Abs(this.skeletonInfo_script.HandLeftPos.y - this.skeletonInfo_script.ShoulderLeftPos.y) < 0.1f &&
            Mathf.Abs(this.skeletonInfo_script.HandRightPos.y - this.skeletonInfo_script.ShoulderRightPos.y) < 0.1f)
        {
            //(������) Kinect�������a���B�z
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