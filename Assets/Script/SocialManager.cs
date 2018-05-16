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

	//This is the text which you want to show
	string textToDisplay="Hey Guys! Check out my score: ";

	// Twitter Share Button	
	public void shareScoreOnTwitter () 
	{
		Application.OpenURL (TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay) + ScoreManager.instance.m_score + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}
	#endregion
}
