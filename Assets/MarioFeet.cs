using UnityEngine;
using System.Collections;



public class MarioFeet : MonoBehaviour {
	public GameObject npc;
	private npcBehavior npcBehaviorScript;
	
	public void OnControllerColliderHit(ControllerColliderHit hit) {
		var hitVec = hit.point - transform.position;
		
		if (hitVec.y < 0) {
			Debug.Log("Boop");
			npcBehaviourScript = hit.GetComponent<npcBehaviour>();
			npcBehaviourScript.MarioStomp();
		}
	}
}
