using UnityEngine;
using System.Collections;

public class DeathScreen : MonoBehaviour {
	public float duration = 1.0f;

	// Use this for initialization
	IEnumerator Start () {
		Rect newSize = new Rect(0, 0, Screen.width, Screen.height); //Pixel Inset - Rect (x, y, width, height)
		GetComponent<GUITexture> ().pixelInset = newSize;
		GetComponent<GUITexture> ().color = new Color(0,0,0,0.0f);

		yield return StartCoroutine(Fade(0.0f, 1.0f, duration));

		yield return StartCoroutine(Fade(1.0f, 0.0f, duration));
	}

	// Update is called once per frame
	void Update(){
		Destroy (gameObject, duration*2);
	}

	IEnumerator Fade (float start, float end, float duration) { //define Fade parmeters
		float startTime=Time.time; // Time.time contains current frame time, so remember starting point
		float elapsed;
		do
		{  // calculate how far through we are
			elapsed = Time.time - startTime;
			float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
			GetComponent<GUITexture> ().color = new Color(0,0,0,Mathf.Lerp(start, end, normalisedTime)); //lerp the value of the transparency from the start value to the end value in equal increments
			// wait for the next frame
			yield return null;
			GetComponent<GUITexture> ().color = new Color(0,0,0,end); // ensure the fade is completely finished (because lerp doesn't always end on an exact value)
		}
		while(elapsed < duration); // until duration


//		elapsed = 0;
//		while(elapsed<duration){ // until duration second passed
//			elapsed = Time.time - startTime;
//			float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
//			GetComponent<GUITexture> ().color = new Color(0,0,0,Mathf.Lerp(start, end, normalisedTime)); //lerp the value of the transparency from the start value to the end value in equal increments
//		 	// wait for the next frame
//			yield return null;
//			GetComponent<GUITexture> ().color = new Color(0,0,0,end); // ensure the fade is completely finished (because lerp doesn't always end on an exact value)
//		}
		
	} //end Fade
}
