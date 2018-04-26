using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public SpawnManager sm;
	public UIManager UIm;

	public GameObject Object_1;
	public GameObject Object_2;
	public GameObject Object_3;
	public GameObject Object_4;

	void Awake () {
		if (Instance == null)
			Instance = this;
		else {
			Destroy (gameObject);
		}
	}

	void Start () {
		sm = SpawnManager.Instance;
		UIm = UIManager.Instance;
	}

	void Update () {
		
	}
}
