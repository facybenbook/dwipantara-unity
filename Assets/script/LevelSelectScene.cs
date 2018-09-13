using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Dwipantara {

	public class LevelSelectScene : BasicScene {

		public GameObject animasi;
		Animator botaoanim;
		int state;
		
		public List<LevelSlot> LevelSlots;

		private void Start() {
			botaoanim = animasi.GetComponent<Animator> ();
			InitLevelSlots ();
		}

		private void InitLevelSlots() {
			for (int i = 0; i < LevelSlots.Count; i++) {
				LevelSlots[i].Init((i < Session.Instance.GetTotalLevels()), i + 1, LevelSlotOnClick);
			}
		}

		private void LevelSlotOnClick(int levelId) {
			Session.Instance.PlayLevel(levelId);
			GoToScene (Scene.LevelHandler);
		}

		public void backOnClick() {
			GoToScene (Scene.Mode);
		}

		void Update() {
			state = PlayerPrefs.GetInt("level");
			if(state==1){
				botaoanim.SetTrigger("satu");
			}
			if(state==2){
				botaoanim.SetTrigger("dua");
			}
			if(state==3){
				botaoanim.SetTrigger("tiga");
			}
			if(state==4){
				botaoanim.SetTrigger("empat");
			}
		}
	}
	
}
