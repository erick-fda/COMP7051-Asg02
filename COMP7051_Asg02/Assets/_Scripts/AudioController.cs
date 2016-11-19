/*===========================================================================================
    AudioController                                                                            *//**
	
	Controls music and sound effects in the scene.
	
	@author Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	@version 0.1.0
	@file
	
*//*=======================================================================================*/

/*===========================================================================================
	Dependencies
===========================================================================================*/
using UnityEngine;

/*===========================================================================================
	AudioController
===========================================================================================*/
/**
	Controls music and sound effects in the scene.
*/
public class AudioController : MonoBehaviour
{
    /*=======================================================================================
		Internal Types
	=======================================================================================*/
    /**
        Struct containing string constants for audio names.
    */
    public struct AudioNames
    {
        public const string Footsteps = "Footsteps";
        public const string WallCollision = "WallCollision";
        public const string DayMusic = "DayMusic";
        public const string NightMusic = "NightMusic";
    }

    /*=======================================================================================
		Fields
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
		Game Object References
	---------------------------------------------------------------------------------------*/
    public AudioSource FootstepsAudio;      /**< The audio source for the footsteps SFX. */
    public AudioSource WallCollideAudio;    /**< The audio source for the wall collision SFX. */
    public AudioSource DayMusicAudio;       /**< The audio source for the day music. */
    public AudioSource NightMusicAudio;     /**< The audio source for the night music. */
    public GameObject scene;                /**< The scene object. */

    /*---------------------------------------------------------------------------------------
		Public
	---------------------------------------------------------------------------------------*/
    public const float HighMusicVolume = 0.8f;  /**< The volume to play music at when the scene is not foggy. */
    public const float LowMusicVolume = 0.4f;   /**< The volume to play music at when the scene is foggy. */

    /*---------------------------------------------------------------------------------------
		Private
	---------------------------------------------------------------------------------------*/
    private string musicToPlay = AudioNames.NightMusic; /**< The name of the background music to play. */

    /*---------------------------------------------------------------------------------------
		Protected
	---------------------------------------------------------------------------------------*/


    /*=======================================================================================
		Properties
	=======================================================================================*/
    /**
        Public access property for AudioController.musicToPlay.

        @see AudioController.musicToPlay
    */
    public string MusicToPlay
    {
        get { return musicToPlay; }

        set { musicToPlay = value; }
    }

    /*=======================================================================================
		Methods
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
		MonoBehaviour Methods
	---------------------------------------------------------------------------------------*/
    /**
        Called once when the script is loaded.
        Used for initialization that does not involve accessing other objects and for 
        enforcing singleton behaviours.
    */
    void Awake()
    {
        
    }

    /**
		Called once before the first frame update after all Awake() methods have completed.
		Used for initialization that involves accessing other objects.

        Initialize audio in the scene.
	*/
    void Start()
    {
        InitSceneAudio();
    }

    /**
		Called once per frame.
		Used for receiving input and updating game values and objects.
	*/
    void Update()
    {
        ToggleIsMusicPlaying();
    }

    /*---------------------------------------------------------------------------------------
		Utility Methods
	---------------------------------------------------------------------------------------*/
    /**
        Initialize audio in the scene.
    */
    private void InitSceneAudio()
    {
        /* Stop all SFX. */
        FootstepsAudio.Stop();
        WallCollideAudio.Stop();

        /* Determine what music to play. */
        SetDayMusicPlaying(scene.GetComponent<Scene>().IsDaylit);

        /* Play scene music. */
        PlayAudio(MusicToPlay);
    }

    /**
        Begins playing the audio clip specified by audioName.

        @param audioName - The name of the audio clip to play.
    */
    public void PlayAudio(string audioName)
    {
        /* Play the requested audio clip. */
        switch (audioName)
        {
            case AudioNames.Footsteps:
                FootstepsAudio.Play();
                break;

            case AudioNames.WallCollision:
                WallCollideAudio.Play();
                break;

            case AudioNames.DayMusic:
                NightMusicAudio.Stop();
                DayMusicAudio.Play();
                break;

            case AudioNames.NightMusic:
                DayMusicAudio.Stop();
                NightMusicAudio.Play();
                break;

            /* If an invalid audio clip was requested, log a debug message. */
            default:
                Debug.Log("Invalid audio clip \"" + audioName + "\" requested to start.");
                break;
        }
    }

    /**
        Stops playing the audio clip specified by audioName.

        @param audioName - The name of the audio clip to stop.
    */
    public void StopAudio(string audioName)
    {
        /* Stop the requested audio clip. */
        switch (audioName)
        {
            case AudioNames.Footsteps:
                FootstepsAudio.Stop();
                break;

            case AudioNames.WallCollision:
                WallCollideAudio.Stop();
                break;

            case AudioNames.DayMusic:
                DayMusicAudio.Stop();
                break;

            case AudioNames.NightMusic:
                NightMusicAudio.Stop();
                break;

            /* If an invalid audio clip was requested, log a debug message. */
            default:
                Debug.Log("Invalid audio clip \"" + audioName + "\" requested to stop.");
                break;
        }
    }

    /**
        Sets day or night music.
    */
    public void SetDayMusicPlaying(bool playDayMusic)
    {
        MusicToPlay = (playDayMusic) ? AudioNames.DayMusic : AudioNames.NightMusic;
    }

    /**
        Toggles whether background music is playing.
    */
    public void ToggleIsMusicPlaying(bool assumeInput = false)
    {
        if (assumeInput || 
            IRefs.GetKeyDown(IRefs.Command.ToggleMusic, 1, IRefs.InputSource.Any))
        {
            if (DayMusicAudio.isPlaying || NightMusicAudio.isPlaying)
            {
                StopAudio(AudioNames.DayMusic);
                StopAudio(AudioNames.NightMusic);
            }
            else
            {
                PlayAudio(MusicToPlay);
            }
        }
    }

    /*
        Set the volume of music in the scene.
    */
    public void SetMusicVolume()
    {
        DayMusicAudio.volume =
                (RenderSettings.fog) ? AudioController.LowMusicVolume : AudioController.HighMusicVolume;
        NightMusicAudio.volume =
                (RenderSettings.fog) ? AudioController.LowMusicVolume : AudioController.HighMusicVolume;
    }
}
