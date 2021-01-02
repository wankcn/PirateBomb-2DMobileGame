using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsButton : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameID = "3949492";
#elif UNITY_ANDROID
    private string gameID = "3949493";
#endif
    Button adsButton;
    public string placementID = "rewardedVideo";
    
    void Start()
    {
        adsButton = GetComponent<Button>();
    }
    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
    }
}