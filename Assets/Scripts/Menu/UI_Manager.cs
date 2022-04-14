using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Panels")] 
    [SerializeField] private Transform mainPanel;
    [SerializeField] private Transform optionPanel;
    [SerializeField] private Transform creditsPanel;
    
    [Header("Buttons")]
    [SerializeField] private Button playBtn;
    [SerializeField] private Button optionsBtn;
    [SerializeField] private Button creditsBtn;
    [SerializeField] private Button quitBtn;
    
    void Start()
    {
        playBtn.onClick.AddListener(GoToGameScene);
        optionsBtn.onClick.AddListener(GoToOption);
        creditsBtn.onClick.AddListener(GoToCredits);
        quitBtn.onClick.AddListener(QuitGame);
        
    }
    
    void GoToGameScene()
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex: 1);
    }

    void GoToOption()
    { 
        optionPanel.gameObject.SetActive(true);
    }

    void GoToCredits()
    {
        creditsPanel.gameObject.SetActive(true);
    }

    void QuitGame()
    {
        Application.Quit();
    }
    
}
