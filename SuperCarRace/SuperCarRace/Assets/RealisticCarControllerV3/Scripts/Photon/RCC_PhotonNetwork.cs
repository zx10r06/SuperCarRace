using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class RCC_PhotonNetwork : Photon.MonoBehaviour {

	// Main Car Controller, Rigidbody, and Main RCC Camera of the scene. 
	private RCC_CarControllerV3 carController;
	private Rigidbody rigid;
	private RCC_Camera rccCamera;

	// Car's position and rotation. We will send these to server.
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;

	// Used for projected (interpolated) position.
	private Vector3 currentVelocity;
	private float updateTime = 0;

	// All inputs for RCC. We will send these values if we own this vehicle. If this vehicle is owned by other player, receives all these inputs from server.
	private float gasInput = 0f;
	private float brakeInput = 0f;
	private float steerInput = 0f;
	private float handbrakeInput = 0f;
	private float boostInput = 0f;
	private float clutchInput = 0f;
	private float idleInput = 0f;
	private int gear = 0;
	private int direction = 1;
	private bool changingGear = false;
	private bool semiAutomaticGear = false;
	private float fuelInput = 1f;
	private bool engineRunning = false;

	// Lights.
	private bool lowBeamHeadLightsOn = false;
	private bool highBeamHeadLightsOn = false;

	// For Indicators.
	private RCC_CarControllerV3.IndicatorsOn indicatorsOn;

	void Awake(){

		// Getting Main Car Controller, Rigidbody, and Main RCC Camera of the scene. 
		rccCamera = GetComponent<RCC_Camera>();
		carController = GetComponent<RCC_CarControllerV3>();
		rigid = GetComponent<Rigidbody>();

		// If we are the owner of this vehicle, enable Main RCC Camera, and enable Car Controller. Do opposite if another player owned this vehicle.
		if (photonView.isMine){
			if(rccCamera)
				rccCamera.gameObject.SetActive(true);
			carController.canControl = true;
		}else{
			if(rccCamera)
				rccCamera.gameObject.SetActive(false);
			carController.canControl = false;
		}

		// Setting name of the gameobject with Photon View ID.
		gameObject.name = gameObject.name + photonView.viewID;

	}

	void Start(){

//		PhotonNetwork.sendRate = 60;
//		PhotonNetwork.sendRateOnSerialize = 60;

	}

	public void FixedUpdate(){

		// If we are not owner of this vehicle, receive all inputs from server.
		if(!photonView.isMine) {

			carController.AIController = true;
			Vector3 projectedPosition = this.correctPlayerPos + currentVelocity * (Time.time - updateTime);

			if(Vector3.Distance(transform.position, correctPlayerPos) < 15f){
				transform.position = Vector3.Lerp (transform.position, projectedPosition, Time.deltaTime * 5f);
				transform.rotation = Quaternion.Lerp (transform.rotation, this.correctPlayerRot, Time.deltaTime * 5f);
			}else{
				transform.position = correctPlayerPos;
				transform.rotation = correctPlayerRot;
			}
				
			carController.gasInput = gasInput;
			carController.brakeInput = brakeInput;
			carController.steerInput = steerInput;
			carController.handbrakeInput = handbrakeInput;
			carController.boostInput = boostInput;
			carController.clutchInput = clutchInput;
			carController.idleInput = idleInput;
			carController.currentGear = gear;
			carController.direction = direction;
			carController.changingGear = changingGear;
			carController.semiAutomaticGear = semiAutomaticGear;

			carController.fuelInput = fuelInput;
			carController.engineRunning = engineRunning;
			carController.lowBeamHeadLightsOn = lowBeamHeadLightsOn;
			carController.highBeamHeadLightsOn = highBeamHeadLightsOn;
			carController.indicatorsOn = indicatorsOn;

		}

	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		// Sending all inputs, position, rotation, and velocity to server.
		if (stream.isWriting){
			
			//We own this player: send the others our data
			stream.SendNext(carController.gasInput);
			stream.SendNext(carController.brakeInput);
			stream.SendNext(carController.steerInput);
			stream.SendNext(carController.handbrakeInput);
			stream.SendNext(carController.boostInput);
			stream.SendNext(carController.clutchInput);
			stream.SendNext(carController.idleInput);
			stream.SendNext(carController.currentGear);
			stream.SendNext(carController.direction);
			stream.SendNext(carController.changingGear);
			stream.SendNext(carController.semiAutomaticGear);

			stream.SendNext(carController.fuelInput);
			stream.SendNext(carController.engineRunning);
			stream.SendNext(carController.lowBeamHeadLightsOn);
			stream.SendNext(carController.highBeamHeadLightsOn);
			stream.SendNext(carController.indicatorsOn);

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(rigid.velocity);

		}else{
			
			// Network player, receiving all inputs, position, rotation, and velocity from server. 
			gasInput = (float)stream.ReceiveNext();
			brakeInput = (float)stream.ReceiveNext();
			steerInput = (float)stream.ReceiveNext();
			handbrakeInput = (float)stream.ReceiveNext();
			boostInput = (float)stream.ReceiveNext();
			clutchInput = (float)stream.ReceiveNext();
			idleInput = (float)stream.ReceiveNext();
			gear = (int)stream.ReceiveNext();
			direction = (int)stream.ReceiveNext();
			changingGear = (bool)stream.ReceiveNext();
			semiAutomaticGear = (bool)stream.ReceiveNext();

			fuelInput = (float)stream.ReceiveNext();
			engineRunning = (bool)stream.ReceiveNext();
			lowBeamHeadLightsOn = (bool)stream.ReceiveNext();
			highBeamHeadLightsOn = (bool)stream.ReceiveNext();
			indicatorsOn = (RCC_CarControllerV3.IndicatorsOn)stream.ReceiveNext();

			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();
			currentVelocity = (Vector3)stream.ReceiveNext();

			updateTime = Time.time;

		}

	}

}
