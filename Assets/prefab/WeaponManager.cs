using UnityEngine;
using System.Collections;

namespace Dwipantara {

public class WeaponManager : MonoBehaviour {

	public GameObject activeWeapon = null;
	Weapon wpn;
	bool canShoot= true;
	public Animator anim;
	

	// Use this for initialization 
	
	// Update is called once per frame
	void Update () {
		if (InputWrapper.Instance.GetAttack() && canShoot && activeWeapon) {
				canShoot = false;
				StartCoroutine ("CoolDown");


				if (wpn.projectileMode == Weapon.Modes.Straight) {
					anim.SetTrigger ("bpshoot");
					Invoke("busurpanah", 0.7f);
				} 

				if (wpn.projectileMode == Weapon.Modes.Throw) {
					Invoke("lempar", 0.7f);
				} 

				if (wpn.projectileMode == Weapon.Modes.Melee) {
					anim.SetTrigger ("psslash");
					Invoke("pedang", 0.5f);
				} 

				if (wpn.projectileMode == Weapon.Modes.Shield) {
					anim.SetTrigger ("ptpush");
					Invoke("perisai", 0.5f);
				} 
			}
	}

	IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(wpn.coolDown);
		canShoot = true;

	}
	
	void busurpanah() {
		Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
		GameObject projectile = (GameObject)Instantiate (wpn.projectile, transform.position + activeWeapon.transform.GetChild (0).localPosition * transform.parent.localScale.x, Quaternion.Euler (rotation));
		projectile.GetComponent<Rigidbody2D> ().velocity = transform.parent.localScale.x * Vector2.right * wpn.projectileSpeed;
	}

	void lempar(){
		Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
		GameObject projectile = (GameObject)Instantiate (wpn.projectile, transform.position + activeWeapon.transform.GetChild (0).localPosition * transform.parent.localScale.x, Quaternion.Euler (rotation));	
		projectile.GetComponent<Rigidbody2D> ().isKinematic = false;
		projectile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.parent.localScale.x, 1) * wpn.projectileSpeed;
	}

	void pedang(){
		Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
		GameObject projectile = (GameObject)Instantiate (wpn.projectile, transform.position + activeWeapon.transform.GetChild (0).localPosition * transform.parent.localScale.x, Quaternion.Euler (rotation));
		projectile.GetComponent<Rigidbody2D> ().velocity = transform.parent.localScale.x * Vector2.right * wpn.projectileSpeed;
	}

	void perisai(){
		Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
		GameObject projectile = (GameObject)Instantiate (wpn.projectile, transform.position + activeWeapon.transform.GetChild (0).localPosition * transform.parent.localScale.x, Quaternion.Euler (rotation));
	}

	public void UpdateWeapon(GameObject newWeapon)
	{
			activeWeapon = newWeapon;
			wpn = activeWeapon.GetComponent<Weapon> ();
	}

}
}