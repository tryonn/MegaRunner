using UnityEngine;
using System.Collections;

public class SpawnBarreira : MonoBehaviour {

	public GameObject prefab;
	public Transform[] posicoes;
	public float rate;
	public float tempTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		tempTime += Time.deltaTime;

		if (tempTime >= rate){
			tempTime = 0;


			GameObject tempPrefab = Instantiate(prefab) as GameObject;


			int rand = Random.Range(0, 100);



			if (rand < 50){
				tempPrefab.transform.position = posicoes[0].position;
			} else {
				tempPrefab.transform.position = posicoes[1].position;
			}
		}
	
	}
}
