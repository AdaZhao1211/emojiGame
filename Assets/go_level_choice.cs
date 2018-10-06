using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class go_level_choice : MonoBehaviour
{
    public Button lvmenuButton;
    public Button quitButton;
    // Use this for initialization
    void Start()
    {
        lvmenuButton.onClick.AddListener(() => LoadLevelPage());
        //quitButton.onClick.AddListener(() => Application.Quit());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LoadLevelPage()
    {
        SceneManager.LoadScene("level choose", LoadSceneMode.Single);
    }


}
