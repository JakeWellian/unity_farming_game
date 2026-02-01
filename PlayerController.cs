using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    
    public InputActionReference moveInput, actionInput;
    public Animator anim;

    public enum ToolType
    {
        plough,
        wateringCan,
        seeds,
        basket
    }

    public ToolType currentTool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        moveInput.action.Enable();
        actionInput.action.Enable();
    }

    private void OnDisable()
    {
        moveInput.action.Disable();
        actionInput.action.Disable() ;
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


        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            currentTool++;

            if ((int)currentTool >= 4)
            {
                currentTool = ToolType.plough;
            }
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            currentTool = ToolType.plough;
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            currentTool = ToolType.wateringCan;
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            currentTool = ToolType.seeds;
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            currentTool = ToolType.basket;
        }


        if (actionInput.action.WasPressedThisFrame())
        {
            UseTool();
        }

            anim.SetFloat("speed", rb.linearVelocity.magnitude);
    }

    void UseTool()
    {
        GrowBlock block = null;

        block = FindFirstObjectByType<GrowBlock>();

    //block.PloughSoil();

        if (block != null)
        {
            switch (currentTool)
            {
                case ToolType.plough:

                    block.PloughSoil();

                    break;

                case ToolType.wateringCan:

                    break;

                case ToolType.seeds:

                    break;

                case ToolType.basket:

                    break;
            }

        }

    }
    
}
