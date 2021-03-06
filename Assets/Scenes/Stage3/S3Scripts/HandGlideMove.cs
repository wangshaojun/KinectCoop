using UnityEngine;
using System.Collections;

public class HandGlideMove : MonoBehaviour
{
    public GameObject HGMGController;
    private SkeletonInformation HGMSkelForm;
    public float HandGlideRotateY;
    // Use this for initialization
    void Start()
    {
        HGMSkelForm = HGMGController.GetComponent<SkeletonInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -1 * Time.deltaTime, 3 * Time.deltaTime);
        if (HGMSkelForm.HandRightPos.y > HGMSkelForm.ElbowRightPos.y &&
            HGMSkelForm.HandLeftPos.y > HGMSkelForm.ElbowLeftPos.y)
            this.transform.Rotate(0, -(HGMSkelForm.HandRightPos.y - HGMSkelForm.HandLeftPos.y) * this.HandGlideRotateY * Time.deltaTime, 0);
         if (Input.GetKey("left") ) {
              this.transform.Rotate(0, -45 * Time.deltaTime,0);
          }
          if (Input.GetKey("right"))
          {
              this.transform.Rotate(0, 45 * Time.deltaTime, 0);
          }
    }
}
