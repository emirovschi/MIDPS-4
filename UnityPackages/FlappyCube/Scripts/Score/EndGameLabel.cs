using UnityEngine.UI;

public class EndGameLabel : View, IEndGameLabel
{
    public Text Text;

    public void SetScore(int score, int highScore)
    {
        Text.text = "\n" + score + "\n\n" + highScore;
    }
}
