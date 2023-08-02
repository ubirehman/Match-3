#if CHARTBOOST_ADS
using ChartboostSDK;
#endif
using System;
using System.Collections.Generic;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Integrations;
using UnityEngine;
namespace SweetSugar.Scripts.AdsEvents
{
    /// <summary>
    /// Ads manager responsible for initialization and showing
    /// </summary>
    public class AdsManager : UnityEngine.MonoBehaviour
    {
        public static AdsManager THIS;
        //EDITOR: ads events
        public List<AdEvents> adsEvents = new List<AdEvents>();
        //is unity ads enabled
        public bool enableUnityAds;
        //is admob enabled
        public bool enableGoogleMobileAds;
        //is chartboost enabled
        public bool enableChartboostAds;
        //rewarded zone for Unity ads
        public string rewardedVideoZone;
        //admob stuff
        public string admobUIDAndroid;
        public string admobRewardedUIDAndroid;
        public string admobUIDIOS;
        public string admobRewardedUIDIOS;
        private AdManagerScriptable adsSettings;

        private void Awake()
        {
            if (THIS == null) THIS = this;
            else if(THIS != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(this);
            adsSettings = Resources.Load<AdManagerScriptable>("Scriptable/AdManagerScriptable");
            adsEvents = adsSettings.adsEvents;
            admobUIDAndroid = adsSettings.admobUIDAndroid;
            admobUIDIOS = adsSettings.admobUIDIOS;

        }
        
#if GOOGLE_MOBILE_ADS
	
    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    // public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    // {
    //     print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    // }
#endif
        
        public bool GetRewardedUnityAdsReady()
        {
#if APPODEAL
        return AppodealIntegration.THIS.IsRewardedLoaded();
#endif
#if UNITY_ADS

            rewardedVideoZone = "rewardedVideo";
           /*  if (Advertisement.IsReady(rewardedVideoZone))
            {
                return true;
            }
            else
            { */
                rewardedVideoZone = "rewardedVideoZone";
               /*  if (Advertisement.IsReady(rewardedVideoZone))
                {
                    return true;
                } */
            /* }
#endif */

            return false;
        }

        private void OnDisable()
        {
        }

        public delegate void RewardedShown();

        public static event RewardedShown OnRewardedShown;
        public void ShowRewardedAds()
    {
            Debug.Log("show Rewarded ads video in " + LevelManager.THIS.gameStatus);
            // GoogleAdsManager.Instance.ShowRewardedAd();

#if APPODEAL
        Debug.Log("show Rewarded ads video in " + LevelManager.THIS.gameStatus);

        if (GetRewardedUnityAdsReady())
        {
            AppodealIntegration.THIS.ShowRewardedAds();
        }
        else{
#if UNITY_ADS
            Advertisement.Show(rewardedVideoZone, new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result == ShowResult.Finished)
                    {
                        OnRewardedShown?.Invoke();
                        InitScript.Instance.ShowReward();
                    }
                }
            });
#endif
        }
#elif UNITY_ADS
            Debug.Log("show Rewarded ads video in " + LevelManager.THIS.gameStatus);

        if (GetRewardedUnityAdsReady())
        {
            #if UNITY_ADS
            /* Advertisement.Show(rewardedVideoZone, new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result == ShowResult.Finished)
                    {
                        OnRewardedShown?.Invoke();
                        InitScript.Instance.ShowReward();
                    }
                }
            }); */
            #endif
        }
//#elif GOOGLE_MOBILE_ADS//2.2
//        bool stillShow = true;
//#if UNITY_ADS
//        stillShow = !GetRewardedUnityAdsReady ();
//#endif
//        if(stillShow)
//        {
//            Debug.Log("show Admob Rewarded ads video in " + LevelManager.THIS.gameStatus);
//            RewAdmobManager.THIS.ShowRewardedAd(CheckRewardedAds);
//        }
#endif
    }

    public void CheckAdsEvents(GameState state)
    {    
        foreach (var item in adsEvents)
        {
            if (item.gameEvent == state)
            {
                item.calls++;  
                if (item.calls % item.everyLevel == 0)
                    ShowAdByType(item.adType);
            }
        }
    }

    void ShowAdByType(AdType adType)
    {
        if (adType == AdType.AdmobInterstitial && enableGoogleMobileAds)
            ShowAds(false);
        else if (adType == AdType.UnityAdsVideo && enableUnityAds)
            ShowVideo();
        else if (adType == AdType.ChartboostInterstitial && enableChartboostAds)
            ShowAds(true);
        else if(adType == AdType.Appodeal)
            ShowAds(false);
    }

    public void ShowVideo()
    {  
#if UNITY_ADS
        Debug.Log("show Unity ads video in " + LevelManager.THIS.gameStatus);

       /*  if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
        else
        {
            if (Advertisement.IsReady("defaultZone"))
            {
                Advertisement.Show("defaultZone");
            }
        } */
#endif
    }

    public void CacheRewarded()
    {
#if APPODEAL
        AppodealIntegration.THIS.RequestRewarded();
#endif

    }


    public void ShowAds(bool chartboost = true)
    {
        #if APPODEAL
        if(AppodealIntegration.THIS.IsInterstitialLoaded())
        {
            Debug.Log("show  Interstitial in " + LevelManager.THIS.gameStatus);
            AppodealIntegration.THIS.ShowInterstitial();
        }
        #endif
        if (chartboost)
        {
#if CHARTBOOST_ADS
            Debug.Log("show Chartboost Interstitial in " + LevelManager.THIS.gameStatus);

            Chartboost.showInterstitial(CBLocation.Default);
            Chartboost.cacheInterstitial(CBLocation.Default);
#endif
        }
        else
        {
        }
    }
    }
#endif
}