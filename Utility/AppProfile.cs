using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Utility
{
    public class AppProfile : AutoMapper.Profile
    {
        public AppProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ReverseMap();
            CreateMap<Department, DepartmentViewModel>()
                .ReverseMap();
            CreateMap<CashAdvance, CashAdvanceViewModel>()
                .ReverseMap();
        }
    }
}
