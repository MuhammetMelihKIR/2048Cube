using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // PANELS
    [Header("PANEL")]
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _settingCanvas;
    [SerializeField] private GameObject _gameOverCanvas;

    //TEXTS
    [Header("TEXT")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI hsGameOverText;
    public TextMeshProUGUI scoreGameOverText;
  

    //TOGGLES
    [Header("TOGGLE")]
    [SerializeField]private Toggle _soundsToggle;
    [SerializeField]private Toggle _musicToggle;

    //BOOLS
    [Header("BOOL")]
    private bool _isPaused = true;
    [HideInInspector] public bool canTouch;


    
    
    private void Awake()
    {
       
        instance = this;
        
        
    }
    private void Start()
    {
        Time.timeScale = 1;
        canTouch= true;   
        _soundsToggle.isOn = true;
        _musicToggle.isOn = true;
    }
   
  
    
    public void GameOverPanel() 
    {
        Time.timeScale = 0;
        _gameOverCanvas.SetActive(true);
        _settingCanvas.SetActive(false);
        _gameCanvas.SetActive(false);
    }
    IEnumerator TouchDelay() 
    {
        yield return new WaitForSeconds(0.2f);
        canTouch = true;
    }

    #region BUTTONS

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingsButton()
    {
        canTouch= false;        
        Time.timeScale = 0f;
        _settingCanvas.SetActive(true);
        
        
    }

    public void TamamButton()
    {
        StartCoroutine(TouchDelay());
        Time.timeScale = 1f;
        _settingCanvas.SetActive(false);
        
    }
    public void PauseButton()
    {
        if(_isPaused)
        {
            Time.timeScale = 0f;
            _isPaused = false;
            canTouch = false;
        }
        else if (!_isPaused)
        {
            Time.timeScale = 1f;
            StartCoroutine(TouchDelay());
            _isPaused = true;
        }
    }
    #endregion

    #region TOGGLES

    
    public void SoundsToggle()
    {
        if (_soundsToggle.isOn == true) AudioManager.instance.SoundOn();
        if (_soundsToggle.isOn == false) AudioManager.instance.SoundOff();
       
    }
    public void MusicToggle()
    {
        if (_musicToggle.isOn == true) AudioManager.instance.MusicOn();
        else if (_musicToggle.isOn == false) AudioManager.instance.MusicOff();
    }

    #endregion
}
