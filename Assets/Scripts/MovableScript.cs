using UnityEngine;

public class Movible : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float deadPosition = -200;
    [SerializeField] bool isDestroyed = true;
    void Update()
    {
        transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
        if (transform.position.x <= deadPosition && isDestroyed)
        {
            Destroy(gameObject);   
        }
    }
}
