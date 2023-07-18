using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    #region Variables

    public Button AnswerA;
    public Button AnswerB;
    public Button AnswerC;
    public Button AnswerD;
    public TMP_Text AnswerText;

    [FormerlySerializedAs("QuestionOne")] public QuestionConfig Question;

    public TMP_Text QuestionLabel;
    public Image QuestionSprite;

    public Button RestartButton;

    private QuestionConfig _currentQuestion;

    private readonly KeyCode[] _inputKeys =
    {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D,
    };

    private bool _isNewGame;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _currentQuestion = Question;
        AnswerA.onClick.AddListener(OnAnswerAButtonClicked);
        AnswerB.onClick.AddListener(OnAnswerBButtonClicked);
        AnswerC.onClick.AddListener(OnAnswerCButtonClicked);
        AnswerD.onClick.AddListener(OnAnswerDButtonClicked);
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
        RestartButton.gameObject.SetActive(false);
        UpdateUi();
    }

    private void Update()
    {
        if (_isNewGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnAnswerAButtonClicked();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            OnAnswerBButtonClicked();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            OnAnswerCButtonClicked();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnAnswerDButtonClicked();
        }

        for (int i = 0; i < _inputKeys.Length; i++)
        {
            if (IsNextQuestionExist(i) && Input.GetKeyDown(_inputKeys[i]))
            {
                _currentQuestion = GoNextQuestion(i);
                UpdateUi();
            }
        }
    }

    #endregion

    #region Private methods

    private QuestionConfig GoNextQuestion(int index)
    {
        return _currentQuestion.NextQuestions[index];
    }

    private bool IsNextQuestionExist(int index)
    {
        return _currentQuestion.NextQuestions.Length > index;
    }

    private void OnAnswerAButtonClicked()
    {
        Input.GetKeyDown(KeyCode.A);
        Debug.Log("Test A");
    }

    private void OnAnswerBButtonClicked()
    {
        Input.GetKeyDown(KeyCode.B);
        Debug.Log("Test B");
    }

    private void OnAnswerCButtonClicked()
    {
        Input.GetKeyDown(KeyCode.C);
        Debug.Log("Test C");
    }

    private void OnAnswerDButtonClicked()
    {
        Input.GetKeyDown(KeyCode.D);
        Debug.Log("Test D");
    }

    private void OnRestartButtonClicked()
    {
        _isNewGame = false;
        RestartButton.gameObject.SetActive(false);
    }

    private void Restart()
    {
        OnRestartButtonClicked();
    }

    private void UpdateUi()
    {
        AnswerText.text = _currentQuestion.Answer;
        QuestionLabel.text = _currentQuestion.Question;
        QuestionSprite.sprite = _currentQuestion.Sprite;
    }

    #endregion
}