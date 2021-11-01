using UnityEngine;
using UnityEngine.Monetization;

public class ShowAds : MonoBehaviour {

    private const string ADID = "4414532";  // id проекта по Андроид
    private const string VIDEOID = "Rewarded_Android"; // Если смотреть по документации, то название формата рекламы должно быть таким

    private static int countRestarts;

    private void Start() {
        Monetization.Initialize(ADID, true);

        if (countRestarts != 0 && countRestarts % 3 == 0)
        {
            showAd();
            PlayerPrefs.SetInt("score", 100);
        }
            

        countRestarts++;

    }

    void showAd() {
        if(Monetization.IsReady(VIDEOID)) {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(VIDEOID) as ShowAdPlacementContent;
            if (ad != null)
                ad.Show();
        }
    }

}
