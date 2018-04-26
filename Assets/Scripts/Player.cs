using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public int Score;

	private GameManager gm;

	private bool isLeft = true;
	private int Player_Shape;
	private int Player_Color;

	void Start () {
		gm = GameManager.Instance;
		GetComponentInChildren<MeshFilter>().mesh = gm.Object_1.GetComponentInChildren<MeshFilter>().mesh;
	}

	void Update () {
		SwitchPosition ();
		SwitchShape ();
		SwitchColor ();
	}

	private void SwitchPosition () {
		if (Input.GetKeyDown(KeyCode.L)) {
			if (isLeft) {
				transform.position = new Vector3 (gm.sm.Spawn_Point_2.transform.position.x, transform.position.y, transform.position.z);
				isLeft = false;
			} 
			else {
				transform.position = new Vector3 (gm.sm.Spawn_Point_1.transform.position.x, transform.position.y, transform.position.z);
				isLeft = true;
			}
		}
	}

	private void SwitchShape () {
		if (Input.GetKeyDown (KeyCode.A)) {
			if (Player_Shape == 0) {
				GetComponentInChildren<MeshFilter> ().mesh = gm.Object_3.GetComponentInChildren<MeshFilter> ().mesh;
				Player_Shape = 1;
			}
			else if (Player_Shape == 1) {
				GetComponentInChildren<MeshFilter> ().mesh = gm.Object_1.GetComponentInChildren<MeshFilter> ().mesh;
				Player_Shape = 0;
			}
		}
	}

	private void SwitchColor () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Player_Color == 0) {
				GetComponentInChildren<MeshRenderer> ().material.color = gm.Object_4.GetComponentInChildren<MeshRenderer> ().material.color;
				Player_Color = 1;
			}
			else if (Player_Color == 1){
				GetComponentInChildren<MeshRenderer> ().material.color = gm.Object_3.GetComponentInChildren<MeshRenderer> ().material.color;
				Player_Color = 0;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<ItemBehaviour>().Shape == Player_Shape) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}

		if (other.GetComponent<ItemBehaviour>().Color == Player_Color) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}

		if (other.GetComponent<ItemBehaviour>().Shape != Player_Shape && other.GetComponent<ItemBehaviour>().Color != Player_Color) {
			Score += 1;
			gm.UIm.ScoreText.text = "Score: " + Score;
		}
	}
}
