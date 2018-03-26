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
    public CarUserControl cui;

    public aCar(GameObject carObject){
        go = carObject;
		controller = (CarController)carObject.GetComponent(typeof(CarController));
		ai = (CarAIControl)carObject.GetComponent(typeof(CarAIControl));
        wpt = (WaypointProgressTracker)carObject.GetComponent(typeof(WaypointProgressTracker));
        cui = (CarUserControl)carObject.GetComponent(typeof(CarUserControl));
        GameObject camera = (GameObject)controller.camera;

        if (carObject.name == "PlayerCar")
        {
            cui.enabled = true;
            controller.camera.SetActive(true);
            controller.camera.tag = "MainCamera";
        }
        else if (carObject.name == "CameraCar")
        {
            controller.camera.SetActive(true);
            controller.camera.tag = "MainCamera";
        }
        else
        {
            controller.camera.SetActive(false);
        }
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
    //GameObject CameraCar;
    //GameObject PlayerCar;
    //GameObject PlayerCarCam;
    bool haveUpdated = false;

    public bool raceFinished = false;

    ArrayList aCars = new ArrayList();


    // Use this for initialization
    void Start () {

        MainMenu = GameObject.Find("MainMenu");
        InGameMenu = GameObject.Find("InGameMenu");
        WinMenu = GameObject.Find("WinMenu");
        //CameraCar = GameObject.Find("CameraCar");
        //PlayerCar = GameObject.Find("PlayerCar");
        //PlayerCarCam = GameObject.Find("PlayerCamera");
        //FindGameObjectsWithTag("PlayerCamera")[0];

        //AddObjectToReset("CameraCar");
        //aCars.Add(new aCar(GameObject.Find("CameraCar")));
        //AddObjectToReset("PlayerCar");
        //aCars.Add(new aCar(GameObject.Find("PlayerCar")));


        ResetRace();


        //PlayerCarCam.SetActive(false);
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

            //CameraCar.SetActive(false);
            MainMenu.SetActive(false);
            WinMenu.SetActive(false);
            //PlayerCarCam.SetActive(true);

            if (isPaused)
            {
                MainMenu.SetActive(true);
                InGameMenu.SetActive(false);
            }
            else if (raceFinished) {
                WinMenu.SetActive(true);
                InGameMenu.SetActive(false);
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
    public void CreateAICar(string aiCarName, Vector3 position, Vector3 rotation, string color = "Red")
    {

        GameObject carsGO = GameObject.Find("AICars");

        Vector3 startPos = new Vector3(carsGO.transform.position.x, carsGO.transform.position.y, carsGO.transform.position.z);

        GameObject newCar = (GameObject)Instantiate(
            Resources.Load("TheCar"),
            startPos,
            new Quaternion()
        );



        WaypointProgressTracker wpt = (WaypointProgressTracker)newCar.GetComponent(typeof(WaypointProgressTracker));
        wpt.circuit = (WaypointCircuit)GameObject.Find("Waypoints").GetComponent(typeof(WaypointCircuit));
        newCar.name = aiCarName;

        newCar.transform.parent = carsGO.transform;


        GameObject body = (GameObject)newCar.transform.Find("021014SSPC_LD_NoInterior").gameObject.transform.Find("body").gameObject;
        Renderer r = (Renderer)body.GetComponent(typeof(Renderer));
        Material m = (Material)Resources.Load("mat" + color + "Car");
        //r.materials[0] = m;
        r.material = m;

        aCars.Add(new aCar(newCar));

        newCar.transform.position = newCar.transform.position + position;

        //newCar.transform.SetPositionAndRotation(position, new Quaternion());

        //newCar.transform.position = new Vector3(position.x, position.y, position.z);


        //newCar.transform.position.Set(position.x, position.y, position.z);
        //newCar.transform.Rotate(rotation);

    }


    // RACE MANAGER?

    public void PauseRace() {
        //Time.timeScale = 0.0f;
        isPaused = true;
        updateMenus();
    }

    public void StartRace() {

        //ResetRace();
        raceFinished = false;
        isMainMenu = false;
        isPaused = false;
        updateMenus();

        RemoveAndAddCars(true);

    }

    public void ResumeRace()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        updateMenus();
    }

    public void ResetRace() {

        raceFinished = false;

        /*
        foreach (aCar ac in aCars)
        {
            ac.Reset();
        }
        */


        
        //ResumeRace();
        updateMenus();

        RemoveAndAddCars();

    }

    public void RemoveAndAddCars(bool amPlaying = false) {
        // Destroy All others
        foreach (aCar ac in aCars)
        {
            //aCars.Remove(ac);
            foreach (Transform child in ac.go.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(ac.go);
        }
        aCars = new ArrayList();

        //CreateAICar("AICar1", new Vector3(0, 0, 5.0f), Vector3.zero);
        CreateAICar("AICar2", new Vector3(2.5f, 0, 5.0f), Vector3.zero, "Aqua");
        CreateAICar("AICar3", new Vector3(0, 0, 10.0f), Vector3.zero, "Green");
        //CreateAICar("AICar4", new Vector3(2.5f, 0, 10.0f), Vector3.zero);
        //CreateAICar("AICar5", new Vector3(0, 0, 15.0f), Vector3.zero);
        CreateAICar("AICar6", new Vector3(2.5f, 0, 15.0f), Vector3.zero, "Pink");
        CreateAICar("AICar7", new Vector3(0, 0, 20.0f), Vector3.zero, "Blue");
        //CreateAICar("AICar8", new Vector3(2.5f, 0, 20.0f), Vector3.zero);

        if (amPlaying)
        {
            CreateAICar("PlayerCar", new Vector3(0f, 0, 0.0f), Vector3.zero);
        }
        else
        {
            CreateAICar("CameraCar", new Vector3(0f, 0, 0.0f), Vector3.zero);
        }

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
