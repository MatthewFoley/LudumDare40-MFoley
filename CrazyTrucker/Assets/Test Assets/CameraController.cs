using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float distance = 6.4f;
	public float height = 1.4f;
	public float rotationDamping = 3.0f;
	public float heightDamping = 2.0f;
	public float zoomRatio = 0.5f;
	private Vector3 rotationVector;

	void LateUpdate(){
		if(target != null){
			float wantedAngle = rotationVector.y;
			float wantedHeight = target.position.y + height;
			float myAngle = transform.eulerAngles.y;
			float myHeight = transform.position.y;
			myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping*Time.deltaTime);
			myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping*Time.deltaTime);
			Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
			transform.position = target.position;
			transform.position -= currentRotation*Vector3.forward*distance;
			Vector3 temp = transform.position;
			temp.y = myHeight;
			transform.position = temp;
			transform.LookAt(target);
		}
	}

	void FixedUpdate()
	{
		if(target != null){
			Vector3 localVelocity = target.InverseTransformDirection(target.GetComponent<Rigidbody>().velocity);
			if (localVelocity.z < -1f)
			{
				Vector3 temp = rotationVector;
				temp.y = target.eulerAngles.y + 180;
				rotationVector = temp;
			}
			else
			{
				Vector3 temp = rotationVector;
				temp.y = target.eulerAngles.y;
				rotationVector = temp;
			}
			float acc = target.GetComponent<Rigidbody>().velocity.magnitude;
			GetComponent<Camera>().fieldOfView = 70f + acc * zoomRatio * Time.deltaTime;
		}
	}
}
