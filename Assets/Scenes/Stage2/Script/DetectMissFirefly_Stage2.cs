using UnityEngine;
using System.Collections;

/// <summary>
/// Stage2 - 偵測未被玩家拍擊的火蠅
/// </summary>
public class DetectMissFirefly_Stage2 : MonoBehaviour
{
    public CalculateScore_Stage2 CalculateScore_Script;
    public LayerMask EnemyLayer;        //敵人的Layer

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.EnemyLayer.value) > 0)
        {
            this.CalculateScore_Script.MissFireflyCount++;
        }
    }

    // Use this for initialization
    void Start()
    {
        if (this.CalculateScore_Script == null)
            this.CalculateScore_Script = GameObject.Find("CalculateScore").GetComponent<CalculateScore_Stage2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
