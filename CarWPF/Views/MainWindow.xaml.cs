using CarWPF.Models;
using CarWPF.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CarWPF;


public partial class MainWindow : Window, INotifyPropertyChanged
{
    Car? _car;
    ObservableCollection<Car>? _cars;
    public Car? CarT { get => _car; set { _car = value; OnPropertyChanged(); } }
    public ObservableCollection<Car>? ListCars { get => _cars; set { _cars = value; OnPropertyChanged(); } }
    public string? Data { get; private set; }

    public MainWindow()
    {
        CarT = new Car();
        ListCars = new ObservableCollection<Car>();
        InitializeComponent();
        DataContext = this;
        using (CarContext db = new CarContext())
        {
            ListCars = new(db.Cars.ToList());
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using CarContext db = new CarContext();
        {
            if (CarT is not null)
            {
                db.Cars.Add(CarT);
                db.SaveChanges();
                ListCars!.Add(CarT);
                CarT = new Car();
            }
        }
    }

    private void listView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        var item = sender as ListView;
        if (item is not null && item.SelectedItem is not null)
            Data = item.SelectedItem.ToString();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e) //update
    {
        using (CarContext db = new CarContext())
        {
            if (Data is not null)
            {
                var id = Convert.ToInt32(Data.Split(' ')[0]);

                var selectedcar = db.Cars.FirstOrDefault(c => c.Id.Equals(id));
                if (selectedcar is not null && CarT is not null)
                {
                    selectedcar.Make = CarT.Make;
                    selectedcar.Model = CarT.Model;
                    selectedcar.Year = CarT.Year;
                    selectedcar.Stnumber = CarT.Stnumber;

                    db.Cars.Update(selectedcar);
                    db.SaveChanges();

                    ListCars = new(db.Cars.ToList());
                }
            }
        }
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        using (CarContext db = new CarContext())
        {

            if (Data is not null)
            {
                var id = Convert.ToInt32(Data.Split(' ')[0]);

                var selectedcar = db.Cars.FirstOrDefault(c => c.Id.Equals(id));
                if (selectedcar is not null)
                {

                    db.Cars.Remove(selectedcar);
                    db.SaveChanges();

                    ListCars = new(db.Cars.ToList());
                }
            }
        }

    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}