using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour {

	public float movementSpeed;

	void Start () {
		GetComponent<MeshFilter> ().mesh = GetComponent<MeshFilter> ().mesh;
	}

	void Update () {
		if (transform.localPosition != Vector3.zero) {
			transform.position -= new Vector3 (0f, movementSpeed, 0f);
		} 
	}

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<ItemBehaviour> () == null) {
			transform.localPosition = Vector3.zero;
		}
	}
}
