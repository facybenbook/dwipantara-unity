using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dwipantara {
	
public class Player : MonoBehaviour {

	public AudioClip JumpFx; 
	public float maxSpeed = 3;
	public float jumpPower = 100f;
		public float MaxSpeed = 3;
		public float JumpSpeed = 100f;
		public LayerMask WhatIsGround;
		public Transform GroundCheck;
		public bool grounded;
		private bool _jumping = false;
		private bool _facingRight = true;
		private bool _doubleJump = true;
		private float _xVel;
		private float _yVel;
		private Rigidbody2D _groundRigidBody;

	public bool canDoubleJump;

	private Animator anim;
	private Animator anim2;
	public GameObject invenn;

	public GameObject currentInterObj = null;
	public InteractionObject currentInterObjScript = null;
	public Inventory inventory;
	public GameObject[] tempInventory;

	public delegate void PlayerDeathDelegate();
	public static event PlayerDeathDelegate PlayerDeathEvent;
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		anim2 = invenn.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (InputWrapper.Instance.GetUp ()) {
				_jumping = true;
			}
	}

	void FixedUpdate () {
		if (currentInterObj) {
			if(currentInterObjScript.inventory){
				inventory.AddItem (currentInterObj);
			}

		}
		
			_xVel = GetComponent<Rigidbody2D>().velocity.x;
			_yVel = GetComponent<Rigidbody2D>().velocity.y;

			if (_groundRigidBody != null && !grounded) {
				_groundRigidBody = null;
			}
			// Process Horizontal
			if (InputWrapper.Instance.GetRigth ()) {
				_xVel = 1 * MaxSpeed;
			} else if (InputWrapper.Instance.GetLeft ()) {
				_xVel = -1 * MaxSpeed;
			} else {
				_xVel = 0;
			}
			if ((_xVel > 0 && !_facingRight) || (_xVel < 0 && _facingRight)) {
				Flip ();
			}	
			_xVel += PlatformVelocity ().x;

			// Process Vertical
			if (grounded) {
				_yVel = PlatformVelocity ().y - 0.01f; // maintain velocity of platform, with slight downward pressure to keep the collision.
				_doubleJump = true;
			}
			if (_jumping && grounded) {
				_yVel = JumpSpeed;
				AudioPlayer.Instance.PlaySfx (JumpFx);
			} else if (_jumping && _doubleJump) {
				_yVel = JumpSpeed;
				_doubleJump = false;
				AudioPlayer.Instance.PlaySfx (JumpFx);
			}
			_jumping = false;

			GetComponent<Rigidbody2D>().velocity = new Vector2 (_xVel, _yVel);		
			UpdateAnimationParams();
	}

		private Vector2 RelativeVelocity () {
			return GetComponent<Rigidbody2D>().velocity - PlatformVelocity ();
		}

		private Vector2 PlatformVelocity () {
			return (_groundRigidBody == null) ? Vector2.zero : _groundRigidBody.velocity;
		}

		private void Flip () {
			_facingRight = !_facingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

		private void UpdateAnimationParams() {
			anim.SetFloat ("Speed", Mathf.Abs (RelativeVelocity ().x));
			anim.SetBool ("Grounded", grounded);
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("interObject")) {
				Debug.Log (other.name);
				currentInterObj = other.gameObject;
				currentInterObjScript = currentInterObj.GetComponent<InteractionObject> ();
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			currentInterObj = null;
			currentInterObjScript = null;
		}

	public void StartPlayerDeath() {
		Debug.Log("StartPlayerDeath called...");
				if (PlayerDeathEvent != null) {
					PlayerDeathEvent ();
					Respawn ();
				}
	}

		void Respawn(){
			GameObject player = GameObject.Find("Player");
			GameObject respawn = GameObject.Find("Respawn");
			player.transform.position = respawn.transform.position;
		}

		public void SlotSatuClick (){
			if (PlayerPrefs.HasKey("BusurPanah")) {
				anim.SetTrigger ("busurpanah");
				transform.Find("WeaponSlot").GetComponent<WeaponManager>().UpdateWeapon(tempInventory[0]);
				anim2.SetBool ("Tas",true);
			}
		}

		public void SlotDuaClick (){
			if (PlayerPrefs.HasKey("ParangSalawaku")) {
				anim.SetTrigger ("parangsalawaku");
				transform.Find("WeaponSlot").GetComponent<WeaponManager>().UpdateWeapon(tempInventory[1]);
				anim2.SetBool ("Tas",true);
			}
		}

		public void SlotTigaClick (){
			if (PlayerPrefs.HasKey("KerisPasatimpo")) {
				anim.SetTrigger ("kerispasatimpo");
				transform.Find("WeaponSlot").GetComponent<WeaponManager>().UpdateWeapon(tempInventory[2]);
				anim2.SetBool ("Tas",true);
			}
		}

		public void SlotEmpatClick (){
			if (PlayerPrefs.HasKey("PerisaiTalawang")) {
				anim.SetTrigger ("perisaitalawang");
				transform.Find("WeaponSlot").GetComponent<WeaponManager>().UpdateWeapon(tempInventory[3]);
				anim2.SetBool ("Tas",true);
			}
		}
 }
}
