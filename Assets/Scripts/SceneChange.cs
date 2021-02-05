using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private SceneTransition sceneTransition = SceneTransition.NONE;

    public ScreenFadeOut screenFadeOut;

    public void LoadManual()
    {
        sceneTransition = SceneTransition.MANUAL;
        screenFadeOut.gameObject.SetActive(true);
    }

    public void LoadStart()
    {
        sceneTransition = SceneTransition.START;
        screenFadeOut.gameObject.SetActive(true);
    }

    public void LoadTitle()
    {
        sceneTransition = SceneTransition.TITLE;
        screenFadeOut.gameObject.SetActive(true);
    }

    public void ScreenFadeOver()
    {
        switch (sceneTransition)
        {
            case SceneTransition.MANUAL:
                SceneManager.LoadScene("Manual");
                break;
            case SceneTransition.START:
                SceneManager.LoadScene("Game");
                break;
            case SceneTransition.TITLE:
                SceneManager.LoadScene("Title");
                break;
            default:
                break;
        }
    }

    private enum SceneTransition
    {
        NONE, MANUAL, START, TITLE
    }
}
