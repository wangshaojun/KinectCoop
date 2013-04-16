using UnityEngine;
using System.Collections;

public class MovieSkip : MonoBehaviour {

    //µøµ¡¤j¤p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        if (GUI.Button(new Rect(0.9F * _ScreenSize.x, 0.9F * _ScreenSize.y, 0.05F * _ScreenSize.x, 0.05F * _ScreenSize.y), "Skip"))
            GetComponent<MovieClipPlay>().movieTexture.Stop();
    }
}
