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

    public float toolWaitTime = .5f;
    private float toolWaitCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIController.instance.SwitchTool((int)currentTool);
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

        if (toolWaitCounter > 0)
        {
            toolWaitCounter -= Time.deltaTime;
            rb.linearVelocity = Vector2.zero;
        }
        else
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
        }

        bool hasSwitchedTool = false;

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            currentTool++;

            if ((int)currentTool >= 4)
            {
                currentTool = ToolType.plough;
            }

            hasSwitchedTool = true;

        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            currentTool = ToolType.plough;
            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            currentTool = ToolType.wateringCan;
            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            currentTool = ToolType.seeds;
            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            currentTool = ToolType.basket;
            hasSwitchedTool = true;
        }

        if (hasSwitchedTool == true)
        {
           UIController.instance.SwitchTool((int)currentTool);
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

        toolWaitCounter = toolWaitTime;

        if (block != null)
        {
            switch (currentTool)
            {
                case ToolType.plough:

                    block.PloughSoil();

                    anim.SetTrigger("usePlough");

                    break;

                case ToolType.wateringCan:

                    block.WaterSoil();

                    anim.SetTrigger("useWateringCan");

                    break;

                case ToolType.seeds:

                    block.PlantCrop();

                    break;

                case ToolType.basket:

                    block.HarvestCrop();

                    break;
            }

        }

    }
    
}
