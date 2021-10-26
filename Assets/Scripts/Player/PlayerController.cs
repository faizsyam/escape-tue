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


/* sing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;

    private bool isMoving;
    private int readIn;
    private bool lastIsH;
    private Vector2 input;

    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Update(){
        if(!isMoving){
            float getX = Input.GetAxisRaw("Horizontal");
            float getY = Input.GetAxisRaw("Vertical");

            if(readIn == 0){
                if((getX != 0) && (getY == 0)) readIn = 1;
                if((getX == 0) && (getY != 0)) readIn = 2;
            }
            else if(readIn == 1){
                if((getX != 0) && (getY != 0)) readIn = 3;
                if((getX == 0) && (getY != 0)) readIn = 2;
            }
            else if(readIn == 2){
                if((getX != 0) && (getY != 0)) readIn = 4;
                if((getX != 0) && (getY == 0)) readIn = 1;
            }
            
            if(readIn == 3){
                lastIsH = true;
                if(getX == 0) readIn = 2;
            }
            else if(readIn == 4){
                lastIsH = false;
                if(getY == 0) readIn = 1;
            }

            if ((getX != 0) && (getY != 0)){
                if(lastIsH){
                    input.x = 0;
                    input.y = getY;
                }
                else{
                    input.x = getX;
                    input.y = 0;
                }
            }
            else{
                input.x = getX;
                input.y = getY;
            }

            if(input != Vector2.zero){
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos){
        isMoving = true;
		
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
		CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos){
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null){
            return false;
        }
        else{
            return true; 
        }
	}
		
	private void CheckForEncounters(){
		var pos = animator.transform.position;
		if(pos.x >= -1.5 && pos.x <= 2.5 && pos.y >= 12.5 && pos.y <= 14){
			Debug.Log(pos + "Board");
		}
    }
} */
