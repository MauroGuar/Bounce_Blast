using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] bool timerSpawner = false;
    [SerializeField] public GameObject[] objectsToSpawn;
    public GameObject[] mixedObjectsToSpawn;
    [SerializeField] float spawnRate = 2;
    private float timer = 0;
    private System.Random rng;

    private void Awake()
    {
        rng = new System.Random();
    }

    private void Start()
    {
        mixedObjectsToSpawn = Shuffle(objectsToSpawn);
        SpawnObject("Start");
    }

    private void Update()
    {
        if (timerSpawner)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
            }
        }
    }

    public void SpawnObject(String msg)
    {
        Instantiate(mixedObjectsToSpawn[0], transform.position, transform.rotation);
        if (mixedObjectsToSpawn.Length == 0)
        {
            mixedObjectsToSpawn = Shuffle(objectsToSpawn);
        }
        else {
            Instantiate(mixedObjectsToSpawn[0], transform.position, transform.rotation);
            mixedObjectsToSpawn = mixedObjectsToSpawn.Where(val => val != mixedObjectsToSpawn[0]).ToArray();
        }
    }
    private T[] Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
        return array;
    }
}