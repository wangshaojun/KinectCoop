using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-一定時間內產生火蠅
/// </summary>
public class CreateFireFly_Stage2 : MonoBehaviour
{
    public GameObject FireFly;          //火蠅物件

    public float CreateTimeMin = 1;     //最小生成時間
    public float CreateTimeMax = 3;     //最大生成時間

    public Transform[] CreatePoints;    //生成點(可設定多生成點)
    public Transform[] TargetPoints;    //目標點(可設定多目標點)

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //一定時間內產生火蠅
        if (!IsInvoking("CreateEnemy"))
            this.Invoke("CreateEnemy", Random.Range(this.CreateTimeMin, this.CreateTimeMax));
    }

    /// <summary>
    /// 產生火蠅函式
    /// </summary>
    void CreateEnemy()
    {
        int random = Random.Range(0, this.CreatePoints.Length);
        GameObject createObj = (GameObject)Instantiate(
            this.FireFly,
            this.CreatePoints[random].position,
            this.FireFly.transform.rotation);

        createObj.GetComponent<EnemyTrackTarget_Stage2>().SetTargetPoints(this.TargetPoints[random]);
    }

    void OnDrawGizmos()
    {
        //畫出偵測邊界
        Gizmos.color = Color.blue;
        foreach (var obj in this.CreatePoints)
            Gizmos.DrawWireSphere(obj.position, 1);

        Gizmos.color = Color.red;

        foreach (var obj in this.TargetPoints)
            Gizmos.DrawWireSphere(obj.position, 1);
    }
}