using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashAmount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cashAmount;

    private void OnEnable()
    {
        UpdateCash();
    }

    public  void UpdateCash()
    {
        cashAmount.text = PlayerPrefs.GetInt("CashAmount", 0).ToString();
    }

}
