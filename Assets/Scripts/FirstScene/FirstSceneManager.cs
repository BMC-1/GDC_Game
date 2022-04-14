using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    public static FirstSceneManager instance;
    [Header("Transforms")]
    public Transform deadPanel;

    [Header("Player On Scene")] 
    public Transform player;


    private void Awake()
    {
        instance = this;
    }

    public void PlayAgain()
    {
        //Reload Scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
