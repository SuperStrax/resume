
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;


public class GameController : MonoBehaviour
{
    public GameObject[] maps;
    public bool isMainScene;
    public GameObject[] cars;
    public float timeToSpawnFrom = 2f, timeToSpawnTo = 5f;
    private int countCars;
    private Coroutine bottomCars, leftCars, rightCars, upCars;
    private bool isLoseOnce;
    public GameObject canvasLosePanel;
    public Text nowScore, topScore, coinsCount;
    public GameObject horn;
    public AudioSource turnsignal;
    [NonSerialized]public static int countLoses;
    private static bool isAdd;
    public GameObject adsManager;

    private void Start()
    {
        if (!isAdd && PlayerPrefs.GetString("NoAds") != "Yes")
        {
            Instantiate(adsManager, Vector3.zero, Quaternion.identity);
            isAdd = true;
        }
        

        if (PlayerPrefs.GetInt("NowMap") == 2)
        {
            Destroy(maps[0]);
            maps[1].SetActive(true);
            Destroy(maps[2]);
        }
        else if (PlayerPrefs.GetInt("NowMap") == 3)
        {
            Destroy(maps[0]);
            Destroy(maps[1]);
            maps[2].SetActive(true);
            
        }
        else
        {
            maps[0].SetActive(true);
            Destroy(maps[1]);
            Destroy(maps[2]);
            

        }
        CarController.isLose = false;
        CarController.countCars = 0;

        bottomCars = StartCoroutine(BottomCars());
        leftCars = StartCoroutine(LeftCars());
        rightCars = StartCoroutine(RightCars());
        upCars = StartCoroutine(UpCars());

        StartCoroutine(CreateHorn());
    }

   

    private void Update()
    {


        if (CarController.isLose && !isLoseOnce)
        {
            countLoses++;
            StopCoroutine(bottomCars);
            StopCoroutine(leftCars);
            StopCoroutine(rightCars);
            StopCoroutine(upCars);
            nowScore.text = "<color=#7B1616>SCORE:</color> " + CarController.countCars.ToString();
            if(PlayerPrefs.GetInt("Score") < CarController.countCars)
            {
                PlayerPrefs.SetInt("Score", CarController.countCars);
            }

            topScore.text = "<color=#7B1616>TOP:</color> " + PlayerPrefs.GetInt("Score").ToString();

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CarController.countCars);
            coinsCount.text = PlayerPrefs.GetInt("Coins").ToString();

            canvasLosePanel.SetActive(true);
            isLoseOnce = true;
        }
    }


    IEnumerator BottomCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(11.09f, -0.2177844f, -29.2f), 180f);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    IEnumerator LeftCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-59.3f, -0.2177844f, -2.8f), 270f);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    IEnumerator RightCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(49.6f, -0.2177844f, 4.32f), 90f);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    IEnumerator UpCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(3.82f, -0.2177844f, 71.1f), 0f, true);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    void SpawnCar(Vector3 pos, float rotarionY, bool isMoveFromUp = false)
    {
        GameObject newObj = Instantiate(cars[Random.Range(0,cars.Length)], pos, Quaternion.Euler(0, rotarionY, 0)) as GameObject;
        newObj.name = "Car - " + ++countCars;

        int random = isMainScene ? 1 : Random.Range(1, 4);
        switch (random)
        {
            case 1:
                // Move right
                newObj.GetComponent<CarController>().rightTurn = true;
                if (PlayerPrefs.GetString("music") != "No" && !turnsignal.isPlaying)
                {
                    turnsignal.Play();
                    Invoke("StopSound", 2f);
                }
                    
                break;
            case 2:
                // Move left
                newObj.GetComponent<CarController>().leftTurn = true;
                if (PlayerPrefs.GetString("music") != "No" && !turnsignal.isPlaying)
                {
                    turnsignal.Play();
                    Invoke("StopSound", 2f);
                }

                if (isMoveFromUp)
                    newObj.GetComponent<CarController>().moveFromUp = true;
                break;
            case 3:
                // Move forward
                break;
        }

    }
    void StopSound()
    {
        turnsignal.Stop();
    }

    IEnumerator CreateHorn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 9));
            if (PlayerPrefs.GetString("music") != "No")
                Instantiate(horn, Vector3.zero, Quaternion.identity);
        }
    }
}
