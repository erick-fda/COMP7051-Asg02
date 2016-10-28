using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        resetSceneControls();
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


    /**time since the last touchscreen touch. used to detect double tapping*/
    private float timeSinceTap = 10;

    /**manages user input for scene resetting*/
    private void resetSceneControls() {
        //detect if reset button pressed on keyboard or controller
        if (Application.platform != RuntimePlatform.Android && IRefs.GetKeyDown(IRefs.Command.ResetGame))
            resetScene();

        //detects if a double tapp occured
        timeSinceTap += Time.deltaTime;
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) {
                if (timeSinceTap < .3f && !MenuPanel.activeSelf)
                    resetScene();
                if(!MenuPanel.activeSelf)
                    timeSinceTap = 0;
            }

        }
    }


    /* Reload the current scene on user input. */
    public void resetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
