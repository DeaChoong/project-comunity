using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	//Debug.Log ("Hello World!!");
	float y = 0.0f;
	float x = 0.0f;
	float JumpPower;
	bool GravityJudgement = false;
	bool JumpJudgement = false;
	float Accel;

	void Start () {
		StartCoroutine ("UpdateCharacter");
	}

	IEnumerator UpdateCharacter() {
		while (true) {
			Vector3 pos = gameObject.transform.position;
			Debug.Log (y + ", " + pos.y);
			y -= 0.028f;
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

			if (Input.GetKeyDown (KeyCode.Space)) {
				JumpJudgement = true;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
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
					JumpPower -= Accel;
					pos.y += JumpPower;
					y = 0;
					GravityJudgement = false;
				}
			}

			if (!GravityJudgement) {
				pos.y += y;
			} else {
				JumpJudgement = false;
				pos.y = -2.5f;
			}
			gameObject.transform.position = pos;
			yield return null;
		}
	}

	void Jump() {

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
