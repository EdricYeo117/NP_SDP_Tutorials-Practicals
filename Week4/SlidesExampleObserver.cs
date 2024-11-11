using System;
using System.Collections.Generic;

// Subject interface with methods to register, remove, and notify observers
interface Subject
{
    void RegisterObserver(Observer o); // Register an observer
    void RemoveObserver(Observer o);   // Remove an observer
    void NotifyObservers();            // Notify all observers of a change
}

// Observer interface with an update method to receive state changes
interface Observer
{
    void Update(float temp, float humidity, float pressure); // Update the observer with new data
}

// Concrete implementation of the Subject interface
class WeatherData : Subject
{
    private List<Observer> observers; // List to hold observers that are watching this subject
    private float temperature;        // Current temperature data
    private float humidity;           // Current humidity data
    private float pressure;           // Current pressure data

    // Constructor initializes the list of observers
    public WeatherData()
    {
        observers = new List<Observer>();
    }

    // Register an observer by adding it to the observers list
    public void RegisterObserver(Observer o)
    {
        observers.Add(o);
    }

    // Remove an observer from the observers list
    public void RemoveObserver(Observer o)
    {
        observers.Remove(o);
    }

    // Notify all registered observers by calling their update method
    public void NotifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    // This method is called when the measurements change
    public void MeasurementsChanged()
    {
        NotifyObservers(); // Notify observers about the change
    }

    // Method to simulate new weather data and notify observers
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged(); // Call MeasurementsChanged to update observers
    }
}

// Concrete observer implementation that displays current conditions
class CurrentConditionsDisplay : Observer
{
    private float temperature; // Store the temperature for display
    private float humidity;    // Store the humidity for display
    private float pressure;    // Store the pressure for display
    private Subject weatherData; // Reference to the Subject to allow deregistration if needed

    // Constructor registers itself as an observer of the provided Subject
    public CurrentConditionsDisplay(Subject weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    // Update method called by Subject with new data
    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        Display(); // Display updated data
    }

    // Display method to print the current conditions, including pressure
    public void Display()
    {
        Console.WriteLine("Current conditions: " + temperature + "F degrees, " 
                          + humidity + "% humidity, and " 
                          + pressure + " pressure");
    }
}

// Test program to demonstrate the Observer pattern
class WeatherStation
{
    static void Main(string[] args)
    {
        WeatherData weatherData = new WeatherData(); // Create the Subject

        // Create an observer and register it to receive updates from WeatherData
        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);

        // Simulate new weather measurements
        weatherData.SetMeasurements(80, 65, 30.4f);
        weatherData.SetMeasurements(82, 70, 29.2f);
        weatherData.SetMeasurements(78, 90, 29.2f);
    }
}
