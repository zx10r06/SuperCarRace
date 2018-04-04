using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class OtherSkiddingSoundsClass_ {
	[Tooltip("The sound that the vehicle will emit when skidding or skidding on a terrain defined by the tag of this index.")]
	public AudioClip skiddingSound;
	[Range(0.1f,3.0f)][Tooltip("The sound volume associated with the variable 'skiddingSound'")]
	public float volume = 1.5f;
	[Tooltip("The tag that will represent this index. Lands with this tag will receive skidlines based on the preferences of this index.")]
	public string groundTag;
	[Tooltip("The 'physicsMaterial' that will represent this index. Lands with this tag will receive sounds based on the preferences of this index.")]
	public PhysicMaterial physicMaterial;

	[Space(15)][Tooltip("The sound that the wheels will emit when they find a terrain defined by the tag or physicMaterial of this index.")]
	public AudioClip groundSound;
	[Range(0.01f,1.0f)][Tooltip("The sound volume associated with the variable 'groundSound'.")]
	public float volumeGroundSound = 0.15f;
}

[RequireComponent(typeof(Rigidbody))][RequireComponent(typeof(MSSkidMarks))]
public class MSSkidMarksOptionalSounds : MonoBehaviour {

	[Tooltip("The default sound that will be emitted when the vehicle slides or skates.")]
	public AudioClip standardSound;
	[Range(0.1f,3.0f)][Tooltip("The default volume of the skid sound.")]
	public float standardVolume = 1.5f;

	public enum GroundSelect {useTag, usePhysicsMaterial};
	[Space(20)][Tooltip("Here you can define whether the code will detect the ground by tag or through 'physics material'")]
	public GroundSelect groundDetection = GroundSelect.useTag;
	[Tooltip("The trail of skidding that the vehicle will do on land defined by tags should be set here.")]
	public OtherSkiddingSoundsClass_[] otherSounds;


	MSSkidMarks baseScript;
	AudioSource skiddingSoundAUD;
	AudioSource[] groundSoundsAUD;

	WheelCollider rightFrontWheel;
	WheelCollider leftFrontWheel;
	WheelCollider rightRearWheel;
	WheelCollider leftRearWheel;
	WheelCollider[] extraWheels;
	WheelCollider[] wheelColliderList;

	int[] wheelEmitterSoundX;
	int[] wheelBlockSoundX;

	PhysicMaterial physicMaterialFD;
	PhysicMaterial physicMaterialFE;
	PhysicMaterial physicMaterialTD;
	PhysicMaterial physicMaterialTE;

	WheelHit tempWheelHit;

	bool wheelFDIsGrounded;
	bool changedGroundSKid;
	bool wheelFEIsGrounded;
	bool wheelTDIsGrounded;
	bool wheelTEIsGrounded;
	bool skidExtraWheels;
	bool forwardSKid;
	bool skiddingIsTrue;

	int groundedWheelsSkid;
	int wheelsInOneTag;

	float rpmFD;
	float rpmFE;
	float rpmTD;
	float rpmTE;

	float skidLatFD;
	float skidLatFE;
	float skidLatTD;
	float skidLatTE;

	float skidForwardFD;
	float skidForwardFE;
	float skidForwardTD;
	float skidForwardTE;

	float KMhSounds;
	float sensibilitySkid1;
	float sensibilitySKid2;
	float maxSKidSensibility;
	float rpmExtraWheels;

	string wheelTagFD;
	string wheelTagFE;
	string wheelTagTD;
	string wheelTagTE;

	void Start () {
		baseScript = GetComponent<MSSkidMarks> ();
		groundSoundsAUD = new AudioSource[otherSounds.Length];
		GenerateSKidSounds ();
		rightFrontWheel = baseScript.rightFrontWheel.wheelCollider;
		leftFrontWheel = baseScript.leftFrontWheel.wheelCollider;
		rightRearWheel = baseScript.rightRearWheel.wheelCollider;
		leftRearWheel = baseScript.leftRearWheel.wheelCollider;
		extraWheels = new WheelCollider[baseScript.otherWheels.Length];
		for (int x = 0; x < extraWheels.Length; x++) {
			extraWheels [x] = baseScript.otherWheels [x].wheelCollider;
		}
		//
		wheelColliderList = new WheelCollider[(4+extraWheels.Length)];
		wheelColliderList [0] = rightFrontWheel;
		wheelColliderList [1] = leftFrontWheel;
		wheelColliderList [2] = rightRearWheel;
		wheelColliderList [3] = leftRearWheel;
		for (int x = 0; x < extraWheels.Length; x++) {
			wheelColliderList [x + 4] = extraWheels [x];
		}
		//
		wheelEmitterSoundX = new int[otherSounds.Length];
		wheelBlockSoundX = new int[otherSounds.Length];
	}
	void Update () {
		KMhSounds = baseScript.KMh;
		//
		wheelFDIsGrounded = rightFrontWheel.isGrounded;
		wheelFEIsGrounded = leftFrontWheel.isGrounded;
		wheelTDIsGrounded = rightRearWheel.isGrounded;
		wheelTEIsGrounded = leftRearWheel.isGrounded;
		//
		EmitSkidSounds ();
		if (otherSounds.Length > 0) {
			GroundSoundsEmitter (wheelColliderList);
		}
	}
	//

	void GenerateSKidSounds(){
		if (standardSound) {
			skiddingSoundAUD = GenerateAudioSourceSkid ("standardSkidSound", 10, 1, standardSound, false, false, false);
		}
		if (otherSounds.Length > 0) {
			for (int x = 0; x < otherSounds.Length; x++) {
				if (otherSounds [x].groundSound) {
					groundSoundsAUD [x] = GenerateAudioSourceSkid ("GroundSounds" + x, 10, otherSounds [x].volumeGroundSound, otherSounds [x].groundSound, true, false, false);
				}
			}
		}
	}

	public AudioSource GenerateAudioSourceSkid(string name, float minDistance, float volume, AudioClip audioClip, bool loop, bool playNow, bool playOnAwake){
		GameObject audioSource = new GameObject (name);
		audioSource.transform.position = transform.position;
		audioSource.transform.parent = transform;
		AudioSource temp = audioSource.AddComponent<AudioSource> () as AudioSource;
		temp.minDistance = minDistance;
		temp.volume = volume;
		temp.clip = audioClip;
		temp.loop = loop;
		temp.playOnAwake = playOnAwake;
		temp.spatialBlend = 1.0f;
		temp.dopplerLevel = 0.0f;
		if (playNow) {
			temp.Play ();
		}
		return temp;
	}

	void GroundSoundsEmitter(WheelCollider[] wheelColliders){
		for (int j = 0; j < otherSounds.Length; j++) {
			wheelEmitterSoundX [j] = 0;
			wheelBlockSoundX [j] = 0;
		}
		for (int i = 0; i < wheelColliders.Length; i++) {
			WheelCollider wheelCollider = wheelColliders [i];
			wheelCollider.GetGroundHit (out tempWheelHit);
			for (int x = 0; x < otherSounds.Length; x++) {
				if (otherSounds [x].groundSound) {
					if (wheelCollider.isGrounded) {
						if (groundDetection == GroundSelect.useTag) {
							if (tempWheelHit.collider.gameObject.CompareTag(otherSounds [x].groundTag)) {
								wheelEmitterSoundX [x] ++;
								if (!groundSoundsAUD [x].isPlaying && groundSoundsAUD[x]) {
									groundSoundsAUD [x].PlayOneShot (groundSoundsAUD [x].clip);
								}
							} else {
								wheelBlockSoundX[x]++;
							}
						}
						else if (groundDetection == GroundSelect.usePhysicsMaterial) {
							if (tempWheelHit.collider.sharedMaterial == otherSounds [x].physicMaterial) {
								wheelEmitterSoundX [x] ++;
								if (!groundSoundsAUD [x].isPlaying && groundSoundsAUD[x]) {
									groundSoundsAUD [x].PlayOneShot (groundSoundsAUD [x].clip);
								}
							} else {
								wheelBlockSoundX[x]++;
							}
						}
					} else {
						wheelBlockSoundX[x]++;
					}
				}
			}
		}
		for (int x = 0; x < otherSounds.Length; x++) {
			if(wheelBlockSoundX[x] > 0 && wheelEmitterSoundX[x] == 0 && groundSoundsAUD[x]){
				groundSoundsAUD [x].Stop ();
			}
			if ((KMhSounds/3.6f) < 1.5f && groundSoundsAUD[x]) {
				groundSoundsAUD [x].Stop ();
			}
		}
	}

	void EmitSkidSounds(){
		if (standardSound) {
			sensibilitySkid1 = (1.0f / baseScript.sensibility);
			sensibilitySKid2 = (3.0f / baseScript.sensibility);
			maxSKidSensibility = (1.2f / baseScript.sensibility);
			//

			if (wheelFDIsGrounded) {
				rightFrontWheel.GetGroundHit (out tempWheelHit);
				skidLatFD = Mathf.Abs (tempWheelHit.sidewaysSlip);
				skidForwardFD = Mathf.Abs (tempWheelHit.forwardSlip);
				wheelTagFD = tempWheelHit.collider.gameObject.tag;
				if (groundDetection == GroundSelect.usePhysicsMaterial) {
					physicMaterialFD = tempWheelHit.collider.sharedMaterial;
				}
			}

			if (wheelFEIsGrounded) {
				leftFrontWheel.GetGroundHit (out tempWheelHit);
				skidLatFE = Mathf.Abs (tempWheelHit.sidewaysSlip);
				skidForwardFE = Mathf.Abs (tempWheelHit.forwardSlip);
				wheelTagFE = tempWheelHit.collider.gameObject.tag;
				if (groundDetection == GroundSelect.usePhysicsMaterial) {
					physicMaterialFE = tempWheelHit.collider.sharedMaterial;
				}
			}

			if (wheelTDIsGrounded) {
				rightRearWheel.GetGroundHit (out tempWheelHit);
				skidLatTD = Mathf.Abs (tempWheelHit.sidewaysSlip);
				skidForwardTD = Mathf.Abs (tempWheelHit.forwardSlip);
				wheelTagTD = tempWheelHit.collider.gameObject.tag;
				if (groundDetection == GroundSelect.usePhysicsMaterial) {
					physicMaterialTD = tempWheelHit.collider.sharedMaterial;
				}
			}

			if (wheelTEIsGrounded) {
				leftRearWheel.GetGroundHit (out tempWheelHit);
				skidLatTE = Mathf.Abs (tempWheelHit.sidewaysSlip);
				skidForwardTE = Mathf.Abs (tempWheelHit.forwardSlip);
				wheelTagTE = tempWheelHit.collider.gameObject.tag;
				if (groundDetection == GroundSelect.usePhysicsMaterial) {
					physicMaterialTE = tempWheelHit.collider.sharedMaterial;
				}
			}

			rpmFD = Mathf.Abs(rightFrontWheel.rpm);
			rpmFE = Mathf.Abs(leftFrontWheel.rpm);
			rpmTD = Mathf.Abs(rightRearWheel.rpm);
			rpmTE = Mathf.Abs(leftRearWheel.rpm);

			skiddingSoundAUD.volume = ((skidLatFD + skidLatFE + skidLatTD + skidLatTE) / 4.0f) * standardVolume;


			//PATINANDO OU RODA TRAVADA=
			forwardSKid = false;
			if (KMhSounds > (75.0f/baseScript.sensibility)) {
				if ((rpmFD < sensibilitySKid2) || (rpmFE < sensibilitySKid2) || (rpmTD < sensibilitySKid2) || (rpmTE < sensibilitySKid2)) {
					if (wheelFDIsGrounded || wheelFEIsGrounded || wheelTDIsGrounded || wheelTEIsGrounded) {
						forwardSKid = true;
						skiddingSoundAUD.volume = 0.3f * standardVolume;
					}
				}
			}

			//extra wheels
			if (extraWheels.Length > 0) {
				skidExtraWheels = false;
				for (int x = 0; x < extraWheels.Length; x++) {
					if (extraWheels [x].isGrounded) {
						rpmExtraWheels = Mathf.Abs (extraWheels [x].rpm);
						extraWheels [0].GetGroundHit (out tempWheelHit);
						if (Mathf.Abs (tempWheelHit.sidewaysSlip) >= sensibilitySkid1) {
							if (extraWheels [x].isGrounded) {
								skidExtraWheels = true;
							}
						}
						if (KMhSounds > (75.0f / baseScript.sensibility)) {
							if (rpmExtraWheels < sensibilitySKid2) {
								if (extraWheels [x].isGrounded) {
									forwardSKid = true;
									skiddingSoundAUD.volume = 0.3f * standardVolume;
								}
							}
						}
						if (KMhSounds < 20.0f * (Mathf.Clamp (baseScript.sensibility, 1, 3))) {
							if (tempWheelHit.forwardSlip > maxSKidSensibility) {
								if (extraWheels [x].isGrounded) {
									forwardSKid = true;
									skiddingSoundAUD.volume = 0.3f * standardVolume;
								}
							}
						}
					}
				}
			}
			//

			if (KMhSounds < 20.0f * (Mathf.Clamp(baseScript.sensibility,1,3))){
				if ((skidForwardFD > maxSKidSensibility) || (skidForwardFE > maxSKidSensibility) || (skidForwardTD > maxSKidSensibility) || (skidForwardTE > maxSKidSensibility)) {
					if (wheelFDIsGrounded || wheelFEIsGrounded || wheelTDIsGrounded || wheelTEIsGrounded) {
						forwardSKid = true;
						skiddingSoundAUD.volume = 0.3f * standardVolume;
					}
				} else {
					forwardSKid = false;
				}
			}

			//CHECAR TAGS 
			groundedWheelsSkid = 0;
			changedGroundSKid = false;
			if (wheelFDIsGrounded) { groundedWheelsSkid++; }
			if (wheelFEIsGrounded) { groundedWheelsSkid++; }
			if (wheelTDIsGrounded) { groundedWheelsSkid++; }
			if (wheelTEIsGrounded) { groundedWheelsSkid++; }

			for (int x = 0; x < otherSounds.Length; x++) {
				if (!changedGroundSKid) {
					wheelsInOneTag = 0;
					if (wheelFDIsGrounded) {
						if (groundDetection == GroundSelect.useTag) {
							if (wheelTagFD == otherSounds [x].groundTag) {
								wheelsInOneTag++;
							}
						}
						else if (groundDetection == GroundSelect.usePhysicsMaterial) {
							if (otherSounds [x].physicMaterial) {
								if (physicMaterialFD == otherSounds [x].physicMaterial) {
									wheelsInOneTag++;
								}
							}
						}
					}
					if (wheelFEIsGrounded) {
						if (groundDetection == GroundSelect.useTag) {
							if (wheelTagFE == otherSounds [x].groundTag) {
								wheelsInOneTag++;
							}
						}
						else if (groundDetection == GroundSelect.usePhysicsMaterial) {
							if (otherSounds [x].physicMaterial) {
								if (physicMaterialFE == otherSounds [x].physicMaterial) {
									wheelsInOneTag++;
								}
							}
						}
					}
					if (wheelTDIsGrounded) {
						if (groundDetection == GroundSelect.useTag) {
							if (wheelTagTD == otherSounds [x].groundTag) {
								wheelsInOneTag++;
							}
						}
						else if (groundDetection == GroundSelect.usePhysicsMaterial) {
							if (otherSounds [x].physicMaterial) {
								if (physicMaterialTD == otherSounds [x].physicMaterial) {
									wheelsInOneTag++;
								}
							}
						}
					}
					if (wheelTEIsGrounded) {
						if (groundDetection == GroundSelect.useTag) {
							if (wheelTagTE == otherSounds [x].groundTag) {
								wheelsInOneTag++;
							}
						}
						else if (groundDetection == GroundSelect.usePhysicsMaterial) {
							if (otherSounds [x].physicMaterial) {
								if (physicMaterialTE == otherSounds [x].physicMaterial) {
									wheelsInOneTag++;
								}
							}
						}
					}
					if (wheelsInOneTag >= groundedWheelsSkid) {
						if (otherSounds [x].skiddingSound) {
							skiddingSoundAUD.clip = otherSounds [x].skiddingSound;
							if (skiddingIsTrue) {
								skiddingSoundAUD.volume = otherSounds [x].volume;
							}
							changedGroundSKid = true;
						}
					}
				}
			}
			if (!changedGroundSKid) {
				skiddingSoundAUD.clip = standardSound;
			}

			//TOCAR OS SONS
			if (((skidLatFD > sensibilitySkid1) && wheelFDIsGrounded) ||
			    ((skidLatFE > sensibilitySkid1) && wheelFEIsGrounded) ||
			    ((skidLatTD > sensibilitySkid1) && wheelTDIsGrounded) ||
			    ((skidLatTE > sensibilitySkid1) && wheelTEIsGrounded) ||
			    (skidExtraWheels) || (forwardSKid)) {
				skiddingIsTrue = true;
			} else {
				skiddingIsTrue = false;
			}
			//
			if (skiddingIsTrue && !skiddingSoundAUD.isPlaying) {
				skiddingSoundAUD.Play ();
			}
			else {
				skiddingSoundAUD.volume = Mathf.Lerp (skiddingSoundAUD.volume, 0, Time.deltaTime * 5.0f);
				if (skiddingSoundAUD.volume < 0.3f) {
					skiddingSoundAUD.Stop ();
				}
			}
		}

	}
}
