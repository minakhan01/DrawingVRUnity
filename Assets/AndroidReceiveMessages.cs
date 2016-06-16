using UnityEngine;
using System.Collections;

public class AndroidReceiveMessages : MonoBehaviour {

	private AndroidJavaObject toastExample = null;
	private AndroidJavaObject activityContext = null;
	GameObject pivotSpell;
	GameObject pivotSpellCursor;

	// Use this for initialization
	void Start () {
		AndroidJNI.AttachCurrentThread();
		AndroidJNIHelper.debug = true; 
		if(toastExample == null) {
			using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
			}

			using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.choosemuse.example.libmuse.MainActivity")) {
				if(pluginClass != null) {
//					toastExample = pluginClass.CallStatic<AndroidJavaObject>("instance");
					toastExample = pluginClass.CallStatic<AndroidJavaObject>("getInstance", activityContext);
//					activityContext.Call("print", "this");
				}
			}
		}
		pivotSpell = GameObject.Find("PivotSpell");
		pivotSpellCursor = pivotSpell.transform.Find("Cursor").gameObject;
	}

	// Update is called once per frame
	void Update () {
//		int RValue = 0;
//				using (AndroidJavaClass javaClass = new AndroidJavaClass("com.choosemuse.example.libmuse.MainActivity")) {
//			using (AndroidJavaObject activity = javaClass.GetStatic<AndroidJavaObject>("mContext"))
//			{
//			Debug.Log("hello");
//				Debug.Log("rate :"+activity.CallStatic<float>("getRate"));
//			}
//		}
//
//		//		Debug.Log("rate" + RValue.ToString() );
	}

	void receiveAlpha(string message) {
		Debug.Log("message from java: " + message);
		float result;
		float.TryParse(message, out result);
		Debug.Log("change amplitude: " + result);
		pivotSpellCursor.GetComponent<CursorOscillation>().amplitudeOffset = result/4f;
	}

	void receiveEeg(string message) {
//		Debug.Log("message from java: " + message);
	}

	void receiveAccel(string message) {
//		Debug.Log("message from java: " + message);
	}

	void receiveStatus(string message) {
		Debug.Log("message from java: " + message);
	}
}