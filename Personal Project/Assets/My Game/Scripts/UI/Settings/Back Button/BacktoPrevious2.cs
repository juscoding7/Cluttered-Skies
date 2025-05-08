using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BacktoPrevious2 : MonoBehaviour
{
    private Button button;
    public GameObject settingsButton2;
    public GameObject scoreText;
    public GameObject settingsMenu;
    public GameObject backButton;
    public GameObject pausePanel;
    public GameObject volumeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(Back);
    }

    void Back()
    {
        settingsButton2.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);
        volumeCanvas.gameObject.SetActive(false);
    }
}
