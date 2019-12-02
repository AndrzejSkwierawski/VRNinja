using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
	public Rigidbody RB;

	public bool IsActive = false;
	public float radius;
	public float hight;

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
		transform.Translate(moveSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, moveSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime, 0f);
		transform.Rotate(rotateSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, -rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
