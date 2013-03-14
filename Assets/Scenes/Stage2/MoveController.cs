using UnityEngine;
using System.Collections;


public class MoveController : MonoBehaviour
{
    private SkeletonInformation skeletonInfo_script;
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
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        { this.transform.rigidbody.AddForce(new Vector3(0, 0, 10)); }
        
    }
}
