using Chartboost;
using Chartboost.Banner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAd : MonoBehaviour
{
    public string appID = "64e7e535bcab79250b78b3c9";
    public string appSignature = "68fedacd7c05a45f9f76807e35f8b5a47e91bb40";
    public bool testMode = true;

    private ChartboostMediationBannerAd bannerAd;

    //Loading banner
    private void Awake()
    {
        ChartboostMediation.StartWithOptions(appID, appSignature);
        ChartboostMediation.SetTestMode(testMode);

        if (bannerAd != null)
        {
            return;
        }

        bannerAd = ChartboostMediation.GetBannerAd("BannerAd", ChartboostMediationBannerAdSize.Standard);

        bannerAd.Load(ChartboostMediationBannerAdScreenLocation.BottomCenter);

    }
}
