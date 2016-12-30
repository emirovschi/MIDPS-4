using UnityEngine;

public class ObstacleController : Controller<IObstacle>
{
	public ObstacleController(IObstacle view) : base(view)
	{
	}

	public void Init(int layer, int position, float height)
    {
        View.SetPosition(new Vector3(position * 5, height * 2.5f, layer * 7.5f));
    }
}

