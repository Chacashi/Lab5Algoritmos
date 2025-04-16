using UnityEngine;

public class CustomDoubleCircleList<T> : CircularDoubleLinkedList<Character>
{

    Node<Character> peak = null;
    int currentIndex = 0;


    public Node<Character> Peak => peak;
    public int CurrentIndex => currentIndex;

    public override void Add(Character value)
    {
        Node<Character> newNode = new Node<Character>(value);
        count++;
        if (head == null)
        {

            head = newNode;
            last = newNode;

            head.SetNext(head);
            head.SetPrev(head);
            currentIndex = 1;
            peak = Head;
            return;
        }

        last.SetNext(newNode);
        newNode.SetPrev(last);
        newNode.SetNext(head);

        head.SetPrev(newNode);

        last = newNode;


    }


    public override void Remove(Character value)
    {
        base.Remove(value);
    }


    public override void RemoveAll()
    {
        base.RemoveAll();
        currentIndex = 0; 
        peak = null;
    }



    public void NextCharacter()
    {
        if(count == 0)
        {
            Debug.Log("No hay personajes en la lista");
            return;
        }
        peak = peak.Next;
        if (peak.Prev == last)
            currentIndex = 1;
        else
            currentIndex++;


        ShowInfoPeek();

    }

    public void BackCharacter()
    {
        if (count == 0)
        {
            Debug.Log("No hay personajes en la lista");
            return;
        }
        peak = peak.Prev;
        if (peak.Next == head)
            currentIndex = count;
        else
            currentIndex--;


        ShowInfoPeek();

    }

    public void ShowInfoPeek()
    {
        if (peak == null)
        {
            Debug.Log("No hay personajes en la lista");
            return;
        }
        Debug.Log("Personaje actual: " + peak.Value.NameCharacter);
        Debug.Log("Index: " + currentIndex);
    }



}
