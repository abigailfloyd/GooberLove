using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start()
	{
		targetPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			//transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

			//Turn this on for slight spring cam
			//transform.position = targetPos;

			//Turn this on for no spring cam
			transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);

		}
	}
}
