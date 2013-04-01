using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�@�w�ɶ������ͤ���
/// </summary>
public class CreateFireFly_Stage2 : MonoBehaviour
{
    public GameObject FireFly;          //���Ǫ���

    public float CreateTimeMin = 1;     //�̤p�ͦ��ɶ�
    public float CreateTimeMax = 3;     //�̤j�ͦ��ɶ�

    public Transform[] CreatePoints;    //�ͦ��I(�i�]�w�h�ͦ��I)
    public Transform[] TargetPoints;    //�ؼ��I(�i�]�w�h�ؼ��I)

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�@�w�ɶ������ͤ���
        if (!IsInvoking("CreateEnemy"))
            this.Invoke("CreateEnemy", Random.Range(this.CreateTimeMin, this.CreateTimeMax));
    }

    /// <summary>
    /// ���ͤ��Ǩ禡
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
        //�e�X�������
        Gizmos.color = Color.blue;
        foreach (var obj in this.CreatePoints)
            Gizmos.DrawWireSphere(obj.position, 1);

        Gizmos.color = Color.red;

        foreach (var obj in this.TargetPoints)
            Gizmos.DrawWireSphere(obj.position, 1);
    }
}