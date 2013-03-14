using UnityEngine;
using System.Collections;

public class Texture_2D : MonoBehaviour {

    //�����j�p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //���s��Rectangle
    public Rect LabelRect;

    //�Ϯ�
    public Texture Texture2d;

    //�Ϯ��C��
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
