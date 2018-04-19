using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public int Score;

	private GameManager gm;

	private bool isLeft = true;
	private bool isSquare = true;
	private bool isWhite = true;

	void Start () {
		gm = GameManager.Instance;
		GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
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
			if (isSquare) {
				GetComponent<MeshFilter> ().mesh = gm.White_Sphere.GetComponent<MeshFilter> ().mesh;
				isSquare = false;
			}
			else {
				GetComponent<MeshFilter> ().mesh = gm.White_Cube.GetComponent<MeshFilter> ().mesh;
				isSquare = true;
			}
		}
	}

	private void SwitchColor () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isWhite) {
				GetComponent<MeshRenderer> ().material.color = gm.Black_Sphere.GetComponent<MeshRenderer> ().material.color;
				isWhite = false;
			}
			else {
				GetComponent<MeshRenderer> ().material.color = gm.White_Sphere.GetComponent<MeshRenderer> ().material.color;
				isWhite = true;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<MeshRenderer> ().material.color == GetComponent<MeshRenderer> ().material.color) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}

		if (other.GetComponent<MeshFilter> ().sharedMesh.name == GetComponent<MeshFilter> ().sharedMesh.name) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}

		if (other.GetComponent<MeshRenderer> ().material.color != GetComponent<MeshRenderer> ().material.color && other.GetComponent<MeshFilter> ().sharedMesh.name != GetComponent<MeshFilter> ().sharedMesh.name) {
			Score += 1;
			gm.UIm.ScoreText.text = "Score: " + Score;
		}
	}
}
