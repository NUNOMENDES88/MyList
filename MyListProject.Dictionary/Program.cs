using MyListProject.Common.Models;
using MyListProject.Dictionary.Classes;

MyListClass<EmployeeModel> myListClass = new MyListClass<EmployeeModel>
{
    { 1, new EmployeeModel(1, "David", "Software Developer", 50, 1000) },
    { 2, new EmployeeModel(2, "Charlotte", "Finance", 30, 5000) },
    { 3, new EmployeeModel(3, "Elizabeth", "Marketing", 40, 3000) },
    { 4, new EmployeeModel(4, "Thomas", "Office Administration", 35, 4000) }
};
EmployeeModel getEmployeeDetail = myListClass.GetById(1);
getEmployeeDetail.Name += " 1";
myListClass.Update(1, getEmployeeDetail);
myListClass.Remove(1);
myListClass.Add(1, new EmployeeModel(1, "David", "Software Developer", 50, 1000));