using UnityEngine;
using System.Collections;

public class DetectSkeletonisEnable : MonoBehaviour
{
    public SkeletonWrapper skeletonWrapper;
    public bool SkeletonIsEnable = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�p�G�줣�착�[
        if (this.skeletonWrapper.trackedPlayers[0] == -1)
        {
            this.SkeletonIsEnable = false;
        }
        else
        {
            this.SkeletonIsEnable = true;
        }


        if (SkeletonIsEnable)
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        else
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}