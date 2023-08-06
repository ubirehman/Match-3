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
        print("<color=red> GRANT MONEY </color>");
        PlayerPrefs.SetInt("CashAmount", amountToGive + PlayerPrefs.GetInt("CashAmount", 0));
        PlayerPrefs.Save();

        valueText.text = amountToGive.ToString();
        cashAmount.text = PlayerPrefs.GetInt("CashAmount", 0).ToString();
        yield return new WaitForSeconds(waitTime);

        moneyPanel.SetActive(true);
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
