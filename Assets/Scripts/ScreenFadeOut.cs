using UnityEngine;

public class ScreenFadeOut : MonoBehaviour
{
    public GameObject sceneChange;

    public void ScreenFadeOver()
    {
        sceneChange.GetComponent<SceneChange>().ScreenFadeOver();
    }
}
