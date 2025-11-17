using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text menuText;
    public int button;
    bool[] buttonMainSelect;
    string[] buttonMainText;
    bool[] buttonSettingsSelect;
    string[] buttonSettingsText;
    bool[] buttonGameOverSelect;
    string[] buttonGameOverText;
    bool[] buttonYouWinSelect;
    string[] buttonYouWinText;
    bool[] buttonCreditsSelect;
    string[] buttonCreditsText;
    bool check;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if ( GameManager.gameManager.gameState == "game" ){
            this.gameObject.SetActive(false);
        }
        button = 0;
        buttonMainSelect = new bool[] { true, false, false, false };
        buttonMainText = new string[] { "> Start <", "  Settings  ", "  Credits  ", "  Quit  "};
        buttonSettingsSelect = new bool[] { true, false, false };
        buttonSettingsText = new string[] { "> Fullscreen <", "  VSync  ", "  Back  " };
        buttonGameOverSelect = new bool[] { true, false, false };
        buttonGameOverText = new string[] { "> Retry <", "  Main Menu  ", "  Quit  " };
        buttonYouWinSelect = new bool[] { true, false, false };
        buttonYouWinText = new string[] { "> Retry <", "  Main Menu  ", "  Quit  " };
        buttonCreditsSelect = new bool[] { true };
        buttonCreditsText = new string[] { "> Back <" };
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if ( button < 3) {
            // if (Input.GetKeyDown(KeyCode.S)){
                // button += 1;
            // }
        // }

        // if ( button > 0 ){
            // if (Input.GetKeyDown(KeyCode.W)){
                // button -= 1;
            // }
        // }

        // Debug.Log("Button: "+button);

        // if (Input.GetKeyDown(KeyCode.Space)){
            // switch (button){
                // Start
                // case 0:
                    // GameManager.gameManager.gameState = "game";
                // break;
                // Settings
                // case 1:

                // break;
                // Credits
                // case 2:

                // break;
                // Quit
                // case 3:
                    // Application.Quit();
                // break;
            // }
        // }
        
        // Debug.Log("Menu State: "+GameManager.gameManager.menuType);

        // setting the text stuff
        if ( GameManager.gameManager.menuType == "main" ) {
            menuText.text = "COMETS: THE GAME" + "\n" + "\n" + "\n" + "\n" + buttonMainText[0] + "\n" + buttonMainText[1] + "\n" + buttonMainText[2] + "\n" + buttonMainText[3];
        }
        if ( GameManager.gameManager.menuType == "settings" ) {
            menuText.text = "SETTINGS" + "\n" + "\n" + "\n" + "\n" + buttonSettingsText[0] + "\n" + buttonSettingsText[1] + "\n" + buttonSettingsText[2] + "\n";
        }
        if ( GameManager.gameManager.menuType == "gameover" ) {
            menuText.text = "GAME OVER" + "\n" + "\n" + "\n" + "\n" + buttonGameOverText[0] + "\n" + buttonGameOverText[1] + "\n" + buttonGameOverText[2];
        }
        if ( GameManager.gameManager.menuType == "youwin" ) {
            menuText.text = "YOU WIN!" + "\n" + "\n" + "\n" + "\n" + buttonYouWinText[0] + "\n" + buttonYouWinText[1] + "\n" + buttonYouWinText[2];
        }
        if ( GameManager.gameManager.menuType == "credits" ) {
            menuText.text = "CREDITS" + "\n" + "\n" + "\n" + "\n" + "Art: PenelopeG4m3s\nProgramming: PenelopeG4m3s" + "\n" + "Audio:"+ "\n" + "Thunka wunka mysterion.wav - Calethos" + "\n" + "8 bit death sound - MentosLat" + "\n" + "Fire 1 8bit.wav - Mrthenoronha" + "\n" + "UFO.wav - Calmarius" + "\n" + buttonCreditsText[0];
        }
    }

    // Select Up
    public void SelectUp(){
        if ( button > 0 ){
            button -= 1;
            // make sure we are in the main menu
            if ( GameManager.gameManager.menuType == "main" ){
                buttonMainSelect[0] = false;
                buttonMainSelect[1] = false;
                buttonMainSelect[2] = false;
                buttonMainSelect[3] = false;
                buttonMainSelect[button] = true;
                buttonMainText[0] = "  Start  ";
                buttonMainText[1] = "  Settings  ";
                buttonMainText[2] = "  Credits  ";
                buttonMainText[3] = "  Quit  ";
                buttonMainText[button] = "> " + buttonMainText[button] + " <";
            }
            // make sure we are in the settings menu
            if ( GameManager.gameManager.menuType == "settings" ){
                buttonSettingsSelect[0] = false;
                buttonSettingsSelect[1] = false;
                buttonSettingsSelect[2] = false;
                buttonSettingsSelect[button] = true;
                buttonSettingsText[0] = "  Fullscreen  ";
                buttonSettingsText[1] = "  VSync  ";
                buttonSettingsText[2] = "  Back  ";
                buttonSettingsText[button] = "> " + buttonSettingsText[button] + " <";
            }
            // make sure we are in the game over menu
            if ( GameManager.gameManager.menuType == "gameover" ) {
                buttonGameOverSelect[0] = false;
                buttonGameOverSelect[1] = false;
                buttonGameOverSelect[2] = false;
                buttonGameOverSelect[button] = true;
                buttonGameOverText[0] = "  Retry  ";
                buttonGameOverText[1] = "  Main Menu  ";
                buttonGameOverText[2] = "  Quit  ";
                buttonGameOverText[button] = "> " + buttonGameOverText[button] + " <";
            }
            // make sure we are in the you win menu
            if ( GameManager.gameManager.menuType == "youwin" ) {
                buttonYouWinSelect[0] = false;
                buttonYouWinSelect[1] = false;
                buttonYouWinSelect[2] = false;
                buttonYouWinSelect[button] = true;
                buttonYouWinText[0] = "  Retry  ";
                buttonYouWinText[1] = "  Main Menu  ";
                buttonYouWinText[2] = "  Quit  ";
                buttonYouWinText[button] = "> " + buttonYouWinText[button] + " <";
            }
        }
    }

    // Select Down
    public void SelectDown(){
        if ( button < 3 ){
            button += 1;
            // make sure we are in the main menu
            if ( GameManager.gameManager.menuType == "main" ){
                buttonMainSelect[0] = false;
                buttonMainSelect[1] = false;
                buttonMainSelect[2] = false;
                buttonMainSelect[3] = false;
                buttonMainSelect[button] = true;
                buttonMainText[0] = "  Start  ";
                buttonMainText[1] = "  Settings  ";
                buttonMainText[2] = "  Credits  ";
                buttonMainText[3] = "  Quit  ";
                buttonMainText[button] = "> " + buttonMainText[button] + " <";
            }
            // make sure we are in the settings menu
            if ( GameManager.gameManager.menuType == "settings" ){
                buttonSettingsSelect[0] = false;
                buttonSettingsSelect[1] = false;
                buttonSettingsSelect[2] = false;
                buttonSettingsSelect[button] = true;
                buttonSettingsText[0] = "  Fullscreen  ";
                buttonSettingsText[1] = "  VSync  ";
                buttonSettingsText[2] = "  Back  ";
                buttonSettingsText[button] = "> " + buttonSettingsText[button] + " <";
            }
            // make sure we are in the game over menu
            if ( GameManager.gameManager.menuType == "gameover" ) {
                buttonGameOverSelect[0] = false;
                buttonGameOverSelect[1] = false;
                buttonGameOverSelect[2] = false;
                buttonGameOverSelect[button] = true;
                buttonGameOverText[0] = "  Retry  ";
                buttonGameOverText[1] = "  Main Menu  ";
                buttonGameOverText[2] = "  Quit  ";
                buttonGameOverText[button] = "> " + buttonGameOverText[button] + " <";
            }
            // make sure we are in the you win menu
            if ( GameManager.gameManager.menuType == "youwin" ) {
                buttonYouWinSelect[0] = false;
                buttonYouWinSelect[1] = false;
                buttonYouWinSelect[2] = false;
                buttonYouWinSelect[button] = true;
                buttonYouWinText[0] = "  Retry  ";
                buttonYouWinText[1] = "  Main Menu  ";
                buttonYouWinText[2] = "  Quit  ";
                buttonYouWinText[button] = "> " + buttonYouWinText[button] + " <";
            }
        }
    }

    // Accept
    public void Accept(){
        check = true;
        // check that we are in the main menu
        if ( GameManager.gameManager.menuType == "main" && check){
            switch (button){
                // Start
                case 0:
                    GameManager.gameManager.StartGame();
                    // GameManager.gameManager.lives = 3;
                    // ui.gameObject.SetActive(true);
                    // this.gameObject.SetActive(false);
                    check = false;
                break;
                // Settings
                case 1:
                    GameManager.gameManager.menuType = "settings";
                    button = 0;
                    buttonSettingsSelect[0] = true;
                    buttonSettingsSelect[1] = false;
                    buttonSettingsSelect[2] = false;
                    buttonSettingsText[0] = "> Fullscreen <";
                    buttonSettingsText[1] = "  VSync  ";
                    buttonSettingsText[2] = "  Back  ";
                    check = false;
                break;
                // Credits
                case 2:
                    GameManager.gameManager.menuType = "credits";
                    button = 0;
                    buttonCreditsSelect[0] = true;
                    check = false;
                break;
                // Quit
                case 3:
                    Application.Quit();
                    check = false;
                break;
            }
        }
        // check that we are in the settings menu
        if ( GameManager.gameManager.menuType == "settings" && check){
            switch (button){
                // Fullscreen
                case 0:
                    Screen.fullScreen = !Screen.fullScreen;
                    check = false;
                break;
                // VSync
                case 1:
                    if ( QualitySettings.vSyncCount == 1 ){
                        QualitySettings.vSyncCount = 2;
                    }
                    if (QualitySettings.vSyncCount == 0){
                        QualitySettings.vSyncCount = 2;
                    }
                    if (QualitySettings.vSyncCount == 2){
                        QualitySettings.vSyncCount = 0;
                    }
                    check = false;
                break;
                // Back
                case 2:
                    Debug.Log("Menu.cs line 260 menuType == "+GameManager.gameManager.menuType);
                    GameManager.gameManager.menuType = "main";
                    button = 1;
                    buttonMainSelect[0] = false;
                    buttonMainSelect[1] = true;
                    buttonMainSelect[2] = false;
                    buttonMainSelect[3] = false;
                    buttonMainText[0] = "  Start  ";
                    buttonMainText[1] = "> Settings <";
                    buttonMainText[2] = "  Credits  ";
                    buttonMainText[3] = "  Quit  ";
                    check = false;
                break;
            }
        }
        // check that we are in the game over menu
        if ( GameManager.gameManager.menuType == "gameover" && check) {
            switch(button){
                // Retry
                case 0:
                    GameManager.gameManager.StartGame();
                    check = false;
                break;
                // Main Menu
                case 1:
                    GameManager.gameManager.menuType = "main";
                    button = 0;
                    buttonMainSelect[0] = true;
                    buttonMainSelect[1] = false;
                    buttonMainSelect[2] = false;
                    buttonMainSelect[3] = false;
                    buttonMainText[0] = "> Start <";
                    buttonMainText[1] = "  Settings  ";
                    buttonMainText[2] = "  Credits  ";
                    buttonMainText[3] = "  Quit  ";
                    buttonGameOverText[0] = "> Retry <";
                    buttonGameOverText[1] = "  Main Menu  ";
                    buttonGameOverText[2] = "  Quit  ";
                    check = false;
                break;
                // Quit
                case 2:
                    Application.Quit();
                    check = false;
                break;
            }
        }
        // check that we are in the you win menu
        if ( GameManager.gameManager.menuType == "youwin" && check) {
            switch(button){
                // Retry
                case 0:
                    GameManager.gameManager.StartGame();
                    check = false;
                break;
                // Main Menu
                case 1:
                    GameManager.gameManager.menuType = "main";
                    button = 0;
                    buttonMainSelect[0] = true;
                    buttonMainSelect[1] = false;
                    buttonMainSelect[2] = false;
                    buttonMainSelect[3] = false;
                    buttonMainText[0] = "> Start <";
                    buttonMainText[1] = "  Settings  ";
                    buttonMainText[2] = "  Credits  ";
                    buttonMainText[3] = "  Quit  ";
                    buttonYouWinText[0] = "> Retry <";
                    buttonYouWinText[1] = "  Main Menu  ";
                    buttonYouWinText[2] = "  Quit  ";
                    check = false;
                break;
                // Quit
                case 2:
                    Application.Quit();
                    check = false;
                break;
            }
        }
        // check that we are in the credits menu
        if ( GameManager.gameManager.menuType == "credits" && check) {
            switch (button) {
                // back
                case 0:
                    GameManager.gameManager.menuType = "main";
                    button = 2;
                    buttonMainSelect[0] = false;
                    buttonMainSelect[1] = false;
                    buttonMainSelect[2] = true;
                    buttonMainSelect[3] = false;
                    buttonMainText[0] = "  Start  ";
                    buttonMainText[1] = "  Settings  ";
                    buttonMainText[2] = "> Credits <";
                    buttonMainText[3] = "  Quit  ";
                    check = false;
                break;
            }
        }
    }

}
