using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject Player;

	public Vector3 offset;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Player != null)
		{
			Vector3 camPos = transform.position;
			Vector3 desiredPos = Player.transform.position;

			Vector3 smoothedPos = Vector3.Lerp(camPos, desiredPos, 0.125f);

			transform.position = new Vector3(smoothedPos.x, transform.position.y, transform.position.z);
		}
	}
}
