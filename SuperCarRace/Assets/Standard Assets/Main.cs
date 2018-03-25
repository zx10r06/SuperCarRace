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
    GameObject InGameMenu;
    GameObject WinMenu;
    ArrayList objectsToReset = new ArrayList();
    GameObject CameraCar;
    GameObject PlayerCar;
    GameObject PlayerCarCam;
    bool haveUpdated = false;

    public bool raceFinished = false;

    ArrayList aCars = new ArrayList();


    // Use this for initialization
    void Start () {

        MainMenu = GameObject.Find("MainMenu");
        InGameMenu = GameObject.Find("InGameMenu");
        WinMenu = GameObject.Find("WinMenu");
        CameraCar = GameObject.Find("CameraCar");
        PlayerCar = GameObject.Find("PlayerCar");
        PlayerCarCam = GameObject.Find("PlayerCamera");
        //FindGameObjectsWithTag("PlayerCamera")[0];

        AddObjectToReset("CameraCar");
        AddObjectToReset("PlayerCar");

        PlayerCarCam.SetActive(false);
        //PlayerCar.SetActive(false);

        if (GameObject.Find("AICar1") != null) {
            aCars.Add(new aCar("AICar1"));
            AddObjectToReset("AICar1");
        }

        if (GameObject.Find("AICar2") != null)
        {
            aCars.Add(new aCar("AICar2"));
            AddObjectToReset("AICar2");
        }

        if (GameObject.Find("AICar3") != null)
        {
            aCars.Add(new aCar("AICar3"));
            AddObjectToReset("AICar3");
        }

        if (GameObject.Find("AICar4") != null)
        {
            aCars.Add(new aCar("AICar4"));
            AddObjectToReset("AICar4");
        }


    }

    // Update is called once per frame
    void Update () {

        if (haveUpdated == false)
        {
            haveUpdated = true;
            updateMenus();
        }

        foreach(aCar ac in aCars)
        {
		    ac.controller.udpateText ();
        }

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
                MainMenu.SetActive(true);
                InGameMenu.SetActive(false);
            }
            else if (raceFinished) {
                WinMenu.SetActive(true);
            }
            else
            {
                MainMenu.SetActive(false);
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
        //Time.timeScale = 0.0f;
        isPaused = true;
        updateMenus();
    }

    public void StartRace() {
        raceFinished = false;
        isMainMenu = false;

        foreach(aCar ac in aCars)
        {
		    ac.ai.StartDriving ();
            ac.ai.StartDriving ();
            ac.ai.StartDriving ();
            ac.ai.StartDriving ();
        }

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
