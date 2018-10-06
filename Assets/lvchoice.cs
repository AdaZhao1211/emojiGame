using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class lvchoice : MonoBehaviour {
    public Button levelButton;

    public Button introButton;
    public Button quitButton;
	// Use this for initialization
	void Start () {
        if(staticValue.levelValue == 0)
        {
            levelButton.onClick.AddListener(() => LoadLevelPage());
            introButton.onClick.AddListener(() => LoadIntroPage());
            quitButton.onClick.AddListener(() => Application.Quit());
        }
        
        if(staticValue.levelValue == 1)
        {
            levelButton.GetComponent<Image>().color = Color.red;
            introButton.onClick.AddListener(() => LoadIntroPage());
            quitButton.onClick.AddListener(() => Application.Quit());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void LoadIntroPage()
    {
        SceneManager.LoadScene("video_intro", LoadSceneMode.Single);
    }
    void LoadLevelPage()
    {
        SceneManager.LoadScene("level 1", LoadSceneMode.Single);
    }

}
