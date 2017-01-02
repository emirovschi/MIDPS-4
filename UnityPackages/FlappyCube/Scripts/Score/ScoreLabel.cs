using UnityEngine.UI;

public class ScoreLabel : View, IScoreLabel
{
    public Text Text;

    public void SetScore(string score)
    {
        Text.text = score;
    }
}
