using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�B�z�i�J��ê�����d��(����UI�B����H���i���D)
/// </summary>
public class Obstacle_Stage2 : MonoBehaviour
{
    public GameObject Player;       //���a����H��

    private bool isTip = false;     //�O�_��ܴ���UI

    public Rect TipRect;            //����UI��Rect

    public float MoveDistance;
    public float MoveSpeed;

    public Color HintTextColor;
    
    public GUIStyle style;

    private float addValue;
    private Vector3 originPosition;
    
    // Use this for initialization
    void Start()
    {
        this.originPosition = this.transform.position;
        this.addValue = Random.value * this.MoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.Player.transform.position.z - this.transform.position.z) < 5)
            this.isTip = true;

        else
            this.isTip = false;

        if (this.addValue > this.MoveDistance)
        {
            this.addValue = this.MoveDistance;
            this.MoveSpeed = -this.MoveSpeed;
        }
        else if (this.addValue < 0)
        {
            this.addValue = 0;
            this.MoveSpeed = -this.MoveSpeed;
        }
        this.addValue += this.MoveSpeed * Time.deltaTime;

        this.style.normal.textColor = this.HintTextColor;
        this.transform.position = new Vector3(this.originPosition.x, this.originPosition.y - this.addValue, this.originPosition.z);
    }

    void OnGUI()
    {
        //���ܪ�UI
        if (this.isTip)
            GUI.Box(new Rect(
                Screen.width * TipRect.x, Screen.height * TipRect.y, Screen.width * TipRect.width, Screen.height * TipRect.height),
                "�`�N�G����ê��",
                this.style);
    }
}
