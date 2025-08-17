using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs;

    // Rangos generacion
    private float zSpawnRange = 20;     // Rango  Z por el jugador!
    private float spawnPosX = 0;   // X por el carrito
    private float spawnHeight = 25f;
    private float startDelay = 1;
    private float spawnInterval = 0.75f;
    private float torqueAmount = 3f; // Torque-giro

    void Start()
    {
        InvokeRepeating("SpawnFruit", startDelay, spawnInterval);   // Repetir frutas
    }


    void Update()
    {

    }



    void SpawnFruit()
    {
        int index = Random.Range(0, fruitPrefabs.Length);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnHeight, Random.Range(-zSpawnRange, zSpawnRange));
        GameObject fruit = Instantiate(fruitPrefabs[index], spawnPos, Quaternion.identity);
        Rigidbody rb = fruit.GetComponent<Rigidbody>();


        Vector3 randomTorque = new Vector3(
            Random.Range(-torqueAmount, torqueAmount),
            Random.Range(-torqueAmount, torqueAmount),
            Random.Range(-torqueAmount, torqueAmount)
        );

        rb.AddTorque(randomTorque, ForceMode.Impulse);


    }
    
    public void StopSpawning()
    {
    CancelInvoke(); // Detiene el InvokeRepeating
    }   
}
