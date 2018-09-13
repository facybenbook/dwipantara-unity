using UnityEngine;
using System.Collections;

namespace Dwipantara {

	public class InteractiveCoinController : LevelPiece { 

		public AudioClip CoinPickupFx;
		public delegate void StartInteractionDelegate();
		public static event StartInteractionDelegate StartInteractionEvent;

		private void OnTriggerStay2D(Collider2D col) {
			if (col.gameObject.tag == "Player") {	
				if (StartInteractionEvent != null) {
					StartInteractionEvent ();
					AudioPlayer.Instance.PlaySfx (CoinPickupFx);
					Destroy (gameObject);
				}
			}
		}

	}

}
