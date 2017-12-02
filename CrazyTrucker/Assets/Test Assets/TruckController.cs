using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour {

	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public Transform[] wheelMeshes = new Transform[4];

	public Transform resetPosition;
	public Rigidbody truckMass;

	public float maxTorque = 50f;
	public float steering = 2f;
	public float currentForward;



	void Update()
	{
		UpdateWheels ();
		currentForward = transform.eulerAngles.y;;
		if (Input.GetButtonDown ("Jump")) 
		{

			transform.position += new Vector3 (0, 2, 0);
			transform.eulerAngles = new Vector3 (0, currentForward, 0);


			for (int i = 0; i < 4; i++) 
			{
				wheelColliders [i].motorTorque = 0;
			}
		}
	}

	void FixedUpdate()
	{
		float steer = Input.GetAxis ("Horizontal");
		float accelerate = Input.GetAxis ("Vertical");

		float finalSteer = steer * 45f;

		wheelColliders [0].steerAngle = finalSteer;
		wheelColliders [1].steerAngle = finalSteer;

		for (int i = 2; i < 4; i++) 
		{
			wheelColliders [i].motorTorque = accelerate * maxTorque;
		}
	}

	void UpdateWheels()
	{
		for (int i = 0; i < 4; i++) 
		{
			Quaternion quat;
			Vector3 position;
			wheelColliders[i].GetWorldPose (out position, out quat);

			//wheelMeshes [i].position = position;
			wheelMeshes [i].rotation = quat;
			wheelMeshes [i].Rotate (Vector3.forward * (-90));
			wheelMeshes [i].Rotate (Vector3.right * (180));
		}
	}
}
