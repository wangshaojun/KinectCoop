using UnityEngine;
using System.Collections;

public class AudioPlayOneShot : MonoBehaviour {

    public AudioClip[] Audio;
    public int audioCount;
    public bool playOneShot;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
      
        if (playOneShot)
        {
            playOneShot = false;
            if(Audio[audioCount] && !this.audio.isPlaying)
            {
                this.audio.Stop();
                PlayAudio(audioCount);
            }
        }
	}



    public void PlayAudio(int _audioCount)
    {
        this.audio.PlayOneShot(Audio[_audioCount]);
    }
}
