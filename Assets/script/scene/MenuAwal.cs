using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Dwipantara {

	public class MenuAwal : BasicScene {

		public Text BuildInfoText;

		private void Start() {
			Debug.developerConsoleVisible = true;
			SetBuildInfo();
		}

		private void SetBuildInfo () {
			string info = "";
			BuildInfoText.text = info;
		}

		public void ActiveZoneOnClick() {
			GoToScene (Scene.Menu);
		}
	}
}
