using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using student_reg_system.Models;
using student_reg_system.database;
using student_reg_system.ViewModels;
using System.Collections.ObjectModel;
using Moq;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Microsoft.Extensions.DependencyInjection;

namespace student_reg_system.UnitTestsStudentRegistration
{
    public class GPACalculatorVMTests
    {

        private readonly string _path = @"D:\UOR education\SEM03\PP-Project\GUI-Project\Student-Registration-System\student-reg-system\sqlite\StudentData.db";
        [Fact]
        public void SearchCommand_FetchesStudentFromDatabase()
        {
            // Arrange
            var studentId = 1;
            var studentName = "John Doe";
            var studentEmail = "john.doe@example.com";
            var moduleList = new List<Module>()
            {
                new Module { ModuleId = 1, Grade = "A", CreditValue = 3 },
                new Module { ModuleId = 2, Grade = "B+", CreditValue = 4 },
                new Module { ModuleId = 3, Grade = "C", CreditValue = 2 }
            };
            var student = new Student
            {
                StudentIDStudent = studentId,
                FirstNameStudent = "John",
                LastNameStudent = "Doe",
                EmailAdress = studentEmail,
                Modules = moduleList
            };

            var serviceProvider = new ServiceCollection()
                .AddDbContext<StudentContext>(optionsBuilder => optionsBuilder.UseSqlite($"DataSource={_path}"))
                .BuildServiceProvider();

            var vm = new GPACalculatorVM { StudentId = studentId };
            vm.ModuleList = new ObservableCollection<Module>();

            // Act
            vm.Search();

            // Assert
            Assert.Equal(studentName, vm.StudentName);
            Assert.Equal(studentEmail, vm.StudenEmail);
            Assert.Equal(moduleList.Count, vm.ModuleList.Count);
            for (int i = 0; i < moduleList.Count; i++)
            {
                Assert.Equal(moduleList[i].ModuleId, vm.ModuleList[i].ModuleId);
                Assert.Equal(moduleList[i].Grade, vm.ModuleList[i].Grade);
                Assert.Equal(moduleList[i].CreditValue, vm.ModuleList[i].CreditValue);
            }
        }

    }
}
