using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacktoPrevious1 : MonoBehaviour
{
    private Button button;
    public GameObject settingsButton1;
    public GameObject mainMenuButtons;
    public GameObject settingsMenu;
    public GameObject backButton;
    public GameObject gameTitle;
    public GameObject logoPlane;
    public GameObject volumeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(Back);

    }

    void Back()
    {
        settingsButton1.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        mainMenuButtons.gameObject.SetActive(true);
        gameTitle.gameObject.SetActive(true);
        logoPlane.gameObject.SetActive(true);
        volumeCanvas.gameObject.SetActive(false);
        
    }
}
