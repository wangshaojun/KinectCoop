using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-處理進入惡魔範圍內的提示UI
/// </summary>
public class DevilAppearHintUI_Stage2 : MonoBehaviour
{
    public Color HintColor;
    public float HintDistance;
    public GameObject Player;       //玩家控制的人物    
    public Texture HintTexture;
    public Rect TipRect;            //提示UI的Rect        
    public GUIStyle style;

    private Vector2 screenOffset;
    private Vector2 screenSize;             //視窗大小

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.screenSize = new Vector2((float)Screen.width / 1024.0f, (float)Screen.height / 768.0f);     //抓當前螢幕大小
    }

    void OnGUI()
    {
        GUI.color = this.HintColor;

        //提示的UI
        float distance = this.transform.position.z - this.Player.transform.position.z;
        if (distance < this.HintDistance && distance > -1)
            GUI.Box(new Rect(
                Screen.width * TipRect.x, Screen.height * TipRect.y, this.screenSize.x * this.HintTexture.width * TipRect.width, this.screenSize.y * this.HintTexture.height * TipRect.height),
                this.HintTexture,
                this.style);
    }
}
