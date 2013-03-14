using UnityEngine;
using System.Collections;

/// <summary>
/// 第二關-距離提示條的UI
/// </summary>
public class DistanceHintUI_Stage2 : MonoBehaviour
{
    public Rect DistanceHintRect;           //距離提示條的Rectangle

    public GameObject MoverObject;          //移動的物件
    public GameObject EndPositionObject;    //終點物件

    public Texture DistanceHintBoxTexture;  //提示距離條的貼圖
    public Texture ArrowTexture;            //箭頭的貼圖

    public float ArrowStartPosX;            //提示箭頭開始的位置
    public float ArrowWidth = 25;           //提示箭頭的大小
    public GUIStyle style;

    private Vector2 screenSize;             //視窗大小
    private float totalDistance;            //總長度
    private float arrowCurrentPosX;         //箭頭當前的位置

    // Use this for initialization
    void Start()
    {
        //計算總長度
        this.totalDistance = Vector3.Distance(this.MoverObject.transform.position, this.EndPositionObject.transform.position);

        this.arrowCurrentPosX = this.ArrowStartPosX;
    }

    // Update is called once per frame
    void Update()
    {
        this.screenSize = new Vector2(Screen.width, Screen.height);     //抓當前螢幕大小

        float distanceHintBoxTextureWidth;
        distanceHintBoxTextureWidth = this.DistanceHintRect.width * this.screenSize.x;
        this.arrowCurrentPosX = Mathf.Lerp(this.ArrowStartPosX - (this.ArrowWidth / 2), this.ArrowStartPosX + distanceHintBoxTextureWidth - this.ArrowWidth, 1 - Vector3.Distance(this.MoverObject.transform.position, this.EndPositionObject.transform.position) / this.totalDistance);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(this.arrowCurrentPosX, this.DistanceHintRect.y * this.screenSize.y - this.ArrowWidth, this.ArrowWidth, this.ArrowWidth), this.ArrowTexture, this.style);

        GUI.Box(new Rect(this.DistanceHintRect.x * this.screenSize.x, this.DistanceHintRect.y * this.screenSize.y, this.DistanceHintRect.width * this.screenSize.x, this.DistanceHintRect.height * this.screenSize.y),
                        this.DistanceHintBoxTexture,
                        this.style);
    }
}