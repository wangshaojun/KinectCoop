using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �ĤG��-���a�籼���Ǫ��B�z
/// </summary>
public class PlayerDestroyEnemy_Stage2 : MonoBehaviour
{
    public CalculateScore_Stage2 CalculateScore_Script;
    public LayerMask EnemyLayer;        //�ĤH��Layer

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.EnemyLayer.value) > 0)
        {
            Destroy(other.gameObject);
            this.CalculateScore_Script.KillFireflyCount++;
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