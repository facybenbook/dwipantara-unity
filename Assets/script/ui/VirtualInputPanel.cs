using UnityEngine;
using System.Collections;

namespace Dwipantara {

	public class VirtualInputPanel : MonoBehaviour {

		public void LeftOnPress() {
			InputWrapper.Instance.VirtualLeft = true;
		}
		
		public void LeftOnRelease() {
			InputWrapper.Instance.VirtualLeft = false;
		}
		
		public void RightOnPress() {
			InputWrapper.Instance.VirtualRight = true;
		}
		
		public void RightOnRelease() {
			InputWrapper.Instance.VirtualRight = false;
		}
		
		public void UpOnPress() {
			InputWrapper.Instance.VirtualUp =  true;
		}

		public void UpOnRelease() {
			InputWrapper.Instance.VirtualUp =  false;
		}

		public void AttackOnPress() {
			InputWrapper.Instance.VirtualAttack =  true;
		}

		public void AttackOnRelease() {
			InputWrapper.Instance.VirtualAttack =  false;
		}
	}
}
