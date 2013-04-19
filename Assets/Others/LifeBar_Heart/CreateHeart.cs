using UnityEngine;
using System.Collections;

public class CreateHeart : MonoBehaviour {

    //�����j�p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);
    
    //StageData
    public StageData stageData;
    public Rect texRect;
    public Texture2D tex2D;
    public int heartCount; //�ߪ��ƶq

    //�p�G���`
    public bool isLost;
    //Private ��ܤ���
    private bool _isGUIEnable;
    //�Ϥ����Z
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
        //�p�GGUI�n���
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
