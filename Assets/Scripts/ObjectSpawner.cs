using UnityEngine;

public class BarrierSpawnerScript : MonoBehaviour
{
    [SerializeField] bool timerSpawner = false;
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] float spawnRate = 2;
    private float timer = 0; 
    void Start()
    {
        spawnObject();
    }
    void Update()
    {
       if (timerSpawner)
       {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } else {
            spawnObject();
            timer = 0;
        }
       }
    }

    void spawnObject(){
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0,objectsToSpawn.Length)];
        Instantiate(objectToSpawn, transform.position, transform.rotation);    
    }
}
