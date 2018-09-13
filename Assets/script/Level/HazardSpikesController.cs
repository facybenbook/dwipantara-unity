using UnityEngine;
using System.Collections;

namespace Dwipantara {

	public class HazardSpikesController : LevelPiece {

		public AudioClip PlayerLoseFx;

		private void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.tag == "Player") {
				Player player = col.gameObject.GetComponent<Player>();
				AudioPlayer.Instance.PlaySfx (PlayerLoseFx);
				player.StartPlayerDeath();
			}
		}
	}
}
