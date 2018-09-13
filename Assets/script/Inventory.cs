using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dwipantara {

public class Inventory : MonoBehaviour {

	public GameObject[] inventory = new GameObject[8];
	public Button[] InventoryButtons = new Button[8];
	// Use this for initialization

	public void AddItem(GameObject item)
	{
		bool itemAdded = false;

			if(item.name.Contains("BusurPanah")) {
				Debug.Log (item.name + " was added");
				itemAdded = true;
				string BusurPanah = "BusurPanah";
				PlayerPrefs.SetInt("Awal", 1);
				PlayerPrefs.SetString("BusurPanah", BusurPanah);
				item.SendMessage ("DoInteraction");
			} 

			if(item.name.Contains("ParangSalawaku")) {
				Debug.Log (item.name + " was added");
				itemAdded = true;
				string ParangSalawaku = "ParangSalawaku";
				PlayerPrefs.SetString("ParangSalawaku", ParangSalawaku);
				item.SendMessage ("DoInteraction");
			} 

			if(item.name.Contains("KerisPasatimpo")) {
				Debug.Log (item.name + " was added");
				itemAdded = true;
				string KerisPasatimpo = "KerisPasatimpo";
				PlayerPrefs.SetString("KerisPasatimpo", KerisPasatimpo);
				item.SendMessage ("DoInteraction");
			}

			if(item.name.Contains("PerisaiTalawang")) {
				Debug.Log (item.name + " was added");
				itemAdded = true;
				string PerisaiTalawang = "PerisaiTalawang";
				PlayerPrefs.SetString("PerisaiTalawang", PerisaiTalawang);
				item.SendMessage ("DoInteraction");
			}

		if(!itemAdded) {
			Debug.Log ("Inventory Full!");
		}
	}

	
	}
}
