
using UnityEngine;

public class TankController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 20f, mag, rotate = 5, rotateCorpus = 5, camSpeed = 3, rotateGun = 10, forceShoot = 10, forceBullet = 20;
    private Transform corpus, turret, gun;
    private bool isRotate = true, isDontRotate, isRotateDown = true, isDontRotateDown;
    public Transform cam;
    public GameObject fire, shoot, bullet;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        corpus = this.gameObject.transform.GetChild(0);
        turret = this.gameObject.transform.GetChild(1);
        gun = this.turret.transform.GetChild(0);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPoint = shoot.transform.position;
            Quaternion spawnRoot = shoot.transform.rotation;
            GameObject blt = Instantiate(bullet, spawnPoint, spawnRoot) as GameObject;
            Rigidbody Run = blt.GetComponent<Rigidbody>();
            Run.AddForce(blt.transform.forward * forceBullet);

            GameObject vfx = Instantiate(fire, shoot.transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 0.5f);
            rb.AddRelativeForce(Vector3.back * forceShoot);

        }
        

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * rotateCorpus * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotateCorpus * Time.deltaTime);


        mag = rb.velocity.magnitude + speed;
        if (Input.GetKey(KeyCode.W) && mag <= 16)
        {

            if (corpus.transform.localEulerAngles.x <= 278f && corpus.transform.localEulerAngles.x != 270f)
            {
                isDontRotate = true;
            }
                
            rb.AddRelativeForce(Vector3.forward * mag);
            if (corpus.transform.localEulerAngles.x >= 270f && isRotate)
            {
                corpus.transform.Rotate(Vector3.right * rotate * Time.deltaTime);
                turret.transform.Rotate(Vector3.right * rotate * Time.deltaTime);
            }
            

        }
        else if (Input.GetKey(KeyCode.S) && mag <= 12)
        {

            if (corpus.transform.localEulerAngles.x <= 274f && corpus.transform.localEulerAngles.x != 270.5f)
            {
                isDontRotateDown = true;
            }
            rb.AddRelativeForce(Vector3.back * mag);
            if (corpus.transform.localEulerAngles.x >= 270.5f && isRotateDown)
            {
                corpus.transform.Rotate(Vector3.left * rotate * Time.deltaTime);
                turret.transform.Rotate(Vector3.left * rotate * Time.deltaTime);
            }

        }
        else if (isDontRotate)
        {
            isRotate = false;
            turret.transform.Rotate(Vector3.left * rotate * Time.deltaTime);
            corpus.transform.Rotate(Vector3.left * rotate * Time.deltaTime);
            if(corpus.transform.localEulerAngles.x <= 270 || corpus.transform.localEulerAngles.x <= 271)
            {
                isDontRotate = false;
            }
            isRotate = true;

        }
        else if (isDontRotateDown)
        {
            isRotateDown = false;
            turret.transform.Rotate(Vector3.right * rotate * Time.deltaTime);
            corpus.transform.Rotate(Vector3.right * rotate * Time.deltaTime);
            if (corpus.transform.localEulerAngles.x >= 274f || corpus.transform.localEulerAngles.x >= 274.5f)
            {
                isDontRotateDown = false;
            }
            isRotateDown = true;
        }

        float camUp = Input.GetAxis("Mouse Y");
        float camLeft = Input.GetAxis("Mouse X");
        if (camUp > 0)
        {
            cam.transform.Rotate(Vector3.left * Time.deltaTime * camSpeed);
            if (gun.transform.localEulerAngles.x >= 290 || gun.transform.localEulerAngles.x <= 16 && gun.transform.localEulerAngles.x >= 0)
                gun.transform.Rotate(Vector3.left * Time.deltaTime * rotateGun);
        }
        else if (camUp < 0)
        {
            cam.transform.Rotate(Vector3.right * Time.deltaTime * camSpeed);
            if (gun.transform.localEulerAngles.x <= 15 || gun.transform.localEulerAngles.x >= 289 && gun.transform.localEulerAngles.x <= 360)
                gun.transform.Rotate(Vector3.right * Time.deltaTime * rotateGun);
        }

        if (camLeft > 0)
        {
            cam.transform.Rotate(Vector3.up * Time.deltaTime * camSpeed);
            if (gun.transform.localEulerAngles.z <= 30 || gun.transform.localEulerAngles.z >= 329 && gun.transform.localEulerAngles.z <= 360)
                gun.transform.Rotate(Vector3.forward * Time.deltaTime * rotateGun);
        }
        else if (camLeft < 0)
        {
            cam.transform.Rotate(Vector3.down * Time.deltaTime * camSpeed);
            if (gun.transform.localEulerAngles.z >= 330 || gun.transform.localEulerAngles.z <= 31 && gun.transform.localEulerAngles.z >= 0)
                gun.transform.Rotate(Vector3.back * Time.deltaTime * rotateGun);
        }

    }

}
