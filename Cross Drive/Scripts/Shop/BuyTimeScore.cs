
using UnityEngine;
using UnityEngine.UI;

public class BuyTimeScore : MonoBehaviour
{
    public AudioClip succes, fail;
    public Text coinsCount, timeCount;
    public Animation coinsText;

    public void BuyTime(int needCoins)
    {
        timeCount.text = PlayerPrefs.GetInt("TimeScore").ToString();
        int coins = PlayerPrefs.GetInt("Coins");

        if (coins < needCoins)
        {
            if (PlayerPrefs.GetString("music") != "No")
            {
                GetComponent<AudioSource>().clip = fail;
                GetComponent<AudioSource>().Play();
            }


            coinsText.Play();
        }

        else
        {
            switch (needCoins)
            {
                case 100:
                    PlayerPrefs.SetInt("TimeScore", PlayerPrefs.GetInt("TimeScore") + 1);

                    break;
            }

            int nowCoins = coins - needCoins;
            coinsCount.text = nowCoins.ToString();
            PlayerPrefs.SetInt("Coins", nowCoins);

            if (PlayerPrefs.GetString("music") != "No")
            {
                GetComponent<AudioSource>().clip = succes;
                GetComponent<AudioSource>().Play();
            }
        }

    }
}
