using MyListProject.Common.Models;
using System.Collections;

namespace MyListProject.Arrays.Comparers
{
    public class EmployeeNameComparer : IComparer<EmployeeModel>
    {
        public int Compare(EmployeeModel? atual, EmployeeModel? next)
        {
            if (atual == null)
                return -1;
            if (next == null)
                return 1;
            return (new CaseInsensitiveComparer()).Compare(atual.Name, next.Name);
        }
    }
}
