using UnityEngine;
using System.Collections;

public class Digletts: MonoBehaviour {

    public float Interval = 5; //兩次出現的間隔時間
    public float Stay = 5;     //出現後的等待時間

    private int oldValue;
    private float addTime;
    public AudioClip Appear;
    public AudioClip Die;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        int newValue = RandomValue(oldValue);
        

        if (newValue >= 0)
        {
            oldValue = newValue;
            transform.GetChild(newValue).SendMessage("AnimationActive");
            transform.GetChild(newValue).audio.PlayOneShot(Appear);
        }
	}


    int RandomValue(int oldValue)
    {
        int newValue;

        addTime += Time.deltaTime;
        if (addTime > Interval)
        {
            addTime = 0;
            do
            {
                newValue = Random.Range(0, 8);
            }
            while (oldValue == newValue);
            return  newValue;
        }
        return -1;
        
    }
}
