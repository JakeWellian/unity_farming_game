using UnityEngine;

public class IdleNPC : MonoBehaviour
{
    public GameObject dialogueBubble; // assign bubble in inspector
    private bool playerInRange;

    void Start()
    {
        if (dialogueBubble != null)
        {
            dialogueBubble.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            if (dialogueBubble != null)
            {
                dialogueBubble.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if (dialogueBubble != null)
            {
                dialogueBubble.SetActive(false);
            }
        }
    }
}