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

    public Texture HintTexture;
    public Color HintColor;

    public GUIStyle style;

    private float addValue;
    private Vector3 originPosition;

    public CalculateScore_Stage2 CalculateScore_Script;
    public LayerMask PlayerLayer;        //玩家的Layer

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            this.CalculateScore_Script.TouchObstacleCount++;
            other.transform.position -= new Vector3(0, 0, 3);
        }
    }

    // Use this for initialization
    void Start()
    {
        this.originPosition = this.transform.position;
        this.addValue = Random.value * this.MoveDistance;
        if (this.CalculateScore_Script == null)
            this.CalculateScore_Script = GameObject.Find("CalculateScore").GetComponent<CalculateScore_Stage2>();
    }

    // Update is called once per frame
    void Update()
    {
        //當玩家靠近時出現提示
        if (Mathf.Abs(this.Player.transform.position.z - this.transform.position.z) < 5)
            this.isTip = true;
        else
            this.isTip = false;

        //控制物體移動
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

        this.style.normal.textColor = this.HintColor;
        this.transform.position = new Vector3(this.originPosition.x, this.originPosition.y - this.addValue, this.originPosition.z);
    }

    void OnGUI()
    {
        GUI.color = this.HintColor;
        //提示的UI
        if (this.isTip)
            GUI.Box(new Rect(
                Screen.width * TipRect.x, Screen.height * TipRect.y, Screen.width * TipRect.width, Screen.height * TipRect.height),
                this.HintTexture,
                this.style);
    }
}
