using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dwipantara {

public class CollectionPanel : MonoBehaviour {

	public GameObject collectSign, data;

	public string whichDataGet = "vdata1";

	void Start () {
		
	}

	public void Collect()
	{
		collectSign.gameObject.SetActive (true);

		int DataGet = PlayerPrefs.GetInt (whichDataGet);

		if (DataGet == 1){

		} else {
			Invoke ("GetTrophy", 1f);
		}
	}

	void GetTrohphy() 
	{
		collectSign.SetActive (false);

		data.SetActive (true);

		PlayerPrefs.SetInt (whichDataGet, 1);
	}
}
}