/*===========================================================================================
    DayNight                                                                            *//**
	@deprecated

	Toggles day/night lighting for a GameObject's renderer.
    To be used with the "Day and Night" shader.
	
	@author Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	@version 0.2.0
	@file
	
*//*=======================================================================================*/

/*===========================================================================================
	Dependencies
===========================================================================================*/
using UnityEngine;

/*===========================================================================================
	DayNight
===========================================================================================*/
/**
    @deprecated

	Toggles day/night lighting for a GameObject's renderer.
    To be used with the "Day and Night" shader.
*/
public class DayNight : MonoBehaviour
{
    /*=======================================================================================
		Fields
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
		Game Object References
	---------------------------------------------------------------------------------------*/


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
    private bool isDaylit = false;   /**< Is the object lit by daylight? */  

    /*---------------------------------------------------------------------------------------
		Protected
	---------------------------------------------------------------------------------------*/


    /*=======================================================================================
		Properties
	=======================================================================================*/
    /*
        Public access property for isDaylit.

        Private setting only.
    */
    public bool IsDaylit
    {
        get
        {
            return isDaylit;
        }

        private set
        {
            isDaylit = value;

            /* Set the ambient and diffuse intensity values. */
            float ambient = (isDaylit) ? AMBIENT_DAY : AMBIENT_NIGHT;
            float diffuse = (isDaylit) ? DIFFUSE_DAY : DIFFUSE_NIGHT;

            Renderer rend = GetComponent<Renderer>();

            rend.material.SetFloat("_AmbientIntensity", ambient);
            rend.material.SetFloat("_DiffuseIntensity", diffuse);
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

        Begins the scene with night lighting.
    */
    void Awake()
    {
        /* Begin the scene with night lighting. */
        IsDaylit = false;
    }

    /**
		Called once before the first frame update.
		Used for initializing referenced object variables and other values.
	*/
    void Start()
    {

    }

    /**
		Called once per frame.
		Used for general updating of game values and objects.

        Can toggle day/night lighting for the renderer.
	*/
    void Update()
    {
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
        Toggles day/night lighting on the object.
    */
    private void ToggleLighting()
    {
        /* Toggle day/night lighting if key goes down. */
        if (IRefs.GetKeyDown(IRefs.Command.ToggleLighting))
        {
            IsDaylit = !IsDaylit;
        }
    } 
}
