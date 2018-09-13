using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dwipantara {

public class InventoryControl : MonoBehaviour {
	
	private Animator anim;
	public GameObject [] collect;
	public GameObject clue;
	public Button[] InventoryButtons = new Button[9];
	private int Awal = 0;
	// Use this for initialization
	void Start () {
			anim = gameObject.GetComponent<Animator>();

	}

	void Update (){
		Awal = PlayerPrefs.GetInt("Awal");
		if (Awal==1) {
		clue.gameObject.SetActive(true);
		}
		
		if(PlayerPrefs.HasKey("BusurPanah")) {
			InventoryButtons [0].image.overrideSprite = collect[0].GetComponent<SpriteRenderer> ().sprite;
		}

		if (PlayerPrefs.HasKey("ParangSalawaku")) {
			InventoryButtons [1].image.overrideSprite = collect[1].GetComponent<SpriteRenderer> ().sprite;
		}

		if (PlayerPrefs.HasKey("KerisPasatimpo")) {
			InventoryButtons [2].image.overrideSprite = collect[2].GetComponent<SpriteRenderer> ().sprite;
		}

		if (PlayerPrefs.HasKey("PerisaiTalawang")) {
			InventoryButtons [3].image.overrideSprite = collect[3].GetComponent<SpriteRenderer> ().sprite;
		}
	}

		public void closeInventory() {
			anim.SetBool ("Tas",true);
		}

		public void openInventory() {
			anim.SetBool ("Tas",false);
			clue.gameObject.SetActive (false);
			PlayerPrefs.SetInt("Awal", 2);
		}
	
	}
}