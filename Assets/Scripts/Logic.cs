using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float _score = 0.0f;

    private void Start()
    {
       ResetScore();
    }
    private void Update()
    {
        AddScore();
    }

    private void AddScore()
    {
        _score += Time.deltaTime;
        _score = Mathf.Round(_score * 100) / 100;
        scoreText.text = _score.ToString();
    }

    [ContextMenu("Reset Score")]
    public void ResetScore()
    {
        scoreText.text = "0";
    }
}
