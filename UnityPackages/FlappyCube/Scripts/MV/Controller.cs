public abstract class Controller<T> where T : IView
{
	private readonly T view;

	public T View
	{
		get
		{
			return view;
		}
	}

	public Controller(T view)
	{
		this.view = view;
	}
}
