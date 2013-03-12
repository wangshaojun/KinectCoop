using UnityEngine;
using System.Collections;

/// <summary>
/// 取得使用者的資料
/// </summary>
public class GetPlayerInfo : MonoBehaviour {


    public DataCollection dataCollection;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("DataCollection"))
            dataCollection = GameObject.Find("DataCollection").GetComponent<DataCollection>();
        else
            Debug.LogWarning("沒有載入 DataCollection");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
