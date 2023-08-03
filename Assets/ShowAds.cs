using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAds : MonoBehaviour
{
    void OnEnable()
    {
        GoogleAdsManager.Instance.ShowBannerAd();
    }

    void OnDisable()
    {
        GoogleAdsManager.Instance.HideBannerAd();
    }
}
