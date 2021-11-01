
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{

    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("TimeScore").ToString();
    }


}
