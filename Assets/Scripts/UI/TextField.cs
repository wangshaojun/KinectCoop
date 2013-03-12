using UnityEngine;
using System.Collections;

public class TextField : MonoBehaviour {

    //�����j�p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //�����ֽ�
    public GUISkin guiSkin;

    //���s��Rectangle
    public Rect TextFieldRect;

    //���s�W����r
    public string TextFieldText;

    //��r�j�p - �̾�1280�����
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
    /// �M���r��
    /// </summary>
    public void Clear()
    {
        TextFieldText = "";
    }
}
