using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class WinCondition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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

        if (other.attachedRigidbody == null)
        {
            return;
        }

        if (other.attachedRigidbody.gameObject.tag == "AICar" || other.attachedRigidbody.gameObject.tag == "PlayerCar")
        {
            Debug.Log("TRIGGER ENTERED: " + other.attachedRigidbody.tag);
            CarAIControl carAI = (CarAIControl)other.attachedRigidbody.gameObject.GetComponent(typeof(CarAIControl));
            carAI.StopDriving();
        }

    }

}

