using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public LayerMask solidObjectsLayer;
	public LayerMask interactableLayer;

	public event Action HintFound;

	private Animator animator;

	private bool isMoving;
	private Vector2 input;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void HandleUpdate()
	{
		if (!isMoving)
		{
			input.x = Input.GetAxisRaw("Horizontal");
			input.y = Input.GetAxisRaw("Vertical");

			if (input != Vector2.zero)
			{
				animator.SetFloat("moveX", input.x);
				animator.SetFloat("moveY", input.y);

				var targetPos = transform.position;
				targetPos.x += input.x;
				targetPos.y += input.y;

				if (IsWalkable(targetPos))
					StartCoroutine(Move(targetPos));
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Interact();
		}

	}

	void Interact()
	{
		var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
		var InteractPos = transform.position + facingDir;

		var collider = Physics2D.OverlapCircle(InteractPos, 0.3f, interactableLayer);
		if (collider != null) 
		{
			collider.GetComponent<Interactibles>()?.Interact();
			HintFound();
		}
	}

	IEnumerator Move(Vector3 targetPos)
	{
		isMoving = true;	

		while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) 
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
			yield return null;
		}
		transform.position = targetPos;

		isMoving = false;
	}

	private bool IsWalkable(Vector3 targetPos)
	{
		if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
		{
			return false;
		}
		return true;
	}

}
