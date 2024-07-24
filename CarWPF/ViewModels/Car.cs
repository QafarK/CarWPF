using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CarWPF.ViewModels;

public class Car : INotifyPropertyChanged
{
    int _id;
    string? _make;
    string? _model;
    string? _year;
    string? _stnumber;

    public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
    public string? Make { get => _make; set { _make = value; OnPropertyChanged(); } }
    public string? Model { get => _model; set { _model = value; OnPropertyChanged(); } }
    public string? Year { get => _year; set { _year = value; OnPropertyChanged(); } }
    public string? Stnumber { get => _stnumber; set { _stnumber = value; OnPropertyChanged(); } }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    //public Car()
    //{

    //}
    //public Car(Car car)
    //{
    //    car.Id = Id;
    //    car.Make = _make;
    //    car.Model = _model;
    //    car.Year = _year;
    //    car.Stnumber = _stnumber;
    //}
    public override string ToString()
    {
        return $@"{Id} Make: {Make} Model: {Model} Year: {Year} Stnumber: {Stnumber}";
    }

    //public object Clone()
    //{
    //    return new Car(this);
    //}
}
