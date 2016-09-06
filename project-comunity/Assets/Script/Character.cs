using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	//Debug.Log ("Hello World!!");
	float y = 0.0f;
	float x = 0.0f;
	float JumpPower;
	float Accel;
	bool GravityJudgement = false;
	bool JumpJudgement = false;
	bool Judgement = false;

	void Start () {
		StartCoroutine ("UpdateCharacter");
	}

	IEnumerator UpdateCharacter() {
		while (true) {
			Vector3 pos = gameObject.transform.position;
			Move (ref pos);
			Jump (ref pos);
			yield return null;
		}
	}

	void Move(ref Vector3 pos) {
		if (Input.GetKey (KeyCode.RightArrow)) {
			pos.x -= x;
			if (x <= -0.4f) {
				x = -0.42f;
			}
			x -= 0.06f;
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			x = 0.0f;
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			pos.x += x;
			if (x <= -0.4f) {
				x = -0.42f;
			}
			x -= 0.06f;
		}
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			x = 0.0f;
		}
	}

	void Jump(ref Vector3 pos) {
		y -= 0.028f;
		Debug.Log (Judgement);
		if (Input.GetKey (KeyCode.Space)) {
			JumpJudgement = true;
		}

		if (!JumpJudgement) {
			JumpPower = 0.9f;
			Accel = 0.1f;
		} else {
			if (JumpPower <= 0.0f) {
				Accel = 0.0f;
				JumpPower = 0.0f;
			} else {
				if (Input.GetKey (KeyCode.Space) && JumpPower <= 0.2f) {
					JumpJudgement = false;
				}
				JumpPower -= Accel;
				pos.y += JumpPower;
				y = 0;
				GravityJudgement = false;
			}
		}
		
		if (!GravityJudgement) {
			if (Input.GetKey (KeyCode.Space) && JumpPower <= 0.2f) {
				JumpJudgement = false;
			}
			pos.y += y;
		} else {
			JumpJudgement = false;
			Judgement = false;
			pos.y = -2.5f;
		}
		gameObject.transform.position = pos;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Ground") {
			GravityJudgement = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Ground") {
			y = 0;
			GravityJudgement = false;
		}
	}
}
