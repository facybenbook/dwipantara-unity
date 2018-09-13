using UnityEngine;
using System.Collections;

namespace Dwipantara {
	public partial class Level : MonoBehaviour {

		#region SINGLETON
		
		private static Level _instance;
		
		public static Level Instance {
			get {
				if(_instance == null)
				{
					_instance = GameObject.FindObjectOfType<Level>();
				}
				return _instance;
			}
		}
		
		#endregion

		private Background background;

		private void Awake() {
			_instance = this as Level;
		}

		private void Start () {
			SetGravity ();
			AudioPlayer.Instance.PlayBgm(Bgm);
		}
	
		public void SetGravity () {
			if(Physics2D.gravity.y != Gravity) {
				Physics2D.gravity = new Vector3 (0, Gravity);
			}
		}
	}
}
