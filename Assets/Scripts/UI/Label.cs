using UnityEngine;
using System.Collections;

public class Label : MonoBehaviour {

    //視窗大小
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //介面皮膚
    public GUISkin guiSkin;

    //按鈕的Rectangle
    public Rect LabelRect;

    //按鈕上的文字
    public string LabelText;

    //文字大小 - 依據1280為基準
    public int FontSize;

    //文字顏色
    public Color TextColor = Color.white;

	// Use this for initialization
    void Start () {
        if (!guiSkin)       Debug.LogWarning(this.name + "-guiSkin" + "-Unset");
        if (FontSize == 0)  Debug.LogWarning(this.name + "-FontSize" + "-Unset");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (guiSkin)
            GUI.skin = this.guiSkin;

        Rect rect = new Rect(LabelRect.x * _ScreenSize.x
                        , LabelRect.y * _ScreenSize.y
                        , LabelRect.width * _ScreenSize.x
                        , LabelRect.height * _ScreenSize.y);

        GUI.skin.label.fontSize = (int)((_ScreenSize.x / 1280) * FontSize);

        GUI.skin.label.normal.textColor = TextColor;

        GUI.Label(rect, LabelText);
    }

}
