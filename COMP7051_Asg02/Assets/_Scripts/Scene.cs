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
using UnityEngine.UI;

/*===========================================================================================
	Scene
===========================================================================================*/
/**
	Manages scene state and acts as a MonoBehaviour agent for the Game.
*/
public class Scene : MonoBehaviour
{
    /*=======================================================================================
		Fields
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
		Game Object References
	---------------------------------------------------------------------------------------*/
    public GameObject Player;       /**< The player GameObject. */
    public GameObject Monster;       /**< The monster GameObject. */

    public Material mat_Ground;     /**< The material for the level's ground. */
    public Material mat_TopWalls;   /**< The material for the maze's top walls. */
    public Material mat_NorthWalls; /**< The material for the maze's north walls. */
    public Material mat_SouthWalls; /**< The material for the maze's south walls. */
    public Material mat_EastWalls;  /**< The material for the maze's east walls. */
    public Material mat_WestWalls;  /**< The material for the maze's west walls. */

    public int score; /**the player's score*/
    public Text scoreText; /**the text to display the player score*/

    /*---------------------------------------------------------------------------------------
		Public
	---------------------------------------------------------------------------------------*/
    public const float AMBIENT_DAY = 0.7f;  /* Ambient light intensity during the day. */
    public const float DIFFUSE_DAY = 1.0f;  /* Diffuse light intensity during the day. */

    public const float AMBIENT_NIGHT = 0.2f;    /* Ambient light intensity during the night. */
    public const float DIFFUSE_NIGHT = 0.4f;    /* Diffuse light intensity during the night. */

    /*---------------------------------------------------------------------------------------
		Private
	---------------------------------------------------------------------------------------*/
    private bool isDaylit = false;  /**< Is the scene lit by daylight? */

    /*=======================================================================================
		Properties
	=======================================================================================*/
    /*
        Public access property for isDaylit.
        Private setting only.

        @see isDaylit
    */
    public bool IsDaylit
    {
        get { return isDaylit; }

        private set
        {
            isDaylit = value;

            /* Determine whether to use day or night lighting. */
            float ambient = (isDaylit) ? AMBIENT_DAY : AMBIENT_NIGHT;
            float diffuse = (isDaylit) ? DIFFUSE_DAY : DIFFUSE_NIGHT;

            /* Set the day or night lighting for the materials in the scene. */
            mat_Ground.SetFloat("_AmbientIntensity", ambient);
            mat_Ground.SetFloat("_DiffuseIntensity", diffuse);

            mat_TopWalls.SetFloat("_AmbientIntensity", ambient);
            mat_TopWalls.SetFloat("_DiffuseIntensity", diffuse);

            mat_NorthWalls.SetFloat("_AmbientIntensity", ambient);
            mat_NorthWalls.SetFloat("_DiffuseIntensity", diffuse);

            mat_SouthWalls.SetFloat("_AmbientIntensity", ambient);
            mat_SouthWalls.SetFloat("_DiffuseIntensity", diffuse);

            mat_EastWalls.SetFloat("_AmbientIntensity", ambient);
            mat_EastWalls.SetFloat("_DiffuseIntensity", diffuse);

            mat_WestWalls.SetFloat("_AmbientIntensity", ambient);
            mat_WestWalls.SetFloat("_DiffuseIntensity", diffuse);
        }
    }

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
    */
    void Awake()
    {

    }

    /**
		Called once before the first frame update.
		Used for initializing referenced object variables and other values.

        Begins the scene with night lighting.
	*/
    void Start()
    {
        /* Begin the scene with night lighting. */
        IsDaylit = false;

        /* Set the volume of music in the scene. */
        Player.GetComponent<AudioController>().SetMusicVolume();
    }

    /**
		Called once per frame.
		Used for general updating of game values and objects.

        Checks for input to toggle fog.
        Checks for input to toggle lighting.
	*/
    void Update()
    {
        /* Check for input to toggle fog. */
        ToggleFog();

        /* Check for input to toggle lighting. */
        ToggleLighting();
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
    public void ToggleFog(bool assumeInput = false)
    {
        /* Toggle fog if key goes down. */
        if (assumeInput ||
            IRefs.GetKeyDown(IRefs.Command.ToggleFog))
        {
            RenderSettings.fog = !RenderSettings.fog;
            Player.GetComponent<AudioController>().SetMusicVolume();
        }
    }

    /*
        Toggles day/night lighting in the scene.
    */
    public void ToggleLighting(bool assumeInput = false)
    {
        if (assumeInput ||
            IRefs.GetKeyDown(IRefs.Command.ToggleLighting))
        {
            IsDaylit = !IsDaylit;
            Player.GetComponent<AudioController>().SetDayMusicPlaying(IsDaylit);
            Player.GetComponent<AudioController>().PlayAudio(Player.GetComponent<AudioController>().MusicToPlay);
        }
    }

    public void setScore(int newScore) {
        score = newScore;
        scoreText.text = "Score: " + score.ToString();
    }

    public void addToScore(int addedScore) {
        score += addedScore;
        scoreText.text = "Score: " + score.ToString();
    }

}
