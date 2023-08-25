using Chartboost;
using Chartboost.Banner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAd : MonoBehaviour
{
    
    private ChartboostMediationBannerAd bannerAd;

    //Loading banner
    [System.Obsolete]
    private void Awake()
    {
        // New Manual Initialization after 4.1.0
        ChartboostMediation.StartWithAppIdAndAppSignature(ChartboostMediationSettings.AppId, ChartboostMediationSettings.AppSignature);

        var appID = "64e7e535bcab79250b78b3c9";
        var appSignature = "68fedacd7c05a45f9f76807e35f8b5a47e91bb40";


        ChartboostMediation.StartWithAppIdAndAppSignature(appID, appSignature);


        ChartboostMediation.SetTestMode(true);

        if (bannerAd != null)
            return;

        bannerAd = ChartboostMediation.GetBannerAd("BannerAd", ChartboostMediationBannerAdSize.Standard);

        bannerAd.Load(ChartboostMediationBannerAdScreenLocation.Center);
    }
}
