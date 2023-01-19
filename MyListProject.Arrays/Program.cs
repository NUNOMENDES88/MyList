using MyListProject.Arrays.Classes;
using MyListProject.Arrays.Comparers;
using MyListProject.Common.Models;
MyListClass<EmployeeModel> myListClass = new MyListClass<EmployeeModel>
{
    new EmployeeModel(10, "David", "Software Developer", 50, 1000),
    new EmployeeModel(2, "Charlotte", "Finance", 30, 5000),
    new EmployeeModel(30, "Elizabeth", "Marketing", 40, 3000),
    new EmployeeModel(4, "Thomas", "Office Administration", 35, 4000)
};
myListClass.Sort(new  EmployeeAgeComparer());
myListClass.Sort(new EmployeeNameComparer());
Predicate<EmployeeModel> predicate = new(x => x.Id == 4);
EmployeeModel getEmployeeDetail = myListClass.GetById(predicate);
getEmployeeDetail.Name += " 1";
myListClass.Update(predicate, getEmployeeDetail);
myListClass.Remove(predicate);
myListClass.Add(new EmployeeModel(1, "David", "Software Developer", 50, 1000));