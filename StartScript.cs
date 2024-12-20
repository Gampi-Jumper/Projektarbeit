using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public AudioSource click;
    public AudioSource whoosh;

    public Animation buttonUpAnim;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CoroutineGoToGameScene()
    {
        StartCoroutine(StartGameScene());
    }

    IEnumerator StartGameScene()
    {
        click.Play();
        whoosh.Play();
        buttonUpAnim.Play("ButtonUp");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
}
