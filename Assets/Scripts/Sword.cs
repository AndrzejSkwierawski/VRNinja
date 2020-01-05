using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
	public bool IsActive = false;
	public GameObject Blade;
	public GameObject Handle;

	public float SwordMoveSpeed   = 2f;
	public float SwordRotateSpeed = 25f;

	private float moveSpeed;
	private float rotateSpeed;

	// Start is called before the first frame update
	void Start()
    {
		moveSpeed   = SwordMoveSpeed;
		rotateSpeed = SwordRotateSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(moveSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, moveSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime, 0f, Space.World);
		transform.Rotate(rotateSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, -rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

		if (IsActive)
		{
			//																R		G			B	Transparency
			Blade.GetComponent<MeshRenderer>().material.color = new Color(0.2443f, 0.5224f, 0.8490f, 0f);
			Handle.GetComponent<MeshRenderer>().material.color = new Color(0.2443f, 0.5224f, 0.8490f, 0f);
		}
		else
		{
			Blade.GetComponent<MeshRenderer>().material.color = new Color(0.2443f, 0.5224f, 0.8490f, 1f);
			Handle.GetComponent<MeshRenderer>().material.color = new Color(0.2443f, 0.5224f, 0.8490f, 1f);

		}

	}
}
