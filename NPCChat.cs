using UnityEngine;

public class NPCChat : MonoBehaviour
{
    public GameObject dialogueBubble; // assign bubble in inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            

            if (dialogueBubble != null)
            {
                dialogueBubble.SetActive(false);
            }
        }
    }
}
