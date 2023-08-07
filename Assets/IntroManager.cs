using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] Image loadingBarFillerImage;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("TOS", 0).Equals(1) ? 1 : 3);
        asyncOperation.allowSceneActivation = false;

        loadingBarFillerImage.DOFillAmount(1, 2f).SetEase(Ease.Linear).OnComplete(() => asyncOperation.allowSceneActivation = true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
