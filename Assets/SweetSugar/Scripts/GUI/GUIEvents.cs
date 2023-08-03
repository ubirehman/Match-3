using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Integrations;
using SweetSugar.Scripts.MapScripts.StaticMap.Editor;
using SweetSugar.Scripts.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace SweetSugar.Scripts.GUI
{
	/// <summary>
	/// GUI events for Facebook, Settings and main scene
	/// </summary>
	public class GUIEvents : MonoBehaviour
	{
		public GameObject loading;
		public Image loadingBarImage;
		void Update()
		{
			if (name == "FaceBook" || name == "Share" || name == "FaceBookLogout")
			{
				if (!LevelManager.THIS.FacebookEnable)
					gameObject.SetActive(false);
			}
		}

		public void Settings()
		{
			SoundBase.Instance.GetComponent<AudioSource>().PlayOneShot(SoundBase.Instance.click);

			MenuReference.THIS.Settings.gameObject.SetActive(true);

		}

		public void Play()
		{
			SoundBase.Instance.GetComponent<AudioSource>().PlayOneShot(SoundBase.Instance.click);
			AsyncOperation asyncOperation;
			LeanTween.delayedCall(1, () =>
			{
				asyncOperation = SceneManager.LoadSceneAsync(Resources.Load<MapSwitcher>("Scriptable/MapSwitcher").GetSceneName());
				asyncOperation.allowSceneActivation = false;

				loadingBarImage.DOFillAmount(1, 1f).SetEase(Ease.Linear).OnComplete(() => asyncOperation.allowSceneActivation = true);

			});
		}

		public void Pause()
		{
			SoundBase.Instance.GetComponent<AudioSource>().PlayOneShot(SoundBase.Instance.click);

			if (LevelManager.THIS.gameStatus == GameState.Playing)
				GameObject.Find("CanvasGlobal").transform.Find("MenuPause").gameObject.SetActive(true);

		}

		public void FaceBookLogin()
		{
#if FACEBOOK

			FacebookManager.THIS.CallFBLogin ();
#endif
		}

		public void FaceBookLogout()
		{
#if FACEBOOK
			FacebookManager.THIS.CallFBLogout ();

#endif
		}

		public void Share()
		{
#if FACEBOOK

			FacebookManager.THIS.Share ();
#endif
		}

	}
}
