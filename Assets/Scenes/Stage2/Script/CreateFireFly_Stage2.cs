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
        Instantiate(this.FireFly,
            this.CreatePoints[Random.Range(0, this.CreatePoints.Length)].position,
            this.FireFly.transform.rotation);
    }

    void OnDrawGizmos()
    {
        //�e�X�������
        foreach (var obj in this.CreatePoints)
            Gizmos.DrawWireSphere(obj.position, 1);
    }
}