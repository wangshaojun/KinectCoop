using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�ĤH���ʭy�񪺳B�z
/// </summary>
public class EnemyTrackTarget_Stage2 : MonoBehaviour
{
    public float TrackSpeed;        //�l�ܪ��a���t��
    private Transform Target;    //�ؼ��I

    // Use this for initialization
    void Start()
    {
    }

    public void SetTargetPoints(Transform target)
    {
        this.Target = target;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            Mathf.Lerp(this.transform.position.x, this.Target.position.x, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.y, this.Target.position.y, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.z, this.Target.position.z, this.TrackSpeed * Time.deltaTime));
    }
}