using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwipantara {

public class CharacterHolder : MonoBehaviour {

	// Use this for initialization

	void OnTriggerEnter2D(Collider2D col)
	{
		col.transform.parent = gameObject.transform;
	}

	void OnTriggerExit2D(Collider2D col)
	{
			col.transform.parent = null;
	}
}
}
