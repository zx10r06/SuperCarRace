using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;

public class Main : MonoBehaviour {

    bool isMainMenu = true;
    GameObject MainMenu;
    bool isPaused = false;
    GameObject PauseMenu;
    GameObject InGameMenu;
    GameObject WinMenu;
    ArrayList objectsToReset = new ArrayList();
    GameObject CameraCar;
    GameObject PlayerCar;
    GameObject PlayerCarCam;
    bool haveUpdated = false;

    public bool raceFinished = false;

    GameObject AICar1;
    GameObject AICar2;
    GameObject AICar3;
    GameObject AICar4;

    /*
    WaypointProgressTracker AICar1_wpt;
    WaypointProgressTracker AICar2_wpt;
    WaypointProgressTracker AICar3_wpt;
    WaypointProgressTracker AICar4_wpt;
    */


    CarController AICar1_controller;
    CarController AICar2_controller;
    CarController AICar3_controller;
    CarController AICar4_controller;

    // Use this for initialization
    void Start () {

        MainMenu = GameObject.Find("MainMenu");
        PauseMenu = GameObject.Find("PauseMenu");
        InGameMenu = GameObject.Find("InGameMenu");
        WinMenu = GameObject.Find("WinMenu");
        CameraCar = GameObject.Find("CameraCar");
        PlayerCar = GameObject.Find("PlayerCar");
        PlayerCarCam = GameObject.Find("PlayerCamera");
        //FindGameObjectsWithTag("PlayerCamera")[0];

        AddObjectToReset("CameraCar");
        AddObjectToReset("AICar1");
        AddObjectToReset("AICar2");
        AddObjectToReset("AICar3");
        AddObjectToReset("AICar4");
        AddObjectToReset("PlayerCar");

        PlayerCarCam.SetActive(false);
        //PlayerCar.SetActive(false);

        AICar1 = (GameObject)GameObject.Find("AICar1");
        AICar2 = (GameObject)GameObject.Find("AICar2");
        AICar3 = (GameObject)GameObject.Find("AICar3");
        AICar4 = (GameObject)GameObject.Find("AICar4");

        /*
        AICar1_wpt = (WaypointProgressTracker)AICar1.GetComponent(typeof(WaypointProgressTracker));
        AICar2_wpt = (WaypointProgressTracker)AICar2.GetComponent(typeof(WaypointProgressTracker));
        AICar3_wpt = (WaypointProgressTracker)AICar3.GetComponent(typeof(WaypointProgressTracker));
        AICar4_wpt = (WaypointProgressTracker)AICar4.GetComponent(typeof(WaypointProgressTracker));
        */

        AICar1_controller = (CarController)GameObject.Find("AICar1").GetComponent(typeof(CarController));
        AICar2_controller = (CarController)GameObject.Find("AICar2").GetComponent(typeof(CarController));
        AICar3_controller = (CarController)GameObject.Find("AICar3").GetComponent(typeof(CarController));
        AICar4_controller = (CarController)GameObject.Find("AICar4").GetComponent(typeof(CarController));

    }

    // Update is called once per frame
    void Update () {



        if (haveUpdated == false)
        {
            haveUpdated = true;
            updateMenus();
        }


        AICar1_controller.udpateText();
        AICar2_controller.udpateText();
        AICar3_controller.udpateText();
        AICar4_controller.udpateText();

        //Check if finished race
        //if (isMainMenu == false)
        //{



        string[] s = new string[1];
        s[0] = "CameraCar";
        foreach (string carName in s)
        {

        GameObject go = GameObject.Find(carName);
        if (go != null)
        {
            CarAIControl cAI = (CarAIControl)GameObject.Find(carName).GetComponent(typeof(CarAIControl));
            if (cAI.amDriving() == false)
            {
                ResetRace();
            }
        }


        }

        //}



    }

    void updateMenus() {

        if (isMainMenu)
        {
            MainMenu.SetActive(true);
            PauseMenu.SetActive(false);
            InGameMenu.SetActive(false);
            WinMenu.SetActive(false);

            if (raceFinished)
            {
                WinMenu.SetActive(true);
            }

        }
        else
        {

            CameraCar.SetActive(false);
            MainMenu.SetActive(false);
            WinMenu.SetActive(false);
            PlayerCarCam.SetActive(true);

            if (isPaused)
            {
                PauseMenu.SetActive(true);
                InGameMenu.SetActive(false);
            }
            else if (raceFinished) {
                WinMenu.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(false);
                InGameMenu.SetActive(true);
                WinMenu.SetActive(false);
            }
        }

    }

    void AddObjectToReset(string name)
    {
        objectsToReset.Add(
            (CarController)GameObject.Find(name)
                .GetComponent(typeof(CarController))
        );
    }

    public void PauseRace() {
        Time.timeScale = 0.0f;
        isPaused = true;
        updateMenus();
    }

    public void StartRace() {
        raceFinished = false;
        isMainMenu = false;
        ResetRace();
        updateMenus();
    }

    public void ResumeRace()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        updateMenus();
    }

    public void ResetRace() {

        raceFinished = false;
        foreach (CarController cc in objectsToReset)
        {
            cc.ResetVehicle();
        }
        ResumeRace();
        updateMenus();
        raceFinished = false;
    }

    public int GetPosition(string carName) {
        // Check each Cars position for the highest... 
        // highest is first, lowest is last
        WaypointProgressTracker wpt = (WaypointProgressTracker)GameObject.Find(carName).GetComponent(typeof(WaypointProgressTracker));
        int myPosition = 1;
        float myDistanceTravelled = 0.0f;
        foreach (CarController cc in objectsToReset)
        {
            if (cc.name == carName)
            {
                myDistanceTravelled = wpt.progressDistance;
            }
        }
        foreach (CarController cc in objectsToReset)
        {
            if (cc.name != "PlayerCar" && cc.name != "CameraCar" && cc.name != carName)
            {
                WaypointProgressTracker wpt2 = (WaypointProgressTracker)GameObject.Find(cc.name).GetComponent(typeof(WaypointProgressTracker));
                if (wpt2.progressDistance > myDistanceTravelled)
                {
                    myPosition = myPosition + 1;
                }
            }
        }
        return (myPosition);
    }

    public void FinishedRace() {
        raceFinished = true;
        updateMenus();
    }


}
