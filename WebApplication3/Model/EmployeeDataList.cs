using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication3.Model
{
    public class EmployeeView
    {
        public int Id { get; set; }


        [Display(Name= "Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле {0} является обязательным")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength:8, MinimumLength = 2,ErrorMessage = "Длина имени не должа быть меньше 2х символов и больше 8")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "Поле {0} является обязательным")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле {0} является обязательным")]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }


        [Display(Name = "Почта")]
        [RegularExpression("^[-._a-z0-9]+@(?:[a-z0-9][-a-z0-9]+\\.)+[a-z]{2,6}$", ErrorMessage = "Введите корректный Email в формате email@host.domen")]
        public string Email { get; set; }

        [Display(Name = "Зарплата")]
        public int Salary { get; set; }

        public string Department { get; set; }


    }

    public interface IEmployeeData
    {
        IEnumerable<EmployeeView> GetAll();
        EmployeeView GetById(int id);
        void Comit();
        void AddNew(EmployeeView empl);
        void Delete(int id);
    //    void Edit(int? id);
    }

    public class EmployeeDataList:IEmployeeData
    {
        private readonly List<EmployeeView> _employee;


        public EmployeeDataList()
        {
            _employee= new List<EmployeeView>(3)
            {
                new EmployeeView(){Id = 1,Age = 23,Department = "Sales",LastName = "Иванов",Name = "Дмитрий",SecondName = "Петрович", Salary = 70000, Email = "PetrovichDI@mail.ru"},
                new EmployeeView(){Id = 2,Age = 32,Department = "Programmer",LastName = "Ильха",Name = "Ольга",SecondName = "Александровна", Salary = 40000, Email = "IlhaOA@gmail.com"},
                new EmployeeView(){Id = 3,Age = 45,Department = "Director",LastName = "Самин",Name = "Роман",SecondName = "Федорович", Salary = 1000, Email = "SaminRF@yandex.ru"}
            };
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employee;
        }

        public EmployeeView GetById(int id)
        {
            return _employee.Find(em => em.Id == id);
        }

        public void Comit()
        {
        }

        public void AddNew(EmployeeView empl)
        {
            empl.Id = _employee.Max(e => e.Id) + 1;
            _employee.Add(empl);
        }

        public void Delete(int id)
        {
            _employee.Remove(_employee.Find(em=>em.Id==id));
        }

      
    }
}
