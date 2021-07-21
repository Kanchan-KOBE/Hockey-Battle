using UnityEngine;
using UnityEngine.SceneManagement;

using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;

public class MainScene : MonoBehaviour
{
    InterstitialAdGameObject interstitialAd;

    void Start()
    {
        interstitialAd = MobileAds.Instance
            .GetAd<InterstitialAdGameObject>("Interstitial Ad");

        MobileAds.Initialize((initStatus) => {
            Debug.Log("Initialized MobileAds");
        });
        interstitialAd.LoadAd();
    }

    public void OnClickShowButton()
    {
        // Display an interstitial ad
        interstitialAd.ShowIfLoaded();
    }
}