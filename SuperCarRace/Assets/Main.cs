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

	// Use this for initialization
	void Start () {

        MainMenu = GameObject.Find("MainMenu");
        PauseMenu = GameObject.Find("PauseMenu");
        InGameMenu = GameObject.Find("InGameMenu");
        CameraCar = GameObject.Find("CameraCar");

        AddObjectToReset("CameraCar");
        AddObjectToReset("AICar1");
        AddObjectToReset("AICar2");
        AddObjectToReset("AICar3");
        AddObjectToReset("AICar4");
        AddObjectToReset("PlayerCar");
    }

    // Update is called once per frame
    void Update () {

        if (isMainMenu)
        {
            MainMenu.SetActive(true);
            PauseMenu.SetActive(false);
            InGameMenu.SetActive(false);
        }
        else
        {
            MainMenu.SetActive(false);
            InGameMenu.SetActive(true);
            CameraCar.SetActive(false);

            if (isPaused)
            {
                PauseMenu.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(false);
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
    }

    public void StartRace() {
        isMainMenu = false;
        ResetRace();
    }

    public void ResumeRace()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void ResetRace() {
        foreach (CarController cc in objectsToReset)
        {
            cc.ResetVehicle();
        }
        ResumeRace();
    }


}
