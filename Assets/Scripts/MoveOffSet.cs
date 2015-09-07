using UnityEngine;
using System.Collections;

public class MoveOffSet : MonoBehaviour {

	private Material currentMaterial;

	public float speed;
	private float offSet;

	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		offSet += 0.001f;

		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet * speed, 0));
	}
}
