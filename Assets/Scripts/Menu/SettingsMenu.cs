using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public List<Resolution> resolutions = new List<Resolution>();
    public Text qualityText;
    public Text resolutionText;
    

    public void Start()
    {
        SetQulityText(5);
        resolutionText.text = Screen.currentResolution.ToString();
    }

    public void SetQulityText(int qualityValue)
    {
        switch (qualityValue)
        {
            case 1:
                qualityText.text = "VERY LOW";
                break;
            case 2:
                qualityText.text = "LOW";
                break;
            case 3:
                qualityText.text = "MEDIUM";
                break;
            case 4:
                qualityText.text = "VERY HIGH";
                break;
            case 5:
                qualityText.text = "ULTRA";
                break;
        }
    }
    public void SetQualityToLower()
    {
        int qualityValue;
        qualityValue = QualitySettings.GetQualityLevel();
        if (qualityValue <= 0) return;
        QualitySettings.SetQualityLevel(--qualityValue);
        SetQulityText(qualityValue);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void SetQualityToHigher()
    {
        int qualityValue;
        qualityValue = QualitySettings.GetQualityLevel();
        if (qualityValue >= 5) return;
        QualitySettings.SetQualityLevel(++qualityValue);
        SetQulityText(qualityValue);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume" , volume);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public int resolutionIndex = 1;
    public int resWeidth;
    public int resHeight;


    public void SetHigherResolution()
    {
        resolutionIndex++;

        switch (resolutionIndex)
        {
            case 0:
                resWeidth = 1280;
                resHeight = 720;
                SetResolution();
                Debug.Log(resHeight + " " + resHeight);
                break;
            case 1:
                resWeidth = 1920;
                resHeight = 1080;
                SetResolution();
                Debug.Log(resHeight + " " + resHeight);
                break;
            case 2:
                resWeidth = 2560;
                resHeight = 1440;
                SetResolution();
                Debug.Log(resHeight + " " + resHeight);
                break;
        }
        while (resolutionIndex >= 2) return;

    }

    public void SetLowerResolution()
    {
        resolutionIndex--;
        switch (resolutionIndex)
        {
            case 0:
                resWeidth = 1280;
                resHeight = 720;
                SetResolution();
                Debug.Log(resHeight + " " + resHeight);
                break;
            case 1:
                resWeidth = 1920;
                resHeight = 1080;
                SetResolution();
                Debug.Log(resHeight + " " + resHeight);
                break;
            case 2:
                resWeidth = 2560;
                resHeight = 1440;
                SetResolution();
                Debug.Log(resHeight + " " + resHeight);
                break;
        }
        while (resolutionIndex <= 0) return ;

    }
    
    public void SetResolution()
    {
        Screen.SetResolution(resWeidth , resHeight, true);
        resolutionText.text = Screen.currentResolution.ToString();
    }
}
