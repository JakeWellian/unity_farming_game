using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrencyController : MonoBehaviour
{
    public static CurrencyController instance;

    public float winAmount = 1000f;
    public string winnerScene;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }


    public float currentMoney;

    private void Start()
    {
        UIController.instance.UpdateMoneyText(currentMoney);
    }

    public void SpendMoney(float amountToSpend)
    {
        currentMoney -= amountToSpend;

        UIController.instance.UpdateMoneyText(currentMoney);
    }
   
    public void AddMoney(float amountToAdd)
    {
        currentMoney += amountToAdd;

        UIController.instance.UpdateMoneyText(currentMoney);

        // Check win condition
        if (currentMoney >= winAmount)
        {
            // Close UI before changing scene
            if (UIController.instance.theIC.gameObject.activeSelf)
            {
                UIController.instance.theIC.OpenClose();
            }

            if (UIController.instance.theShop.gameObject.activeSelf)
            {
                UIController.instance.theShop.OpenClose();
            }

            PlayerPrefs.SetInt("FinalDays", TimeController.instance.currentDay);

            // Destroy persistent systems
            Destroy(UIController.instance.gameObject);
            Destroy(PlayerController.instance.gameObject);
            Destroy(GridInfo.instance.gameObject);
            Destroy(TimeController.instance.gameObject);
            Destroy(CropController.instance.gameObject);
            Destroy(CurrencyController.instance.gameObject);

            SceneManager.LoadScene(winnerScene);
        }
    }

    public bool CheckMoney(float amount)
    {
        if(currentMoney >= amount)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
