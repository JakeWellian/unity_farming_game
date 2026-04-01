using UnityEngine;

public class WildPlant : MonoBehaviour
{
    [Tooltip("Unique ID for this plant - must be different for every plant in the game")]
    public string plantID;

    [Tooltip("Which crop this wild plant rewards when picked up")]
    public CropController.CropType cropType;

    public SpriteRenderer theSR;

    private bool isCollected = false;

    private void Start()
    {
        // Check if this plant was already collected in a previous session/scene visit
        if (PlayerPrefs.GetInt("WildPlant_" + plantID, 0) == 1)
        {
            isCollected = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        isCollected = true;

        // Save to PlayerPrefs so it stays gone across scenes
        PlayerPrefs.SetInt("WildPlant_" + plantID, 1);
        PlayerPrefs.Save();

        // Award the crop to the player
        CropController.instance.AddCrop(cropType);

        AudioManager.instance.PlaySFX(3);

        // Refresh inventory UI if it's open
        if (UIController.instance.theIC.gameObject.activeSelf)
        {
            UIController.instance.theIC.UpdateDisplay();
        }

        // Optional: play a sound
        // AudioManager.instance.PlaySFXPitchAdjusted(2);

        gameObject.SetActive(false);
    }
}