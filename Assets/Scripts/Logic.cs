using System.Globalization;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Logic : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private TextMeshProUGUI recordTextMesh;
    private float _score = 0.0f;
    private float _recordScore = 0.0f;
    public bool clearRecordScoreOnStart;

    private void Start()
    {
        if (clearRecordScoreOnStart)
        {
            ClearRecord();
        }

        UpdateRecordScore();
        ResetScore();
    }

    private void Update()
    {
        AddScore();
        recordTextMesh.text = "Record: " + _recordScore.ToString(CultureInfo.InvariantCulture);
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
            PlayerPrefs.SetFloat("RecordScore", _recordScore);
            PlayerPrefs.Save();
        }
    }

    private void ClearRecord()
    {
        _recordScore = 0.0f;
        PlayerPrefs.SetFloat("RecordScore", _recordScore);
        PlayerPrefs.Save();
    }
}