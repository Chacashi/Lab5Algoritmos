using UnityEngine;

public class Stack<T> 
{
    public class NodeStack
    {
        private NodeStack prev;
        private T value;


        public NodeStack Prev => prev;

        public T Value => value;
        public NodeStack(T value)
        {
            this.value = value;
            this.prev = null;
        }


        public void SetPrev(NodeStack prev)
        {
            this.prev = prev;
        }
    }
    private NodeStack last = null;
    private int count = 0;

    public NodeStack Last => last;

    public int Count => count;
    public virtual void Push(T item)
    {
        NodeStack newNode = new NodeStack(item);
        count++;

        if (last == null)
        {
            last = newNode;
            return;
        }
        newNode.SetPrev(last);
        last = newNode;

    }
    public virtual T Pop()
    {
        if (count <= 1)
        {
            Clear();
            count = 0;
            return default;
        }
        count--;
        NodeStack popNode = last;

        last = last.Prev;
        return popNode.Value;
    }

    public virtual T Peak()
    {
        if (last == null)
            return default;
        return last.Value;
    }
    public virtual void Clear()
    {
        last = null;
    }
}

