using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof(CarController))]
    public class NewBehaviourScript : MonoBehaviour {


        private CarController m_CarController;    // Reference to actual car controller we are controlling

                                                  // Use this for initialization
        void Start () {

            m_CarController = GetComponent<CarController>();

        }

        // Update is called once per frame
        void Update () {
		
	    }

        public void HandBrake() {
            Debug.Log("Handbrake fired");
            m_CarController.Move(0, 0, -1f, 1f);
        }
    }
}
