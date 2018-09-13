using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Dwipantara {

	public class Mode : BasicScene {



		public void jelajahOnClick() {
			GoToScene (Scene.LevelSelect);
		}
	
		public void kuisOnClick() {
			GoToScene (Scene.mulaikuis);
		}



		public void BotaoJogar()
		{
			Sistema.instancia.BotaoSom();
			SceneManager.LoadScene("topikkuis");
			Sistema.instancia.SetClick(1);
		}
	}
}