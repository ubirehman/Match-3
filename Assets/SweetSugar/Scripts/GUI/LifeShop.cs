using SweetSugar.Scripts.Core;
using TMPro;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
	/// <summary>
	/// Life shop popup
	/// </summary>
	public class LifeShop : MonoBehaviour
	{
		public TextMeshProUGUI costText;
		public int CostIfRefill = 12;
		// Use this for initialization
		void OnEnable ()
		{
            costText.text = "" + CostIfRefill;
			if (!LevelManager.THIS.enableInApps)
				transform.Find ("Image/Buttons/BuyLife").gameObject.SetActive (false);
		
		}
	
	}
}
