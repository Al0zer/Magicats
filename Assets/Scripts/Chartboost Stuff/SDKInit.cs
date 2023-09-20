using Chartboost;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKInit : MonoBehaviour
{
    private void Awake()
    {
        // New Manual Initialization after 4.1.0
        ChartboostMediation.StartWithOptions(ChartboostMediationSettings.AppId, ChartboostMediationSettings.AppSignature);

        var appID = "64e7e535bcab79250b78b3c9";
        var appSignature = "68fedacd7c05a45f9f76807e35f8b5a47e91bb40";

        ChartboostMediation.StartWithOptions(appID, appSignature);

        //ChartboostMediation.SetTestMode(true);
    }
}
