using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreModel _scoreModel;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _scoreModel.Changed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreModel.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
       _score.text = score.ToString();
    }
}
