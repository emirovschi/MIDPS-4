public interface IPool<TC, TV> where TC : Controller<TV> where TV : IView
{
    TC Create();

    void Delete(TC controller);
}
