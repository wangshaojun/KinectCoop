using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-處理進入障礙物的範圍內(提示UI、控制人物可跳躍)
/// </summary>
public class Obstacle_Stage2_Old : MonoBehaviour
{
    public GameObject Player;       //玩家控制的人物

    private bool isTip = false;     //是否顯示提示UI

    public Rect TipRect;            //提示UI的Rect

    public Color HintTextColor;
    
    public GUIStyle style;

    /// <summary>
    /// 當玩家進入障礙物範圍時...
    /// </summary>
    /// <param name="other">進入的物體</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(this.Player))   //判斷是否為玩家控制的人物
        {
            this.isTip = true;
        }
    }

    /// <summary>
    /// 當玩家離開障礙物範圍時...
    /// </summary>
    /// <param name="other">離開的物體</param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(this.Player))   //判斷是否為玩家控制的人物
        {
            this.isTip = false;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isTip)
        {
            //(未完成) 處理玩家進入提示後的反應
            if (Input.GetKeyUp(KeyCode.G))
            {
                this.Player.rigidbody.velocity = new Vector3(0, 6, 6);
                //this.Player.transform.Translate(0, 4, 4);
            }
            this.style.normal.textColor = this.HintTextColor;
        }
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
