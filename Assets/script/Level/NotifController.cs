using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwipantara {

	public class NotifController : MonoBehaviour {

	public GameObject notif;	

	void OpenPanel ()
	{
		notif.gameObject.SetActive (true);
		Time.timeScale = 0;
	}

	private void OnTriggerEnter2D(Collider2D col) {
			OpenPanel ();
	}	
}
}
