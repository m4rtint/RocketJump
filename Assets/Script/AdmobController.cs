using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobController : MonoBehaviour
{

    [SerializeField]
    bool m_DEBUGADMOB;

    //Bannner
    BannerView bannerView;

    // Use this for initialization
    void Awake()
    {
        InitializeMobileAds();
        InitializeBanner();
    }

    void InitializeMobileAds()
    {
        string appId = "unexpected_platform";

#if UNITY_ANDROID
        appId = "ca-app-pub-2541894783789070~5523162027";
#elif UNITY_IPHONE
        appId = "ca-app-pub-2541894783789070~5439401544";
#else
        appId = "ca-app-pub-2541894783789070~5523162027";
#endif
        MobileAds.Initialize(appId);
    }

    void InitializeBanner(){
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
                                         .AddTestDevice(deviceID).Build();

        string adUnitId = "";
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-2541894783789070/4509463259";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-2541894783789070/9187074865";
#endif
        if (m_DEBUGADMOB)
        {
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        bannerView.LoadAd(request);
    }

}
