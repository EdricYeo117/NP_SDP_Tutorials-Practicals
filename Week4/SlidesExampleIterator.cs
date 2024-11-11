class OddIterator : Iterator {
    List<int> values;
    int position = 0;

public OddIterator(List<int> values) {
    this.values = values;
    // Move position to first odd number, skip even numbers
    while ((position < values.Count) && (values[position] % 2 != 0)) {
        position++;
    }
}

public bool hasNext() {
    return position < values.Count;
}

public object next() {
    int value = values[position];
    position++;
    // Move position to next odd number, skip even numbers
    while ((position < values.Count) && (values[position] % 2 != 1)) {
        position++;
    }
    return value;
}

}

interface Iterator {
    public bool hasNext();
    public object next();
}

// Example usage
List<int> list = new List<int>();
list.Add(1);
list.Add(2);
list.Add(3);

// Create an iterator for odd numbers
OddIterator oddIterator = new OddIterator(list);
while (oddIterator.hasNext()) {
    Console.WriteLine((int)oddIterator.next());
}