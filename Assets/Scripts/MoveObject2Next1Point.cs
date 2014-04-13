using UnityEngine;
using System.Collections;

public class MoveObject2Next1Point : MonoBehaviour {

	public GameObject secondPosition;
	public float speed = 3.0f;
	public float timePoint = 0.2f;

	private Vector3 posOrigin;

	IEnumerator Start(){
		posOrigin = transform.position;
		while(true){
			yield return StartCoroutine(movePos(transform, posOrigin, secondPosition.transform.position, speed));
			yield return StartCoroutine(movePos(transform, secondPosition.transform.position, posOrigin, speed));
		}
	}

	IEnumerator movePos(Transform thisTrans, Vector3 startPos, Vector3 endPos, float time){
		float i= 0.0f;
		float rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTrans.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
		yield return new WaitForSeconds (timePoint);
	}
}
