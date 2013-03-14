using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 第二關-拍掉火蠅的處理
/// </summary>
public class DestroyEnemy_Stage2 : MonoBehaviour
{
    public float DetectDistance = 1;    //偵測的距離
    public LayerMask EnemyLayer;        //敵人的Layer
    
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
                //(未完成) 未來這裡寫拍掉火螢的判斷
                if (Input.GetKeyUp(KeyCode.B))
                {
                    Destroy(collider.gameObject);
                }
                //-----------------------------
            }
        }
    }

    void OnDrawGizmos()
    {
        //畫出偵測邊界
        Gizmos.DrawWireSphere(this.transform.position, this.DetectDistance);
    }
}