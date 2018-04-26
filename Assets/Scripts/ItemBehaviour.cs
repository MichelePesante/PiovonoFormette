using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour {

	public int Shape;
	public int Color;
	public float MovementSpeed;

	void Start () {
		GetComponentInChildren<MeshFilter> ().mesh = GetComponentInChildren<MeshFilter> ().mesh;
	}

	void Update () {
		if (transform.localPosition != Vector3.zero) {
			transform.position -= new Vector3 (0f, MovementSpeed, 0f);
		} 
	}

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<ItemBehaviour> () == null) {
			transform.localPosition = Vector3.zero;
		}
	}
}
