using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private GameObject player;

	public float smoothing = 5f;        // The speed with which the camera will be following.

    Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		offset = transform.position - player.transform.position;
        transform.LookAt(player.transform);
	}
	
	/*/
	void LateUpdate () {
		 transform.position = player.transform.position + offset;
	}
	*/

	void FixedUpdate ()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 playerCamPos = player.transform.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp (transform.position, playerCamPos, smoothing * Time.deltaTime);
    }
}
