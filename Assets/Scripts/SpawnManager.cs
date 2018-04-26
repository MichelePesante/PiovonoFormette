using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	private GameManager gm;

	private float globalTimer = 0f;
	private float timerCheck = 30f;
	private float timer = 0f;

	public static SpawnManager Instance;

	public GameObject Spawn_Point_1;
	public GameObject Spawn_Point_2;
	public List <GameObject> Items;

	void Awake () {
		if (Instance == null)
			Instance = this;
		else {
			Destroy (gameObject);
		}
	}

	void Start () {
		gm = GameManager.Instance;
	}

	void Update () {
		timer += Time.deltaTime;
		globalTimer += Time.deltaTime;

		if (timer >= 2f) {
			timer = 0f;
			SpawnRandomItem ();
		}

		if (globalTimer >= timerCheck) {
			timerCheck += 30f;
			foreach (GameObject item in Items) {
				item.GetComponent<ItemBehaviour>().MovementSpeed += 0.05f;
			}
		}
	}

	private void SpawnRandomItem () {
		int randomNumber = Random.Range (0, 12);
		if (Items [randomNumber].transform.localPosition == Vector3.zero) {
			int newRandomNumber = Random.Range (1, 3);
			if (newRandomNumber == 1)
				Items [randomNumber].transform.position = Spawn_Point_1.transform.position;
			if (newRandomNumber == 2)
				Items [randomNumber].transform.position = Spawn_Point_2.transform.position;
		} 
		else {
			timer = 2f;
		}
	}
}
