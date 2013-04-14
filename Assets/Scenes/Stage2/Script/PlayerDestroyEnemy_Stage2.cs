using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 第二關-玩家拍掉火蠅的處理
/// </summary>
public class PlayerDestroyEnemy_Stage2 : MonoBehaviour
{
    public LayerMask EnemyLayer;        //敵人的Layer

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.EnemyLayer.value) > 0)
        {
            Destroy(other.gameObject);
            this.audio.Play();      //電擊蟲被擊中音效
            CalculateScore_Stage2.KillFireflyCount++;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}