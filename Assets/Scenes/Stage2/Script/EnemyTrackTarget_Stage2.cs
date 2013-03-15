using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-敵人移動軌跡的處理
/// </summary>
public class EnemyTrackTarget_Stage2 : MonoBehaviour
{
    public float TrackSpeed;    //追蹤玩家的速度
    private Transform[] Targets;  //玩家

    // Use this for initialization
    void Start()
    {
    }

    public void SetTargetPoints(Transform[] targets)
    {
        this.Targets = targets;
    }

    // Update is called once per frame
    void Update()
    {
        int random = Random.Range(0, Targets.Length);
        this.transform.position = new Vector3(
            Mathf.Lerp(this.transform.position.x, this.Targets[random].position.x, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.y, this.Targets[random].position.y, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.z, this.Targets[random].position.z, this.TrackSpeed * Time.deltaTime));
    }
}