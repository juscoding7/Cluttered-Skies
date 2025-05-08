using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    private Button button;
    public GameObject settingsButton;
    public GameObject mainMenuButtons;
    public GameObject gameTitle;
    public GameObject logoPlane;
    public GameObject scoreText;
    public GameObject settingsMenu;
    public GameObject backButton;
    public GameObject pausePanel;
    public GameObject volumeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(SettingsPage);
        
    }

    // Update is called once per frame
    void SettingsPage()
    {
        settingsButton.gameObject.SetActive(false);
        mainMenuButtons.gameObject.SetActive(false);
        gameTitle.gameObject.SetActive(false);
        logoPlane.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        volumeCanvas.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
    }
}
