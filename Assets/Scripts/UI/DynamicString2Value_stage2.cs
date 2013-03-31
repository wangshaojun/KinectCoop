using UnityEngine;
using System.Collections;

public class DynamicString2Value_stage2 : MonoBehaviour {

    public Stage2Data StageData;

    //�����j�p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //�����ֽ�
    public GUISkin guiSkin;

    //���s��Rectangle
    public Rect LabelRect;

    //���s�W����r
    public string LabelText;

    //��r�j�p - �̾�1280�����
    public int FontSize;

    //��r�C��
    public Color TextColor = Color.white;

    //�Φr���@���_�Ө��o���
    public string Key;


	// Use this for initialization
	void Start () {
        if (!guiSkin) Debug.LogWarning(this.name + "-guiSkin" + "-Unset");
        if (FontSize == 0) Debug.LogWarning(this.name + "-FontSize" + "-Unset");
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

        if(PlayerPrefs.GetInt(StageData.stageName.ToString() + StageData.stageType.ToString() + Key).ToString() != "")
        LabelText = PlayerPrefs.GetInt(StageData.stageName.ToString() + StageData.stageType.ToString() + Key).ToString();

        //�]��PlayerPref�줣�줤�媺��
        if (Key == "PlayerName") LabelText = StageData.dataCollection.PlayerName;

        GUI.Label(rect, LabelText);

    }
}
