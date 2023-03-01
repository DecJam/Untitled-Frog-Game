using Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Vector2 movementInputVector = Vector2.zero;
	private bool jumpPressedThisFrame = false;
	private CharacterController characterController = null;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();	
	}

	public void LateUpdate()
	{
		// Handle jump 
		if (jumpPressedThisFrame)
		{
			// Jump
		}

		// handle movement Input
		Vector3 finaMovementVec = Vector3.zero;

		// Interperate movementInputVector w = forward etc
		// Dont forget to use Time.deltaTime to make sure movement is in per second and not per frame

		// Applies motion to characterController
		characterController.Move(finaMovementVec);
	}

	private void JumpPressed() { jumpPressedThisFrame = true; }
	private void MovementInputAdded(Vector2 movementInput) { movementInputVector = movementInput; }

	private void OnEnable()
	{
		PlayerInputHandler.OnSpacePress += JumpPressed;
		PlayerInputHandler.OnMovementInput += MovementInputAdded;
	}

	private void OnDisable()
	{
		PlayerInputHandler.OnSpacePress -= JumpPressed;
		PlayerInputHandler.OnMovementInput -= MovementInputAdded;
	}
}
