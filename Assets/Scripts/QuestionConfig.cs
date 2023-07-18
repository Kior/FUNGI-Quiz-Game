using UnityEngine;

[CreateAssetMenu(fileName = nameof(QuestionConfig), menuName = "Configs/Question Config")]
public class QuestionConfig : ScriptableObject
{
    #region Variables

    [TextArea(4, 6)]
    public string Answer;

    public QuestionConfig[] NextQuestions;
    [TextArea(4, 10)]
    public string Question;

    public Sprite Sprite;

    #endregion
}