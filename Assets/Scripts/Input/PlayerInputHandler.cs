using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
	public class PlayerInputHandler : MonoBehaviour
	{
		[SerializeField] private bool showDebugLogs = false;

		private PlayerInputControls playerControls = null;

		public static event Action OnSpacePress;
		public static event Action OnLeftMouseClick;
		public static event Action OnRightMouseClick;
		public static event Action<Vector2> OnMovementInput;

		private void Awake()
		{
			playerControls = new PlayerInputControls();
			playerControls.FrogControl.Space.performed += ctx => OnSpacePress?.Invoke();
			playerControls.FrogControl.LeftClick.performed += ctx => OnLeftMouseClick?.Invoke();
			playerControls.FrogControl.RightClick.performed += ctx => OnRightMouseClick?.Invoke();
			playerControls.FrogControl.MovementInput.performed += ctx => OnMovementInput?.Invoke(ctx.ReadValue<Vector2>());

			if (showDebugLogs)
			{
				OnSpacePress += SpacePressed;
				OnLeftMouseClick += LeftClicked;
				OnRightMouseClick += RightClicked;
				OnMovementInput += MovementPressed;
			}
		}

		private void OnEnable() { playerControls.Enable(); }

		private void OnDisable() { playerControls.Disable(); }

		// Editor stuff
		private void SpacePressed() { Debug.Log("Pressed: Space"); }
		private void LeftClicked() { Debug.Log("Pressed: Left Click"); }
		private void RightClicked() { Debug.Log("Pressed: Right Click"); }
		private void MovementPressed(Vector2 movement) { Debug.Log($"Pressed: Movement {movement}"); }
	}
}
