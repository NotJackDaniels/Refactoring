using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyMove : MonoBehaviour {

    public GameObject objectSprite;
    public float Speed;
	public float shiftSpeed;
	public float altSpeed;
	public float spendShiftEnergy;
	public float spendAltEnergy;
	public float spendSpaceEnergy;
	public float upEnergy;

	public Slider slider;
	private float energy = 1;

    private float gravity = 300f;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
		// ускоренный бег
		if (Input.GetKey (KeyCode.LeftShift) && energy > 0) {
			Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			_controller.Move (move * Time.deltaTime * shiftSpeed);
			if (move != Vector3.zero)
				transform.forward = -move;

			move.y -= gravity * Time.deltaTime;
			_controller.Move (move * Time.deltaTime);
			energy -= spendShiftEnergy;
		}
		// увороты
		else if (Input.GetKey (KeyCode.LeftAlt) && energy > 0) {
			Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			_controller.Move (move * Time.deltaTime * altSpeed);
			if (move != Vector3.zero)
				transform.forward = -move;

			move.y -= gravity * Time.deltaTime;
			_controller.Move (move * Time.deltaTime);
			energy -= spendAltEnergy;
		}
		// прыжки
		else if (Input.GetKey(KeyCode.Space) && energy > 0) {
			Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			_controller.Move (move * Time.deltaTime * Speed);
			if (move != Vector3.zero)
				transform.forward = -move;

			move.y += gravity * Time.deltaTime;
			_controller.Move (move * Time.deltaTime);
			move.y -= gravity * Time.deltaTime;
			_controller.Move (move * Time.deltaTime);

			energy -= spendSpaceEnergy;
		}
		// обычный клик
		else {
			Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			_controller.Move (move * Time.deltaTime * Speed);
			if (move != Vector3.zero)
				transform.forward = -move;

			move.y -= gravity * Time.deltaTime;
			_controller.Move (move * Time.deltaTime);
		}

		slider.value = energy;
		if(energy < 1) energy += upEnergy;
    }
}
