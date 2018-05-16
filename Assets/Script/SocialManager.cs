using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialManager : MonoBehaviour {

	#region App Store
	public void AppRate()
	{      
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.MartinTsang.BirdyHop");
        #elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/id1384642685");
        #endif
	}

	#endregion

	#region Twitter
	//Twitter Share Link
	string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";

	//Language
	string TWEET_LANGUAGE = "en";

	// Twitter Share Button	
	public void ShareScoreOnTwitter() 
	{
		//This is the text which you want to show
		string AND_textToDisplay="WOW! I scored :"+ScoreManager.instance.m_score +" in the #BirdyHop game on Android https://play.google.com/store/apps/details?id=com.MartinTsang.BirdyHop";
		string IOS_textToDisplay="WOW! I scored :"+ScoreManager.instance.m_score +" in the #BirdyHop game on iOS https://itunes.apple.com/us/app/birdy-hop/id1384642685?ls=1&mt=8";

		string textToDisplay = AND_textToDisplay;
		#if UNITY_IPHONE
		textToDisplay = IOS_textToDisplay;
		#endif

		string shareURL = TWITTER_ADDRESS + "?text=" + WWW.EscapeURL (textToDisplay) + "&amp;lang=" + WWW.EscapeURL (TWEET_LANGUAGE);
		Debug.Log (shareURL);

		Application.OpenURL(shareURL);
	
	}
	#endregion
}
