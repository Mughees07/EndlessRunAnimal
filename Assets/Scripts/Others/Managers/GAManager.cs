using UnityEngine;
using System.Collections;
using GameAnalyticsSDK;
public class GAManager : SingeltonBase<GAManager>  {


	const string  cartType = "Shop";
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

/* amount = How manny coins or gems , itemType = coinPack or GemsPack ,itemId = purchaseID , cartType = from whee purchases Shop  */
		public void LogBusinessEvent(int amount, string itemType ,string itemId , string receipt, string signature){
				#if UNITY_IPHONE
				GameAnalytics.NewBusinessEventIOS(string currency, int amount, string itemType, string itemId, string cartType, string receipt)
				#endif
				#if UNITY_ANDROID
					//if(UserPrefs.isAmazonBuild){
					
					//} else {
					GameAnalytics.NewBusinessEventGooglePlay(Constants.INAPP_CURRENCY, amount, itemType, itemId, cartType , receipt, signature);
					//}
				#endif
			}
/* status = start or complete fail etc , world = Indoor or outdoor ,level = questposition , phase = quest#  */
		public void LogProgressionEvent(GAProgressionStatus status,string world, string point,string phase, int prize){
			#if UNITY_IPHONE
			GameAnalytics.NewProgressionEvent(status, world, point, phase, prize);
			#endif
			#if UNITY_ANDROID
			//if(UserPrefs.isAmazonBuild){
				
			//} else {
				GameAnalytics.NewProgressionEvent(status, world, point, phase, prize);
			//}
			#endif
		}
/* isSink = source or Sink , currencyType = Gems or Coins ,price = amount , eventName = where  , itemId = What bought or spent */
	/*ZI - Source = if we are spending our currency somewhere, lets say buying a car 
	 Sink = if we are earning currency from somewhere, lets say level complete*/

		public void LogResourceEvent(bool isSink,string currencyType, float amount,string eventName, string itemId){
		//Debug.LogError("VAlue inside GA Manager"+amount);		
		#if UNITY_IPHONE
			if(isSink){
			GameAnalytics.NewResourceEvent(GA_Resource.GAResourceFlowType.GAResourceFlowTypeSink, currencyType, Mathf.Abs((float)amount), eventName,itemId);
			}
			else{
			GameAnalytics.NewResourceEvent(GA_Resource.GAResourceFlowType.GAResourceFlowTypeSource, currencyType, Mathf.Abs((float)amount), eventName,itemId);
			}	
			#endif
			#if UNITY_ANDROID
			//if(UserPrefs.isAmazonBuild){
			//} else {
				if(isSink){

				GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, currencyType,amount,eventName,itemId);
				}
				else{
				GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, currencyType,amount,eventName,itemId);
				}	
			//}
			#endif
		}
	/*
	 *  event Name = which screen	 * 
	 */

	public void LogDesignEvent(string eventName){
		#if UNITY_IPHONE
		GameAnalytics.NewDesignEvent(eventName);
		#endif
		
		#if UNITY_ANDROID
			//if(UserPrefs.isAmazonBuild){
			
			//} else {
			#if UNITY_EDITOR
			//Debug.Log("GA Event *************** "+ eventName+"**********************************");
			#endif
			GameAnalytics.NewDesignEvent(eventName);
			//}
		#endif
	}		
	/*
	 *  GA_Error.SeverityType --> critical , debug, error, info, warning	 * 
	 */
	public void LogErrorEvent(string error){
		#if UNITY_IPHONE
				
		#endif
		
		#if UNITY_ANDROID
			//if(UserPrefs.isAmazonBuild){
			
			//} else {

			if(error.Equals("critical"))
				GameAnalytics.NewErrorEvent (GAErrorSeverity.Critical, error);
			else if(error.Equals("debug"))
				GameAnalytics.NewErrorEvent (GAErrorSeverity.Debug, error);
			else if(error.Equals("error"))
				GameAnalytics.NewErrorEvent (GAErrorSeverity.Error, error);
			else if(error.Equals("info"))
				GameAnalytics.NewErrorEvent (GAErrorSeverity.Info, error);
			else if(error.Equals("warning"))
				GameAnalytics.NewErrorEvent (GAErrorSeverity.Warning, error);


			//}	
		#endif
	}
}
