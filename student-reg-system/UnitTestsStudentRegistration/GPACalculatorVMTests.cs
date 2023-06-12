using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using student_reg_system.Models;
using System.Collections.ObjectModel;

namespace student_reg_system.UnitTestsStudentRegistration
{
    public class GPACalculatorVMTests
    {
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
            var mockContext = new Mock<StudentContext>();
            mockContext.Setup(c => c.Students.Include(s => s.Modules))
                       .Returns(new List<Student> { student }.AsQueryable());
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
