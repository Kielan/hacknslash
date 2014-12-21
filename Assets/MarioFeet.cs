using UnityEngine;
using System.Collections;

public class MarioFeet : MonoBehaviour {
	
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		var hitVec = hit.point - transform.position;
		
		if (hitVec.y < 0) {
			Debug.Log("Boop");
			hit.gameObject.SendMessage("MarioStomp");
		}
	}
}