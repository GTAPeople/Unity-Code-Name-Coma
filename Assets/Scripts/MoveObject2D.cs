using UnityEditor;
using UnityEngine;
using System.Collections;

public class MoveObject2D : MonoBehaviour {

	[SerializeField]
	public GameObject[] _next;
	public float speed = 3.0f;
	public float timeDelay = 0.2f;

	private Vector3 posOrigin;

	// Use this for initialization
	IEnumerator Start () {
		posOrigin = transform.position;
		Vector3 lastPos= posOrigin;
		if (_next != null && _next.Length > 0){
			while(true){
				for(int i=0; i < _next.Length; i++){
					yield return StartCoroutine(movePos(transform, (i==0)? posOrigin:_next[i-1].transform.position , _next[i].transform.position, speed));
					lastPos = _next[i].transform.position;
				}
				if(posOrigin!=lastPos){
					for(int i=_next.Length-1; i >= 0; i--){
						yield return StartCoroutine(movePos(transform, _next[i].transform.position, (i==0)? posOrigin:_next[i-1].transform.position, speed));
					}
				}
			}

		}else{
			Debug.Log("Please, add EmptyGameObject to Element inside the Size.");
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
		yield return new WaitForSeconds (timeDelay);
	}
}
