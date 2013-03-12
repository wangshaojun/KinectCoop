using UnityEngine;
using System.Collections;

public class SavePlayerName : MonoBehaviour {

    public DataCollection dataCollection;
    public TextField nameTextfield;

	// Use this for initialization
	void Start () {
        dataCollection.PlayerName = nameTextfield.TextFieldText;
        dataCollection.PlayerTotalScore = 0;
        dataCollection.StartTime = System.DateTime.Now.ToString(); // 取得系統時間

        PlayerPrefs.SetString("PlayerName", dataCollection.PlayerName);

        //進入Stage1
        Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
