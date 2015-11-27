using UnityEngine;
using System.Collections;

public class DoneCameraMovement : MonoBehaviour
{
	public float smooth = 1.5f;			// The relative speed at which the camera will catch up.
	
	
	public Transform player;			// Reference to the player's transform.
	public Vector3 relCameraPos;		// The relative position of the camera from the player.
	public float relCameraPosMag;		// The distance of the camera from the player.
	public Vector3 newPos;				// The position the camera is trying to reach.

	private float c1lerp = 0.25f;
	private float c2lerp = 0.5f;
	private float c3lerp = 0.75f;

	
	void FixedUpdate ()
	{
		if(!player) return;
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if(axis > 0 && relCameraPos.y < 10){
			relCameraPos.y+=0.1f;
		}
		else if(axis < 0 && relCameraPos.y > 1) {
			relCameraPos.y -= 0.1f;
		}
		// The standard position of the camera is the relative position of the camera from the player.
		Vector3 standardPos = player.position + relCameraPos;
		
		// The abovePos is directly above the player at the same distance as the standard position.
		Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;
		
		// An array of 5 points to check if the camera can see the player.
		Vector3[] checkPoints = new Vector3[5];
		
		// The first is the standard position of the camera.
		checkPoints[0] = standardPos;
		
		// The next three are 25%, 50% and 75% of the distance between the standard position and abovePos.
		checkPoints[1] = Vector3.Lerp(standardPos, abovePos, c1lerp);
		checkPoints[2] = Vector3.Lerp(standardPos, abovePos, c2lerp);
		checkPoints[3] = Vector3.Lerp(standardPos, abovePos, c3lerp);
		
		// The last is the abovePos.
		checkPoints[4] = abovePos;
		
//		 Run through the check points...
		for(int i = 0; i < checkPoints.Length; i++)
		{
			// ... if the camera can see the player...
			if(ViewingPosCheck(checkPoints[i]))
				// ... break from the loop.
				break;
		}
		
		// Lerp the camera's position between it's current position and it's new position.
		transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
		
		// Make sure the camera is looking at the player.
		SmoothLookAt();
	}
	
	
	bool ViewingPosCheck (Vector3 checkPos)
	{
		RaycastHit hit;
		
		// If a raycast from the check position to the player hits something...
		if(Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag))
			// ... if it is not the player...
			if(hit.transform != player)
				// This position isn't appropriate.
				return false;
		
		// If we haven't hit anything or we've hit the player, this is an appropriate position.
		newPos = checkPos;
		return true;
	}
	
	
	void SmoothLookAt ()
	{
		// Create a vector from the camera towards the player.
		Vector3 relPlayerPosition = player.position - transform.position;
		
		// Create a rotation based on the relative position of the player being the forward vector.
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
		
		// Lerp the camera's rotation between it's current rotation and the rotation that looks at the player.
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}
}
