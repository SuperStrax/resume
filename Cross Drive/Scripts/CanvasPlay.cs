
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CanvasPlay : MonoBehaviour
{
    private AudioSource audioSource;
    public Image image;
    public Text timeScore;
    public Sprite time, notime;

    private void Start()
    {

        timeScore.text = PlayerPrefs.GetInt("TimeScore").ToString();
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        
        if (timeScore.text == "0")
        {
            image.sprite = notime;
        }

    }

    public void OnClick()
    {
        if (timeScore.text != "0")
        {
            int result = Int32.Parse(timeScore.text);
            
            audioSource.Play();
            StartCoroutine(ClickTime());
            result--;
            PlayerPrefs.SetInt("TimeScore", result);
            timeScore.text = PlayerPrefs.GetInt("TimeScore").ToString();
            

        }

        if (timeScore.text == "0")
        {
            image.sprite = notime;
        }
    }

    IEnumerator ClickTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(5);
        Time.timeScale = 1f;
    }
}
