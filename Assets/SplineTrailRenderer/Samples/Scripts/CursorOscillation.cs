using UnityEngine;
using System.Collections;

public class CursorOscillation : MonoBehaviour 
{
	public Vector3 axis = Vector3.one;
	public float speed = 1f;
	public float amplitude = 1f;
	public float offset = 1f;
	public float amplitudeOffset = 0;

	Vector3 initialLocalPos;

	void Awake()
	{
		initialLocalPos = transform.localPosition;
		Oscillate();
	}

	void Start()
	{
		Oscillate();
	}
	
	void Update () 
	{
		Oscillate();
	}

	void Oscillate()
	{
		amplitude = amplitude + 0.001f*Mathf.Sin(amplitudeOffset);
		transform.localPosition = initialLocalPos + axis * offset +
			(axis * Mathf.Sin(Time.time * amplitude));
			
			//new Vector3(transform.localPosition.x, 
			//offset + Mathf.Sin(Time.time * speed) * amplitude, transform.localPosition.z);
	}
}
