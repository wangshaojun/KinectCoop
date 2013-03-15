using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �ĤG��-���a�籼���Ǫ��B�z
/// </summary>
public class PlayerDestroyEnemy_Stage2 : MonoBehaviour
{
    public StageData stageData;
    public float DetectDistance = 1;    //�������Z��
    public LayerMask EnemyLayer;        //�ĤH��Layer
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(this.transform.position, this.DetectDistance, this.EnemyLayer))
        {
            foreach (var collider in Physics.OverlapSphere(this.transform.position, this.DetectDistance, this.EnemyLayer))
            {
                //(������) ���ӳo�̼g�籼���ê��P�_
                if (Input.GetKeyUp(KeyCode.B))
                {
                    Destroy(collider.gameObject);
                    this.stageData.PositiveScore++;
                }
                //-----------------------------
            }
        }

    }

    void OnDrawGizmos()
    {
        //�e�X�������
        Gizmos.DrawWireSphere(this.transform.position, this.DetectDistance);
    }
}