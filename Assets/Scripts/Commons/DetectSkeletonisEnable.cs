using UnityEngine;
using System.Collections;

public class DetectSkeletonisEnable : MonoBehaviour
{
    public SkeletonWrapper skeletonWrapper;
    public bool SkeletonIsEnable = false;
    public bool TimeScaleEnable = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果抓不到骨架
        if (this.skeletonWrapper.trackedPlayers[0] == -1)
        {
            this.SkeletonIsEnable = false;
            if (TimeScaleEnable)
                Time.timeScale = 0.00000001f;
        }
        else
        {
            this.SkeletonIsEnable = true;
            if (TimeScaleEnable)
                Time.timeScale = 1;
        }

        if (SkeletonIsEnable)
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        else
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}