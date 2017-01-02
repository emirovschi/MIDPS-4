using Zenject;

public class ControllerFactory<TC, TV> : Factory<TC> where TC : Controller<TV> where TV : IView
{
}

