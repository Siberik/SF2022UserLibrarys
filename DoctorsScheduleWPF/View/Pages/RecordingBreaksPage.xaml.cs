using DoctorsScheduleWPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DoctorsScheduleWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecordingBreaksPage.xaml
    /// </summary>
    public partial class RecordingBreaksPage : Page
    {
       
        
        public RecordingBreaksPage()
        {
            Core db = new Core();
            InitializeComponent();
            
            TypeEventComboBox.ItemsSource = db.context.Appointments.ToList();
            TypeEventComboBox.DisplayMemberPath = "TypeEventId";
        }

      
    }
}
