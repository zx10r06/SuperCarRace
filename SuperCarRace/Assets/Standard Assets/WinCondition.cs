using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class WinCondition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
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

        if (carName == "AICar" || carName == "PlayerCar")
        {
            Debug.Log("TRIGGER ENTERED: " + carName);
            CarAIControl carAI = (CarAIControl)other.attachedRigidbody.gameObject.GetComponent(typeof(CarAIControl));
            carAI.StopDriving();

            if (carName == "PlayerCar")
            {
                Main m = (Main)GameObject.Find("Main").GetComponent("Main");
                m.FinishedRace();
            }

        }

    }

}

