using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-處理進入障礙物的範圍內(提示UI、控制人物可跳躍)
/// </summary>
public class Obstacle_Stage2 : MonoBehaviour
{
    public GameObject Player;       //玩家控制的人物

    private bool isTip = false;     //是否顯示提示UI

    public Rect TipRect;            //提示UI的Rect

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
        //提示的UI
        if (this.isTip)
            GUI.Box(new Rect(
                Screen.width * TipRect.x, Screen.height * TipRect.y, Screen.width * TipRect.width, Screen.height * TipRect.height),
                "注意：有障礙物",
                this.style);
    }
}
