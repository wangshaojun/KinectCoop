using UnityEngine;
using System.Collections;

public class HandGlideBodyRotate : MonoBehaviour {
    public GameObject HGBRGController;
    private SkeletonInformation HGBRSkelForm;
    public float HandGlideAngelZ, HGAZ_Parameter;
    // Use this for initialization
    void Start()
    {   
        HGBRSkelForm = HGBRGController.GetComponent<SkeletonInformation>();
        HandGlideAngelZ = 0;
    }
	
	// Update is called once per frame
	void Update () {
        HandGlideAngelZ = (HGBRSkelForm.HandRightPos.y - HGBRSkelForm.HandLeftPos.y) * HGAZ_Parameter;
        this.gameObject.transform.Rotate(0, 0, HandGlideAngelZ);
	}
}
