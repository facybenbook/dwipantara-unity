using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Dwipantara {

	public class HintMessagePanel : MonoBehaviour {

		public GameObject Container;
		public Text MessageValue,MessageValue2,MessageValue3;

		private void Awake() {
			Container.SetActive(false);
		}

		public void SetMessage(string message,string message2,string message3) {
			MessageValue.text = message;
			MessageValue2.text = message2;
			MessageValue3.text = message3;
		}

		public void Show() {
			Container.SetActive(true);
		}

		public void Hide() {
			Container.SetActive(false);
		}
	}
}
