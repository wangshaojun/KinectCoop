using UnityEngine;
using System.Collections;

public class LightningBugPath : MonoBehaviour
{
    public GameObject HandGlideColliderObj;
    public GameObject ObjInTriggerPos;

    float Bug_P_X, Bug_P_Y, Bug_P_Z, Glide_P_X, Glide_P_Y, Glide_P_Z;
    float Dis_X, Dis_Y, Dis_Z;
    public float BugSpeedRate;

    public enum Rotat
    { 
        right,left
    }
    public Rotat rotat;

    // Use this for initialization
    void Start()
    {
        HandGlideColliderObj = GameObject.Find("Hand_GlidBody");
        ObjInTriggerPos = GameObject.Find("ObjInTrigger");

        Glide_P_X = HandGlideColliderObj.transform.position.x;
        Glide_P_Y = HandGlideColliderObj.transform.position.y;
        Glide_P_Z = HandGlideColliderObj.transform.position.z;

        Bug_P_X = this.gameObject.transform.position.x;
        Bug_P_Y = this.gameObject.transform.position.y;
        Bug_P_Z = this.gameObject.transform.position.z;

        Dis_X = Glide_P_X - Bug_P_X;
        Dis_Y = Glide_P_Y - Bug_P_Y;
        Dis_Z = Glide_P_Z - Bug_P_Z;

        if (rotat == Rotat.right)
        {
            this.gameObject.transform.eulerAngles = new Vector3(HandGlideColliderObj.transform.eulerAngles.x + Mathf.Atan(Dis_Y / Mathf.Sqrt(Mathf.Pow(Dis_Z, 2) + Mathf.Pow(Dis_X, 2))) * 180 / Mathf.PI,
                HandGlideColliderObj.transform.eulerAngles.y + Vector2.Angle(new Vector2((ObjInTriggerPos.transform.position.x - HandGlideColliderObj.transform.position.x), (ObjInTriggerPos.transform.position.z - HandGlideColliderObj.transform.position.z)),
                new Vector2((this.transform.position.x - HandGlideColliderObj.transform.position.x), (this.transform.position.z - HandGlideColliderObj.transform.position.z))),
                this.transform.rotation.z);
        }
        else
        {
            this.gameObject.transform.eulerAngles = new Vector3(HandGlideColliderObj.transform.eulerAngles.x + Mathf.Atan(Dis_Y / Mathf.Sqrt(Mathf.Pow(Dis_Z, 2) + Mathf.Pow(Dis_X, 2))) * 180 / Mathf.PI,
                HandGlideColliderObj.transform.eulerAngles.y - Vector2.Angle(new Vector2((ObjInTriggerPos.transform.position.x - HandGlideColliderObj.transform.position.x), (ObjInTriggerPos.transform.position.z - HandGlideColliderObj.transform.position.z)),
                new Vector2((this.transform.position.x - HandGlideColliderObj.transform.position.x), (this.transform.position.z - HandGlideColliderObj.transform.position.z))),
                this.transform.rotation.z);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(Dis_X * Time.deltaTime * BugSpeedRate, Dis_Y * Time.deltaTime * BugSpeedRate,
            Dis_Z * Time.deltaTime * BugSpeedRate);
    }
}
