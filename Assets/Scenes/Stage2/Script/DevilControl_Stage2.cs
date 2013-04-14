using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�B�z�c�]������
/// </summary>
public class DevilControl_Stage2 : MonoBehaviour
{
    public float MoveDistance;
    public float MoveSpeed;
    public LayerMask PlayerLayer;        //���a��Layer

    private float addValue;
    private Vector3 originPosition;

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            CalculateScore_Stage2.TouchObstacleCount++;
            other.transform.position -= new Vector3(0, 0, 3);
        }
    }

    // Use this for initialization
    void Start()
    {
        this.originPosition = this.transform.position;
        this.addValue = Random.value * this.MoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.audio.isPlaying)
        {
            //����鲾��
            if (this.addValue > this.MoveDistance)
            {
                this.addValue = this.MoveDistance;
                this.MoveSpeed = -this.MoveSpeed;
            }
            else if (this.addValue < 0)
            {
                this.addValue = 0;
                this.MoveSpeed = -this.MoveSpeed;
                this.audio.Play();
            }
            this.addValue += this.MoveSpeed * Time.deltaTime;

            this.transform.position = new Vector3(this.originPosition.x, this.originPosition.y - this.addValue, this.originPosition.z);
        }
    }
}