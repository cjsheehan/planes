using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private float thrust = 10f;
	private float maxVelocity = 100f;
	private float minVelocity = 0f;
	private float rotate = 2f;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frames
	void FixedUpdate()
	{
		if (Input.GetKey("up"))
		{
			rb2d.AddForce(transform.right * thrust);
			if (rb2d.velocity.magnitude > maxVelocity)
			{
				rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
			}
		}

		if (Input.GetKey("down"))
		{
			rb2d.AddForce(transform.right * thrust * -1);
			if (rb2d.velocity.magnitude < minVelocity)
			{
				rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, minVelocity);
			}
		}

		if (Input.GetKey("left"))
		{
			RotateLeft();
		}

		if (Input.GetKey("right"))
		{
			RotateRight();
		}

		ClampPositionToScreen();

	}

	void ClampPositionToScreen()
	{
		// X axis
		if (transform.position.x <= -11.75f)
		{
			transform.position = new Vector2(-11.75f, transform.position.y);
		}
		else if (transform.position.x >= 11.75f)
		{
			transform.position = new Vector2(11.75f, transform.position.y);
		}

		// Y axis
		if (transform.position.y <= 0f)
		{
			transform.position = new Vector2(transform.position.x, 0);
		}
		else if (transform.position.y >= 6.5f)
		{
			transform.position = new Vector2(transform.position.x, 6.5f);
		}
	}

	void RotateLeft()
	{
		transform.Rotate(0, 0, rotate);
	}

	void RotateRight()
	{
		transform.Rotate(0, 0, rotate * -1);
	}


}
