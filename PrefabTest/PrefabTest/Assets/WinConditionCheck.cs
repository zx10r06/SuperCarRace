using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionCheck : MonoBehaviour {

    RaceManager raceManagerScript;

    // Use this for initialization
    void Start () {
        raceManagerScript = (RaceManager)GameObject.Find("RaceManager").GetComponent(typeof(RaceManager));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        string carName = other.attachedRigidbody.gameObject.name;
        Debug.Log("TRIGGER ENTERED: " + carName);

        if (carName == "PlayerCar")
        {
            raceManagerScript.TitleScreen();
            raceManagerScript.ResetCars(true);
        }
        else if (carName == "DemoCar")
        {
            // restart race
            raceManagerScript.ResetCars(true);
        }
        else
        {
            //ai car finished race
            // remove car... ?
            Debug.LogWarning("Should remove this AI car... " + carName);
        }

        /*
        string carTag = other.attachedRigidbody.gameObject.tag;

        if (other.attachedRigidbody == null)
        {
            return;
        }

        if (carTag == "AICar" || carName == "PlayerCar" || carName == "CameraCar")
        {

            CarAIControl carAI = (CarAIControl)other.attachedRigidbody.gameObject.GetComponent(typeof(CarAIControl));
            if (carAI != null)
            {
                carAI.StopDriving();
            }

            if (carName == "PlayerCar")
            {
                m.FinishedRace();
            }
            else if (carName == "CameraCar")
            {
                m.ResetRace();
            }
            else
            {

            }

        }
        */

    }

}
