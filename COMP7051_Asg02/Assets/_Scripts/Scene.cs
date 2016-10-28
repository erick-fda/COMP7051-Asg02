/*===========================================================================================
    Scene                                                                               *//**
	
	Manages scene state and acts as a MonoBehaviour agent for the Game.
	
	@author Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	@version 0.2.0
	@file
	
*//*=======================================================================================*/

/*===========================================================================================
	Dependencies
===========================================================================================*/
using UnityEngine;
using UnityEngine.SceneManagement;

/*===========================================================================================
	Scene
===========================================================================================*/
/**
	Manages scene state and acts as a MonoBehaviour agent for the Game.
*/
public sealed class Scene : MonoBehaviour
{
    /*=======================================================================================
		Singleton
	=======================================================================================*/
    /**
        Private static Scene instance.
    */
    private static Scene instance = null;

    /**
        Public access property for Scene.instance.

        @see Scene.instance
    */
    public static Scene Instance
    {
        get { return instance; }

        set { instance = value; }
    }

    /*=======================================================================================
		Fields
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
		Game Object References
	---------------------------------------------------------------------------------------*/


    /*---------------------------------------------------------------------------------------
		Public
	---------------------------------------------------------------------------------------*/
    

    /*---------------------------------------------------------------------------------------
		Private
	---------------------------------------------------------------------------------------*/


    /*=======================================================================================
		Properties
	=======================================================================================*/


    /*=======================================================================================
		Methods
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
		MonoBehaviour Methods
	---------------------------------------------------------------------------------------*/
    /**
        Called once when the script is loaded.

        Used for setting up references to other scripts and enforcing singleton behaviours 
        on MonoBehaviours.
        
        Enforces the singleton pattern on the Scene.
    */
    void Awake()
    {
        /* Enforce the singleton pattern on the Scene. */
        EnforceSingleton();
    }

    /**
		Called once before the first frame update.
		Used for initializing referenced object variables and other values.

        Begins the scene with fog off.
	*/
    void Start()
    {

    }

    /**
		Called once per frame.
		Used for general updating of game values and objects.

        Can toggle fog in the scene.
	*/
    void Update()
    {
        ToggleFog();
        resetSceneControls();

    }

    /**
		Called by a frame-rate-independent timer before game physics are updated.
		Used for calculating game physics.
	*/
    void FixedUpdate()
    {

    }

    /**
		Called after all Update() calculations have been performed.
		Used for follow cameras, procedural animation, and obtaining last known states.
	*/
    void LateUpdate()
    {

    }

    /*---------------------------------------------------------------------------------------
		Utility Methods
	---------------------------------------------------------------------------------------*/
    /*
        Toggles fog in the scene.
    */
    private void ToggleFog()
    {
        /* Toggle fog if key goes down. */
        if (IRefs.GetKeyDown(IRefs.Command.ToggleFog))
        {
            RenderSettings.fog = !RenderSettings.fog;
        }
    }

    /**time since the last touchscreen touch. used to detect double tapping*/
    private float timeSinceTap = 10;

    /**manages user input for scene resetting*/
    private void resetSceneControls() {
        //detect if reset button pressed on keyboard or controller
        if (IRefs.GetKeyDown(IRefs.Command.ResetGame))
            resetScene();

        //detects if a double tapp occured
        timeSinceTap += Time.deltaTime;
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended) {
                if(timeSinceTap < 1)
                    resetScene();
                timeSinceTap = 0;
            }
               
        }
    }


    /* Reload the current scene on user input. */
    public void resetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*---------------------------------------------------------------------------------------
		Singleton Methods
	---------------------------------------------------------------------------------------*/
    /**
        Enforces singleton behaviour on the Scene.
        Prevents secondary instances from being created and destroys them if they are.
    */
    private void EnforceSingleton()
    {
        /* If instance is null, set this Scene as the instance and ensure that it 
            is not destroyed on loading subsequent scenes. */
        if (Instance == null)
        {
            Instance = this;

            Debug.Log("Scene instance created.");
        }
        /* If instance is not null and is not this Scene, destroy this 
            Scene. */
        else if (Instance != this)
        {
            Destroy(this.gameObject);

            Debug.Log("Scene instance destroyed.");
        }
    }
}
