using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public SpawnManager sm;
	public UIManager UIm;

	public GameObject White_Cube;
	public GameObject Black_Cube;
	public GameObject White_Sphere;
	public GameObject Black_Sphere;

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
