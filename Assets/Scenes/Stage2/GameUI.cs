using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public GameObject Mover;
    public GameObject EndPos;
    private float Distance;
    
    public Texture PosTexture;
    public Texture ArrowTexture;
    private float CurrentPosX;

    public float PosTextureWidth = 500;
    public float StartPosX = 50;
    private float arrowWidth = 25;
    public GUIStyle style;
    // Use this for initialization
    void Start()
    {
        this.Distance = Vector3.Distance(this.Mover.transform.position, this.EndPos.transform.position);
        this.CurrentPosX = this.StartPosX;
    }

    // Update is called once per frame
    void Update()
    {

        this.CurrentPosX = Mathf.Lerp(this.StartPosX - (this.arrowWidth / 2), this.StartPosX + this.PosTextureWidth - (this.arrowWidth / 2), 1 - Vector3.Distance(this.Mover.transform.position, this.EndPos.transform.position) / this.Distance);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(this.CurrentPosX, 50, this.arrowWidth, this.arrowWidth), this.ArrowTexture, this.style);
        GUI.Box(new Rect(50, 75, 500, 100), this.PosTexture, this.style);

        //GUILayout.BeginVertical();
        //{

        //    GUILayout.Space(Screen.height * 0.05f);
        //    GUILayout.BeginHorizontal();
        //    {
        //        GUILayout.Space(Screen.width * 0.05f);
        //        GUILayout.BeginVertical();
        //        {
        //            GUILayout.Box(this.ArrowTexture,this.style,GUILayout.Width(Screen.width * 0.05f));
        //            GUILayout.Box(this.PosTexture, this.style, GUILayout.Width(Screen.width * 0.8f), GUILayout.Height(Screen.height * 0.1f));
        //        }
        //        GUILayout.EndVertical();
        //    }
        //    GUILayout.EndHorizontal();
        //}
        //GUILayout.EndVertical();
    }
}