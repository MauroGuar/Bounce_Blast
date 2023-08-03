using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float _score = 0.0f;
    private float _recordScore = 0.0f;

    private void Start()
    {
        UpdateRecordScore();
        ResetScore();
    }

    private void Update()
    {
        AddScore();
    }

    private void AddScore()
    {
        _score += Time.deltaTime;
        scoreText.text = _score.ToString("F1").Replace(",", ".");
    }

    [ContextMenu("Reset Score")]
    public void ResetScore()
    {
        scoreText.text = "0";
    }

    public void UpdateRecordScore()
    {
        _recordScore = PlayerPrefs.GetFloat("RecordScore", 0.0f);
        if (_score > _recordScore)
        {
            _recordScore = _score;
            PlayerPrefs.SetFloat("RecordScore",_recordScore);
            PlayerPrefs.Save();
        }
    }
}