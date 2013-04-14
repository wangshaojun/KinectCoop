using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�B�z�i�J�c�]�d�򤺪�����UI
/// </summary>
public class DevilAppearHintUI_Stage2 : MonoBehaviour
{
    public Color HintColor;
    public float HintDistance;
    public GameObject Player;       //���a����H��    
    public Texture HintTexture;
    public Rect TipRect;            //����UI��Rect        
    public GUIStyle style;

    private Vector2 screenOffset;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this.style.normal.textColor = this.HintColor;
    }

    void OnGUI()
    {
        GUI.color = this.HintColor;

        //���ܪ�UI
        float distance = this.transform.position.z - this.Player.transform.position.z;
        if (distance < this.HintDistance && distance > -1)
            GUI.Box(new Rect(
                Screen.width * TipRect.x, Screen.height * TipRect.y, Screen.width * TipRect.width, Screen.height * TipRect.height),
                this.HintTexture,
                this.style);
    }
}
