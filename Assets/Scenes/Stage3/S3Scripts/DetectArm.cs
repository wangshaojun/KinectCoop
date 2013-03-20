using UnityEngine;
using System.Collections;

public class DetectArm : MonoBehaviour
{

    public GameObject DAGController;
    private SkeletonInformation DASkelForm;

    public DetectSkeletonisEnable detectSkeleton_script;
    // Use this for initialization
    void Start()
    {
        DASkelForm = DAGController.GetComponent<SkeletonInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.detectSkeleton_script.SkeletonIsEnable)
        {
            if (DASkelForm.HandLeftPos.y < DASkelForm.ShoulderLeftPos.y || DASkelForm.HandRightPos.y < DASkelForm.ShoulderRightPos.y)
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0.00000001f;
                
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Time.timeScale = 1;
                
            }
        }
    }
}
