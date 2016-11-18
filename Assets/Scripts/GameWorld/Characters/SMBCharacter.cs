﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
[RequireComponent (typeof (SMBRigidBody))]
[RequireComponent (typeof (SMBCollider))]
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (SpriteRenderer))]
public class SMBCharacter : MonoBehaviour {

	protected bool  _isOnGround;

	// Custom components
	protected AudioSource     _audio;
	protected Animator        _animator;
	protected SpriteRenderer  _renderer;
	protected SMBRigidBody    _body;
	protected SMBCollider     _collider;

	public float xSpeed = 1f;
	public float ySpeed = 5f;

	public float momentum = 3f;

	void Awake() {

		_audio    = GetComponent<AudioSource> ();
		_body     = GetComponent<SMBRigidBody> ();
		_collider = GetComponent<SMBCollider> ();
		_animator = GetComponent<Animator> ();
		_renderer = GetComponent<SpriteRenderer> ();
	}

	protected void Move(float speed) {

		_body.velocity.x = Mathf.Lerp (_body.velocity.x, speed * Time.fixedDeltaTime, 
			momentum * Time.fixedDeltaTime);

		float side = Mathf.Sign (speed);

		if (side == (float)SMBConstants.MoveDirection.Forward)
			_renderer.flipX = false;

		if (side == (float)SMBConstants.MoveDirection.Backward)
			_renderer.flipX = true;

		// Lock player x position
		Vector3 playerPos = transform.position;
		playerPos.x = Mathf.Clamp (playerPos.x, SMBGameWorld.Instance.LockLeftX - SMBGameWorld.Instance.TileSize, 
			SMBGameWorld.Instance.LockRightX);
		transform.position = playerPos;
	}

	virtual protected void OnHalfVerticalCollisionEnter(Collider2D collider) {

		if(Mathf.Sign(_body.velocity.y) == -1f)
			_isOnGround = true;
	}

	virtual protected void OnFullVerticalCollisionEnter(Collider2D collider) {

		if(Mathf.Sign(_body.velocity.y) == -1f)
			_isOnGround = true;
	}

	virtual protected void OnVerticalCollisionExit() {

		_isOnGround = false;
	}

	public bool isFlipped() {

		return _renderer.flipX;
	}
}