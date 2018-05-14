using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour {

	public void AppRate()
	{      
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.MartinTsang.BirdyHop");
        #elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/id1384642685");
        #endif
	}
}
