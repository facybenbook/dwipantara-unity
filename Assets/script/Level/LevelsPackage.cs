using UnityEngine;
using System.Collections.Generic;

namespace Dwipantara {
	public class LevelsPackage : ScriptableObject {

		public const string Suffix = "_level";
		public const string ResourcePath = "LevelsPackage";
		public const string FullPath = "Assets/Resources/LevelsPackage.asset";
		public List<LevelMetadata> metadataList;
		public bool hasChanges = false;
	}	
}
