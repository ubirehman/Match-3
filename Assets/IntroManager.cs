using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] Image loadingBarFillerImage;
    // Start is called before the first frame update
    void Start()
    {
        loadingBarFillerImage.DOFillAmount(1, 2f).SetEase(Ease.Linear).OnComplete(()=> SceneManager.LoadScene(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
