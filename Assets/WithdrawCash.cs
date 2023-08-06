using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WithdrawCash : MonoBehaviour
{
    public TextMeshProUGUI totalEarningText;
    public TextMeshProUGUI apologyText;


    public Button withdrawButton;

    void OnEnable()
    {
        totalEarningText.text = "YOUR TOTAL EARNINGS: " + PlayerPrefs.GetString("CashAmount", "0");
        apologyText.text = "SORRY, WE ARE NOT OFFERING WITHDRAWAL AT\n<color=red>" + PlayerPrefs.GetString("Country") + "</color>";

        var cashAmount = int.Parse(PlayerPrefs.GetString("CashAmount", "0"));
        if (cashAmount < 5600)
        {
            withdrawButton.interactable = false;
        }
    }
}
