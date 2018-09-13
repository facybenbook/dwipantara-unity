using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Dwipantara {

	public class LevelHandlerUtils : MonoBehaviour {

		private static Level _level;

		public static IEnumerator LoadLevel(string sceneName) {
			SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
			yield return 0;
			_level = GameObject.FindObjectOfType<Level>();
		}

		public static void DestroyLevel() {
			if(_level != null) {
				Destroy(_level.gameObject);
			}
		}
	}
}
