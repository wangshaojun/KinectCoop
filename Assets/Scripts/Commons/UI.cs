using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {


    private Vector2 ScreenSize;

    public string StageName;
    public Rect StageName_Size;

    public bool isRichText;

    public RichText richText;
	// Use this for initialization
	void Start () {
        
        if (isRichText)
            print(richText.ChkisValid(StageName));
	
	}
	
	// Update is called once per frame
	void Update () {

        //string Username = PlayerPrefs.GetString("Username");
        //print(PlayerPrefs.GetString("Username"));
	}


    void OnGUI()
    {
        
        ScreenSize = new Vector2(Screen.width, Screen.height);

        Rect StageName_SizeLabel = new Rect(StageName_Size.x * ScreenSize.x,
                                            StageName_Size.y * ScreenSize.y,
                                            StageName_Size.width * ScreenSize.x,
                                            StageName_Size.height * ScreenSize.y);


        GUI.Label(StageName_SizeLabel, StageName);


    }
}
