namespace Assignment
{
    // Represents a pack that can hold inventory items
    public class Pack
    {
        private InventoryItem[] _items; // Array to store the inventory items

        private readonly int _maxCount; // Maximum count of items the pack can hold
        private readonly float _maxVolume; // Maximum volume the pack can hold
        private readonly float _maxWeight; // Maximum weight the pack can hold

        private int _currentCount; // Current count of items in the pack (defaults to 0)
        private float _currentVolume; // Current volume occupied in the pack
        private float _currentWeight; // Current weight of the items in the pack

        // Default constructor sets the maxCount to 10, maxVolume to 20, and maxWeight to 30
        public Pack() : this(10, 20, 30) { }

        // Constructor that allows specifying the max count, max volume, and max weight of the pack
        public Pack(int maxCount, float maxVolume, float maxWeight)
        {
            _items = new InventoryItem[maxCount]; // Initialize the array to hold inventory items
            _maxCount = maxCount; // Set the maximum count
            _maxVolume = maxVolume; // Set the maximum volume
            _maxWeight = maxWeight; // Set the maximum weight
        }

        // Getter for the maximum count
        public int GetMaxCount()
        {
            return _maxCount;
        }

        // Getter for the current count
        public int GetCurrentCount()
        {
            return _currentCount;
        }

        // Method to add an inventory item to the pack
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

        // Overrides the ToString() method to display information about the pack
        public override string ToString()
        {
            string packContents = $"Pack is currently at {_currentCount}/{_maxCount} items, {_currentWeight}/{_maxWeight} weight, and {_currentVolume}/{_maxVolume} volume.";

            return packContents;
        }
    }

    // Represents an abstract base class for inventory items
    public abstract class InventoryItem
    {
        private readonly float _volume; // Volume of the inventory item
        private readonly float _weight; // Weight of the inventory item

        // Constructor to initialize the volume and weight of the inventory item
        protected InventoryItem(float volume, float weight)
        {
            if (volume <= 0f || weight <= 0f)
            {
                throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
            }
            _volume = volume;
            _weight = weight;
        }

        // Getter for the volume of the inventory item
        public float GetVolume()
        {
            return _volume;
        }

        // Getter for the weight of the inventory item
        public float GetWeight()
        {
            return _weight;
        }

        // Abstract method to display information about the inventory item
        public abstract string Display();
    }

    // Represents an arrow inventory item
    public class Arrow : InventoryItem
    {
        public Arrow() : base(0.05f, 0.1f) { }

        public override string Display()
        {
            return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Represents a bow inventory item
    public class Bow : InventoryItem
    {
        public Bow() : base(4f, 1f) { }

        public override string Display()
        {
            return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Represents a rope inventory item
    public class Rope : InventoryItem
    {
        public Rope() : base(1.5f, 1f) { }

        public override string Display()
        {
            return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Represents a water inventory item
    public class Water : InventoryItem
    {
        public Water() : base(3f, 2f) { }

        public override string Display()
        {
            return $"Water with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Represents a food inventory item
    public class Food : InventoryItem
    {
        public Food() : base(0.5f, 1f) { }

        public override string Display()
        {
            return $"Food with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    // Represents a sword inventory item
    public class Sword : InventoryItem
    {
        public Sword() : base(3f, 5f) { }

        public override string Display()
        {
            return $"A sword with weight {GetWeight()} and volume {GetVolume()}";
        }
    }
}
