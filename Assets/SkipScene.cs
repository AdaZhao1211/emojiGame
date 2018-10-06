using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipScene : MonoBehaviour {
    public Button skipButton;
    public VideoPlayer _videoplayer;
	// Use this for initialization
	void Start () {
        skipButton.onClick.AddListener(() => LoadMainPage());
	}
	
	// Update is called once per frame
	void Update () {
		if(_videoplayer.isPlaying == false)
        {
            Debug.Log("finished");
            LoadMainPage();
        }
	}
    void LoadMainPage()
    {
        SceneManager.LoadScene("main menu", LoadSceneMode.Single);
    }
}
