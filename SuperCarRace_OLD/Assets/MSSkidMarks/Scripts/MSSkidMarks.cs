using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class groundClass {
	[Tooltip("If this variable is true, the vehicle will generate a continuous trail in this terrain.")]
	public bool continuousMarking = false;
	[Tooltip("Tag of the ground so the code can identify each location.")]
	public string groundTag = "ground";
	[Tooltip("The 'physics material' associated with the terrain.")]
	public PhysicMaterial physicMaterial;
	[Tooltip("Color of the skid mark on this terrain.")]
	public Color skidMarkColor = new Color(0.5f, 0.2f, 0.0f, 0);
	[Tooltip("Opacity of the skid mark on this terrain.")]
	[Range(0.1f, 1.0f)]
	public float opacity = 0.8f;
}

[Serializable]
public class wheelClass {
	[Tooltip("A wheel collider component should be associated with this variable.")]
	public WheelCollider wheelCollider;
	[Tooltip("Horizontal displacement of the location where the skid mark is generated.")]
	[Range(-2.0f, 2.0f)]
	public float displacement = 0.0f;
	[HideInInspector] public Mesh rendSKDmarks;
	[HideInInspector] public bool generatingSkidMarks;
}

[Serializable]
public class DefaultMaterialClass {
	[Tooltip("Intensity of the normal map of the skid mark.")]
	[Range(0.0f, 1.0f)]
	public float normalMapIntensity = 0.7f;
	[Tooltip("Smoothness effect that will be applied to the skid mark.")]
	[Range(0.0f, 1.0f)]
	public float smoothness = 0.0f;
	[Tooltip("Metallic effect that will be applied to the skid mark.")]
	[Range(0.0f, 1.0f)]
	public float metallic = 0.0f;
}

public class MSSkidMarks : MonoBehaviour {

	[Tooltip("Shader 'MSSkidMarksShader' must be associated with this variable.")]
	public Shader MSSkidMarksShader;
	[Tooltip("here you can set some default settings for skid marks if you are not using a 'custom material'.")]
	public DefaultMaterialClass settingsDefaultMaterial;

	[Space(15)]
	[Tooltip("An optional material, which can be used in place of the standard material of the asset.")]
	public Material customMaterial;

	public enum SizeEnum {_600, _1200, _2400, _4800, _7200, _9600, _12000};
	[Space(15)]
	[Tooltip("The maximum length that the 'skidMarks' track can achieve.")]
	public SizeEnum maxTrailLength = SizeEnum._2400;
	[Tooltip("The width of the skid mark.")]
	[Range(0.1f, 6.0f)]
	public float trailWidth = 0.3f;
	[Tooltip("The sensitivity to slips of tires, to start generating the skid marks.")]
	[Range(1.0f, 10.0f)]
	public float sensibility = 2.0f;
	[Tooltip("The default opacity of skid marks, when no specific terrain is found.")]
	[Range(0.1f, 1.0f)]
	public float defaultOpacity = 1.0f;
	[Tooltip("The distance that the slip mark will have from the ground when it is generated.")]
	[Range(0.001f, 0.1f)]
	public float distanceOfTheGround = 0.02f;
	[Tooltip("The default color of the skid mark when no specific terrain is found.")]
	public Color defaultColor = new Color(0.15f, 0.15f, 0.15f, 0);

	[Space(15)]
	[Tooltip("The right front wheel of the vehicle must be associated here.")]
	public wheelClass rightFrontWheel;
	[Tooltip("The left front wheel of the vehicle must be associated here.")]
	public wheelClass leftFrontWheel;
	[Tooltip("The right rear wheel of the vehicle must be associated here.")]
	public wheelClass rightRearWheel;
	[Tooltip("The left rear wheel of the vehicle must be associated here.")]
	public wheelClass leftRearWheel;
	[Tooltip("Other wheels must be associated here.")]
	public wheelClass[] otherWheels;

	public enum GroundSelect { useTag, usePhysicsMaterial };
	[Space(15)]
	[Tooltip("Here you can define whether the code will detect the ground by tag or through 'physics material'")]
	public GroundSelect groundDetection = GroundSelect.useTag;
	[Tooltip("Other lands are set up from here.")]
	public groundClass[] otherGround;

	private readonly Dictionary<Mesh, int> currentIndexes = new Dictionary<Mesh, int>();
	[HideInInspector]
	public float KMh;
	float tempAlphaSkidMarks;
	bool enableSkidMarks;
	Rigidbody rb;
	WheelHit tempWHeelHit;
	Vector3 skidTemp;
	Vector3 wheelWorldPositionTemp;
	Vector3[] lastPoint;

	int CacheSize = 2400;
	List<Vector3> vertices;
	List<Vector3> normals;
	List<Color> colors;
	List<Vector2> uv;
	List<int> tris;

	void Start() {
		switch (maxTrailLength) {
			case SizeEnum._600: CacheSize = 600; break;
			case SizeEnum._1200: CacheSize = 1200; break;
			case SizeEnum._2400: CacheSize = 2400; break;
			case SizeEnum._4800: CacheSize = 4800; break;
			case SizeEnum._7200: CacheSize = 7200; break;
			case SizeEnum._9600: CacheSize = 9600; break;
			case SizeEnum._12000: CacheSize = 12000; break;
		}
		vertices = new List<Vector3>(CacheSize);
		normals = new List<Vector3>(CacheSize);
		colors = new List<Color>(CacheSize);
		uv = new List<Vector2>(CacheSize);
		tris = new List<int>(CacheSize * 3);
		//
		lastPoint = new Vector3[4 + otherWheels.Length];
		rb = GetComponent<Rigidbody>();
		if(MSSkidMarksShader != null) {
			SetValues();
			enableSkidMarks = true;
		}
		else {
			enableSkidMarks = false;
		}
	}

	void Update() {
		KMh = rb.velocity.magnitude * 3.6f;
	}

	void LateUpdate() {
		if(enableSkidMarks == true) {
			CheckTheGroundForSkidMarks();
		}
	}

	void CheckTheGroundForSkidMarks() {
		if(rightFrontWheel.wheelCollider != null) {
			if(rightFrontWheel.wheelCollider.isGrounded) {
				rightFrontWheel.generatingSkidMarks = GenerateSkidMarks(rightFrontWheel.wheelCollider, rightFrontWheel.rendSKDmarks, rightFrontWheel.generatingSkidMarks, rightFrontWheel.displacement, 0);
			}
			else {
				rightFrontWheel.generatingSkidMarks = false;
			}
		}

		if(leftFrontWheel.wheelCollider != null) {
			if(leftFrontWheel.wheelCollider.isGrounded) {
				leftFrontWheel.generatingSkidMarks = GenerateSkidMarks(leftFrontWheel.wheelCollider, leftFrontWheel.rendSKDmarks, leftFrontWheel.generatingSkidMarks, leftFrontWheel.displacement, 1);
			}
			else {
				leftFrontWheel.generatingSkidMarks = false;
			}
		}

		if(rightRearWheel.wheelCollider != null) {
			if(rightRearWheel.wheelCollider.isGrounded) {
				rightRearWheel.generatingSkidMarks = GenerateSkidMarks(rightRearWheel.wheelCollider, rightRearWheel.rendSKDmarks, rightRearWheel.generatingSkidMarks, rightRearWheel.displacement, 2);
			}
			else {
				rightRearWheel.generatingSkidMarks = false;
			}
		}

		if(leftRearWheel.wheelCollider != null) {
			if(leftRearWheel.wheelCollider.isGrounded) {
				leftRearWheel.generatingSkidMarks = GenerateSkidMarks(leftRearWheel.wheelCollider, leftRearWheel.rendSKDmarks, leftRearWheel.generatingSkidMarks, leftRearWheel.displacement, 3);
			}
			else {
				leftRearWheel.generatingSkidMarks = false;
			}
		}

		for(int x = 0; x < otherWheels.Length; x++) {
			if(otherWheels[x].wheelCollider != null) {
				if(otherWheels[x].wheelCollider.isGrounded) {
					otherWheels[x].generatingSkidMarks = GenerateSkidMarks(otherWheels[x].wheelCollider, otherWheels[x].rendSKDmarks, otherWheels[x].generatingSkidMarks, otherWheels[x].displacement, (x + 4));
				}
				else {
					otherWheels[x].generatingSkidMarks = false;
				}
			}
		}
	}

	private int GetCurrentVerticeIndexForMesh(Mesh mesh) {
		int result;
		currentIndexes.TryGetValue(mesh, out result);
		result += 2;
		result %= mesh.vertexCount;
		result += mesh.vertexCount;
		currentIndexes[mesh] = result;
		return result;
	}

	private static T GetRepeatedArrayValue<T>(List<T> array, int index) {
		return array[GetRepeatedArrayIndex(array, index)];
	}

	private static int GetRepeatedArrayIndex<T>(List<T> array, int index) {
		return (index + array.Count) % array.Count;
	}

	private bool GenerateSkidMarks(WheelCollider collider, Mesh wheelMesh, bool generating, float displacement, int indexLastMark) {
		if(!collider.GetGroundHit(out tempWHeelHit))
			return false;

		Quaternion quatTemp;
		collider.GetWorldPose(out wheelWorldPositionTemp, out quatTemp);
		tempWHeelHit.point = wheelWorldPositionTemp - Vector3.up * collider.radius;

		tempAlphaSkidMarks = Mathf.Abs(tempWHeelHit.sidewaysSlip);
		skidTemp = tempWHeelHit.sidewaysDir * trailWidth / 2f * Vector3.Dot(collider.attachedRigidbody.velocity.normalized, tempWHeelHit.forwardDir);
		skidTemp -= tempWHeelHit.forwardDir * trailWidth * 0.1f * Vector3.Dot(collider.attachedRigidbody.velocity.normalized, tempWHeelHit.sidewaysDir);
		if(KMh > (75.0f / sensibility) && Mathf.Abs(collider.rpm) < (3.0f / sensibility)) {
			if(collider.isGrounded) {
				tempAlphaSkidMarks = 10;
			}
		}
		float maxSkid = 1.2f / sensibility;
		if(KMh < 20.0f * (Mathf.Clamp(sensibility, 1, 3))) {
			if(Mathf.Abs(tempWHeelHit.forwardSlip) > maxSkid) {
				if(collider.isGrounded) {
					tempAlphaSkidMarks = 10;
				}
			}
		}

		for(int x = 0; x < otherGround.Length; x++) {
			if(groundDetection == GroundSelect.useTag) {
				if(tempWHeelHit.collider.gameObject.CompareTag(otherGround[x].groundTag)) { //Bruno: gameObject.tag cria garbage, use CompareTag no lugar
					if(otherGround[x].continuousMarking) {
						tempAlphaSkidMarks = 10;
					}
					break;
				}
			}
			else if(groundDetection == GroundSelect.usePhysicsMaterial) {
				if(otherGround[x].physicMaterial) {
					if(tempWHeelHit.collider.sharedMaterial == otherGround[x].physicMaterial) {
						if(otherGround[x].continuousMarking) {
							tempAlphaSkidMarks = 10;
						}
						break;
					}
				}
			}
		}

		if(tempAlphaSkidMarks < (1 / sensibility)) {
			return false;
		}
		float distance = (lastPoint[indexLastMark] - tempWHeelHit.point - skidTemp).sqrMagnitude;
		float alphaAplic = Mathf.Clamp(tempAlphaSkidMarks, 0.0f, 1.0f);

		if(generating) {
			if(distance < 0.1f) {
				return true;
			}
		}

		wheelMesh.GetVertices(vertices);
		wheelMesh.GetNormals(normals);
		wheelMesh.GetTriangles(tris, 0);
		wheelMesh.GetColors(colors);
		wheelMesh.GetUVs(0, uv);

		int verLenght = GetCurrentVerticeIndexForMesh(wheelMesh);
		int triLength = verLenght * 3;

		vertices[GetRepeatedArrayIndex(vertices, verLenght - 1)] = tempWHeelHit.point + tempWHeelHit.normal * distanceOfTheGround - skidTemp + tempWHeelHit.sidewaysDir * displacement;
		vertices[GetRepeatedArrayIndex(vertices, verLenght - 2)] = tempWHeelHit.point + tempWHeelHit.normal * distanceOfTheGround + skidTemp + tempWHeelHit.sidewaysDir * displacement;
		normals[GetRepeatedArrayIndex(normals, verLenght - 1)] = normals[GetRepeatedArrayIndex(normals, verLenght - 2)] = tempWHeelHit.normal;

		Color corRastro = defaultColor;
		corRastro.a = Mathf.Clamp(alphaAplic * defaultOpacity, 0.01f, 1.0f);

		for(int x = 0; x < otherGround.Length; x++) {
			if(groundDetection == GroundSelect.useTag) {
				string tagg = otherGround[x].groundTag;
				if(tempWHeelHit.collider.gameObject.CompareTag(tagg)) {
					corRastro = otherGround[x].skidMarkColor;
					corRastro.a = Mathf.Clamp(alphaAplic * otherGround[x].opacity, 0.01f, 1.0f);
					break;
				}
			}
			else if(groundDetection == GroundSelect.usePhysicsMaterial) {
				if(otherGround[x].physicMaterial) {
					if(tempWHeelHit.collider.sharedMaterial == otherGround[x].physicMaterial) {
						corRastro = otherGround[x].skidMarkColor;
						corRastro.a = Mathf.Clamp(alphaAplic * otherGround[x].opacity, 0.01f, 1.0f);
						break;
					}
				}
			}
		}

		colors[GetRepeatedArrayIndex(colors, verLenght - 1)] = colors[GetRepeatedArrayIndex(colors, verLenght - 2)] = corRastro;

		tris[GetRepeatedArrayIndex(tris, triLength + 0)] = tris[GetRepeatedArrayIndex(tris, triLength + 3)] =
			tris[GetRepeatedArrayIndex(tris, triLength + 1)] = tris[GetRepeatedArrayIndex(tris, triLength + 4)] =
				tris[GetRepeatedArrayIndex(tris, triLength + 2)] = tris[GetRepeatedArrayIndex(tris, triLength + 5)] =
					tris[GetRepeatedArrayIndex(tris, triLength + 6)] = tris[GetRepeatedArrayIndex(tris, triLength + 9)] =
						tris[GetRepeatedArrayIndex(tris, triLength + 7)] = tris[GetRepeatedArrayIndex(tris, triLength + 10)] =
							tris[GetRepeatedArrayIndex(tris, triLength + 8)] = tris[GetRepeatedArrayIndex(tris, triLength + 11)];

		if(generating) {
			tris[GetRepeatedArrayIndex(tris, triLength - 1)] = GetRepeatedArrayIndex(vertices, verLenght - 2);
			tris[GetRepeatedArrayIndex(tris, triLength - 2)] = GetRepeatedArrayIndex(vertices, verLenght - 1);
			tris[GetRepeatedArrayIndex(tris, triLength - 3)] = GetRepeatedArrayIndex(vertices, verLenght - 3);
			tris[GetRepeatedArrayIndex(tris, triLength - 4)] = GetRepeatedArrayIndex(vertices, verLenght - 3);
			tris[GetRepeatedArrayIndex(tris, triLength - 5)] = GetRepeatedArrayIndex(vertices, verLenght - 4);
			tris[GetRepeatedArrayIndex(tris, triLength - 6)] = GetRepeatedArrayIndex(vertices, verLenght - 2);

			uv[GetRepeatedArrayIndex(uv, verLenght - 1)] =
				uv[GetRepeatedArrayIndex(uv, verLenght - 3)] + Vector2.right * distance * 0.01f;
			uv[GetRepeatedArrayIndex(uv, verLenght - 2)] =
				uv[GetRepeatedArrayIndex(uv, verLenght - 4)] + Vector2.right * distance * 0.01f;

		}
		else {
			uv[GetRepeatedArrayIndex(uv, verLenght - 1)] = Vector2.zero;
			uv[GetRepeatedArrayIndex(uv, verLenght - 2)] = Vector2.up;
		}
		lastPoint[indexLastMark] = vertices[GetRepeatedArrayIndex(vertices, verLenght - 1)];
		wheelMesh.SetVertices(vertices);
		wheelMesh.SetNormals(normals);
		wheelMesh.SetTriangles(tris, 0);
		wheelMesh.SetColors(colors);
		wheelMesh.SetUVs(0, uv);
		wheelMesh.RecalculateBounds();
		return true;
	}

	Mesh GerarRendRef(Material skdMaterial, GameObject refParent) {
		GameObject rendRef = new GameObject("SKDMark "+ transform.name);
		rendRef.AddComponent<MeshFilter>();
		rendRef.AddComponent<MeshRenderer>();
		Mesh mesh = rendRef.GetComponent<MeshFilter>().mesh = new Mesh();
		mesh.vertices = new Vector3[CacheSize];
		mesh.normals = new Vector3[CacheSize];
		mesh.uv = new Vector2[CacheSize];
		mesh.colors = new Color[CacheSize];
		mesh.triangles = new int[CacheSize * 3];
		mesh.MarkDynamic();
		rendRef.GetComponent<MeshRenderer>().material = skdMaterial;
		rendRef.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		rendRef.transform.parent = refParent.transform;
		return mesh;
	}

	void SetValues() {
		Material skidmarkMaterial;
		if(customMaterial) {
			skidmarkMaterial = customMaterial;
		}
		else {
			skidmarkMaterial = new Material(MSSkidMarksShader);
			skidmarkMaterial.mainTexture = GenerateTextureAndNormalMap(true);
			skidmarkMaterial.SetTexture("_NormalMap", GenerateTextureAndNormalMap(false));
			skidmarkMaterial.SetFloat("_NormFactor", settingsDefaultMaterial.normalMapIntensity);
			skidmarkMaterial.SetFloat("_Glossiness", settingsDefaultMaterial.smoothness);
			skidmarkMaterial.SetFloat("_Metallic", settingsDefaultMaterial.metallic);
		}
		Color skidColor = defaultColor;
		skidColor.a = defaultOpacity;
		skidmarkMaterial.color = skidColor;
		//
		GameObject objTemp = GameObject.Find("MsSkidMarksSystem_Meshes");
		if (!objTemp) {
			objTemp = new GameObject("MsSkidMarksSystem_Meshes");
		}
		rightFrontWheel.rendSKDmarks = GerarRendRef(skidmarkMaterial, objTemp);
		leftFrontWheel.rendSKDmarks = GerarRendRef(skidmarkMaterial, objTemp);
		rightRearWheel.rendSKDmarks = GerarRendRef(skidmarkMaterial, objTemp);
		leftRearWheel.rendSKDmarks = GerarRendRef(skidmarkMaterial, objTemp);
		for(int x = 0; x < otherWheels.Length; x++) {
			otherWheels[x].rendSKDmarks = GerarRendRef(skidmarkMaterial, objTemp);
		}
	}

	public Texture GenerateTextureAndNormalMap(bool isTexture) {
		Texture2D texture = new Texture2D(32, 32, TextureFormat.ARGB32, false);
		Color transparentColor1 = new Color(0.0f, 0.0f, 0.0f, 0.5f);
		Color transparentColor2 = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		if (isTexture) {
			transparentColor1 = new Color(1.0f, 1.0f, 1.0f, 0.15f);
			transparentColor2 = new Color(1.0f, 1.0f, 1.0f, 0.6f);
		}
		for(int x = 0; x < 32; x++) {
			for(int y = 0; y < 32; y++) {
				texture.SetPixel(x, y, Color.white);
			}
		}
		for(int y = 0; y < 32; y++) {
			for(int x = 0; x < 32; x++) {
				if(y == 0 || y == 1 || y == 30 || y == 31) {
					texture.SetPixel(x, y, transparentColor1);
				}
				if(y == 6 || y == 7 || y == 15 || y == 16 || y == 24 || y == 25) {
					texture.SetPixel(x, y, transparentColor2);
				}
			}
		}
		texture.Apply();
		return texture;
	}

}