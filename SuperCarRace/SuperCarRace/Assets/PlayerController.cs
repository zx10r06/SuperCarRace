using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    GameObject theCar;

    void Start()
    {
        theCar = gameObject.transform.Find("Model_Sofie@Driving by BUMSTRUM").gameObject;
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            RCC_CarControllerV3 rccV3 = theCar.GetComponent<RCC_CarControllerV3>();
            rccV3.canControl = false;
            return;
        }
        else
        {
            // is player!
            //Set the Camera system to the player car
            RCC_Camera camera = (RCC_Camera)GameObject.Find("RCCCamera").GetComponent(typeof(RCC_Camera));
            camera.SetPlayerCar(theCar);

            Camera cinematicCamera = (Camera)GameObject.Find("Animation").GetComponent(typeof(Camera));
            cinematicCamera.enabled = false;
        }


        /*
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        */
    }

    public override void OnStartLocalPlayer()
    {
        //
        //GetComponent<MeshRenderer>().material.color = Color.blue;

        //RCC_CharacterController rccCC = gameObject.transform.Find("Model_Sofie@Driving by BUMSTRUM").GetComponent<RCC_CharacterController>();
        //rccCC.enabled = true;

        //gameObject.transform.Find("Model_Sofie@Driving by BUMSTRUM").gameObject.SetActive(true);

    }
}