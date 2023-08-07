using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TermsCondition : MonoBehaviour
{
    AsyncOperation asyncOperation;
    void OnEnable()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
    }
    public void SaveTOS()
    {
        PlayerPrefs.SetInt("TOS", 1);
        asyncOperation.allowSceneActivation = true;
    }
}
