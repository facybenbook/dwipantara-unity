using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Dwipantara {

	public class BasicScene : MonoBehaviour {

		public enum Scene {
			MenuAwal,
			Menu,
			Mode,
			mulaikuis,
			LevelSelect,
			LevelHandler,
		}

		protected virtual void Awake() {

		}

		protected void GoToScene(Scene scene) {
			SceneManager.LoadScene (scene.ToString ());
		}

		protected void GoToScene(string sceneName) {
			SceneManager.LoadScene (sceneName);
		}
	}

}
