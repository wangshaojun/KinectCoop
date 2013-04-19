using UnityEngine;
using System.Collections;

public class CreateHeart : MonoBehaviour {

    //視窗大小
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);
    
    //StageData
    public StageData stageData;
    public Rect texRect;
    public Texture2D tex2D;
    public int heartCount; //心的數量

    //如果死亡
    public bool isLost;
    //Private 顯示介面
    private bool _isGUIEnable;
    //圖片間距
    private float _spacing;       
    private Vector2 _heartPosition;
	// Use this for initialization
	void Start () {
        _spacing = texRect.width;
	}

    // Update is called once per frame
    void Update()
    {
        if (stageData.stageType == DataCollection.StageType.Hard || stageData.stageType == DataCollection.StageType.Boss)
            _isGUIEnable = true;
        else
            _isGUIEnable = false;

        if (heartCount == 0)
            isLost = true;
        else
            isLost = false;
    }

    void OnGUI()
    {
        //如果GUI要顯示
        if (_isGUIEnable)
        {
            for (int i = 0; i < heartCount; i++)
            {
                Rect rect = new Rect(texRect.x * _ScreenSize.x - _spacing * i * _ScreenSize.x
                                , texRect.y * _ScreenSize.y
                                , texRect.width * _ScreenSize.x
                                , texRect.height * _ScreenSize.y);
                GUI.DrawTexture(rect, tex2D);
            }
        }
    }
        
}
