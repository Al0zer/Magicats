using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chartboost;

public class Delegates : MonoBehaviour
{
    /* 
     * SUBSCRIBING STATIC DELEGATES
     */
    private void OnEnable()
    {
        // Start Delegate
        ChartboostMediation.DidStart += DidStart;

        // ILRD Delegate
        ChartboostMediation.DidReceiveImpressionLevelRevenueData += DidReceiveImpressionLevelRevenueData;

        // Partner Initialization Data Delegate
        ChartboostMediation.DidReceivePartnerInitializationData += DidReceivePartnerInitializationData;

        // Error Handling Delegate
        ChartboostMediation.UnexpectedSystemErrorDidOccur += UnexpectedSystemErrorDidOccur;

        // Banner Ad Delegates
        ChartboostMediation.DidLoadBanner += DidLoadBanner;
        ChartboostMediation.DidClickBanner += DidClickBanner;
        ChartboostMediation.DidRecordImpressionBanner += DidRecordImpressionBanner;
    }

    /* 
     * UNSUBSCRIBING DELEGATES
     */
    private void OnDisable()
    {
        // Remove event handlers
        ChartboostMediation.DidStart -= DidStart;

        // ILRD Delegate
        ChartboostMediation.DidReceiveImpressionLevelRevenueData -= DidReceiveImpressionLevelRevenueData;

        // Partner Initialization Data Delegate
        ChartboostMediation.DidReceivePartnerInitializationData -= DidReceivePartnerInitializationData;

        // Error Handling Delegate
        ChartboostMediation.UnexpectedSystemErrorDidOccur -= UnexpectedSystemErrorDidOccur;

        // Banner Ad Delegates
        ChartboostMediation.DidLoadBanner -= DidLoadBanner;
        ChartboostMediation.DidClickBanner -= DidClickBanner;
        ChartboostMediation.DidRecordImpressionBanner -= DidRecordImpressionBanner;
    }

    /*
     * LIFECYCLE DELEGATES
     */

    // Start Delegate
    private void DidStart(string error)
    {
        Debug.Log($"DidStart: {error}");
        // Logic goes here
    }

    // ILRD Delegate
    private void DidReceiveImpressionLevelRevenueData(string placement, Hashtable impressionData)
    {
        var json = JsonTools.Serialize(impressionData);
        Debug.Log($"DidReceiveImpressionLevelRevenueData {placement}: {json}");
    }

    // Partner Initialization Data Delegate
    private void DidReceivePartnerInitializationData(string partnerInitializationData)
    {
        Debug.Log($"DidReceivePartnerInitializationData: ${partnerInitializationData}");
    }

    // Error Handling Delegate
    private static void UnexpectedSystemErrorDidOccur(string error)
    {
        Debug.LogErrorFormat(error);
    }


    /*
     *  BANNER AD DELEGATES
     */
    private void DidLoadBanner(string placementName, string loadId, BidInfo info, string error)
    {
        Debug.Log($"DidLoadBanner{placementName}, {placementName}, Price: ${info.Price:F4}, Auction Id: {info.AuctionId}, Partner Id: {info.PartnerId}. {error}");
    }

    private void DidClickBanner(string placementName, string error)
    {
        Debug.Log($"DidClickBanner {placementName}: {error}");
    }

    private void DidRecordImpressionBanner(string placementName, string error)
    {
        Debug.Log($"DidRecordImpressionBanner {placementName}: {error}");
    }
}
