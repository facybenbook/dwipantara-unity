using UnityEngine;
using System.Collections;

namespace Dwipantara {

public class Weapon : MonoBehaviour {

	public enum Modes 
	{ Melee, Shield, Straight, Follow, Throw}


	public Sprite sprite;
	public GameObject projectile;
	public float projectileSpeed;
	public float coolDown;

	public Modes projectileMode;

	// Use this for initialization
	void Start () {

	}

}
}
