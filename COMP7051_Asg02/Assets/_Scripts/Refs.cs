/*===========================================================================================
    Refs                                                                                *//**
	
	Static class for globally-accessible structs, enums, and other minor types.
	
	@author Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	@version 0.1.0
	@file
	
*//*=======================================================================================*/

/*===========================================================================================
	Dependencies
===========================================================================================*/


/*===========================================================================================
	Refs
===========================================================================================*/
/**
	Namespace for globally-accessible structs, enums, and other minor types.
*/
public static class Refs
{
    /*=======================================================================================
		Game Constants
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
        Scenes
    ---------------------------------------------------------------------------------------*/
    /**
        Struct containing string constants for scene names.
    */
    public struct Scenes
    {
        public const string MainMenu = "mainMenuScene";
        public const string Battle = "mainScene";
    }

    /*---------------------------------------------------------------------------------------
        Tags
    ---------------------------------------------------------------------------------------*/
    /**
        Struct containing string constants for GameObject tags.
    */
    public struct Tags
    {
        public const string Wall = "Wall";
    }

    /*---------------------------------------------------------------------------------------
        PlayerPrefs
    ---------------------------------------------------------------------------------------*/
    /**
        Struct containing string constants for PlayerPrefs variable names.
    */
    public struct PlayerPrefs
    {

    }

    /*=======================================================================================
		File System
	=======================================================================================*/
    /*---------------------------------------------------------------------------------------
        Directories
    ---------------------------------------------------------------------------------------*/
    /**
        Struct containing string constants for directories.
    */
    public struct Directories
    {
        public const string SaveDataDirectory = "/Saves";
    }

    /*---------------------------------------------------------------------------------------
        Filenames
    ---------------------------------------------------------------------------------------*/
    /**
        Struct containing string constants for filenames.
    */
    public struct Filenames
    {
        public const string SaveDataFile = "SaveData.dat";
    }

    /*---------------------------------------------------------------------------------------
        Filepaths
    ---------------------------------------------------------------------------------------*/
    /**
        Struct containing string constants for filepaths.
    */
    public struct Filepaths
    {
        public const string SaveDataFilepath =
            Refs.Directories.SaveDataDirectory + "/" + Refs.Filenames.SaveDataFile;
    }
}
