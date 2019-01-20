using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfExperiment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> users = new ObservableCollection<User>();

        public void AddUser(object sender, RoutedEventArgs e)
        {
            users.Add(new User { Name = txtBxName.Text, Surname = txtBxSurname.Text });
        }

        public MainWindow()
        {
            InitializeComponent();
            users.Add(new User { Name = "Friedrich", Surname = "Nietzsche" });
            users.Add(new User { Name = "Arthur", Surname = "Schopenhauer" });

            lstBxUsers.ItemsSource = users;
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lstBxUsers.SelectedItem != null)
            {
                users.Remove(lstBxUsers.SelectedItem as User);
            }
        }
    }


    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }


        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    this.surname = value;
                    this.NotifyPropertyChanged("Surname");
                }
            }
        }


        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
