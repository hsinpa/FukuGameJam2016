using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonGM : MonoBehaviour {

    public string MainMeun;
    public string This;

    public AudioSource AS;
    public AudioClip[] SX;



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

    public void Hil()
    {
        AudioSource A = gameObject.GetComponent<AudioSource>();
        A.PlayOneShot(SX[0]);
    }

    public void Pre()
    {
        AudioSource A = gameObject.GetComponent<AudioSource>();
        A.PlayOneShot(SX[1]);
    }
}
