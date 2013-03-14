using UnityEngine;
using System.Collections;

public class Texture_2D : MonoBehaviour {

    //視窗大小
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //按鈕的Rectangle
    public Rect LabelRect;

    //圖案
    public Texture Texture2d;

    //圖案顏色
    public Color TextureColor = Color.white;

	// Use this for initialization
    void Start () {
        if (!Texture2d) Debug.LogWarning(this.name + "-Texture2d" + "-Unset");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        Rect rect = new Rect(LabelRect.x * _ScreenSize.x
                        , LabelRect.y * _ScreenSize.y
                        , LabelRect.width * _ScreenSize.x
                        , LabelRect.height * _ScreenSize.y);

        GUI.color = TextureColor;
        GUI.DrawTexture(rect, Texture2d);

    }

}
