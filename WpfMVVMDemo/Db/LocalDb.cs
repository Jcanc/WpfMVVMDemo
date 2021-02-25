using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMDemo.Models;

namespace WpfMVVMDemo.Db
{
    public class LocalDb
    {
        public LocalDb()
        {
            Init();
        }

        List<Student> lstStu;
        public void Init()
        {
            lstStu = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "小明",
                    Sex = "男",
                    Hobby = "篮球、跑步",
                    BirthDate = Convert.ToDateTime("2014/1/14")
                },
                new Student
                {
                    Id = 2,
                    Name = "小红",
                    Sex = "女",
                    Hobby = "跳绳",
                    BirthDate = Convert.ToDateTime("2014/5/19")
                },
                new Student
                {
                    Id = 3,
                    Name = "小军",
                    Sex = "男",
                    Hobby = "足球",
                    BirthDate = Convert.ToDateTime("2013/11/14")
                },
                new Student
                {
                    Id = 4,
                    Name = "小芳",
                    Sex = "女",
                    Hobby = "唱歌、画画",
                    BirthDate = Convert.ToDateTime("2014/3/5")
                },
                new Student
                {
                    Id = 5,
                    Name = "小李",
                    Sex = "男",
                    Hobby = "武术",
                    BirthDate = Convert.ToDateTime("2014/10/25")
                }
            };
        }

        public Student GetStudentById(int id)
        {
            var data = lstStu.FirstOrDefault(o => o.Id == id);
            return data;
        }

        public List<Student> GetStudentByName(string name)
        {
            var dataList = lstStu.FindAll(o => o.Name.Contains(name));
            return dataList;
        }

        public void Add(Student stu)
        {
            if (stu != null)
            {
                lstStu.Add(stu);
            }
        }

        public void Del(int id)
        {
            var data = lstStu.FirstOrDefault(o => o.Id == id);
            if (data != null)
            {
                lstStu.Remove(data);
            }
        }
    }
}
