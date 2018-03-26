using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class WinCondition : MonoBehaviour
{

    Main m;


    // Use this for initialization
    void Start()
    {
        m = (Main)GameObject.Find("Main").GetComponent("Main");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AICar" || collision.gameObject.tag == "PlayerCar")
        {
            Debug.Log("Collision Detected: " + collision.gameObject.tag);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        string carName = other.attachedRigidbody.gameObject.tag;

        if (other.attachedRigidbody == null)
        {
            return;
        }

        if (carName == "AICar" || carName == "PlayerCar" || carName == "CameraCar")
        {
            Debug.Log("TRIGGER ENTERED: " + carName);

            CarAIControl carAI = (CarAIControl)other.attachedRigidbody.gameObject.GetComponent(typeof(CarAIControl));
            if (carAI != null)
            {
                carAI.StopDriving();
            }

            if (carName == "PlayerCar")
            {
                m.FinishedRace();
            }
            else if (carName == "CameraCar") {
                m.ResetRace();
            }
            else
            {

            }

        }

    }

}

