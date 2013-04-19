using UnityEngine;
using System.Collections;

public class MovieClipPlay : MonoBehaviour
{

    public Camera gameCamera;

    public GameObject[] Others;
    public GameObject movieClip;
    public MovieTexture movieTexture;
    // Use this for initialization
    void Start()
    {
        movieTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (movieTexture.isPlaying)
        {
            if (gameCamera) gameCamera.gameObject.SetActive(false);
            foreach (GameObject gameObject in Others)
                gameObject.SetActive(false);
            Time.timeScale = 0.00000001F;
        }
        else
        {
            if (gameCamera) gameCamera.gameObject.SetActive(true);
            foreach (GameObject gameObject in Others)
                gameObject.SetActive(true);

            movieClip.SetActive(false);
            Time.timeScale = 1F;
        }

    }
}
