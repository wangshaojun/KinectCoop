using UnityEngine;
using System.Collections;

public class HandGlideBodyRotate : MonoBehaviour
{
    public GameObject HGBRGController;
    public GameObject HandGlideBody;
    private SkeletonInformation HGBRSkelForm;
    public float HandGlideAngelZ, HGAZ_Parameter;
    // Use this for initialization
    void Start()
    {
        HGBRSkelForm = HGBRGController.GetComponent<SkeletonInformation>();
        HandGlideAngelZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandGlideAngelZ = -(HGBRSkelForm.HandRightPos.y - HGBRSkelForm.HandLeftPos.y) * HGAZ_Parameter;
        if (HGBRSkelForm.HandRightPos.y > HGBRSkelForm.ElbowRightPos.y &&
            HGBRSkelForm.HandLeftPos.y > HGBRSkelForm.ElbowLeftPos.y)
            this.gameObject.transform.rotation = Quaternion.Euler(HandGlideBody.transform.eulerAngles.x + 330, HandGlideBody.transform.eulerAngles.y + 180, HandGlideAngelZ);
    }
}
