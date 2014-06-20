using UnityEngine;
using System.Collections;

public class CameraFollow_ : MonoBehaviour
{

		public Transform _target;
		private Vector3 lastPos;
		// Use this for initialization
		void Start ()
		{
		transform.position = new Vector3(_target.position.x, _target.position.y, -30f);
				lastPos = _target.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				Vector3 newPos = _target.position;
	
				if (newPos != lastPos) {
						Vector3 diff = newPos - lastPos;
						transform.position += diff;
						lastPos = newPos;
				}
		}
}
