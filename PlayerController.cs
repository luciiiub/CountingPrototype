using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 18.0f;
    public float zRange = 20.0f; // Limite eje Z

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mover en eje Z mundial (ya que el modelo esta rotado -90 Y!!!)
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed, Space.World);

        // Limitar movimiento eje Z 
        float clampedZ = Mathf.Clamp(transform.position.z, -zRange, zRange);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
    }
}
