using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�ĤH���ʭy�񪺳B�z
/// </summary>
public class EnemyTrackTarget_Stage2 : MonoBehaviour
{
    public float TrackSpeed;    //�l�ܪ��a���t��
    private Transform[] Targets;  //���a

    // Use this for initialization
    void Start()
    {
    }

    public void SetTargetPoints(Transform[] targets)
    {
        this.Targets = targets;
    }

    // Update is called once per frame
    void Update()
    {
        int random = Random.Range(0, Targets.Length);
        this.transform.position = new Vector3(
            Mathf.Lerp(this.transform.position.x, this.Targets[random].position.x, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.y, this.Targets[random].position.y, this.TrackSpeed * Time.deltaTime),
            Mathf.Lerp(this.transform.position.z, this.Targets[random].position.z, this.TrackSpeed * Time.deltaTime));
    }
}