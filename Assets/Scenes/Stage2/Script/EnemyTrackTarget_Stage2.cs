using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-敵人移動軌跡的處理
/// </summary>
public class EnemyTrackTarget_Stage2 : MonoBehaviour
{
    public float TrackSpeed;        //追蹤玩家的速度
    private Transform Target;    //目標點

    // Use this for initialization
    void Start()
    {
    }

    public void SetTargetPoints(Transform target)
    {
        this.Target = target;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            Mathf.Lerp(this.transform.position.x, this.Target.position.x, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.y, this.Target.position.y, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.z, this.Target.position.z, this.TrackSpeed * Time.deltaTime));
    }
}