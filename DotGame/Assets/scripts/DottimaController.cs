using UnityEngine;

public class DottimaController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = moveInput.normalized * speed;
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);

    }
}
