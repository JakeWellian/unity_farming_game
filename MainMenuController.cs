using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string levelToStart;

    private void Start()
    {
        AudioManager.instance.PlayTitle();
    }

    public void PlayGame()
    {
        // Clear all wild plant collected states for fresh run
        //PlayerPrefs.DeleteKey("WildPlant_forest_01");
        //PlayerPrefs.DeleteKey("WildPlant_barn_02");
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(levelToStart);

        AudioManager.instance.PlayNextBGM();

        AudioManager.instance.PlaySFXPitchAdjusted(5);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quitting The Game");

        AudioManager.instance.PlaySFXPitchAdjusted(5);
    }
}
