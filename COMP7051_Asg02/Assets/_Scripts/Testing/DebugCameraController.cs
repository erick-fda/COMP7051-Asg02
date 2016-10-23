/*===========================================================================================
    DebugCameraController                                                               *//**
	
	Allows for moving the game camera freely.
    Used for debugging of game environment and environmental effects.
	
	@author Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	@version 0.1.0
	@file
	
*//*=======================================================================================*/

/*===========================================================================================
	Dependencies
===========================================================================================*/
using UnityEngine;

/*===========================================================================================
	DebugCameraController
===========================================================================================*/
/**
	Allows for moving the game camera freely.
    Used for debugging of game environment and environmental effects.
*/
public class DebugCameraController : MonoBehaviour
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
    public float speed = 100;   /**< Camera movement speed. */

    /*---------------------------------------------------------------------------------------
		Private
	---------------------------------------------------------------------------------------*/
    private float move; /**< Distance to move camera this frame. */

    /*---------------------------------------------------------------------------------------
		Protected
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
    */
    void Awake()
    {

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

        Can move the camera.
	*/
    void Update()
    {
        move = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(0, move, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(move, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(0, -move, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(-move, 0, 0);
        }

        if (Input.GetKey(KeyCode.Equals))
        {
            gameObject.transform.Translate(0, 0, move);
        }

        if (Input.GetKey(KeyCode.Minus))
        {
            gameObject.transform.Translate(0, 0, -move);
        }
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

}
