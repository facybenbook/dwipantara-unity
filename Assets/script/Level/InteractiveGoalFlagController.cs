using UnityEngine;
using System.Collections;

namespace Dwipantara {
	
	public class InteractiveGoalFlagController : LevelPiece { 

		public AudioClip PlayerWinFx;
		
		public delegate void StartInteractionDelegate();
		public static event StartInteractionDelegate StartInteractionEvent;
		
		private void OnTriggerEnter2D(Collider2D col) {
			if(StartInteractionEvent != null) {
				AudioPlayer.Instance.PlaySfx (PlayerWinFx);
				StartInteractionEvent();
				Respawn();
			}
		}

		void Respawn(){
			GameObject player = GameObject.Find("Player");
			GameObject respawn = GameObject.Find("Respawn");
			player.transform.position = respawn.transform.position;
		}
		
	}
	
}
