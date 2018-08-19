using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingWinter : MonoBehaviour {

    public void AppRate()
    {
#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.MartinTsang.PengyHop");
#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/id1384642685");
#endif
    }
}
