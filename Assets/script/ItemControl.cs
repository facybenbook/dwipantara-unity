using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwipantara {

public class ItemControl : MonoBehaviour {

	public GameObject[] item;
	public GameObject notif1,notif2,notif3;
	// Use this for initialization
	void Update () {
			if(PlayerPrefs.HasKey("BusurPanah")) {
				item [0].gameObject.SetActive (false);
			}
			if(PlayerPrefs.HasKey("ParangSalawaku")) {
				item [1].gameObject.SetActive (false);
			}
			if(PlayerPrefs.HasKey("KerisPasatimpo")) {
				item [2].gameObject.SetActive (false);
			}
			if(PlayerPrefs.HasKey("PerisaiTalawang")) {
				item [3].gameObject.SetActive (false);
			}
	}

	public void ClosePanel1 (){
			notif1.gameObject.SetActive (false);
			Time.timeScale = 1;
	}

	public void ClosePanel2 (){
			notif2.gameObject.SetActive (false);
			Time.timeScale = 1;
	} 

	public void ClosePanel3 (){
			notif3.gameObject.SetActive (false);
			Time.timeScale = 1;
	} 
}
}