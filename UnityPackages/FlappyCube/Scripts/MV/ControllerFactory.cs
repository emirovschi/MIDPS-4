using Zenject;

public class ControllerFactory<TC, TV> : IFactory<TC> where TC : Controller<TV> where TV : IView
{
	private readonly DiContainer container;

	public ControllerFactory(DiContainer container)
	{
		this.container = container;
	}

	public TC Create()
	{
		return container.Resolve<TC>();
	}
}

