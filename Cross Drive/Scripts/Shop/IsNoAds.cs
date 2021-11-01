
using UnityEngine;

public class IsNoAds : MonoBehaviour
{
    void Start()
    {

        if (PlayerPrefs.GetString("NoAds") == "Yes")
        {
            Destroy(gameObject);
        }
    }

}
