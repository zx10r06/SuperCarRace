using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Vehicles.Car;

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

        

    }

    bool haveUpdated = false;

    // Update is called once per frame
    void Update () {

        if (haveUpdated == false)
        {
            haveUpdated = true;
            updateMenus();
        }



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
