using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    public CharacterScriptableObject characterData;
    [SerializeField] private TrailRenderer trailRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Move();
    }

    void InputManagement()
    {
        if (isDashing)
        {
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }

        if (moveDir.y != 0 && moveDir.x != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed);
    }

    private IEnumerator Dash()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 && moveY == 0)
        {
            canDash = false;
            isDashing = true;
            rb.velocity = new Vector2(moveX * dashingPower, 1f);
            trailRenderer.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            trailRenderer.emitting = false;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }
        if (moveY != 0 && moveX == 0)
        {
            canDash = false;
            isDashing = true;
            rb.velocity = new Vector2(1f, dashingPower * moveY);
            trailRenderer.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            trailRenderer.emitting = false;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }
        if (moveY != 0 && moveX != 0)
        {
            canDash = false;
            isDashing = true;
            rb.velocity = new Vector2(dashingPower * moveX, dashingPower * moveY);
            trailRenderer.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            trailRenderer.emitting = false;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }

    }
}