using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using SweetSugar.Scripts.Core;


public class LevelCompleteCash : MonoBehaviour
{
    [SerializeField] GameObject moneyPanel;
    [SerializeField] TextMeshProUGUI valueText;

    [SerializeField] TextMeshProUGUI cashAmount;

    [SerializeField] int amountToGive = 20;
    [SerializeField] float waitTime = 3f;


    void OnEnable()
    {
        StartCoroutine(GrantMoney());
    }

    private IEnumerator GrantMoney()
    {
        valueText.text = amountToGive.ToString();
        PlayerPrefs.SetInt("CashAmount", amountToGive);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(waitTime);

        moneyPanel.SetActive(true);
        cashAmount.text = PlayerPrefs.GetInt("CashAmount", 0).ToString();
    }



    public void WatchAd()
    {
        GoogleAdsManager.Instance.adEventCode = 1;
        InitScript.Instance.currentReward = RewardsType.DoubleUpCash;

        GoogleAdsManager.Instance.ShowRewardedAd();
    }

    public void DoubleUpRewardOnAdWatch()
    {
        valueText.text = (amountToGive * 2).ToString();
        PlayerPrefs.SetInt("CashAmount", (amountToGive * 2) + PlayerPrefs.GetInt("CashAmount", 0));
        PlayerPrefs.Save();
    }

}
