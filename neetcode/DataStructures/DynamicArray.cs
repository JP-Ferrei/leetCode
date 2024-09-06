namespace neetcode.DataStructures;

public class DynamicArray
{
    private int _capacity = 0;
    private int _size = 0;
    private int?[] _array;

    public DynamicArray(int capacity)
    {
        Console.WriteLine("null");
        _array = new int?[capacity];
        _capacity = capacity;
    }

    public int? Get(int i)
    {
        return _array[i];
    }

    public void Set(int i, int n)
    {
        _array[i] = n;
    }

    public void PushBack(int n)
    {
        Console.WriteLine("null");
        if (_size == _capacity)
        {
            Resize();
        }
        _array[_size] = n;
        _size++;
    }

    public int? PopBack()
    {
        Console.WriteLine($"size {_size} capacity {_capacity}");
        var data = _array[_size - 1];
        _array[_size - 1] = null;
        _size--;
        return data;
    }

    private void Resize()
    {
        var newCapacity = _capacity * 2;
        var newArray = new int?[newCapacity];
        for (int i = 0; i < _capacity; i++)
        {
            newArray[i] = _array[i];
        }

        _array = newArray;
        _capacity = newCapacity;
    }

    public int GetSize()
    {
        return _size;
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public void Print()
    {
        Console.WriteLine(string.Join(", ", _array));
    }
}
