using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    
    public InputActionReference moveInput;
    public Animator anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        moveInput.action.Enable();
    }

    private void OnDisable()
    {
        moveInput.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * movespeed;

        if (rb.linearVelocityX < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.linearVelocityX > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        anim.SetFloat("speed", rb.linearVelocity.magnitude);
    }
}
