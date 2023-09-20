using Chartboost.AdFormats.Fullscreen;
using Chartboost.Requests;
using Chartboost;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FullscreenAd : MonoBehaviour
{
    public string appID = "64e7e535bcab79250b78b3c9";
    public string appSignature = "68fedacd7c05a45f9f76807e35f8b5a47e91bb40";
    public bool testMode = true;
    // Strong reference to cached ad.
    private IChartboostMediationFullscreenAd fullscreenPlacement;

    private void Awake()
    {
        ChartboostMediation.StartWithOptions(appID, appSignature);
        //ChartboostMediation.SetTestMode(testMode);
        //_ = LoadShowFullAd();
    }

    //Subscribing
    private void OnEnable()
    {
        GameOver.OnGameOver += LoadFullscreenTask;
    }

    //Unsubscribing 
    private void OnDisable()
    {
        GameOver.OnGameOver -= LoadFullscreenTask;
    }

    //Task 
    private void LoadFullscreenTask()
    {
        _ = LoadShowFullAd();
    }

    private void OnDestroy()
    {
        fullscreenPlacement.Invalidate();
    }

    public async Task LoadShowFullAd()
    {

        //Loading Fullscreen Ad

        // keywords are optional
        var keywords = new Dictionary<string, string> { { "i12_keyword1", "i12_value1" } };

        // Create a Fullscreen Ad Load Request
        var loadRequest = new ChartboostMediationFullscreenAdLoadRequest("FullAd", keywords);

        // Subscribing Instance Delegates
        loadRequest.DidClick += fullscreenAd => Debug.Log($"DidClick Name: {fullscreenAd.Request.PlacementName}");

        loadRequest.DidClose += (fullscreenAd, error) =>
        Debug.Log(!error.HasValue ? $"DidClose Name: {fullscreenAd.Request.PlacementName}"
        : $"DidClose with Error. Name: {fullscreenAd.Request.PlacementName}, Code: {error?.Code}, Message: {error?.Message}");

        loadRequest.DidReward += fullscreenAd => Debug.Log($"DidReward Name: {fullscreenAd.Request.PlacementName}");

        loadRequest.DidRecordImpression += fullscreenAd => Debug.Log($"DidImpressionRecorded Name: {fullscreenAd.Request.PlacementName}");

        loadRequest.DidExpire += fullscreenAd => Debug.Log($"DidExpire Name: {fullscreenAd.Request.PlacementName}");

        // Await on FullscreenAd Load
        var loadResult = await ChartboostMediation.LoadFullscreenAd(loadRequest);


        // Failed to Load
        if (loadResult.Error.HasValue)
        {
            Debug.Log($"Fullscreen Failed to Load: {loadResult.Error?.Code}, message: {loadResult.Error?.Message}");
            return;
        }

        // Successful Load!

        // Set strong reference to cached ad
        fullscreenPlacement = loadResult.Ad;

        // Set custom data before show
        fullscreenPlacement.CustomData = "CUSTOM DATA HERE!";

        var placementName = fullscreenPlacement?.Request?.PlacementName;
        Debug.Log($"Fullscreen Placement Loaded with PlacementName: {placementName}");

        //Showing Fullscreen Ad

        if (fullscreenPlacement == null)
            return;


        // Make a load request
        var adShowResult = await fullscreenPlacement.Show();
        var error = adShowResult.Error;


        // Failed to Show
        if (error.HasValue)
        {
            Debug.Log($"Fullscreen Failed to Show with Value: {error?.Code}, {error?.Message}");
            return;
        }


        // Successful Fullscreen Show. This will only finish after the ad show is completed.
        var metrics = adShowResult.Metrics;
        Debug.Log($"Fullscreen Ad Did Show: {JsonConvert.SerializeObject(metrics, Formatting.Indented)}");
    }
}
        