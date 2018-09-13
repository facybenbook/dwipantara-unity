using UnityEngine;
using System.Collections;

namespace Dwipantara {

	public class InteractiveSignController : LevelPiece {

		public AudioClip SignFx;
		public GameObject HintMessage;
		public string Message,Message2,Message3;	

		private void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.tag == "Player") {
				AudioPlayer.Instance.PlaySfx (SignFx);
				HintMessage.gameObject.SetActive (true);
			}
		}

		private void OnTriggerExit2D(Collider2D col) {
			if (col.gameObject.tag == "Player") {
				HintMessage.gameObject.SetActive (false);
			}
		}
	}
}
