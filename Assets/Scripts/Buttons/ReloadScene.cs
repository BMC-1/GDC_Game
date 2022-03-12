using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour
{
    private Button playAgain;
    
    void Start()
    {
        playAgain = GetComponent<Button>();
        playAgain.onClick.AddListener(ReloadCurrentScene);
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
