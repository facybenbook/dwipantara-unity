using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwipantara {

public class InteractionObject : MonoBehaviour {

	public bool inventory;
	
	public void DoInteraction()
	{
		gameObject.SetActive(false);
	}
}
}
