using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwipantara {

	public class KematianController : LevelPiece {

	// Use this for initialization
		public AudioClip PlayerLoseFx;

		private void OnCollisionEnter2D(Collision2D coll) {
			if (coll.gameObject.layer == LayerMask.NameToLayer("Player")) {
				Player player = coll.gameObject.GetComponent<Player>();
				AudioPlayer.Instance.PlaySfx (PlayerLoseFx);
				player.StartPlayerDeath();
			}
		}
}
}