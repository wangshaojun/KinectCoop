using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�N�W�X��ɪ�����R��
/// </summary>
public class BorderDestroy_Stage2 : MonoBehaviour
{
    public float DestroyRadius = 5;     //��ɲy�Ϊ��b�|
    public LayerMask DestroyLayer;
    
    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        //�T�{�O�_������i�J�d��
        if (Physics.CheckSphere(this.transform.position, this.DestroyRadius, this.DestroyLayer))
        { 
            //�R���i�J�d�򤺪�����
            foreach (var obj in Physics.OverlapSphere(this.transform.position, this.DestroyRadius, this.DestroyLayer))
                Destroy(obj.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        //�e�X�������
        Gizmos.DrawWireSphere(this.transform.position, this.DestroyRadius);
    }
}
