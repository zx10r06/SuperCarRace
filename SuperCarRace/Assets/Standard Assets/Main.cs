using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;

public class aCar : object {

	public GameObject go;
	public CarController controller;
	public CarAIControl ai;
    public WaypointProgressTracker wpt;

    public aCar(GameObject carObject){
        go = carObject;
		controller = (CarController)carObject.GetComponent(typeof(CarController));
		ai = (CarAIControl)carObject.GetComponent(typeof(CarAIControl));
        wpt = (WaypointProgressTracker)carObject.GetComponent(typeof(WaypointProgressTracker));
    }

    public void Reset() {
        controller.ResetVehicle();

        if (ai != null)
        {
            ai.StartDriving();
        }
    }

}

public class Main : MonoBehaviour {

    bool isMainMenu = true;
    GameObject MainMenu;
    bool isPaused = false;
    GameObject InGameMenu;
    GameObject WinMenu;
    //ArrayList objectsToReset = new ArrayList();
    GameObject CameraCar;
    GameObject PlayerCar;
    GameObject PlayerCarCam;
    bool haveUpdated = false;

    public bool raceFinished = false;

    ArrayList aCars = new ArrayList();


    // Use this for initialization
    void Start () {

        CreateAICar("AICar1", new Vector3(-88, 3.5f, -237), Vector3.zero);

        MainMenu = GameObject.Find("MainMenu");
        InGameMenu = GameObject.Find("InGameMenu");
        WinMenu = GameObject.Find("WinMenu");
        CameraCar = GameObject.Find("CameraCar");
        PlayerCar = GameObject.Find("PlayerCar");
        PlayerCarCam = GameObject.Find("PlayerCamera");
        //FindGameObjectsWithTag("PlayerCamera")[0];

        //AddObjectToReset("CameraCar");
        aCars.Add(new aCar(GameObject.Find("CameraCar")));
        //AddObjectToReset("PlayerCar");
        aCars.Add(new aCar(GameObject.Find("PlayerCar")));


        PlayerCarCam.SetActive(false);
        //PlayerCar.SetActive(false);

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

        /*
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
        */

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
            }
        }

    }

    /*
    void AddObjectToReset(string name)
    {
        objectsToReset.Add(
            (CarController)GameObject.Find(name)
                .GetComponent(typeof(CarController))
        );
    }
    */

    // AI MANAGER?
    public void CreateAICar(string aiCarName, Vector3 position, Vector3 rotation)
    {
        GameObject newCar = (GameObject)Instantiate(
            Resources.Load("TheCar"),
            position,
            new Quaternion()
        );
        WaypointProgressTracker wpt = (WaypointProgressTracker)newCar.GetComponent(typeof(WaypointProgressTracker));
        wpt.circuit = (WaypointCircuit)GameObject.Find("Waypoints").GetComponent(typeof(WaypointCircuit));
        newCar.name = aiCarName;
        newCar.transform.Rotate(rotation);

        newCar.transform.parent = GameObject.Find("AICars").transform;

        aCars.Add(new aCar(newCar));

    }


    // RACE MANAGER?

    public void PauseRace() {
        //Time.timeScale = 0.0f;
        isPaused = true;
        updateMenus();
    }

    public void StartRace() {
        ResetRace();
        raceFinished = false;
        isMainMenu = false;
        isPaused = false;
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

        foreach (aCar ac in aCars)
        {
            ac.Reset();
        }

        //ResumeRace();
        updateMenus();
    }

    public int GetPosition(string carName) {
        // Check each Cars position for the highest... 
        // highest is first, lowest is last
        int myPosition = 1;
        float myDistanceTravelled = 0.0f;
        foreach (aCar ac in aCars)
        {
            if (ac.go.name == carName)
            {
                myDistanceTravelled = ac.wpt.progressDistance;
            }
        }
        foreach (aCar ac in aCars)
        {
            if (ac.go.name != "PlayerCar" && ac.go.name != "CameraCar" && ac.go.name != carName)
            {
                if ((float)ac.wpt.progressDistance > (float)myDistanceTravelled)
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
