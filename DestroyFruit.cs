using UnityEngine;

public class DestroyFruit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // Si choca con objeto con tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);      // Destruir fruta
        }

        // Si choca con objeto con tag "Ground" 
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);   // Destruir fruta que cae al suelo
        }
    }
}
