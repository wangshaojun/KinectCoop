using UnityEngine;
using System.Collections;

/// <summary>
/// ���o�ϥΪ̪����
/// </summary>
public class GetPlayerInfo : MonoBehaviour {


    public DataCollection dataCollection;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("DataCollection"))
            dataCollection = GameObject.Find("DataCollection").GetComponent<DataCollection>();
        else
            Debug.LogWarning("�S�����J DataCollection");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
