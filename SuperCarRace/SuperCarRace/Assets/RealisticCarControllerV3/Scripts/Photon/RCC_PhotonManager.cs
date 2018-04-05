using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RCC_PhotonManager : MonoBehaviour {

	public GameObject startButton;
	public GameObject chat;
	public InputField playerName;

	void Start () {

		playerName.gameObject.SetActive(false);
		startButton.SetActive(false);
		chat.SetActive(false);
		ConnectToServer();
	
	}

	void ConnectToServer () {

		print("Connecting To Photon Server");
		if (PhotonNetwork.connectionState == ConnectionState.Connected) 
			PhotonNetwork.Disconnect ();
		
		PhotonNetwork.ConnectUsingSettings ("RCC V3.1");

	
	}

	void OnGUI(){

		if(PhotonNetwork.connectionState != ConnectionState.Connected)
			GUI.color = Color.red;
		GUILayout.Label("State: " + PhotonNetwork.connectionStateDetailed.ToString());
		GUI.color = Color.white;
		GUILayout.Label("Total Player Count: " + PhotonNetwork.playerList.Length.ToString());
		GUILayout.Label("Ping: " + PhotonNetwork.GetPing());

	}

	void OnJoinedLobby(){

		print("Joined Lobby");
		PhotonNetwork.JoinRandomRoom();

	}

	void OnPhotonRandomJoinFailed(){

		print("Joining to random room has failed!, Creating new room...");
		PhotonNetwork.CreateRoom(null);

	} 

	void OnJoinedRoom(){

		print("Joined Room");
		playerName.gameObject.SetActive(true);

	}

	public void SetPlayerName(string name){

		PhotonNetwork.playerName = name;
		
		playerName.gameObject.SetActive(false);
		chat.SetActive(true);
		startButton.SetActive(true);

	}

}
