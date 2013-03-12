using UnityEngine;
using System.Collections;

public class TextField : MonoBehaviour {

    //視窗大小
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //介面皮膚
    public GUISkin guiSkin;

    //按鈕的Rectangle
    public Rect TextFieldRect;

    //按鈕上的文字
    public string TextFieldText;

    //文字大小 - 依據1280為基準
    public int FontSize;

	// Use this for initialization
	void Start () {
        if (!guiSkin)               Debug.LogWarning(this.name + "-guiSkin" + "-Unset");
        if (FontSize == 0)          Debug.LogWarning(this.name + "-FontSize" + "-Unset");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        if (guiSkin)
            GUI.skin = this.guiSkin;

        Rect rect = new Rect(TextFieldRect.x * _ScreenSize.x
                        , TextFieldRect.y * _ScreenSize.y
                        , TextFieldRect.width * _ScreenSize.x
                        , TextFieldRect.height * _ScreenSize.y);

        GUI.skin.textField.fontSize = (int)((_ScreenSize.x / 1280) * FontSize);

        TextFieldText = GUI.TextField(rect, TextFieldText);
    }

    /// <summary>
    /// 清除字串
    /// </summary>
    public void Clear()
    {
        TextFieldText = "";
    }
}
