using UnityEngine;
using System.Collections;

public class DetectArm : MonoBehaviour {

    public GameObject DAGController;
    private SkeletonInformation DASkelForm;
    // Use this for initialization
    void Start()
    {
        DASkelForm = DAGController.GetComponent<SkeletonInformation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (DASkelForm.HandLeftPos.y < DASkelForm.ShoulderLeftPos.y || DASkelForm.HandRightPos.y < DASkelForm.ShoulderRightPos.y)
        {
            Time.timeScale = 0.00000001f;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
	}
}
