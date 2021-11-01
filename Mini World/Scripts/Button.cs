
using UnityEngine;
using System.Collections;


public class Button : MonoBehaviour
{
    public GameObject buttonTime, time;

    public void onClickTime()
    {
        StartCoroutine(ClickTime());
        
        
    }

    IEnumerator ClickTime()
    {
        time.SetActive(false);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(5);
        Time.timeScale = 1f;
        buttonTime.SetActive(false);

    }

}
