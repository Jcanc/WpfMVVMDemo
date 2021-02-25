using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVMDemo.Db;
using WpfMVVMDemo.Models;
using WpfMVVMDemo.Views;

namespace WpfMVVMDemo.ViewModels
{
    public class ViewStudentModel : ViewModelBase
    {
        private string search = string.Empty;
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Student> gridModelList;
        public ObservableCollection<Student> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value; RaisePropertyChanged(); }
        }

        public RelayCommand QueryCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand<int> DelCommand { get; set; }

        private LocalDb localDb;
        public ViewStudentModel()
        {
            localDb = new LocalDb();
            QueryCommand = new RelayCommand(Query);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand<int>(Edit);
            ResetCommand = new RelayCommand(Reset);
            DelCommand = new RelayCommand<int>(Del);
        }

        public void Query()
        {
            var dataList = localDb.GetStudentByName(Search);
            GridModelList = new ObservableCollection<Student>();
            if (dataList != null)
            {
                dataList.ForEach(o => GridModelList.Add(o));
            }
        }

        public void Add()
        {
            var stu = new Student();
            var view = new ViewStudent("新增学生：", stu);
            var r = view.ShowDialog();
            if (r.Value)
            {
                stu.Id = GridModelList.Max(o => o.Id) + 1;
                localDb.Add(stu);
                Query();
            }
        }

        public void Edit(int id)
        {
            var data = localDb.GetStudentById(id);
            if (data != null)
            {
                var tData = new Student
                {
                    Id = data.Id,
                    Name = data.Name,
                    Sex = data.Sex,
                    Hobby = data.Hobby,
                    BirthDate = data.BirthDate
                };

                var view = new ViewStudent("编辑学生：", data);
                var r = view.ShowDialog();
                if (!r.Value)
                {
                    var model = GridModelList.FirstOrDefault(o => o.Id == id);
                    model.Name = tData.Name;
                    model.Sex = tData.Sex;
                    model.Hobby = tData.Hobby;
                    model.BirthDate = tData.BirthDate;
                }
            }
        }

        public void Reset()
        {
            Search = string.Empty;
            localDb.Init();
            Query();
        }

        public void Del(int id)
        {
            var data = localDb.GetStudentById(id);
            if (data != null)
            {
                var r = MessageBox.Show($"是否删除学生：{data.Name}？", "删除学生", MessageBoxButton.YesNoCancel);
                if (r == MessageBoxResult.Yes)
                {
                    localDb.Del(id);
                    Query();
                }
                
            }
        }
    }
}
