using UnityEngine;
using System.Collections;

public class HidePlayer : MonoBehaviour
{

	[SerializeField, Range(0, 10)]
	float time = 1;

	[SerializeField]
	Vector3	endPosition;

	//[SerializeField]
	//AnimationCurve curve;

	private float startTime;
	private Vector3 startPosition;

	void Start ()
	{

		if (time <= 0) {
			transform.position = endPosition;
			enabled = false;
			return;
		}

		startTime = 3.0f;
		startPosition = new Vector3(-5, -3, 0);
	}
	
	void Update ()
	{
    StartCoroutine(Wait());

		var diff = Time.timeSinceLevelLoad - startTime;
		if (diff > time) {
			transform.position = endPosition;
			enabled = false;
		}

		var rate = diff / time;
		//var pos = curve.Evaluate(rate);
		
		transform.position = Vector3.Lerp (startPosition, endPosition, rate);
		//transform.position = Vector3.Lerp (startPosition, endPosition, pos);
		
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
    private IEnumerator Wait(){


yield return new WaitForSeconds(3.0f);
    }

}
