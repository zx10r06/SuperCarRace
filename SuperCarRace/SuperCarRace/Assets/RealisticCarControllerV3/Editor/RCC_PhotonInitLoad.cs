//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2016 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using UnityEngine;
using UnityEditor;

public class RCC_PhotonInitLoad : MonoBehaviour {

	[InitializeOnLoad]
	public class InitOnLoad {

		static InitOnLoad(){

			if(!EditorPrefs.HasKey("PhotonForRCC3.1Installed")){
				EditorPrefs.SetInt("PhotonForRCC3.1Installed", 1);
				EditorUtility.DisplayDialog("Photon For Realistic Car Controller", "Be sure you have imported latest Photon to your project. Pass in your AppID to Photon, enable auto join lobby, and run the RCC Photon demo scene. You can find more detailed info in documentation", "Ok");
			}

		}

	}

}
