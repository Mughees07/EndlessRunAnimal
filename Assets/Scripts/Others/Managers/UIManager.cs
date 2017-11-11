using UnityEngine;
using System.Collections;

#if UNITY_5_3_1
using UnityEngine.SceneManagement;
#endif
public class UIManager : SingeltonBase<UIManager> {

	/// <summary>
	/// Raises the game play event.
	/// </summary>
	public void OnGamePlay(){
		#if UNITY_5_3_1
		SceneManager.LoadScene (0);
		#endif
		#if UNITY_5_1_2		 
		Application.LoadLevel(0);
		#endif
	}


}
