using UnityEngine;
using System.Collections;

public class AudioPlayOneShot : MonoBehaviour {

    public AudioClip Audio;
    private bool isPlayed = false;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayed)
        {
            if (this.audio.isPlaying == false)
                ;// Destroy(this);
        }
	}



    public void PlayAudio()
    {
        isPlayed = true;
        if (!this.GetComponent<AudioSource>())
            this.gameObject.AddComponent<AudioSource>();

        this.audio.PlayOneShot(Audio);


    }
}
