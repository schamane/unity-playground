using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			Debug.Log("Player triger game exit");
			Application.Quit();
		}
	}
}
