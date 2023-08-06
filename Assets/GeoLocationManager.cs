using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GeoLocationManager : MonoBehaviour
{
    public static GeoLocationManager Instance { get; private set; }

    private const string IpInfoApiUrl = "https://ipinfo.io/?token=925c362f150bdc";

    public string CurrentCountry { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FetchCountryFromInternet());
    }

    private IEnumerator FetchCountryFromInternet()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(IpInfoApiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string responseText = webRequest.downloadHandler.text;
                var json = JsonUtility.FromJson<IpInfoResponse>(responseText);
                CurrentCountry = json.country;
                PlayerPrefs.SetString("Country", json.city + ", " + CurrentCountry);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogError("Failed to fetch geolocation data: " + webRequest.error);
            }
        }
    }

    [System.Serializable]
    private class IpInfoResponse
    {
        public string country;
        public string city;
    }
}
