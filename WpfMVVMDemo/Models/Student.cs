using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMDemo.Models
{
    public class Student : ViewModelBase
    {
        /// <summary>
        /// id
        /// </summary>
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 性别
        /// </summary>
        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 爱好
        /// </summary>
        private string hobby;
        public string Hobby
        {
            get { return hobby; }
            set { hobby = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; RaisePropertyChanged(); }
        }
    }
}
