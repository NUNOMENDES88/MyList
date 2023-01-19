using MyListProject.Common.Models;

namespace MyListProject.Arrays.Comparers
{
    public class EmployeeAgeComparer : IComparer<EmployeeModel>
    {
        public int Compare(EmployeeModel? atual, EmployeeModel? next)
        {
            if (atual == null)
                return -1;
            if (next == null)
                return 1;
            return atual.Age.CompareTo(next.Age);
        }
    }
}
