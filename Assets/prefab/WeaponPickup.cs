using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	public GameObject weaponHere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().sprite = weaponHere.GetComponent<SpriteRenderer> ().sprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GetComponent<SpriteRenderer>().sprite=null;
				}

	}
}
