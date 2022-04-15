using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void ActivateTheBehaviourOfButton()
    {
        FindObjectOfType<SceneChanger>().LoadNextScene();
    }
}
