using UnityEngine;
using System.Collections;

public class DetectSkeletonisEnable : MonoBehaviour {

    public SkeletonWrapper skeletonWrapper;
    private bool _skeletonIsEnable = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
        //如果抓不到骨架
        if (skeletonWrapper.trackedPlayers[0] == -1)
            _skeletonIsEnable = false;
        else
            _skeletonIsEnable = true;
        

        
        if (_skeletonIsEnable)
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        else
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        
	}
}
