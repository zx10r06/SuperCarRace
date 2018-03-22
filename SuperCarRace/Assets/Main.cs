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
    ArrayList objectsToReset = new ArrayList();
    GameObject CameraCar;
    GameObject PlayerCar;
    GameObject PlayerCarCam;
    bool haveUpdated = false;

    GameObject AICar1;
    GameObject AICar2;
    GameObject AICar3;
    GameObject AICar4;
    WaypointProgressTracker AICar1_wpt;
    WaypointProgressTracker AICar2_wpt;
    WaypointProgressTracker AICar3_wpt;
    WaypointProgressTracker AICar4_wpt;

    CarController AICar1_controller;
    CarController AICar2_controller;
    CarController AICar3_controller;
    CarController AICar4_controller;

    // Use this for initialization
    void Start () {

        MainMenu = GameObject.Find("MainMenu");
        PauseMenu = GameObject.Find("PauseMenu");
        InGameMenu = GameObject.Find("InGameMenu");
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

        AICar1_wpt = (WaypointProgressTracker)AICar1.GetComponent(typeof(WaypointProgressTracker));
        AICar2_wpt = (WaypointProgressTracker)AICar2.GetComponent(typeof(WaypointProgressTracker));
        AICar3_wpt = (WaypointProgressTracker)AICar3.GetComponent(typeof(WaypointProgressTracker));
        AICar4_wpt = (WaypointProgressTracker)AICar4.GetComponent(typeof(WaypointProgressTracker));

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

        TextMesh tm1 = (TextMesh)AICar1_controller.GetComponentInChildren(typeof(TextMesh));
        tm1.text = AICar1_wpt.progressDistance.ToString() + "\r\n";
        TextMesh tm2 = (TextMesh)AICar2_controller.GetComponentInChildren(typeof(TextMesh));
        tm2.text = AICar2_wpt.progressDistance.ToString() + "\r\n";
        TextMesh tm3 = (TextMesh)AICar3_controller.GetComponentInChildren(typeof(TextMesh));
        tm3.text = AICar3_wpt.progressDistance.ToString() + "\r\n";
        TextMesh tm4 = (TextMesh)AICar4_controller.GetComponentInChildren(typeof(TextMesh));
        tm4.text = AICar4_wpt.progressDistance.ToString() + "\r\n";

    }

    void updateMenus() {

        if (isMainMenu)
        {
            MainMenu.SetActive(true);
            PauseMenu.SetActive(false);
            InGameMenu.SetActive(false);
        }
        else
        {

            CameraCar.SetActive(false);
            MainMenu.SetActive(false);
            PlayerCarCam.SetActive(true);

            if (isPaused)
            {
                PauseMenu.SetActive(true);
                InGameMenu.SetActive(false);
            }
            else
            {
                PauseMenu.SetActive(false);
                InGameMenu.SetActive(true);
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
        foreach (CarController cc in objectsToReset)
        {
            cc.ResetVehicle();
        }
        ResumeRace();
        updateMenus();
    }

}
