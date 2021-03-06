﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetPos;
    public float speed;
    public float dashRange;
    private Vector2 direction;
    private Animator animator;
    private SpriteRenderer mySpriteRenderer;
    private enum Facing {UP, DOWN, LEFT, RIGHT};
    private Facing facingDir = Facing.DOWN;

    void Start()
    {
        // animator variable will reference the animator component on the player sprite
        animator = GetComponent<Animator>();

        // mySpriteRenderer variable will reference the Sprite Renderer component on the player sprite
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Checks the input given by the player
        TakeInput();
        // Calls Move method
        Move();
    }

    private void Move()
    {
        // Moves player sprite depending on the values of direction variable * the speed given to the player sprite * deltaTime
        transform.Translate(direction * speed * Time.deltaTime);


        // Checks if player sprite is in an idle state
        if(direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
        } 
        else
        {
            // If its in an idle state the specified layer (Running layer) will lose its priority
            animator.SetLayerWeight(1, 0);
        }

    }


    private void TakeInput()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            facingDir = Facing.UP;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            facingDir = Facing.DOWN;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Flips player sprite on the X axis
            mySpriteRenderer.flipX = true;
            facingDir = Facing.LEFT;
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Flips player sprite on the X axis
            mySpriteRenderer.flipX = false;
            facingDir = Facing.RIGHT;
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerDash();
        }
    }

    private void PlayerDash()
    {
        Vector2 currentPos = transform.position;
        targetPos = Vector2.zero;
        if (facingDir == Facing.UP)
        {
            targetPos.y = 1;
        }
        if (facingDir == Facing.DOWN)
        {
            targetPos.y = -1;
        }
        if (facingDir == Facing.LEFT)
        {
            targetPos.x = -1;
        }
        if (facingDir == Facing.RIGHT)
        {
            targetPos.x = 1;
        }
        transform.Translate(targetPos * dashRange);
    }


    private void SetAnimatorMovement(Vector2 direction)
    {
        // SetLayerWeight takes two arguments an id of the layer and the weight of the layer
        // Sets priority to the specified layer (Running Layer)
        animator.SetLayerWeight(1, 1);
        // SetFloat takes two arguments a string name and a float value
        animator.SetFloat("x_dir", direction.x);
        animator.SetFloat("y_dir", direction.y);
    }

}
