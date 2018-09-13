using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

namespace Dwipantara {

	public class CommonTasks {

		[MenuItem("Dwipantara/Start Game")]
		public static void PlayIntroScene() {
			string introScenePath = EditorBuildSettings.scenes[0].path;
			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
			EditorSceneManager.OpenScene(introScenePath);
			EditorApplication.isPlaying = true;
		}
	}
}