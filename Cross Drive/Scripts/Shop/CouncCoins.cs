
using UnityEngine;
using UnityEngine.UI;

public class CouncCoins : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
