using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfMVVMDemo.Models;

namespace WpfMVVMDemo.Views
{
    /// <summary>
    /// ViewStudent.xaml 的交互逻辑
    /// </summary>
    public partial class ViewStudent : Window
    {
        private List<string> lstSex = new List<string>
        {
            "男","女","未知"
        };

        public ViewStudent(string title, Student stu)
        {
            InitializeComponent();

            this.DataContext = new
            {
                Model = stu,
                Title = title
            };

            cbSex.ItemsSource = lstSex;
            if (title.Equals("新增学生："))
            {
                stu.BirthDate = DateTime.Now;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
