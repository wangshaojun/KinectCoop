using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stage2 - �������Q���a����������
/// </summary>
public class DetectMissFirefly_Stage2 : MonoBehaviour
{
    public float destroyTime = 5;       //�P���ɶ�
    public LayerMask EnemyLayer;        //�ĤH��Layer

    private List<GameObject> destroyObjestList { get; set; }

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.EnemyLayer.value) > 0)
        {
            CalculateScore_Stage2.MissFireflyCount++;

            //�S�����������Ǥ@�w�ɶ���(destroyTime)�P��
            this.destroyObjestList.Add(other.gameObject);
            Invoke("AutoDestroy", this.destroyTime);
        }
    }

    /// <summary>
    /// �P������\��
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
