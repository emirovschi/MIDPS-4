using System.Collections.Generic;
using ModestTree;
using UnityEngine;

public class Pool<TC, TV> : IPool<TC, TV> where TC : Controller<TV> where TV : IView
{
    private readonly ControllerFactory<TC, TV> factory;
    private readonly Queue<TC> buffer; 

    public Pool(ControllerFactory<TC, TV> factory)
    {
        this.factory = factory;
        this.buffer = new Queue<TC>();
    }

    public TC Create()
    {
        if (buffer.IsEmpty())
        {
            return factory.Create();
        }
        return TurnOn(buffer.Dequeue());
    }

    public void Delete(TC controller)
    {
        buffer.Enqueue(TurnOff(controller));
    }

    private TC TurnOn(TC controller)
    {
        //controller.View.Show();
        return controller;
    }

    private TC TurnOff(TC controller)
    {
        //controller.View.Hide();
        return controller;
    }
}
