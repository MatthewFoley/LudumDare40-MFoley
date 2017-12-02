using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBar : MonoBehaviour {

	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	private Rigidbody truckRigidBody;

	public float AntiRoll = 5000.0f;

	void Start ()
	{
		truckRigidBody = GetComponent <Rigidbody>();
	}

	void FixedUpdate ()
	{
		WheelHit hit = new WheelHit();
		float travelL = 1.0f;
		float travelR = 1.0f;

		bool leftgrounded = leftWheel.GetGroundHit(out hit);

		if (leftgrounded)
		{
			travelL = (-leftWheel.transform.InverseTransformPoint(hit.point).y 
				- leftWheel.radius) / leftWheel.suspensionDistance;
		}

		bool rightgrounded = rightWheel.GetGroundHit(out hit);

		if (rightgrounded)
		{
			travelR = (-rightWheel.transform.InverseTransformPoint(hit.point).y 
				- rightWheel.radius) / rightWheel.suspensionDistance;
		}

		var antiRollForce = (travelL - travelR) * AntiRoll;

		if (leftgrounded)
			truckRigidBody.AddForceAtPosition(leftWheel.transform.up * -antiRollForce,
				leftWheel.transform.position); 
		if (rightgrounded)
			truckRigidBody.AddForceAtPosition(rightWheel.transform.up * antiRollForce,
				rightWheel.transform.position); 
	}
}
