using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    public bool isGrounded;
    public bool isJumping;
    public bool isFalling;
    public FixedJoystick joystick;
    private Vector3 moveDirection;
    private bool isRunning;
    private bool isDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDeath = false;
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath) return;
        Move();
        //Jump();
        CheckGroundStatus();
        UpdateAnimations();
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void Move()
    {
        if (isDeath) return;
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveDirection *= speed;
        
        gameObject.transform.Translate(moveDirection * Time.deltaTime, Space.World);

        isRunning = moveDirection.magnitude > 0;
        if (isRunning)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        animator.SetBool("isRunning", isRunning);
    }

    public void Jump()
    {
        if (isDeath) return;
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CheckGroundStatus()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }

    void UpdateAnimations()
    {
        animator.SetFloat("Speed", moveDirection.magnitude);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isJumping", !isGrounded && rb.linearVelocity.y > 0);
        animator.SetBool("isFalling", !isGrounded && rb.linearVelocity.y < 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyObject"))
        {
            isDeath = true;
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(3);
        GamePlayController.instance.Lose();
        Destroy(gameObject);
    }
}
