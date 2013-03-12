using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RichText : MonoBehaviour {


    struct RichTextStruct
    {
        public string Text;
        string fontSize;
        string Color;
        public string Combine;
        public RichTextStruct(string Text = "None", string fontSize = "10", string Color = "#FFFFFFFF")
        {
            this.Text = Text;
            this.fontSize = fontSize;
            this.Color = Color;
            this.Combine = "<size=" + fontSize + "> <color=" + Color + ">" + Text + "</color> </size>";
        }
    }

    private ArrayList RichTextArrayList;
	// Use this for initialization
	void Awake () {

        RichTextArrayList = new ArrayList();
        RichTextStruct text = new RichTextStruct("SSS","10","#FF0000FF");
        RichTextArrayList.Add(text);
        text = new RichTextStruct("SSSS", "10", "#FF0000FF");
        RichTextArrayList.Add(text);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool ChkisValid(string str)
    {
        for (int i = 0; i < RichTextArrayList.Count; i++)
        {
            if (str == ((RichTextStruct)RichTextArrayList[i]).Text)
            {
                print(((RichTextStruct)RichTextArrayList[i]).Combine);
                return true;
            }
        }
        return false;

    }
}
