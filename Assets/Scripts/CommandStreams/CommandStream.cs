using System.Collections.Generic;
using UnityEngine;

public class CommandStream<T> : ScriptableObject
{
    private Queue<T> stream = new Queue<T>();

    public int Count()
    {
        return stream.Count;
    }

    public void Clear()
    {
        stream.Clear();
    }

    public T Dequeue()
    {
        return stream.Dequeue();
    }

    public void Enqueue(T t)
    {
        stream.Enqueue(t);
    }
}
