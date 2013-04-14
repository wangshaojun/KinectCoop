using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stage2 - 盎代ゼ砆產╃阑们
/// </summary>
public class DetectMissFirefly_Stage2 : MonoBehaviour
{
    public float destroyTime = 5;       //綪反丁
    public LayerMask EnemyLayer;        //寄Layer

    private List<GameObject> destroyObjestList { get; set; }

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.EnemyLayer.value) > 0)
        {
            CalculateScore_Stage2.MissFireflyCount++;

            //⊿Τゴ奔们﹚丁(destroyTime)綪反
            this.destroyObjestList.Add(other.gameObject);
            Invoke("AutoDestroy", this.destroyTime);
        }
    }

    /// <summary>
    /// 綪反ン
    /// </summary>
    void AutoDestroy()
    {
        Destroy(this.destroyObjestList[0]);
        this.destroyObjestList.RemoveAt(0);
    }

    // Use this for initialization
    void Start()
    {
        this.destroyObjestList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
