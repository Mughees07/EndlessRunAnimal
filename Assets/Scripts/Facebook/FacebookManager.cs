using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.UI;
//using ExitGames.Demos.DemoAnimator;

public class FacebookManager : MonoBehaviour {
	//public Launcher launcher;
	public FacebookManager instance;
	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		if (!instance)
			instance = this;
		
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}

	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			Debug.Log("Profile:User login Successful");

			// Continue with Facebook SDK
			// ...
			Login ();
		} else {
			Debug.Log("Profile:Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}
		
	private void AuthCallback (ILoginResult result) {
		Debug.Log("Profile:Result :"+result.ToString());
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log("Profile:"+aToken.UserId);

			//FB.API("me/picture?type=square&height=128&width=128",  HttpMethod.GET, GetPicture);
			FB.API("me?fields=id,name", HttpMethod.GET, GetName);

			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}

			//Share ();
		} else {
			Debug.Log("Profile:User cancelled login");
		}
	}
	private void GetPicture(IGraphResult result)
	{
		if (result != null)
		{          
			

			//CentralVariables.userimg =Sprite.Create(result.Texture, new Rect(0,0, 128, 128), new Vector2());     

		}

	}
	private void GetName(IGraphResult result)
	{
		IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.RawResult) as IDictionary;
		string fbname = dict["name"].ToString();
		string fbId = dict ["id"].ToString ();
		//CentralVariables.username = fbname;
		//CentralVariables.userId = fbId;
		//Debug.Log("Profile:API:"+CentralVariables.username);
		//Debug.Log("Profile:API:"+CentralVariables.userId);

		//GameObject.FindObjectOfType<Launcher> ().Connect ();

	}
	public bool requestWaiting;
	public int arrayIndex;

	public void GetFriendsPictures(string id, int arrId)
	{

		arrayIndex = arrId;
		if (!requestWaiting) {
			FB.API (id + "/picture?type=square&height=128&width=128", HttpMethod.GET, GetPictures);
			requestWaiting = true;
		}
	}
	private void GetPictures(IGraphResult result)
	{
		if (result != null)
		{          
			//GameObject.FindObjectOfType<GameplayManager>().users[arrayIndex].userImage=Sprite.Create(result.Texture, new Rect(0,0, 128, 128), new Vector2());    
			requestWaiting = false;
		}

	}
	public void Login()
	{

		var perms = new List<string>(){"public_profile","user_friends"};
		FB.LogInWithReadPermissions(perms, AuthCallback);
			



	}
	public void ShareOnFacebook(string toId,Uri link,string linkName ,string linkCaption,string linkDescription,Uri picture ,string mediaSource,FacebookDelegate<IShareResult> callback)
	{
		
		FB.FeedShare(toId,
			link,
			linkName,
			linkCaption,
			linkDescription,
			picture,
			mediaSource,
			callback
		);
	}
	/// <summary>
	/// Prompts the someone using your app to send game requests, short messages between users. Please see the documentation for details
	/// </summary>
	/// <param name="message">The request string the recipient will see, maximum length 60 characters.</param>
	/// <param name="actionType">Request action type for Structured Requests (SEND,ASKFOR,TURN)</param>
	/// <param name="objectId">Open Graph object ID for structured request</param>
	/// <param name="to">A list of Facebook IDs to which to send the request</param>
	/// <param name="data">Additional data stored with the request on Facebook, and handed back to the app when it reads the request back out. Maximum length 255 characters.</param>
	/// <param name="title">The title for the platform multi-friend selector dialog. Max length 50 characters.</param>
	/// <param name="callback">A callback function which will get invoked with the response. If the sender sends any requests, it will receive an JSON dictionary with two properties, request (a string containing the Request ID assigned by Facebook) and to (an array of string, each element being the Facebook ID of one of the selected recipients). If the sender doesn't send any requests, it will instead be null</param>.</param>
	public void Apprequest(string message,OGActionType actionType,string objectId,IEnumerable<string> to,string data ,string title ,FacebookDelegate<IAppRequestResult> callback )
	{
		FB.AppRequest (
			message, 
			actionType,
			objectId,
			to,
			data,
			title,    
			callback
		);
	}
	/// <summary>
	/// Presents a Sharing dialog to the user allowing them to post content to their own timeline.
	/// </summary>
	/// <param name="contentURL">The URL to which this post should link</param>
	/// <param name="contentTitle">The desired title of the content in the link.</param>
	/// <param name="contentDescription">A short description, rendered below linkName in the story.</param>
	/// <param name="photoURL">A URL for the thumbnail image that appears on the post.</param>
	/// <param name="callback">A delegate which will receive the result of the method call.</param>
	public void ShareLink(Uri contentURL,string contentTitle,string contentDescription,Uri photoURL,FacebookDelegate<IShareResult> callback ){
		FB.ShareLink (
			contentURL,
			contentTitle,
			contentDescription,
			photoURL,
			callback
		);
	}
}
