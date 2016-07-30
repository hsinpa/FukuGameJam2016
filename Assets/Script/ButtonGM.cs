using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonGM : MonoBehaviour {

    public string MainMeun;
    public string This;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frameb
	void Update () {
	
	}

    public void St()
    {
        SceneManager.LoadScene(This);
    }

    public void MainM()
    {
        SceneManager.LoadScene(MainMeun);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
