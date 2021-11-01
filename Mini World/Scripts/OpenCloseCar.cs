
using UnityEngine;

public class OpenCloseCar : MonoBehaviour
{
    public bool player, inCar;
    public GameObject astronaft, exit, carCam, playerCam;

    private void Start()
    {
        gameObject.GetComponent<EasySuspension>().enabled = false;
        gameObject.GetComponent<RearWheelDrive>().enabled = false;
        carCam.SetActive(false);
        playerCam.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = false;
        }
    }

    private void Update()
    {
        if(player == true && Input.GetKeyDown(KeyCode.E))
        {
            
            inCar = true;
            gameObject.GetComponent<EasySuspension>().enabled = true;
            gameObject.GetComponent<RearWheelDrive>().enabled = true;
            carCam.SetActive(true);
            playerCam.SetActive(false);
            astronaft.SetActive(false);
            player = false;
        }else if(inCar == true && Input.GetKeyDown(KeyCode.E))
        {
            astronaft.SetActive(true);
            astronaft.transform.position = exit.transform.position;
            inCar = false;
            gameObject.GetComponent<EasySuspension>().enabled = false;
            gameObject.GetComponent<RearWheelDrive>().enabled = false;
            carCam.SetActive(false);
            playerCam.SetActive(true);
        }
    }
}
