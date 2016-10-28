/*===========================================================================================
    IRefs                                                                               *//**
	
	Static class for game command and input management.
	
	@author Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	@version 1.0.0
	@file
	
*//*=======================================================================================*/

/*===========================================================================================
	Dependencies
===========================================================================================*/
using System.Collections.Generic;
using UnityEngine;

/*===========================================================================================
	IRefs
===========================================================================================*/
/**
	Static class for game command and input management.
*/
public static class IRefs
{
    /*=======================================================================================
        Game Commands
    =======================================================================================*/
    /*---------------------------------------------------------------------------------------
        Command Enum
    ---------------------------------------------------------------------------------------*/
    /**
        An enum of game commands.

        IRefs.CommandStrings maps these names to string represenations.

        @see IRefs.CommandStrings
    */
    public enum Command
    {
        /* Keyboard and Button Commands */
        ToggleLighting,
        ToggleFog,
        ToggleWalkThroughWalls,
        ResetGame,
        PlayerRun


        /* Axis Commands */
        // e.g. -- MoveVertical,
    }

    /*---------------------------------------------------------------------------------------
        Command Strings
    ---------------------------------------------------------------------------------------*/
    /**
        Maps IRefs.Commands to string representations.

        @see IRefs.Command
    */
    private static SortedList<IRefs.Command, string> CommandStrings = new SortedList<Command, string>
    {
        /* Key and Button Commands */
        {Command.ToggleLighting,    "ToggleLighting"},
        {Command.ToggleFog,         "ToggleFog"},
        {Command.ToggleWalkThroughWalls,    "ToggleWalkThroughWalls"},
        {Command.ResetGame,    "ResetGame"},
        {Command.PlayerRun,    "PlayerRun"},

        /* Axis Commands */
        // e.g. -- {Command.MoveVertical,   "MoveVertical"}
    };

    /*=======================================================================================
        Command Mappings
    =======================================================================================*/
    /*---------------------------------------------------------------------------------------
        Keys
    ---------------------------------------------------------------------------------------*/
    /**
        Maps IRefs.CommandStrings strings (with player-denoting suffixes appended) to 
        keyboard and mouse KeyCodes.

        A mapping to KeyCode.None indicates no command mapping for keyboard and mouse.
        
        @see IRefs.CommandStrings
    */
    private static SortedList<string, KeyCode> KeyMap = new SortedList<string, KeyCode>()
    {
        /* Player-Independent Commands */
        // e.g. -- {CommandStrings[Command.MoveUp] + 0, KeyCode.UpArrow},

        /* Player 1 Commands */
        {CommandStrings[Command.ToggleLighting] + 1,  KeyCode.L},
        {CommandStrings[Command.ToggleFog] + 1,       KeyCode.F},
        {CommandStrings[Command.ToggleWalkThroughWalls] + 1,       KeyCode.W},
        {CommandStrings[Command.ResetGame] + 1,       KeyCode.Home},
        {CommandStrings[Command.PlayerRun] + 1,       KeyCode.LeftShift}
    };

    /*---------------------------------------------------------------------------------------
        JoystickButtons
    ---------------------------------------------------------------------------------------*/
    /**
        Maps IRefs.CommandStrings strings (with player-denoting suffixes appended) to 
        IRefs.JoystickButtons.

        A mapping to JoystickButton.None indicates no command mapping for joystick buttons.
        
        @see IRefs.CommandStrings
        @see IRefs.JoystickButton
    */
    private static SortedList<string, IRefs.JoystickButton> JoystickButtonMap = new SortedList<string, IRefs.JoystickButton>()
    {
        /* Player-Independent Commands */
        // e.g. -- {CommandStrings[Command.MoveUp] + 0, JoystickButton.LeftBumper},

        /* Player 1 Commands */
        {CommandStrings[Command.ToggleLighting] + 1,    JoystickButton.B_P1},
        {CommandStrings[Command.ToggleFog] + 1,         JoystickButton.A_P1},
        {CommandStrings[Command.ToggleWalkThroughWalls] + 1,         JoystickButton.Y_P1},
        {CommandStrings[Command.ResetGame] + 1,         JoystickButton.Start_P1},
        {CommandStrings[Command.PlayerRun] + 1,         JoystickButton.LeftBumper_P1},
    };

    /*---------------------------------------------------------------------------------------
        Axes
    ---------------------------------------------------------------------------------------*/
    /**
        Maps IRefs.CommandStrings strings (with player-denoting suffixes appended) to Input 
        Manager axis names WITHOUT platform-denoting suffixes.
        
        @see IRefs.CommandStrings
    */
    private static SortedList<string, string> AxisMap = new SortedList<string, string>()
    {
        /* Player-Independent Commands */
        // e.g. -- {CommandStrings[Command.MoveVertical] + 0,   "MoveVertical"},

        /* Player 1 Commands */
        // e.g. -- {CommandStrings[Command.MoveVertical] + 1,   "MoveVertical_P1"},
    };

    /*=======================================================================================
        Input Sources
    =======================================================================================*/
    /**
        An enum of possible hardware input sources.
    */
    public enum InputSource
    {
        None,           /**< Unknown or nonexistent input source. */
        Any,            /**< Any input source besides InputSource.None. */
        KeyboardMouse,  /**< Keyboard and mouse input. */
        Joystick,       /**< Joystick input. */
    }

    /*=======================================================================================
        Joystick Buttons
    =======================================================================================*/
    /**
        An enum of descriptive joystick button names.

        IRefs.JoystickButtonMap maps IRefs.CommandStrings strings to these names.

        IRefs.JoystickButtonWindows, IRefs.JoystickButtonOSX, and IRefs.JoystickButtonLinux 
        map these names to joystick KeyCodes for Windows, OSX, and Linux platforms, 
        respectively.

        @see IRefs.JoystickButtonMap
        @see IRefs.JoystickButtonWindows
        @see IRefs.JoystickButtonOSX
        @see IRefs.JoystickButtonLinux
    */
    private enum JoystickButton
    {
        /* No command mapping for joystick buttons. */
        None,           /**< No command mapping for joystick buttons. */

        /* Player-Independent Inputs */
        A,              /**< A button on any joystick. */
        B,              /**< B button on any joystick. */
        X,              /**< X button on any joystick. */
        Y,              /**< Y button on any joystick. */
        LeftBumper,     /**< Left bumper on any joystick. */
        RightBumper,    /**< Right bumper on any joystick. */
        Back,           /**< Back button on any joystick. */
        Start,          /**< Start button on any joystick. */
        LeftStick,      /**< Left stick click on any joystick. */
        RightStick,     /**< Right stick click on any joystick. */
        DPadUp,         /**< D-pad up on any joystick. */
        DPadDown,       /**< D-pad down on any joystick. */
        DPadLeft,       /**< D-pad left on any joystick. */
        DPadRight,      /**< D-pad right on any joystick. */
        XBoxButton,     /**< XBox button on any joystick. */

        /* Player 1 Inputs */
        A_P1,           /**< A button on joystick 1. */
        B_P1,           /**< B button on joystick 1. */
        X_P1,           /**< X button on joystick 1. */
        Y_P1,           /**< Y button on joystick 1. */
        LeftBumper_P1,  /**< Left bumper on joystick 1. */
        RightBumper_P1, /**< Right bumper on joystick 1. */
        Back_P1,        /**< Back button on joystick 1. */
        Start_P1,       /**< Start button on joystick 1. */
        LeftStick_P1,   /**< Left stick click on joystick 1. */
        RightStick_P1,  /**< Right stick click on joystick 1. */
        DPadUp_P1,      /**< D-pad up on joystick 1. */
        DPadDown_P1,    /**< D-pad down on joystick 1. */
        DPadLeft_P1,    /**< D-pad left on joystick 1. */
        DPadRight_P1,   /**< D-pad right on joystick 1. */
        XBoxButton_P1,  /**< XBox button on joystick 1. */

        /* Player 2 Inputs */
        A_P2,           /**< A button on joystick 2. */
        B_P2,           /**< B button on joystick 2. */
        X_P2,           /**< X button on joystick 2. */
        Y_P2,           /**< Y button on joystick 2. */
        LeftBumper_P2,  /**< Left bumper on joystick 2. */
        RightBumper_P2, /**< Right bumper on joystick 2. */
        Back_P2,        /**< Back button on joystick 2. */
        Start_P2,       /**< Start button on joystick 2. */
        LeftStick_P2,   /**< Left stick click on joystick 2. */
        RightStick_P2,  /**< Right stick click on joystick 2. */
        DPadUp_P2,      /**< D-pad up on joystick 2. */
        DPadDown_P2,    /**< D-pad down on joystick 2. */
        DPadLeft_P2,    /**< D-pad left on joystick 2. */
        DPadRight_P2,   /**< D-pad right on joystick 2. */
        XBoxButton_P2,  /**< XBox button on joystick 2. */

        /* Player 3 Inputs */
        A_P3,           /**< A button on joystick 3. */
        B_P3,           /**< B button on joystick 3. */
        X_P3,           /**< X button on joystick 3. */
        Y_P3,           /**< Y button on joystick 3. */
        LeftBumper_P3,  /**< Left bumper on joystick 3. */
        RightBumper_P3, /**< Right bumper on joystick 3. */
        Back_P3,        /**< Back button on joystick 3. */
        Start_P3,       /**< Start button on joystick 3. */
        LeftStick_P3,   /**< Left stick click on joystick 3. */
        RightStick_P3,  /**< Right stick click on joystick 3. */
        DPadUp_P3,      /**< D-pad up on joystick 3. */
        DPadDown_P3,    /**< D-pad down on joystick 3. */
        DPadLeft_P3,    /**< D-pad left on joystick 3. */
        DPadRight_P3,   /**< D-pad right on joystick 3. */
        XBoxButton_P3,  /**< XBox button on joystick 3. */

        /* Player 4 Inputs */
        A_P4,           /**< A button on joystick 4. */
        B_P4,           /**< B button on joystick 4. */
        X_P4,           /**< X button on joystick 4. */
        Y_P4,           /**< Y button on joystick 4. */
        LeftBumper_P4,  /**< Left bumper on joystick 4. */
        RightBumper_P4, /**< Right bumper on joystick 4. */
        Back_P4,        /**< Back button on joystick 4. */
        Start_P4,       /**< Start button on joystick 4. */
        LeftStick_P4,   /**< Left stick click on joystick 4. */
        RightStick_P4,  /**< Right stick click on joystick 4. */
        DPadUp_P4,      /**< D-pad up on joystick 4. */
        DPadDown_P4,    /**< D-pad down on joystick 4. */
        DPadLeft_P4,    /**< D-pad left on joystick 4. */
        DPadRight_P4,   /**< D-pad right on joystick 4. */
        XBoxButton_P4,  /**< XBox button on joystick 4. */

        /* Player 5 Inputs */
        A_P5,           /**< A button on joystick 5. */
        B_P5,           /**< B button on joystick 5. */
        X_P5,           /**< X button on joystick 5. */
        Y_P5,           /**< Y button on joystick 5. */
        LeftBumper_P5,  /**< Left bumper on joystick 5. */
        RightBumper_P5, /**< Right bumper on joystick 5. */
        Back_P5,        /**< Back button on joystick 5. */
        Start_P5,       /**< Start button on joystick 5. */
        LeftStick_P5,   /**< Left stick click on joystick 5. */
        RightStick_P5,  /**< Right stick click on joystick 5. */
        DPadUp_P5,      /**< D-pad up on joystick 5. */
        DPadDown_P5,    /**< D-pad down on joystick 5. */
        DPadLeft_P5,    /**< D-pad left on joystick 5. */
        DPadRight_P5,   /**< D-pad right on joystick 5. */
        XBoxButton_P5,  /**< XBox button on joystick 5. */

        /* Player 6 Inputs */
        A_P6,           /**< A button on joystick 6. */
        B_P6,           /**< B button on joystick 6. */
        X_P6,           /**< X button on joystick 6. */
        Y_P6,           /**< Y button on joystick 6. */
        LeftBumper_P6,  /**< Left bumper on joystick 6. */
        RightBumper_P6, /**< Right bumper on joystick 6. */
        Back_P6,        /**< Back button on joystick 6. */
        Start_P6,       /**< Start button on joystick 6. */
        LeftStick_P6,   /**< Left stick click on joystick 6. */
        RightStick_P6,  /**< Right stick click on joystick 6. */
        DPadUp_P6,      /**< D-pad up on joystick 6. */
        DPadDown_P6,    /**< D-pad down on joystick 6. */
        DPadLeft_P6,    /**< D-pad left on joystick 6. */
        DPadRight_P6,   /**< D-pad right on joystick 6. */
        XBoxButton_P6,  /**< XBox button on joystick 6. */

        /* Player 7 Inputs */
        A_P7,           /**< A button on joystick 7. */
        B_P7,           /**< B button on joystick 7. */
        X_P7,           /**< X button on joystick 7. */
        Y_P7,           /**< Y button on joystick 7. */
        LeftBumper_P7,  /**< Left bumper on joystick 7. */
        RightBumper_P7, /**< Right bumper on joystick 7. */
        Back_P7,        /**< Back button on joystick 7. */
        Start_P7,       /**< Start button on joystick 7. */
        LeftStick_P7,   /**< Left stick click on joystick 7. */
        RightStick_P7,  /**< Right stick click on joystick 7. */
        DPadUp_P7,      /**< D-pad up on joystick 7. */
        DPadDown_P7,    /**< D-pad down on joystick 7. */
        DPadLeft_P7,    /**< D-pad left on joystick 7. */
        DPadRight_P7,   /**< D-pad right on joystick 7. */
        XBoxButton_P7,  /**< XBox button on joystick 7. */

        /* Player 8 Inputs */
        A_P8,           /**< A button on joystick 8. */
        B_P8,           /**< B button on joystick 8. */
        X_P8,           /**< X button on joystick 8. */
        Y_P8,           /**< Y button on joystick 8. */
        LeftBumper_P8,  /**< Left bumper on joystick 8. */
        RightBumper_P8, /**< Right bumper on joystick 8. */
        Back_P8,        /**< Back button on joystick 8. */
        Start_P8,       /**< Start button on joystick 8. */
        LeftStick_P8,   /**< Left stick click on joystick 8. */
        RightStick_P8,  /**< Right stick click on joystick 8. */
        DPadUp_P8,      /**< D-pad up on joystick 8. */
        DPadDown_P8,    /**< D-pad down on joystick 8. */
        DPadLeft_P8,    /**< D-pad left on joystick 8. */
        DPadRight_P8,   /**< D-pad right on joystick 8. */
        XBoxButton_P8   /**< XBox button on joystick 8. */
    }

    /*=======================================================================================
        JoystickButton Mappings
    =======================================================================================*/
    /*---------------------------------------------------------------------------------------
        JoystickButton Windows Mappings
    ---------------------------------------------------------------------------------------*/
    /**
        Maps descriptive IRefs.JoystickButton names to joystick KeyCodes for Windows.

        @see IRefs.JoystickButton
    */
    private static SortedList<IRefs.JoystickButton, KeyCode> JoystickButtonWindows = new SortedList<IRefs.JoystickButton, KeyCode>()
    {
        /* No command mapping for joystick buttons on Windows. */
        {IRefs.JoystickButton.None,             KeyCode.None},
        
        /* Player-Independent Inputs */
        {IRefs.JoystickButton.A,                KeyCode.JoystickButton0},
        {IRefs.JoystickButton.B,                KeyCode.JoystickButton1},
        {IRefs.JoystickButton.X,                KeyCode.JoystickButton2},
        {IRefs.JoystickButton.Y,                KeyCode.JoystickButton3},
        {IRefs.JoystickButton.LeftBumper,       KeyCode.JoystickButton4},
        {IRefs.JoystickButton.RightBumper,      KeyCode.JoystickButton5},
        {IRefs.JoystickButton.Back,             KeyCode.JoystickButton6},
        {IRefs.JoystickButton.Start,            KeyCode.JoystickButton7},
        {IRefs.JoystickButton.LeftStick,        KeyCode.JoystickButton8},
        {IRefs.JoystickButton.RightStick,       KeyCode.JoystickButton9},

        /* Player 1 Inputs */
        {IRefs.JoystickButton.A_P1,             KeyCode.Joystick1Button0},
        {IRefs.JoystickButton.B_P1,             KeyCode.Joystick1Button1},
        {IRefs.JoystickButton.X_P1,             KeyCode.Joystick1Button2},
        {IRefs.JoystickButton.Y_P1,             KeyCode.Joystick1Button3},
        {IRefs.JoystickButton.LeftBumper_P1,    KeyCode.Joystick1Button4},
        {IRefs.JoystickButton.RightBumper_P1,   KeyCode.Joystick1Button5},
        {IRefs.JoystickButton.Back_P1,          KeyCode.Joystick1Button6},
        {IRefs.JoystickButton.Start_P1,         KeyCode.Joystick1Button7},
        {IRefs.JoystickButton.LeftStick_P1,     KeyCode.Joystick1Button8},
        {IRefs.JoystickButton.RightStick_P1,    KeyCode.Joystick1Button9},
        
        /* Player 2 Inputs */
        {IRefs.JoystickButton.A_P2,             KeyCode.Joystick2Button0},
        {IRefs.JoystickButton.B_P2,             KeyCode.Joystick2Button1},
        {IRefs.JoystickButton.X_P2,             KeyCode.Joystick2Button2},
        {IRefs.JoystickButton.Y_P2,             KeyCode.Joystick2Button3},
        {IRefs.JoystickButton.LeftBumper_P2,    KeyCode.Joystick2Button4},
        {IRefs.JoystickButton.RightBumper_P2,   KeyCode.Joystick2Button5},
        {IRefs.JoystickButton.Back_P2,          KeyCode.Joystick2Button6},
        {IRefs.JoystickButton.Start_P2,         KeyCode.Joystick2Button7},
        {IRefs.JoystickButton.LeftStick_P2,     KeyCode.Joystick2Button8},
        {IRefs.JoystickButton.RightStick_P2,    KeyCode.Joystick2Button9},
        
        /* Player 3 Inputs */
        {IRefs.JoystickButton.A_P3,             KeyCode.Joystick3Button0},
        {IRefs.JoystickButton.B_P3,             KeyCode.Joystick3Button1},
        {IRefs.JoystickButton.X_P3,             KeyCode.Joystick3Button2},
        {IRefs.JoystickButton.Y_P3,             KeyCode.Joystick3Button3},
        {IRefs.JoystickButton.LeftBumper_P3,    KeyCode.Joystick3Button4},
        {IRefs.JoystickButton.RightBumper_P3,   KeyCode.Joystick3Button5},
        {IRefs.JoystickButton.Back_P3,          KeyCode.Joystick3Button6},
        {IRefs.JoystickButton.Start_P3,         KeyCode.Joystick3Button7},
        {IRefs.JoystickButton.LeftStick_P3,     KeyCode.Joystick3Button8},
        {IRefs.JoystickButton.RightStick_P3,    KeyCode.Joystick3Button9},
        
        /* Player 4 Inputs */
        {IRefs.JoystickButton.A_P4,             KeyCode.Joystick4Button0},
        {IRefs.JoystickButton.B_P4,             KeyCode.Joystick4Button1},
        {IRefs.JoystickButton.X_P4,             KeyCode.Joystick4Button2},
        {IRefs.JoystickButton.Y_P4,             KeyCode.Joystick4Button3},
        {IRefs.JoystickButton.LeftBumper_P4,    KeyCode.Joystick4Button4},
        {IRefs.JoystickButton.RightBumper_P4,   KeyCode.Joystick4Button5},
        {IRefs.JoystickButton.Back_P4,          KeyCode.Joystick4Button6},
        {IRefs.JoystickButton.Start_P4,         KeyCode.Joystick4Button7},
        {IRefs.JoystickButton.LeftStick_P4,     KeyCode.Joystick4Button8},
        {IRefs.JoystickButton.RightStick_P4,    KeyCode.Joystick4Button9},

        /* Player 5 Inputs */
        {IRefs.JoystickButton.A_P5,             KeyCode.Joystick5Button0},
        {IRefs.JoystickButton.B_P5,             KeyCode.Joystick5Button1},
        {IRefs.JoystickButton.X_P5,             KeyCode.Joystick5Button2},
        {IRefs.JoystickButton.Y_P5,             KeyCode.Joystick5Button3},
        {IRefs.JoystickButton.LeftBumper_P5,    KeyCode.Joystick5Button4},
        {IRefs.JoystickButton.RightBumper_P5,   KeyCode.Joystick5Button5},
        {IRefs.JoystickButton.Back_P5,          KeyCode.Joystick5Button6},
        {IRefs.JoystickButton.Start_P5,         KeyCode.Joystick5Button7},
        {IRefs.JoystickButton.LeftStick_P5,     KeyCode.Joystick5Button8},
        {IRefs.JoystickButton.RightStick_P5,    KeyCode.Joystick5Button9},

        /* Player 6 Inputs */
        {IRefs.JoystickButton.A_P6,             KeyCode.Joystick6Button0},
        {IRefs.JoystickButton.B_P6,             KeyCode.Joystick6Button1},
        {IRefs.JoystickButton.X_P6,             KeyCode.Joystick6Button2},
        {IRefs.JoystickButton.Y_P6,             KeyCode.Joystick6Button3},
        {IRefs.JoystickButton.LeftBumper_P6,    KeyCode.Joystick6Button4},
        {IRefs.JoystickButton.RightBumper_P6,   KeyCode.Joystick6Button5},
        {IRefs.JoystickButton.Back_P6,          KeyCode.Joystick6Button6},
        {IRefs.JoystickButton.Start_P6,         KeyCode.Joystick6Button7},
        {IRefs.JoystickButton.LeftStick_P6,     KeyCode.Joystick6Button8},
        {IRefs.JoystickButton.RightStick_P6,    KeyCode.Joystick6Button9},

        /* Player 7 Inputs */
        {IRefs.JoystickButton.A_P7,             KeyCode.Joystick7Button0},
        {IRefs.JoystickButton.B_P7,             KeyCode.Joystick7Button1},
        {IRefs.JoystickButton.X_P7,             KeyCode.Joystick7Button2},
        {IRefs.JoystickButton.Y_P7,             KeyCode.Joystick7Button3},
        {IRefs.JoystickButton.LeftBumper_P7,    KeyCode.Joystick7Button4},
        {IRefs.JoystickButton.RightBumper_P7,   KeyCode.Joystick7Button5},
        {IRefs.JoystickButton.Back_P7,          KeyCode.Joystick7Button6},
        {IRefs.JoystickButton.Start_P7,         KeyCode.Joystick7Button7},
        {IRefs.JoystickButton.LeftStick_P7,     KeyCode.Joystick7Button8},
        {IRefs.JoystickButton.RightStick_P7,    KeyCode.Joystick7Button9},

        /* Player 8 Inputs */
        {IRefs.JoystickButton.A_P8,             KeyCode.Joystick8Button0},
        {IRefs.JoystickButton.B_P8,             KeyCode.Joystick8Button1},
        {IRefs.JoystickButton.X_P8,             KeyCode.Joystick8Button2},
        {IRefs.JoystickButton.Y_P8,             KeyCode.Joystick8Button3},
        {IRefs.JoystickButton.LeftBumper_P8,    KeyCode.Joystick8Button4},
        {IRefs.JoystickButton.RightBumper_P8,   KeyCode.Joystick8Button5},
        {IRefs.JoystickButton.Back_P8,          KeyCode.Joystick8Button6},
        {IRefs.JoystickButton.Start_P8,         KeyCode.Joystick8Button7},
        {IRefs.JoystickButton.LeftStick_P8,     KeyCode.Joystick8Button8},
        {IRefs.JoystickButton.RightStick_P8,    KeyCode.Joystick8Button9}
    };

    /*---------------------------------------------------------------------------------------
        JoystickButton OSX Mappings
    ---------------------------------------------------------------------------------------*/
    /**
        Maps descriptive IRefs.JoystickButton names to joystick KeyCodes for OSX.

        @see IRefs.JoystickButton
    */
    private static SortedList<IRefs.JoystickButton, KeyCode> JoystickButtonOSX = new SortedList<IRefs.JoystickButton, KeyCode>()
    {
        /* No command mapping for joystick buttons on OSX. */
        {IRefs.JoystickButton.None,             KeyCode.None},
        
        /* Player-Independent Inputs */
        {IRefs.JoystickButton.A,                KeyCode.JoystickButton16},
        {IRefs.JoystickButton.B,                KeyCode.JoystickButton17},
        {IRefs.JoystickButton.X,                KeyCode.JoystickButton18},
        {IRefs.JoystickButton.Y,                KeyCode.JoystickButton19},
        {IRefs.JoystickButton.LeftBumper,       KeyCode.JoystickButton13},
        {IRefs.JoystickButton.RightBumper,      KeyCode.JoystickButton14},
        {IRefs.JoystickButton.Back,             KeyCode.JoystickButton10},
        {IRefs.JoystickButton.Start,            KeyCode.JoystickButton9},
        {IRefs.JoystickButton.LeftStick,        KeyCode.JoystickButton11},
        {IRefs.JoystickButton.RightStick,       KeyCode.JoystickButton12},
        {IRefs.JoystickButton.DPadUp,           KeyCode.JoystickButton5},
        {IRefs.JoystickButton.DPadDown,         KeyCode.JoystickButton6},
        {IRefs.JoystickButton.DPadLeft,         KeyCode.JoystickButton7},
        {IRefs.JoystickButton.DPadRight,        KeyCode.JoystickButton8},
        {IRefs.JoystickButton.XBoxButton,       KeyCode.JoystickButton15},

        /* Player 1 Inputs */
        {IRefs.JoystickButton.A_P1,             KeyCode.Joystick1Button16},
        {IRefs.JoystickButton.B_P1,             KeyCode.Joystick1Button17},
        {IRefs.JoystickButton.X_P1,             KeyCode.Joystick1Button18},
        {IRefs.JoystickButton.Y_P1,             KeyCode.Joystick1Button19},
        {IRefs.JoystickButton.LeftBumper_P1,    KeyCode.Joystick1Button13},
        {IRefs.JoystickButton.RightBumper_P1,   KeyCode.Joystick1Button14},
        {IRefs.JoystickButton.Back_P1,          KeyCode.Joystick1Button10},
        {IRefs.JoystickButton.Start_P1,         KeyCode.Joystick1Button9},
        {IRefs.JoystickButton.LeftStick_P1,     KeyCode.Joystick1Button11},
        {IRefs.JoystickButton.RightStick_P1,    KeyCode.Joystick1Button12},
        {IRefs.JoystickButton.DPadUp_P1,        KeyCode.Joystick1Button5},
        {IRefs.JoystickButton.DPadDown_P1,      KeyCode.Joystick1Button6},
        {IRefs.JoystickButton.DPadLeft_P1,      KeyCode.Joystick1Button7},
        {IRefs.JoystickButton.DPadRight_P1,     KeyCode.Joystick1Button8},
        {IRefs.JoystickButton.XBoxButton_P1,    KeyCode.Joystick1Button15},
        
        /* Player 2 Inputs */
        {IRefs.JoystickButton.A_P2,             KeyCode.Joystick2Button16},
        {IRefs.JoystickButton.B_P2,             KeyCode.Joystick2Button17},
        {IRefs.JoystickButton.X_P2,             KeyCode.Joystick2Button18},
        {IRefs.JoystickButton.Y_P2,             KeyCode.Joystick2Button19},
        {IRefs.JoystickButton.LeftBumper_P2,    KeyCode.Joystick2Button13},
        {IRefs.JoystickButton.RightBumper_P2,   KeyCode.Joystick2Button14},
        {IRefs.JoystickButton.Back_P2,          KeyCode.Joystick2Button10},
        {IRefs.JoystickButton.Start_P2,         KeyCode.Joystick2Button9},
        {IRefs.JoystickButton.LeftStick_P2,     KeyCode.Joystick2Button11},
        {IRefs.JoystickButton.RightStick_P2,    KeyCode.Joystick2Button12},
        {IRefs.JoystickButton.DPadUp_P2,        KeyCode.Joystick2Button5},
        {IRefs.JoystickButton.DPadDown_P2,      KeyCode.Joystick2Button6},
        {IRefs.JoystickButton.DPadLeft_P2,      KeyCode.Joystick2Button7},
        {IRefs.JoystickButton.DPadRight_P2,     KeyCode.Joystick2Button8},
        {IRefs.JoystickButton.XBoxButton_P2,    KeyCode.Joystick2Button15},
        
        /* Player 3 Inputs */
        {IRefs.JoystickButton.A_P3,             KeyCode.Joystick3Button16},
        {IRefs.JoystickButton.B_P3,             KeyCode.Joystick3Button17},
        {IRefs.JoystickButton.X_P3,             KeyCode.Joystick3Button18},
        {IRefs.JoystickButton.Y_P3,             KeyCode.Joystick3Button19},
        {IRefs.JoystickButton.LeftBumper_P3,    KeyCode.Joystick3Button13},
        {IRefs.JoystickButton.RightBumper_P3,   KeyCode.Joystick3Button14},
        {IRefs.JoystickButton.Back_P3,          KeyCode.Joystick3Button10},
        {IRefs.JoystickButton.Start_P3,         KeyCode.Joystick3Button9},
        {IRefs.JoystickButton.LeftStick_P3,     KeyCode.Joystick3Button11},
        {IRefs.JoystickButton.RightStick_P3,    KeyCode.Joystick3Button12},
        {IRefs.JoystickButton.DPadUp_P3,        KeyCode.Joystick3Button5},
        {IRefs.JoystickButton.DPadDown_P3,      KeyCode.Joystick3Button6},
        {IRefs.JoystickButton.DPadLeft_P3,      KeyCode.Joystick3Button7},
        {IRefs.JoystickButton.DPadRight_P3,     KeyCode.Joystick3Button8},
        {IRefs.JoystickButton.XBoxButton_P3,    KeyCode.Joystick3Button15},
        
        /* Player 4 Inputs */
        {IRefs.JoystickButton.A_P4,             KeyCode.Joystick4Button16},
        {IRefs.JoystickButton.B_P4,             KeyCode.Joystick4Button17},
        {IRefs.JoystickButton.X_P4,             KeyCode.Joystick4Button18},
        {IRefs.JoystickButton.Y_P4,             KeyCode.Joystick4Button19},
        {IRefs.JoystickButton.LeftBumper_P4,    KeyCode.Joystick4Button13},
        {IRefs.JoystickButton.RightBumper_P4,   KeyCode.Joystick4Button14},
        {IRefs.JoystickButton.Back_P4,          KeyCode.Joystick4Button10},
        {IRefs.JoystickButton.Start_P4,         KeyCode.Joystick4Button9},
        {IRefs.JoystickButton.LeftStick_P4,     KeyCode.Joystick4Button11},
        {IRefs.JoystickButton.RightStick_P4,    KeyCode.Joystick4Button12},
        {IRefs.JoystickButton.DPadUp_P4,        KeyCode.Joystick4Button5},
        {IRefs.JoystickButton.DPadDown_P4,      KeyCode.Joystick4Button6},
        {IRefs.JoystickButton.DPadLeft_P4,      KeyCode.Joystick4Button7},
        {IRefs.JoystickButton.DPadRight_P4,     KeyCode.Joystick4Button8},
        {IRefs.JoystickButton.XBoxButton_P4,    KeyCode.Joystick4Button15},

        /* Player 5 Inputs */
        {IRefs.JoystickButton.A_P5,             KeyCode.Joystick5Button16},
        {IRefs.JoystickButton.B_P5,             KeyCode.Joystick5Button17},
        {IRefs.JoystickButton.X_P5,             KeyCode.Joystick5Button18},
        {IRefs.JoystickButton.Y_P5,             KeyCode.Joystick5Button19},
        {IRefs.JoystickButton.LeftBumper_P5,    KeyCode.Joystick5Button13},
        {IRefs.JoystickButton.RightBumper_P5,   KeyCode.Joystick5Button14},
        {IRefs.JoystickButton.Back_P5,          KeyCode.Joystick5Button10},
        {IRefs.JoystickButton.Start_P5,         KeyCode.Joystick5Button9},
        {IRefs.JoystickButton.LeftStick_P5,     KeyCode.Joystick5Button11},
        {IRefs.JoystickButton.RightStick_P5,    KeyCode.Joystick5Button12},
        {IRefs.JoystickButton.DPadUp_P5,        KeyCode.Joystick5Button5},
        {IRefs.JoystickButton.DPadDown_P5,      KeyCode.Joystick5Button6},
        {IRefs.JoystickButton.DPadLeft_P5,      KeyCode.Joystick5Button7},
        {IRefs.JoystickButton.DPadRight_P5,     KeyCode.Joystick5Button8},
        {IRefs.JoystickButton.XBoxButton_P5,    KeyCode.Joystick6Button15},

        /* Player 6 Inputs */
        {IRefs.JoystickButton.A_P6,             KeyCode.Joystick6Button16},
        {IRefs.JoystickButton.B_P6,             KeyCode.Joystick6Button17},
        {IRefs.JoystickButton.X_P6,             KeyCode.Joystick6Button18},
        {IRefs.JoystickButton.Y_P6,             KeyCode.Joystick6Button19},
        {IRefs.JoystickButton.LeftBumper_P6,    KeyCode.Joystick6Button13},
        {IRefs.JoystickButton.RightBumper_P6,   KeyCode.Joystick6Button14},
        {IRefs.JoystickButton.Back_P6,          KeyCode.Joystick6Button10},
        {IRefs.JoystickButton.Start_P6,         KeyCode.Joystick6Button9},
        {IRefs.JoystickButton.LeftStick_P6,     KeyCode.Joystick6Button11},
        {IRefs.JoystickButton.RightStick_P6,    KeyCode.Joystick6Button12},
        {IRefs.JoystickButton.DPadUp_P6,        KeyCode.Joystick6Button5},
        {IRefs.JoystickButton.DPadDown_P6,      KeyCode.Joystick6Button6},
        {IRefs.JoystickButton.DPadLeft_P6,      KeyCode.Joystick6Button7},
        {IRefs.JoystickButton.DPadRight_P6,     KeyCode.Joystick6Button8},
        {IRefs.JoystickButton.XBoxButton_P6,    KeyCode.Joystick6Button15},

        /* Player 7 Inputs */
        {IRefs.JoystickButton.A_P7,             KeyCode.Joystick7Button16},
        {IRefs.JoystickButton.B_P7,             KeyCode.Joystick7Button17},
        {IRefs.JoystickButton.X_P7,             KeyCode.Joystick7Button18},
        {IRefs.JoystickButton.Y_P7,             KeyCode.Joystick7Button19},
        {IRefs.JoystickButton.LeftBumper_P7,    KeyCode.Joystick7Button13},
        {IRefs.JoystickButton.RightBumper_P7,   KeyCode.Joystick7Button14},
        {IRefs.JoystickButton.Back_P7,          KeyCode.Joystick7Button10},
        {IRefs.JoystickButton.Start_P7,         KeyCode.Joystick7Button9},
        {IRefs.JoystickButton.LeftStick_P7,     KeyCode.Joystick7Button11},
        {IRefs.JoystickButton.RightStick_P7,    KeyCode.Joystick7Button12},
        {IRefs.JoystickButton.DPadUp_P7,        KeyCode.Joystick7Button5},
        {IRefs.JoystickButton.DPadDown_P7,      KeyCode.Joystick7Button6},
        {IRefs.JoystickButton.DPadLeft_P7,      KeyCode.Joystick7Button7},
        {IRefs.JoystickButton.DPadRight_P7,     KeyCode.Joystick7Button8},
        {IRefs.JoystickButton.XBoxButton_P7,    KeyCode.Joystick7Button15},

        /* Player 8 Inputs */
        {IRefs.JoystickButton.A_P8,             KeyCode.Joystick8Button16},
        {IRefs.JoystickButton.B_P8,             KeyCode.Joystick8Button17},
        {IRefs.JoystickButton.X_P8,             KeyCode.Joystick8Button18},
        {IRefs.JoystickButton.Y_P8,             KeyCode.Joystick8Button19},
        {IRefs.JoystickButton.LeftBumper_P8,    KeyCode.Joystick8Button13},
        {IRefs.JoystickButton.RightBumper_P8,   KeyCode.Joystick8Button14},
        {IRefs.JoystickButton.Back_P8,          KeyCode.Joystick8Button10},
        {IRefs.JoystickButton.Start_P8,         KeyCode.Joystick8Button9},
        {IRefs.JoystickButton.LeftStick_P8,     KeyCode.Joystick8Button11},
        {IRefs.JoystickButton.RightStick_P8,    KeyCode.Joystick8Button12},
        {IRefs.JoystickButton.DPadUp_P8,        KeyCode.Joystick8Button5},
        {IRefs.JoystickButton.DPadDown_P8,      KeyCode.Joystick8Button6},
        {IRefs.JoystickButton.DPadLeft_P8,      KeyCode.Joystick8Button7},
        {IRefs.JoystickButton.DPadRight_P8,     KeyCode.Joystick8Button8},
        {IRefs.JoystickButton.XBoxButton_P8,    KeyCode.Joystick8Button15}
    };

    /*---------------------------------------------------------------------------------------
        JoystickButton Linux Mappings
    ---------------------------------------------------------------------------------------*/
    /**
        Maps descriptive IRefs.JoystickButton names to joystick KeyCodes for Linux.

        @see IRefs.JoystickButton
    */
    private static SortedList<IRefs.JoystickButton, KeyCode> JoystickButtonLinux = new SortedList<IRefs.JoystickButton, KeyCode>()
    {
        /* No command mapping for joystick buttons on Linux. */
        {IRefs.JoystickButton.None,             KeyCode.None},
        
        /* Player-Independent Inputs */
        {IRefs.JoystickButton.A,                KeyCode.JoystickButton0},
        {IRefs.JoystickButton.B,                KeyCode.JoystickButton1},
        {IRefs.JoystickButton.X,                KeyCode.JoystickButton2},
        {IRefs.JoystickButton.Y,                KeyCode.JoystickButton3},
        {IRefs.JoystickButton.LeftBumper,       KeyCode.JoystickButton4},
        {IRefs.JoystickButton.RightBumper,      KeyCode.JoystickButton5},
        {IRefs.JoystickButton.Back,             KeyCode.JoystickButton6},
        {IRefs.JoystickButton.Start,            KeyCode.JoystickButton7},
        {IRefs.JoystickButton.LeftStick,        KeyCode.JoystickButton9},
        {IRefs.JoystickButton.RightStick,       KeyCode.JoystickButton10},
        {IRefs.JoystickButton.DPadUp,           KeyCode.JoystickButton13},
        {IRefs.JoystickButton.DPadDown,         KeyCode.JoystickButton14},
        {IRefs.JoystickButton.DPadLeft,         KeyCode.JoystickButton11},
        {IRefs.JoystickButton.DPadRight,        KeyCode.JoystickButton12},
        
        /* Player 1 Inputs */
        {IRefs.JoystickButton.A_P1,             KeyCode.Joystick1Button0},
        {IRefs.JoystickButton.B_P1,             KeyCode.Joystick1Button1},
        {IRefs.JoystickButton.X_P1,             KeyCode.Joystick1Button2},
        {IRefs.JoystickButton.Y_P1,             KeyCode.Joystick1Button3},
        {IRefs.JoystickButton.LeftBumper_P1,    KeyCode.Joystick1Button4},
        {IRefs.JoystickButton.RightBumper_P1,   KeyCode.Joystick1Button5},
        {IRefs.JoystickButton.Back_P1,          KeyCode.Joystick1Button6},
        {IRefs.JoystickButton.Start_P1,         KeyCode.Joystick1Button7},
        {IRefs.JoystickButton.LeftStick_P1,     KeyCode.Joystick1Button9},
        {IRefs.JoystickButton.RightStick_P1,    KeyCode.Joystick1Button10},
        {IRefs.JoystickButton.DPadUp_P1,        KeyCode.Joystick1Button13},
        {IRefs.JoystickButton.DPadDown_P1,      KeyCode.Joystick1Button14},
        {IRefs.JoystickButton.DPadLeft_P1,      KeyCode.Joystick1Button11},
        {IRefs.JoystickButton.DPadRight_P1,     KeyCode.Joystick1Button12},
        
        /* Player 2 Inputs */
        {IRefs.JoystickButton.A_P2,             KeyCode.Joystick2Button0},
        {IRefs.JoystickButton.B_P2,             KeyCode.Joystick2Button1},
        {IRefs.JoystickButton.X_P2,             KeyCode.Joystick2Button2},
        {IRefs.JoystickButton.Y_P2,             KeyCode.Joystick2Button3},
        {IRefs.JoystickButton.LeftBumper_P2,    KeyCode.Joystick2Button4},
        {IRefs.JoystickButton.RightBumper_P2,   KeyCode.Joystick2Button5},
        {IRefs.JoystickButton.Back_P2,          KeyCode.Joystick2Button6},
        {IRefs.JoystickButton.Start_P2,         KeyCode.Joystick2Button7},
        {IRefs.JoystickButton.LeftStick_P2,     KeyCode.Joystick2Button9},
        {IRefs.JoystickButton.RightStick_P2,    KeyCode.Joystick2Button10},
        {IRefs.JoystickButton.DPadUp_P2,        KeyCode.Joystick2Button13},
        {IRefs.JoystickButton.DPadDown_P2,      KeyCode.Joystick2Button14},
        {IRefs.JoystickButton.DPadLeft_P2,      KeyCode.Joystick2Button11},
        {IRefs.JoystickButton.DPadRight_P2,     KeyCode.Joystick2Button12},
        
        /* Player 3 Inputs */
        {IRefs.JoystickButton.A_P3,             KeyCode.Joystick3Button0},
        {IRefs.JoystickButton.B_P3,             KeyCode.Joystick3Button1},
        {IRefs.JoystickButton.X_P3,             KeyCode.Joystick3Button2},
        {IRefs.JoystickButton.Y_P3,             KeyCode.Joystick3Button3},
        {IRefs.JoystickButton.LeftBumper_P3,    KeyCode.Joystick3Button4},
        {IRefs.JoystickButton.RightBumper_P3,   KeyCode.Joystick3Button5},
        {IRefs.JoystickButton.Back_P3,          KeyCode.Joystick3Button6},
        {IRefs.JoystickButton.Start_P3,         KeyCode.Joystick3Button7},
        {IRefs.JoystickButton.LeftStick_P3,     KeyCode.Joystick3Button9},
        {IRefs.JoystickButton.RightStick_P3,    KeyCode.Joystick3Button10},
        {IRefs.JoystickButton.DPadUp_P3,        KeyCode.Joystick3Button13},
        {IRefs.JoystickButton.DPadDown_P3,      KeyCode.Joystick3Button14},
        {IRefs.JoystickButton.DPadLeft_P3,      KeyCode.Joystick3Button11},
        {IRefs.JoystickButton.DPadRight_P3,     KeyCode.Joystick3Button12},
        
        /* Player 4 Inputs */
        {IRefs.JoystickButton.A_P4,             KeyCode.Joystick4Button0},
        {IRefs.JoystickButton.B_P4,             KeyCode.Joystick4Button1},
        {IRefs.JoystickButton.X_P4,             KeyCode.Joystick4Button2},
        {IRefs.JoystickButton.Y_P4,             KeyCode.Joystick4Button3},
        {IRefs.JoystickButton.LeftBumper_P4,    KeyCode.Joystick4Button4},
        {IRefs.JoystickButton.RightBumper_P4,   KeyCode.Joystick4Button5},
        {IRefs.JoystickButton.Back_P4,          KeyCode.Joystick4Button6},
        {IRefs.JoystickButton.Start_P4,         KeyCode.Joystick4Button7},
        {IRefs.JoystickButton.LeftStick_P4,     KeyCode.Joystick4Button9},
        {IRefs.JoystickButton.RightStick_P4,    KeyCode.Joystick4Button10},
        {IRefs.JoystickButton.DPadUp_P4,        KeyCode.Joystick4Button13},
        {IRefs.JoystickButton.DPadDown_P4,      KeyCode.Joystick4Button14},
        {IRefs.JoystickButton.DPadLeft_P4,      KeyCode.Joystick4Button11},
        {IRefs.JoystickButton.DPadRight_P4,     KeyCode.Joystick4Button12},

        /* Player 5 Inputs */
        {IRefs.JoystickButton.A_P5,             KeyCode.Joystick5Button0},
        {IRefs.JoystickButton.B_P5,             KeyCode.Joystick5Button1},
        {IRefs.JoystickButton.X_P5,             KeyCode.Joystick5Button2},
        {IRefs.JoystickButton.Y_P5,             KeyCode.Joystick5Button3},
        {IRefs.JoystickButton.LeftBumper_P5,    KeyCode.Joystick5Button4},
        {IRefs.JoystickButton.RightBumper_P5,   KeyCode.Joystick5Button5},
        {IRefs.JoystickButton.Back_P5,          KeyCode.Joystick5Button6},
        {IRefs.JoystickButton.Start_P5,         KeyCode.Joystick5Button7},
        {IRefs.JoystickButton.LeftStick_P5,     KeyCode.Joystick5Button9},
        {IRefs.JoystickButton.RightStick_P5,    KeyCode.Joystick5Button10},
        {IRefs.JoystickButton.DPadUp_P5,        KeyCode.Joystick5Button13},
        {IRefs.JoystickButton.DPadDown_P5,      KeyCode.Joystick5Button14},
        {IRefs.JoystickButton.DPadLeft_P5,      KeyCode.Joystick5Button11},
        {IRefs.JoystickButton.DPadRight_P5,     KeyCode.Joystick5Button12},

        /* Player 6 Inputs */
        {IRefs.JoystickButton.A_P6,             KeyCode.Joystick6Button0},
        {IRefs.JoystickButton.B_P6,             KeyCode.Joystick6Button1},
        {IRefs.JoystickButton.X_P6,             KeyCode.Joystick6Button2},
        {IRefs.JoystickButton.Y_P6,             KeyCode.Joystick6Button3},
        {IRefs.JoystickButton.LeftBumper_P6,    KeyCode.Joystick6Button4},
        {IRefs.JoystickButton.RightBumper_P6,   KeyCode.Joystick6Button5},
        {IRefs.JoystickButton.Back_P6,          KeyCode.Joystick6Button6},
        {IRefs.JoystickButton.Start_P6,         KeyCode.Joystick6Button7},
        {IRefs.JoystickButton.LeftStick_P6,     KeyCode.Joystick6Button9},
        {IRefs.JoystickButton.RightStick_P6,    KeyCode.Joystick6Button10},
        {IRefs.JoystickButton.DPadUp_P6,        KeyCode.Joystick6Button13},
        {IRefs.JoystickButton.DPadDown_P6,      KeyCode.Joystick6Button14},
        {IRefs.JoystickButton.DPadLeft_P6,      KeyCode.Joystick6Button11},
        {IRefs.JoystickButton.DPadRight_P6,     KeyCode.Joystick6Button12},

        /* Player 7 Inputs */
        {IRefs.JoystickButton.A_P7,             KeyCode.Joystick7Button0},
        {IRefs.JoystickButton.B_P7,             KeyCode.Joystick7Button1},
        {IRefs.JoystickButton.X_P7,             KeyCode.Joystick7Button2},
        {IRefs.JoystickButton.Y_P7,             KeyCode.Joystick7Button3},
        {IRefs.JoystickButton.LeftBumper_P7,    KeyCode.Joystick7Button4},
        {IRefs.JoystickButton.RightBumper_P7,   KeyCode.Joystick7Button5},
        {IRefs.JoystickButton.Back_P7,          KeyCode.Joystick7Button6},
        {IRefs.JoystickButton.Start_P7,         KeyCode.Joystick7Button7},
        {IRefs.JoystickButton.LeftStick_P7,     KeyCode.Joystick7Button9},
        {IRefs.JoystickButton.RightStick_P7,    KeyCode.Joystick7Button10},
        {IRefs.JoystickButton.DPadUp_P7,        KeyCode.Joystick7Button13},
        {IRefs.JoystickButton.DPadDown_P7,      KeyCode.Joystick7Button14},
        {IRefs.JoystickButton.DPadLeft_P7,      KeyCode.Joystick7Button11},
        {IRefs.JoystickButton.DPadRight_P7,     KeyCode.Joystick7Button12},

        /* Player 8 Inputs */
        {IRefs.JoystickButton.A_P8,             KeyCode.Joystick8Button0},
        {IRefs.JoystickButton.B_P8,             KeyCode.Joystick8Button1},
        {IRefs.JoystickButton.X_P8,             KeyCode.Joystick8Button2},
        {IRefs.JoystickButton.Y_P8,             KeyCode.Joystick8Button3},
        {IRefs.JoystickButton.LeftBumper_P8,    KeyCode.Joystick8Button4},
        {IRefs.JoystickButton.RightBumper_P8,   KeyCode.Joystick8Button5},
        {IRefs.JoystickButton.Back_P8,          KeyCode.Joystick8Button6},
        {IRefs.JoystickButton.Start_P8,         KeyCode.Joystick8Button7},
        {IRefs.JoystickButton.LeftStick_P8,     KeyCode.Joystick8Button9},
        {IRefs.JoystickButton.RightStick_P8,    KeyCode.Joystick8Button10},
        {IRefs.JoystickButton.DPadUp_P8,        KeyCode.Joystick8Button13},
        {IRefs.JoystickButton.DPadDown_P8,      KeyCode.Joystick8Button14},
        {IRefs.JoystickButton.DPadLeft_P8,      KeyCode.Joystick8Button11},
        {IRefs.JoystickButton.DPadRight_P8,     KeyCode.Joystick8Button12}
    };

    /*=======================================================================================
        Joystick Axis Suffixes
    =======================================================================================*/
    /**
        Maps Application.RuntimePlatforms to string suffixes which are appended to 
        IRefs.AxisMap names to build Input Manager axis names for joystick inputs on 
        particular runtime platforms.
    */
    private static SortedList<RuntimePlatform, string> JoystickAxisSuffix = new SortedList<RuntimePlatform, string>()
    {
        /* Windows Platforms */
        {RuntimePlatform.WindowsEditor, "_WIN_X"},
        {RuntimePlatform.WindowsPlayer, "_WIN_X"},

        /* OSX Platforms */
        {RuntimePlatform.OSXEditor,     "_OSX_X"},
        {RuntimePlatform.OSXPlayer,     "_OSX_X"},

        /* Linux Platforms */
        {RuntimePlatform.LinuxPlayer,   "_LNX_X"}
    };

    /*=======================================================================================
        GetKey Functions
    =======================================================================================*/
    /**
        Returns true while the requested command is active from a key or joystick button for 
        a specific player.
        
        @returns True while the requested command is active from a key or joystick button.
        
        @param command - The IRefs.Command to check.
        @param inputSource - The IRefs.InputSource to check. Defaults to InputSource.Any.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    public static bool GetKey(IRefs.Command command, int playerNumber = 1, IRefs.InputSource inputSource = IRefs.InputSource.Any)
    {
        /* If an invalid player is requested, throw an ArgumentOutOfRangeException. */
        if ((playerNumber < 0) || (playerNumber > 8))
        {
            throw new System.ArgumentOutOfRangeException(string.Format("Argument " +
                "playerNumber was given as {0}. playerNumber must be an int in the " +
                "range [0-8].", playerNumber), "playerNumber");
        }

        /* Return variable */
        bool isKeyActive;

        /* Check whether the key for the requested command is down. */
        switch (inputSource)
        {
            /* Check any input source. */
            case IRefs.InputSource.Any:
                isKeyActive = (GetKeyboardKey(command, playerNumber) ||
                                GetJoystickButton(command, playerNumber));
                break;

            /* Check keyboard and mouse input. */
            case IRefs.InputSource.KeyboardMouse:
                isKeyActive = GetKeyboardKey(command, playerNumber);
                break;

            /* Check joystick input. */
            case IRefs.InputSource.Joystick:
                isKeyActive = GetJoystickButton(command, playerNumber);
                break;

            /* If an invalid input source is requested, throw an ArgumentOutOfRangeException. */
            default:
                throw new System.ArgumentOutOfRangeException("Argument inputSource is " +
                    "invalid. Please specify an IRefs.InputSource that is not " +
                    "IRefs.InputSource.None.", "inputSource");
        }

        /* Return whether the key for the requested command is active. */
        return isKeyActive;
    }

    /**
        Returns true during the frame the requested command begins from a key or joystick 
        button for a specific player.
        
        @returns True during the frame the requested command begins from a key or joystick 
                    button for a specific player.
        
        @param command - The IRefs.Command to check.
        @param inputSource - The IRefs.InputSource to check. Defaults to InputSource.Any.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    public static bool GetKeyDown(IRefs.Command command, int playerNumber = 1, IRefs.InputSource inputSource = IRefs.InputSource.Any)
    {
        /* If an invalid player is requested, throw an ArgumentOutOfRangeException. */
        if ((playerNumber < 0) || (playerNumber > 8))
        {
            throw new System.ArgumentOutOfRangeException(string.Format("Argument " +
                "playerNumber was given as {0}. playerNumber must be an int in the " +
                "range [0-8].", playerNumber), "playerNumber");
        }

        /* Return variable */
        bool isKeyDown;

        /* Check whether the key for the requested command is going down. */
        switch (inputSource)
        {
            /* Check any input source. */
            case IRefs.InputSource.Any:
                isKeyDown = (GetKeyboardKeyDown(command, playerNumber) ||
                    GetJoystickButtonDown(command, playerNumber));
                break;

            /* Check keyboard and mouse input. */
            case IRefs.InputSource.KeyboardMouse:
                isKeyDown = GetKeyboardKeyDown(command, playerNumber);
                break;

            /* Check joystick input. */
            case IRefs.InputSource.Joystick:
                isKeyDown = GetJoystickButtonDown(command, playerNumber);
                break;

            /* If an invalid input source is requested, throw an ArgumentOutOfRangeException. */
            default:
                throw new System.ArgumentOutOfRangeException("Argument inputSource is " +
                    "invalid. Please specify an IRefs.InputSource that is not " +
                    "IRefs.InputSource.None.", "inputSource");
        }

        /* Return whether the key for the requested command is going down. */
        return isKeyDown;
    }

    /**
        Returns true during the frame the requested command ends from a key or joystick 
        button for a specific player.
        
        @returns True during the frame the requested command ends from a key or joystick 
                        button for a specific player.
        
        @param command - The IRefs.Command to check.
        @param inputSource - The IRefs.InputSource to check. Defaults to InputSource.Any.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    public static bool GetKeyUp(IRefs.Command command, int playerNumber = 1, IRefs.InputSource inputSource = IRefs.InputSource.Any)
    {
        /* If an invalid player is requested, throw an ArgumentOutOfRangeException. */
        if ((playerNumber < 0) || (playerNumber > 8))
        {
            throw new System.ArgumentOutOfRangeException(string.Format("Argument " +
                "playerNumber was given as {0}. playerNumber must be an int in the " +
                "range [0-8].", playerNumber), "playerNumber");
        }

        /* Return variable */
        bool isKeyUp;

        /* Check whether the key for the requested command is going up. */
        switch (inputSource)
        {
            /* Check any input source. */
            case IRefs.InputSource.Any:
                isKeyUp = (GetKeyboardKeyUp(command, playerNumber) ||
                    GetJoystickButtonUp(command, playerNumber));
                break;

            /* Check keyboard and mouse input. */
            case IRefs.InputSource.KeyboardMouse:
                isKeyUp = GetKeyboardKeyUp(command, playerNumber);
                break;

            /* Check joystick input. */
            case IRefs.InputSource.Joystick:
                isKeyUp = GetJoystickButtonUp(command, playerNumber);
                break;

            /* If an invalid input source is requested, throw an ArgumentOutOfRangeException. */
            default:
                throw new System.ArgumentOutOfRangeException("Argument inputSource is " +
                    "invalid. Please specify an IRefs.InputSource that is not " +
                    "IRefs.InputSource.None.", "inputSource");
        }

        /* Return whether the key for the requested command is going up. */
        return isKeyUp;
    }

    /*=======================================================================================
        GetKeyboardKey Functions
    =======================================================================================*/
    /**
        Returns true while the requested command is active from a keyboard or mouse key for 
        a specific player.
        
        @returns True while the requested command is active from a keyboard or mouse key for 
                    a specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static bool GetKeyboardKey(IRefs.Command command, int playerNumber = 1)
    {
        /* Return whether the key for the requested command for the requested player is active. */
        return Input.GetKey(IRefs.KeyMap[(IRefs.CommandStrings[command] + playerNumber)]);
    }

    /**
        Returns true during the frame the requested command begins from a keyboard or mouse 
        key for a specific player.
        
        @returns True during the frame the requested command begins from a keyboard or mouse 
                    key for a specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static bool GetKeyboardKeyDown(IRefs.Command command, int playerNumber = 1)
    {
        /* Return whether the key for the requested command for the requested player is going down. */
        return Input.GetKeyDown(IRefs.KeyMap[(IRefs.CommandStrings[command] + playerNumber)]);
    }

    /**
        Returns true during the frame the requested command ends from a keyboard or mouse 
        key for a specific player.
        
        @returns True during the frame the requested command ends from a keyboard or mouse 
                    key for a specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static bool GetKeyboardKeyUp(IRefs.Command command, int playerNumber = 1)
    {
        /* Return whether the key for the requested command for the requested player is going up. */
        return Input.GetKeyUp(IRefs.KeyMap[(IRefs.CommandStrings[command] + playerNumber)]);
    }

    /*=======================================================================================
        GetJoystickButton Functions
    =======================================================================================*/
    /**
        Returns true while the requested command is active from a joystick button for a 
        specific player.
        
        @returns True while the requested command is active from a joystick button for a 
                    specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static bool GetJoystickButton(IRefs.Command command, int playerNumber = 1)
    {
        /* Return variable. */
        bool isButtonActive;

        /* The joystick button for the requested command for the requested player. */
        IRefs.JoystickButton button = IRefs.JoystickButtonMap[(IRefs.CommandStrings[command] + playerNumber)];

        /* Check whether the joystick button for the requested command for the requested 
            player is active for the current runtime platform. */
        switch (Application.platform)
        {
            /* Check joystick input on Windows. */
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                isButtonActive = Input.GetKey(IRefs.JoystickButtonWindows[button]);
                break;

            /* Check joystick input on OSX. */
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                isButtonActive = Input.GetKey(IRefs.JoystickButtonOSX[button]);
                break;

            /* Check joystick input on Linux. */
            case RuntimePlatform.LinuxPlayer:
                isButtonActive = Input.GetKey(IRefs.JoystickButtonLinux[button]);
                break;

            /* If platform is not Windows, OSX, or Linux, throw an exception. */
            default:
                throw new IRefs.UnsupportedPlatformException("The current application " +
                    "platform is not supported by class IRefs. Only Windows, OSX, and " +
                    "Linux platforms are supported.");
        }

        /* Return whether the joystick button for the requested command is active. */
        return isButtonActive;
    }

    /**
        Returns true during the frame the requested command begins from a joystick button 
        for a specific player.
        
        @returns True during the frame the requested command begins from a joystick button 
                    for a specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static bool GetJoystickButtonDown(IRefs.Command command, int playerNumber = 1)
    {
        /* Return variable. */
        bool isButtonDown;

        /* The joystick button for the requested command for the requested player. */
        IRefs.JoystickButton button = IRefs.JoystickButtonMap[(IRefs.CommandStrings[command] + playerNumber)];

        /* Check whether the joystick button for the requested command for the requested 
            player is active for the current runtime platform. */
        switch (Application.platform)
        {
            /* Check joystick input on Windows. */
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                isButtonDown = Input.GetKeyDown(IRefs.JoystickButtonWindows[button]);
                break;

            /* Check joystick input on OSX. */
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                isButtonDown = Input.GetKeyDown(IRefs.JoystickButtonOSX[button]);
                break;

            /* Check joystick input on Linux. */
            case RuntimePlatform.LinuxPlayer:
                isButtonDown = Input.GetKeyDown(IRefs.JoystickButtonLinux[button]);
                break;

            /* If platform is not Windows, OSX, or Linux, throw an exception. */
            default:
                throw new IRefs.UnsupportedPlatformException("The current application " +
                    "platform is not supported by class IRefs. Only Windows, OSX, and " +
                    "Linux platforms are supported.");
        }

        /* Return whether the joystick button for the requested command is going down. */
        return isButtonDown;
    }

    /**
        Returns true during the frame the requested command ends from a joystick button 
        for a specific player.
        
        @returns True during the frame the requested command ends from a joystick button 
                    for a specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static bool GetJoystickButtonUp(IRefs.Command command, int playerNumber = 1)
    {
        /* Return variable. */
        bool isButtonUp;

        /* The joystick button for the requested command for the requested player. */
        IRefs.JoystickButton button = IRefs.JoystickButtonMap[(IRefs.CommandStrings[command] + playerNumber)];

        /* Check whether the joystick button for the requested command for the requested 
            player is active for the current runtime platform. */
        switch (Application.platform)
        {
            /* Check joystick input on Windows. */
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                isButtonUp = Input.GetKeyUp(IRefs.JoystickButtonWindows[button]);
                break;

            /* Check joystick input on OSX. */
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                isButtonUp = Input.GetKeyUp(IRefs.JoystickButtonOSX[button]);
                break;

            /* Check joystick input on Linux. */
            case RuntimePlatform.LinuxPlayer:
                isButtonUp = Input.GetKeyUp(IRefs.JoystickButtonLinux[button]);
                break;

            /* If platform is not Windows, OSX, or Linux, throw an exception. */
            default:
                throw new IRefs.UnsupportedPlatformException("The current application " +
                    "platform is not supported by class IRefs. Only Windows, OSX, and " +
                    "Linux platforms are supported.");
        }

        /* Return whether the joystick button for the requested command is going up. */
        return isButtonUp;
    }

    /*=======================================================================================
        GetAxis Functions
    =======================================================================================*/
    /**
        Returns the value of the axis for the requested command from keyboard and mouse or 
        joystick inputs for a specific player.
        
        @returns The value of the axis for the requested command from keyboard and mouse or 
                    joystick inputs for a specific player.
        
        @param command - The IRefs.Command to check.
        @param inputSource - The IRefs.InputSource to check. Defaults to InputSource.Any.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    public static float GetAxis(IRefs.Command command, int playerNumber = 1, IRefs.InputSource inputSource = IRefs.InputSource.Any)
    {
        /* If an invalid player is requested, throw an ArgumentOutOfRangeException. */
        if ((playerNumber < 0) || (playerNumber > 8))
        {
            throw new System.ArgumentOutOfRangeException(string.Format("Argument " +
                "playerNumber was given as {0}. playerNumber must be an int in the " +
                "range [0-8].", playerNumber), "playerNumber");
        }

        /* Return variable. */
        float axis;

        /* Check the axis for the requested command. */
        switch (inputSource)
        {
            /* Check any input source. */
            case IRefs.InputSource.Any:
                axis = DominantAxisOf(GetKeyboardAxis(command, playerNumber), GetJoystickAxis(command, playerNumber));
                break;

            /* Check keyboard and mouse input. */
            case IRefs.InputSource.KeyboardMouse:
                axis = GetKeyboardAxis(command, playerNumber);
                break;

            /* Check joystick input. */
            case IRefs.InputSource.Joystick:
                axis = GetJoystickAxis(command, playerNumber);
                break;

            /* If an invalid input source is requested, throw an ArgumentOutOfRangeException. */
            default:
                throw new System.ArgumentOutOfRangeException("Argument inputSource is " +
                    "invalid. Please specify an IRefs.InputSource that is not " +
                    "IRefs.InputSource.None.", "inputSource");
        }

        /* Return the dominant axis for the requested command. */
        return axis;
    }

    /**
        Returns the value of the axis for the requested command from keyboard and mouse 
        inputs for a specific player.
        
        @returns The value of the axis for the requested command from keyboard and mouse 
                    inputs for a specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static float GetKeyboardAxis(IRefs.Command command, int playerNumber = 1)
    {
        /* Return the value of the axis for the requested command for the requested player. */
        return Input.GetAxis(IRefs.AxisMap[(IRefs.CommandStrings[command] + playerNumber)]);
    }

    /**
        Returns the value of the axis for the requested command from joystick inputs for a 
        specific player.
        
        @returns The value of the axis for the requested command from joystick inputs for a 
                    specific player.
        
        @param command - The IRefs.Command to check.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    private static float GetJoystickAxis(IRefs.Command command, int playerNumber = 1)
    {
        /* Return the value of the axis for the requested command for the requested player 
            on the current runtime platform. */
        return Input.GetAxis(IRefs.AxisMap[(IRefs.CommandStrings[command] + playerNumber)] +
                                IRefs.JoystickAxisSuffix[Application.platform]);
    }

    /*=======================================================================================
        GetAxisRaw Functions
    =======================================================================================*/
    /**
        Returns the normalized value of the axis for the requested command from keyboard and 
        mouse or joystick inputs for a specific player. (i.e., -1, 0, or 1, matching the 
        sign of the smoothed axis value.)
        
        @returns The normalized value of the axis for the requested command from keyboard 
                    and mouse or joystick inputs for a specific player.
        
        @param command - The IRefs.Command to check.
        @param inputSource - The IRefs.InputSource to check. Defaults to InputSource.Any.
        @param playerNumber - The player to check input for. Must be within the range [0-8], 
                                with zero indicating that all players' input should be 
                                checked. Defaults to 1.
    */
    public static float GetAxisRaw(IRefs.Command command, int playerNumber = 1, IRefs.InputSource inputSource = IRefs.InputSource.Any)
    {
        /* If an invalid player is requested, throw an ArgumentOutOfRangeException. */
        if ((playerNumber < 0) || (playerNumber > 8))
        {
            throw new System.ArgumentOutOfRangeException(string.Format("Argument " +
                "playerNumber was given as {0}. playerNumber must be an int in the " +
                "range [0-8].", playerNumber), "playerNumber");
        }

        /* Get the dominant axis for the requested command from the requested input source 
            for the requested player. */
        float axis = IRefs.GetAxis(command, playerNumber, inputSource);

        /* Return the normalized value of the axis. */
        return System.Math.Sign(axis);
    }

    /*=======================================================================================
        Axis Support Functions
    =======================================================================================*/
    /**
        Returns the value of the axis with the greatest absolute value from those passed in 
        as parameters.
        
        @returns The value of the axis with the greatest absolute value from those passed in 
                    as parameters.
        
        @param axes - A variable parameter list of axes as floats.
    */
    public static float DominantAxisOf(params float[] axes)
    {
        /* Default return value to zero. */
        float dominantAxis = 0;

        /* Iterate through the list of axes and keep the one with the greatest absolute 
            value. */
        foreach (float axis in axes)
        {
            if (System.Math.Abs(axis) > System.Math.Abs(dominantAxis))
            {
                dominantAxis = axis;
            }
        }

        /* Return the dominant axis. */
        return dominantAxis;
    }

    /*=======================================================================================
        GetMouse Functions
    =======================================================================================*/
    /**
        Returns a Vector2 containing the mouse's abscissa and ordinate from the bottom-left 
        corner of the screen as ratios in the range [0-1].

        Examples of possible returns:
        
        Top-Right corner        = ( 1   , 1   )
        Bottom-Right corner     = ( 1   , 0   )
        Bottom-Left corner      = ( 0   , 0   )
        Top-Left corner         = ( 0   , 1   )

        Center of screen        = ( 0.5 , 0.5 )
        Top-Center of screen    = ( 0.5 , 1   )
        Center-Right of screen  = ( 1   , 0.5 )
        Bottom-Center of screen = ( 0.5 , 0   )
        Center-Left of screen   = ( 0   , 0.5 )

        Center of top-right quadrant    = ( 0.75 , 0.75 )
        Center of bottom-right quadrant = ( 0.75 , 0.25 )
        Center of bottom-left quadrant  = ( 0.25 , 0.25 )
        Center of top-left quadrant     = ( 0.25 , 0.75 )

        @returns A Vector2 containing the mouse's abscissa and ordinate from the 
                    bottom-left corner of the screen as ratios in the range [0-1].
    */
    public static Vector2 GetMouse()
    {
        /* Get the mouse's abscissa and ordinate ratios from the bottom-left corner of 
            the screen. */
        float abscissa = Input.mousePosition.x / Screen.width;
        float ordinate = Input.mousePosition.y / Screen.height;

        /* Return the mouse's displacement ratios from the bottom-left corner of the 
            screen. */
        return new Vector2(abscissa, ordinate);
    }

    /**
        Returns a Vector2 containing the mouse's abscissa and ordinate from the center of 
        the screen as ratios in the range [-1-1].

        Examples of possible returns:
        
        Top-Right corner        = (  1 ,  1 )
        Bottom-Right corner     = (  1 , -1 )
        Bottom-Left corner      = ( -1 , -1 )
        Top-Left corner         = ( -1 ,  1 )

        Center of screen        = (  0 ,  0 )
        Top-Center of screen    = (  0 ,  1 )
        Center-Right of screen  = (  1 ,  0 )
        Bottom-Center of screen = (  0 , -1 )
        Center-Left of screen   = ( -1 ,  0 )

        Center of top-right quadrant    = (  0.5 ,  0.5 )
        Center of bottom-right quadrant = (  0.5 , -0.5 )
        Center of bottom-left quadrant  = ( -0.5 , -0.5 )
        Center of top-left quadrant     = ( -0.5 ,  0.5 )

        @returns A Vector2 containing the mouse's abscissa and ordinate from the center of 
                    the screen as ratios in the range [-1-1].
    */
    public static Vector2 GetMouseFromCenter()
    {
        /* Get the mouse's abscissa and ordinate ratios from the center of the screen. */
        float abscissa = ((Input.mousePosition.x * 2) - Screen.width) / Screen.width;
        float ordinate = ((Input.mousePosition.y * 2) - Screen.height) / Screen.height;

        /* Return the mouse's displacement ratios from the center of the screen. */
        return new Vector2(abscissa, ordinate);
    }

    /*=======================================================================================
        Custom Exception Types
    =======================================================================================*/
    /**
        Exception type due to IRefs functions that depend on the application platform being 
        called while the application is running on an unsupported RuntimePlatform.
    */
    private class UnsupportedPlatformException : System.Exception
    {
        public UnsupportedPlatformException() { }
        public UnsupportedPlatformException(string message) : base(message) { }
        public UnsupportedPlatformException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
