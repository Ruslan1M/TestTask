using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour
{
    private static ScoreSystem _instance;
    public static ScoreSystem Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _highText;
  

    private int _score;
    private int _highScore;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _highText.text = _highScore.ToString();
    }

    public void AddScore(int num)
    {
        _score += num;
        _scoreText.text = _score.ToString();
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if( _highScore < _score)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            _highText.text = _highScore.ToString();
        }
    }

}
