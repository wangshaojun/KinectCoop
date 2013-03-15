using UnityEngine;
using System.Collections;

public class FeetMove : MonoBehaviour {

    public enum Feet { Left, Right };
    public Feet FeetType;
    public SkeletonInformation skeletonInformation;

    private Vector3 OrginalLocalPosition;
    public int ratio; //ºv≈T≠ø≤v≠»

	// Use this for initialization
	void Start () {
        this.OrginalLocalPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
    void Update()
    {
        //  this.transform.position = this.OrginalPosition;
        if (FeetType == Feet.Left)
            this.transform.localPosition = this.OrginalLocalPosition + new Vector3(skeletonInformation.FootLeftPos.x, skeletonInformation.FootLeftPos.z, this.transform.localPosition.z) * ratio;
        if (FeetType == Feet.Right)
            this.transform.localPosition = this.OrginalLocalPosition + new Vector3(skeletonInformation.FootRightPos.x, skeletonInformation.FootRightPos.z, this.transform.localPosition.z) * ratio;
    }
}
