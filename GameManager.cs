using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; //Para el boton

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f;  //Tiempo disponible
    private float timeRemaining;
    private bool isGameOver = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI TimeUpText;

    public PlayerController playerController;
    public SpawnManager spawnManager;
    public GameObject TryAgainButton;  //RECORDAR USAR EL ONCLICK + Y ASIGNAR EL GAMEMANAGER!!!!

    void Start()
    {
        timeRemaining = gameDuration;  // Tiempo restante con la duración del juego
        UpdateTimerUI();  //Sctualiza el tiempo!!!
        TimeUpText.gameObject.SetActive(false);
        TryAgainButton.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime; //Resta tiempo transcu!!
            if (timeRemaining <= 0)  //Comprobante de si el tiempo ha terminado
            {
                timeRemaining = 0;
                isGameOver = true;
                TimeUp();
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()   //$ inserta variables dentro de un string
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"Tiempo: {minutes:00}:{seconds:00}";
    }

    void TimeUp()
    {
        TimeUpText.gameObject.SetActive(true);

        //Detenciones de actividad
        if (playerController != null)
            playerController.enabled = false;

        if (spawnManager != null)
            spawnManager.StopSpawning();  //no funciona por el invoke!!-->spawnManager.enabled = false;

            TryAgainButton.SetActive(true);
    }

     public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
