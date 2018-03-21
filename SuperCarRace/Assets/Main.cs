using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Vehicles.Car;

public class Main : MonoBehaviour {

    ArrayList objectsToReset = new ArrayList();

	// Use this for initialization
	void Start () {
        addObjectToReset("CameraCar");
        addObjectToReset("AICar1");
        addObjectToReset("AICar2");
        addObjectToReset("AICar3");
        addObjectToReset("AICar4");
        //addObjectToReset("PlayerCar");

    }

    // Update is called once per frame
    void Update () {
	}
    

    void addObjectToReset(string name)
    {
        objectsToReset.Add(
            (CarController)GameObject.Find(name)
                .GetComponent(typeof(CarController))
        );
    }

    public void Test() {

        foreach (CarController cc in objectsToReset)
        {
            cc.ResetVehicle();
        }
    }


}
