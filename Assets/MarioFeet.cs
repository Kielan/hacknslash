using UnityEngine;
using System.Collections;



public class MarioFeet : MonoBehaviour {
	public GameObject npc;
	private npcBehavior npcBehaviorScript;

	void Awake () {
		npcBehaviorScript = GetComponent<npcBehavior>();
	}

	public void OnControllerColliderHit(ControllerColliderHit hit) {
		var hitVec = hit.point - transform.position;
		
		if (hitVec.y < 0) {
			Debug.Log("Boop");
			hit.npcBehaviorScript.MarioStomp();
		}
	}
}
