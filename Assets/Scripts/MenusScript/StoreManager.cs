using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Prime31;
using System.Text;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System.Globalization;
//using System;
//using MiniJSON;
using System.Security.Cryptography;



public class StoreManager : SingeltonBase<StoreManager> {
	bool FirstTimeLaunch=true;
	// Product identifiers array is for only IOS Because before performing any inapp you should get Product identifiers from store.
	# if UNITY_IPHONE
		string [] productIdentifiers = { Constants.PACKAGE_UNLOCK_ALL_PLAYERS };
		bool canMakePayments = false;	
	# endif
	# if UNITY_ANDROID
	string [] productIdentifiers = CentralVariables.InAppPackages;
		//string [] managedProductIdentifiers = {Constants.PACKAGE_UNLOCK_ALL_PLAYERS };  	
//		bool isRestoreTransaction = false;

	public static string InApp_purchaseData="";
	public static string InApp_signature="";



	# endif

	public static string packageId="";
	// Used for Purchase from Store.
	public void PurchasePackage(int index){
		string packageName = productIdentifiers [index];
		Debug.Log ("buy one package of " + packageName);
		# if UNITY_IPHONE
			if(canMakePayments)
			{
		        StoreKitBinding.purchaseProduct(packageName,1);
	    	}
		# endif
		
		# if UNITY_ANDROID
//			if(UserPrefs.isAmazonBuild){
//				AmazonIAP.initiatePurchaseRequest(packageName);
//			} else {
			//	if(!isNonConsumedItem(packageName)){
//					GoogleIAB.consumeProduct(packageName);		
				//}
			//
				packageId=packageName;
			//
				GoogleIAB.purchaseProduct(packageName);			  	
			}
		
		# endif
	

	// Used for Restoring Transactions from Store.
	
	public void RestoreCompletedTransactions(){
		# if UNITY_IPHONE
			if(canMakePayments)
			{
				StoreKitBinding.restoreCompletedTransactions();
		        
	    	}
		# endif
		
		# if UNITY_ANDROID
			//UserPrefs.isRestoreTransaction = true;			
			//if(UserPrefs.isAmazonBuild){
//				AmazonIAP.initiateItemDataRequest(managedProductIdentifiers);
			//} else {
		  		//GoogleIAB.queryInventory(managedProductIdentifiers);
			//}
		# endif
	}
	
	// Used for Getting Product Identifier from Store.
	
	private void RequestProductIdentifier(){
		
		# if UNITY_IPHONE
	 		Debug.Log("Before Calling can make payment");
			canMakePayments = StoreKitBinding.canMakePayments();
			if(canMakePayments){
				StoreKitBinding.requestProductData(productIdentifiers);
			}	
		# endif
			
		# if UNITY_ANDROID
			//if(UserPrefs.isAmazonBuild){
				//UserPrefs.isRestoreTransaction = true;	
				//AmazonIAP.initiateItemDataRequest(productIdentifiers);
			//} else {
		GoogleIAB.init(CentralVariables.INAPP_KEY);
				//ConsumeProducts();
				queryInventory();
//				Invoke("ConsumeProducts", 2.0f);
			//}
		# endif
	}

	public void queryInventory()
	{	
		//UserPrefs.isRestoreTransaction = true;
		GoogleIAB.queryInventory(productIdentifiers);
	}
    	
	void Start(){
		this.RequestProductIdentifier();
	}
	
	# if UNITY_IPHONE
	
	    void OnEnable()
	    {
	        // Listens to all the StoreKit events.  All event listeners MUST be removed before this object is disposed!
//			StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
//			StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
//			StoreKitManager.purchaseFailedEvent += purchaseFailed;
	    }
	    
	    
	    void OnDisable()
	    {
	        // Remove all the event handlers
//	        StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
//			StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
//			StoreKitManager.purchaseFailedEvent -= purchaseFailed;
	    }
	
	   	void purchaseFailed( string error )
		{
			Debug.Log( "purchase failed with error: " + error );
			GameManager.Instance.PurchaseProductResult(error, false);
		}
	
		void purchaseCancelled( string error )
		{
			GameManager.Instance.PurchaseProductResult("Purchased Canceled", false);
			Debug.Log( "purchase cancelled with error: " + error );
		}
		
		void restoreTransactionsFailed( string error )
		{
			Debug.Log( "restoreTransactionsFailed: " + error );
		}
		
		void restoreTransactionsFinished()
		{
			Debug.Log( "restoreTransactionsFinished" );
		}
	

	    
	# endif
	
	#region others

//	#if UNITY_ANDROID
//	public WWW verifyReceiptForAndroid(string purchaseData, string signature )
//	{ 
//		
//		//string jsonString = String.Format("\"receipt-data\" : {0}, \"game_id\" : {1}",  transaction.base64EncodedTransactionReceipt,"\"5\"");
//		InApp_purchaseData = purchaseData;
//		InApp_signature = signature;
//
//
//		string hash=CalculateMD5Hash(purchaseData);
//		string encodedData=  WWW.EscapeURL(purchaseData);//System.Text.Encoding.UTF8.GetString(purchaseData);
//		string jsonString = String.Format("\"api_key\" : {0}, \"game_package\" : {1} , \"hash\" : {2} , \"signature\" : {3} , \"signed_data\" : {4}", "\"" +  "333502605316711101" +"\"", "\"" +Constants.GAME_BUNDLE_ID +"\"", "\"" +hash +"\"", "\"" +signature +"\"", "\"" +encodedData+"\"");
//		jsonString =  String.Format("{{{0}}}", jsonString);
//		Debug.Log ("verifyReceipt: "+jsonString + "end of json string");
//		//Debug.LogError ("verifyReceipt: "+jsonString1 + "end of json string");
//
//		Dictionary<String,String> postHeader = new Dictionary<String,String>();
//		postHeader.Add("Content-Type", "application/json");  
//		System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
//		WWW www = new WWW("http://52.7.151.190/inapp/api/inapp/verify/",encoding.GetBytes(jsonString),postHeader);
//		StartCoroutine(WaitForRequest(www));
//		return www; 
//
//
////		Hashtable postHeader = new Hashtable();
////		postHeader.Add("Content-Type", "application/json");  
////		System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
////		WWW www = new WWW("http://54.197.239.209/inapp/index.php/api/inapp/verify",encoding.GetBytes(jsonString),postHeader);
////		StartCoroutine(WaitForRequest(www));
////		return www; 
//	}
//	
//	public string CalculateMD5Hash(string input)
//	{
//		// step 1, calculate MD5 hash from input
//		MD5 md5 = System.Security.Cryptography.MD5.Create();
//		byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
//		byte[] hash = md5.ComputeHash(inputBytes);
//		
//		// step 2, convert byte array to hex string
//		StringBuilder sb = new StringBuilder();
//		for (int i = 0; i < hash.Length; i++)
//		{
//			sb.Append(hash[i].ToString("X2"));
//		}
//		return sb.ToString();
//	}
//	
//	private IEnumerator WaitForRequest(WWW www)
//	{
//		yield return www;
//		Debug.Log("++++++++***********++    "+www.error);
//		if (www.error == null)
//		{
//			string response = www.text; 
//			Debug.Log("+++++++++++++++++++++++++++    " + response);
////			IDictionary search = (IDictionary) MiniJSON3.jsonDecode(response);// .Deserialize(response);
//			Debug.Log("Debugging for dictionary    " + search["status_code"]);
//			//String statusCode = (String) search["status_code"];
//			
//			//if(statusCode.Equals("001"))
//			//{
////				if(!UserPrefs.isAmazonBuild && !isNonConsumedItem(packageId)){
////					GoogleIAB.consumeProduct(packageId);
//				//}
//-+				GameManager.Instance.PurchaseProductResult(packageId, true,InApp_purchaseData,InApp_signature);
//				
//				InApp_purchaseData = "";
//				InApp_signature = "";
//
//				Debug.Log("Purchase successful with Product_id: " + packageId);
//				packageId="";
//			}
//			else
//			{
//				//				if(!UserPrefs.isAmazonBuild && !isNonConsumedItem(packageId)){
//				//					GoogleIAB.consumeProduct(packageId);
//				//				}
//				//				GameManager.Instance.PurchaseProductResult(packageId, true);
//				//				packageId="";
//				
//				
//				GAManager.Instance.LogDesignEvent("User Made a fake purchase against Product_id: " + packageId + " and status code from our server is "+ statusCode);
//				Debug.Log("Fake Purchase");
//				
//				
//			}
//		}
//	}
//	
//	
//	
//	
//	#region Common InApp
	void OnEnable()
	{
//		if(UserPrefs.isAmazonBuild){
//			// Listen to all events for illustration purposes
//			AmazonIAPManager.itemDataRequestFailedEvent += itemDataRequestFailedEvent;
//			AmazonIAPManager.itemDataRequestFinishedEvent += itemDataRequestFinishedEvent;
//			AmazonIAPManager.purchaseFailedEvent += purchaseFailedEvent;
//			AmazonIAPManager.purchaseSuccessfulEvent += purchaseSuccessfulEvent;
//			AmazonIAPManager.purchaseUpdatesRequestFailedEvent += purchaseUpdatesRequestFailedEvent;
//			AmazonIAPManager.purchaseUpdatesRequestSuccessfulEvent += purchaseUpdatesRequestSuccessfulEvent;
//			AmazonIAPManager.onSdkAvailableEvent += onSdkAvailableEvent;
//			AmazonIAPManager.onGetUserIdResponseEvent += onGetUserIdResponseEvent;
//		} else {
			// Listen to all events for illustration purposes
			GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
			GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
			GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
			GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
			GoogleIABManager.purchaseSucceededEvent += purchaseSucceededEvent;
			GoogleIABManager.purchaseFailedEvent += purchaseFailedEvent;
			GoogleIABManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
			GoogleIABManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
		//}
	}
//	
//	
//	void OnDisable()
//	{
////		if(UserPrefs.isAmazonBuild){
////			// Remove all event handlers
////			AmazonIAPManager.itemDataRequestFailedEvent -= itemDataRequestFailedEvent;
////			AmazonIAPManager.itemDataRequestFinishedEvent -= itemDataRequestFinishedEvent;
////			AmazonIAPManager.purchaseFailedEvent -= purchaseFailedEvent;
////			AmazonIAPManager.purchaseSuccessfulEvent -= purchaseSuccessfulEvent;
////			AmazonIAPManager.purchaseUpdatesRequestFailedEvent -= purchaseUpdatesRequestFailedEvent;
////			AmazonIAPManager.purchaseUpdatesRequestSuccessfulEvent -= purchaseUpdatesRequestSuccessfulEvent;
////			AmazonIAPManager.onSdkAvailableEvent -= onSdkAvailableEvent;
////			AmazonIAPManager.onGetUserIdResponseEvent -= onGetUserIdResponseEvent;
////		} else {
//			// Remove all event handlers
//			GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
//			GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
//			GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
//			GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
//			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
//			GoogleIABManager.purchaseSucceededEvent -= purchaseSucceededEvent;
//			GoogleIABManager.purchaseFailedEvent -= purchaseFailedEvent;
//			GoogleIABManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
//			GoogleIABManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
//		//}
//	}
//
//
//
	void purchaseFailedEvent( string error )
	{
		Debug.Log( "purchaseFailedEvent: " + error );
		
		//GameManager.Instance.PurchaseProductResult(error, false,null,null);
	}

	void purchaseFailedEvent( string error, int response )		// In case of android. Call comere here on purchas failed
	{
		Debug.Log( " purchaseFailedEvent: " + error );
		
		//GameManager.Instance.PurchaseProductResult(error, false,null,null);
	}
	
	bool isNonConsumedItem(string packageName)
	{
		bool isNonConsumed = false;
		
//		for(int i = 0; i < managedProductIdentifiers.Length; i++){
//			if(managedProductIdentifiers[i] == packageName ){
//				isNonConsumed = true;
//				break;
//			}
//		}
		
		return isNonConsumed;
	}
	void ConsumeProducts()
	{
		for(int i = 0; i < productIdentifiers.Length; i++){
//			if(!isNonConsumedItem(productIdentifiers[i]))
//			{
				GoogleIAB.consumeProduct(productIdentifiers[i]);
//			}
		}
	}
//	
//	#endregion
//	
//	#region Google InApp
	void billingSupportedEvent()
	{
		Debug.Log( "billingSupportedEvent" );
	}
	
	
	void billingNotSupportedEvent( string error )
	{
		Debug.Log( "billingNotSupportedEvent: " + error );
	}
	
	bool justOnce;
	void queryInventorySucceededEvent( List<GooglePurchase> purchases, List<GoogleSkuInfo> skus )
	{
		Debug.Log( string.Format( "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count ) );
		Prime31.Utils.logObject( purchases );
		Prime31.Utils.logObject( skus );
		
//		if(UserPrefs.isRestoreTransaction && purchases != null){
			
			for(int i=0; i<purchases.Count; i++){					
				Debug.Log("<<>>SkuPurchases:"+purchases[i].productId);
//				if(isNonConsumedItem(purchases[i].productId)){
//					purchaseSucceededEvent(purchases[i]);
					// Aqib Set your variable here somethingtorestore= true;
					
				//	UserPrefs.isRestoreTransaction = false;
//				}						
			//}

//			if(UserPrefs.isRestoreTransaction)
//			{
//				//Debug.Log("InComming");
//				if(!justOnce){
//					GameObject.Find("NothingtoRestoreImage").GetComponent<Image>().enabled=true;
//					GameObject.Find("NothingtoRestoreText").GetComponent<Text>().enabled=true;
//					Invoke("DisbaleIt",2);
//					justOnce=true;
//				}
//				// Nothing to Restore
//			}
//			
			//UserPrefs.isRestoreTransaction = false;
			
		}
	}

	
	void queryInventoryFailedEvent( string error )
	{
		//UserPrefs.isRestoreTransaction = false;
		Debug.Log( "queryInventoryFailedEvent: " + error );
	}
	
	
	void purchaseCompleteAwaitingVerificationEvent( string purchaseData, string signature )
	{
		Debug.Log( "purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature );
	//	if(!packageId.Equals("android.test.purchased"))
			//verifyReceiptForAndroid(purchaseData,signature);
		
		//		if(!UserPrefs.isAmazonBuild && !isNonConsumedItem(purchase.productId)){
		//			GoogleIAB.consumeProduct(purchase.productId);
		//		}
		//		
		//		GameManager.Instance.PurchaseProductResult(purchase.productId, true);
		
	}
	
	
	void purchaseSucceededEvent( GooglePurchase purchase )
	{
		 Debug.Log( "purchaseSucceededEvent: " + purchase );
		//
		GameManager.Instance.PurchaseProductResult(purchase.productId, true);

		GoogleIAB.consumeProduct(purchase.productId);


			
	}
	
	void consumePurchaseSucceededEvent( GooglePurchase purchase )
	{
		Debug.Log( "consumePurchaseSucceededEvent: " + purchase );
	}
	
	
	void consumePurchaseFailedEvent( string error )
	{
		Debug.Log( "consumePurchaseFailedEvent: " + error );
	}
//	
//	#endregion
//	
////	#region Amazon InApp
////	
////	void itemDataRequestFailedEvent()
////	{
////		Debug.Log( "itemDataRequestFailedEvent" );
////	}
////	
////	
////	void itemDataRequestFinishedEvent( List<string> unavailableSkus, List<AmazonItem> availableItems )
////	{
////		Debug.Log( "itemDataRequestFinishedEvent. unavailable skus: " + unavailableSkus.Count + ", avaiable items: " + availableItems.Count );
////	}
////	
////	void purchaseSuccessfulEvent( AmazonReceipt receipt )
////	{
////		Debug.Log( "purchaseSuccessfulEvent: " + receipt );
////		
////		GameManager.Instance.PurchaseProductResult(receipt.sku, true,InApp_purchaseData,InApp_signature);
////
////		InApp_purchaseData = "";
////		InApp_signature = "";
////
////	}
////	
////	
////	void purchaseUpdatesRequestFailedEvent()
////	{
////		Debug.Log( "purchaseUpdatesRequestFailedEvent" );
////		UserPrefs.isRestoreTransaction = false;
////	}
////	
////	void purchaseUpdatesRequestSuccessfulEvent( List<string> revokedSkus, List<AmazonReceipt> receipts )
////	{
////		Debug.Log( "purchaseUpdatesRequestSuccessfulEvent. revoked skus: " + revokedSkus.Count );
////		if(UserPrefs.isRestoreTransaction && receipts != null){			
////			
////			foreach( AmazonReceipt receipt in receipts ){
////				Debug.Log("<<>>SkuPurchases:"+receipt.sku);
////				if(isNonConsumedItem(receipt.sku)){
////					purchaseSuccessfulEvent( receipt );
////					UserPrefs.isRestoreTransaction = false;
////				} 
////			}
////			
////			UserPrefs.isRestoreTransaction = false;
////		}
////	}
////	
////	
////	void onSdkAvailableEvent( bool isTestMode )
////	{
////		Debug.Log( "onSdkAvailableEvent. isTestMode: " + isTestMode );
////	}
////	
////	
////	void onGetUserIdResponseEvent( string userId )
////	{
////		Debug.Log( "onGetUserIdResponseEvent: " + userId );
////	}
////	#endregion
//	
//	#endif

	#endregion
}
