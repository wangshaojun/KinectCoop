using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-敵人追蹤玩家的處理
/// </summary>
public class EnemyTrackPlayer_Stage2 : MonoBehaviour
{
    public float TrackSpeed;    //追蹤玩家的速度
    private GameObject Player;  //玩家

    // Use this for initialization
    void Start()
    {
        this.Player = GameObject.Find("GamePlayer");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            Mathf.Lerp(this.transform.position.x, this.Player.transform.position.x, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.y, this.Player.transform.position.y, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.z, this.Player.transform.position.z, this.TrackSpeed * Time.deltaTime));
    }
}