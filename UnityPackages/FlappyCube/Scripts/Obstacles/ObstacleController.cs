using UnityEngine;

public class ObstacleController : Controller<IObstacle>
{
    private const float Space = 10f;
    private const float Size = 6f;
    private const float LayerSpace = 7.5f;

    private readonly IGame game;
    private float position;
    private float layerSpace;

	public ObstacleController(IGame game, IObstacle view) : base(view)
	{
	    this.game = game;
	}

	public void Init(GameObject buffer, int layer, int position, float height)
    {
        this.position = position * Space;
	    this.layerSpace = layer*Space/3;

        View.SetParent(buffer);
        View.SetPosition(new Vector3(this.position - game.Distance + layerSpace, height * Size, layer * LayerSpace));
	}

    public float GetPosition()
    {
        return position;
    }

    public void Move()
    {
        if (View.Enabled && game.IsStarted)
        {
            View.Move(GetPosition() - game.Distance + layerSpace);
        }
    }
}

