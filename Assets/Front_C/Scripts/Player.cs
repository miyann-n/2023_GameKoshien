using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	[SerializeField, Range(0, 10)]
	float time = 1;

	[SerializeField]
	Vector3	endPosition;

	//[SerializeField]
	//AnimationCurve curve;

	private float firstStartTime;
	private Vector3 startPosition;

	void OnEnable ()
	{
		if (time <= 0) {
			transform.position = endPosition;
			enabled = false;
			return;
		}

		firstStartTime = Time.timeSinceLevelLoad;
		startPosition = transform.position;
	}
	
	void Update ()
	{
		var diff = Time.timeSinceLevelLoad - firstStartTime;
		if (diff > time) {
			transform.position = endPosition;
			enabled = false;
		}

		var rate = diff / time;
		//var pos = curve.Evaluate(rate);
		
		transform.position = Vector3.Lerp (startPosition, endPosition, rate);
		//transform.position = Vector3.Lerp (startPosition, endPosition, pos);
		
		Debug.Log("A");
	}
	
	void OnDrawGizmosSelected ()
	{
#if UNITY_EDITOR

		if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
			startPosition = transform.position;
		}

		UnityEditor.Handles.Label(endPosition, endPosition.ToString());
		UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
		Gizmos.DrawSphere (endPosition, 0.1f);
		Gizmos.DrawSphere (startPosition, 0.1f);

		Gizmos.DrawLine (startPosition, endPosition);
	}
}
