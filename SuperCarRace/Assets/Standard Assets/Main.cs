using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;

public class aCar : object {

	public GameObject go;
	public CarController controller;
	public CarAIControl ai;

	public aCar(string carName){
		go = GameObject.Find (carName);
		controller = (CarController)go.GetComponent(typeof(CarController));
		ai = (CarAIControl)go.GetComponent(typeof(CarAIControl));
	}

}

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

    aCar AICar1;
	aCar AICar2;
	aCar AICar3;
	aCar AICar4;


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

		AICar1 = new aCar ("AICar1");
		AICar2 = new aCar ("AICar2");
		AICar3 = new aCar ("AICar3");
		AICar4 = new aCar ("AICar4");

    }

    // Update is called once per frame
    void Update () {



        if (haveUpdated == false)
        {
            haveUpdated = true;
            updateMenus();
        }

		AICar1.controller.udpateText ();
		AICar2.controller.udpateText ();
		AICar3.controller.udpateText ();
		AICar4.controller.udpateText ();

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

		AICar1.ai.StartDriving ();
		AICar2.ai.StartDriving ();
		AICar3.ai.StartDriving ();
		AICar4.ai.StartDriving ();

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
