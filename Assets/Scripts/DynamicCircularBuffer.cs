using System.Collections.Generic;

public class DynamicCircularBuffer<T>
{
    private T[] buffer;
    private int head;
    private int tail;
    private int count;

    public DynamicCircularBuffer(int initialCapacity)
    {
        buffer = new T[initialCapacity];
        head = 0;
        tail = 0;
        count = 0;
    }

    public int Count => count;

    public int Capacity => buffer.Length;

    public void Add(T item, int addedCapacity = 0)
    {
        if (count == buffer.Length)
            RemoveOldest();

        buffer[head] = item;
        head = (head + 1) % buffer.Length;
        count++;
    }

    public T RemoveOldest()
    {
        if (count == 0)
            throw new System.InvalidOperationException("Buffer is empty.");

        T oldestItem = buffer[tail];
        tail = (tail + 1) % buffer.Length;
        count--;

        return oldestItem;
    }

    public void IncreaseCapacity(int addedCapacity)
    {
        int newCapacity = buffer.Length + addedCapacity;
        T[] newBuffer = new T[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newBuffer[i] = buffer[(tail + i) % buffer.Length];
        }

        buffer = newBuffer;
        head = count;
        tail = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
            {
                int realIndex = (tail + index) % buffer.Length;
                return buffer[realIndex];
            }
            else
            {
                throw new System.IndexOutOfRangeException();
            }
        }
    }
}