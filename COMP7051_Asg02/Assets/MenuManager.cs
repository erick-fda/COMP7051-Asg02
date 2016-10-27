using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    /** the button that opens the main menu*/
    public GameObject MenuButton;

    /**The main menu panel*/
    public GameObject MenuPanel;

	// Use this for initialization
	void Start () {
        closeMenu();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**Opens MainMenu*/
    public void openMenu() {
        MenuButton.SetActive(false);
        MenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    /**closes main menu*/
    public void closeMenu() {
        MenuButton.SetActive(true);
        MenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    /**quit the game*/
    public void quitGame() {
        Application.Quit();
    }
}
