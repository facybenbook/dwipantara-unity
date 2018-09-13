using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

	// Use this for initialization
	public int level;

	void Start () {
		PlayerPrefs.SetInt("level",level);	
	}
}
