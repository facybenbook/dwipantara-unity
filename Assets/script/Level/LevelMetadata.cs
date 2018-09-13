using UnityEngine;
using System;

namespace Dwipantara {
	[Serializable]
	public class LevelMetadata {

		public string scene;
		[SerializeField]
		private string levelName;

		public string LevelName {
			get { return (levelName == null || levelName == "") ? "Untitled" : levelName; }
			set { levelName = value; }
		}

		public string SceneName {
			get {
				Debug.Log ("Scene Name : " + scene);
				return scene;
			}
		}
	}
}