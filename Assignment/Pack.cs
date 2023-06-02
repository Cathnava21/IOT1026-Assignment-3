namespace Assignment;

public class Pack
{
    private InventoryItem[] _items;

    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;

    private int _currentCount; // Defaults to 0
    private float _currentVolume;
    private float _currentWeight;


    // Default constructor sets the maxCount to 10 
    // maxVolume to 20 
    // maxWeight to 30
    public Pack() : this(10, 20, 30) { }

    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        _items = new InventoryItem[maxCount];
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
    }

    // This is called a getter
    public int GetMaxCount()
    {
        return _maxCount;
    }

    public bool Add(InventoryItem item)
    {
        float weight = item.GetWeight();
        float volume = item.GetVolume();
        if (volume <= _maxVolume && (_currentVolume + volume) <= _maxVolume &&
            (_currentWeight + weight) <= _maxWeight && _currentCount < _maxCount)
        {
            _currentWeight += weight;
            _currentVolume += volume;
            _items[_currentCount++] = item;
            return true;
        }
        return false;
    }

    // Implement this class
    public override string ToString()
    {
        string packContents = $"Pack is currently at {_currentCount}/{_maxCount} items, {_currentWeight}/{_maxWeight} weight, and {_currentVolume}/{_maxVolume} volume.";

        return packContents;
    }
}

public abstract class InventoryItem
{
    private readonly float _volume;
    private readonly float _weight;

    protected InventoryItem(float volume, float weight)
    {
        if (volume <= 0f || weight <= 0f)
        {
            throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
        }
        _volume = volume;
        _weight = weight;
    }

    public float GetVolume()
    {
        return _volume;
    }

    public float GetWeight()
    {
        return _weight;
    }

    public abstract string Display();
}

class Arrow : InventoryItem
{
    public Arrow() : base(0.05f, 0.1f) { }

    public override string Display()
    {
        return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
    }
}

class Bow : InventoryItem
{
    public Bow() : base(4f, 1f) { }

    public override string Display()
    {
        return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
    }
}

class Rope : InventoryItem
{
    public Rope() : base(1.5f, 1f) { }

    public override string Display()
    {
        return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
    }
}

class Water : InventoryItem
{
    public Water() : base(3f, 2f) { }

    public override string Display()
    {
        return $"Water with weight {GetWeight()} and volume {GetVolume()}";
    }
}

class Food : InventoryItem
{
    public Food() : base(0.5f, 1f) { }

    public override string Display()
    {
        return $"Food with weight {GetWeight()} and volume {GetVolume()}";
    }
}

class Sword : InventoryItem
{
    public Sword() : base(3f, 5f) { }

    public override string Display()
    {
        return $"A sword with weight {GetWeight()} and volume {GetVolume()}";
    }
}
