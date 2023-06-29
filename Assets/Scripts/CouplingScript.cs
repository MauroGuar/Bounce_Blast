using UnityEngine;

public class CouplingScript : MonoBehaviour
{
    private GameObject _connector;
    private ObjectSpawner _connectorScript;
    private const float ConnectorPos = 17.68f;
    private int _limit = 0;


    private void Start()
    {
        _connector = GameObject.Find("ObjectSpawner");
        _connectorScript = _connector.GetComponent<ObjectSpawner>();
        Debug.Log(_connectorScript.mixedObjectsToSpawn);
    }

    private void Update()
    {
        CheckCoupleConnection();
        // Debug.Log(transform.position);
    }

    private void CheckCoupleConnection()
    {
        /*if (transform.position.x <= 17.68 && _limit == 0)
        {
            _limit += 1;
            _connectorScript.SpawnObject("I am here");
        }*/
    }
}