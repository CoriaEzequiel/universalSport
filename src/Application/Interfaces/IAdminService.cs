using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        List<Admin> GetAllAdmins();
        Admin? Get(int id);
        Admin? Get(string name);
        int AddAdmin(AdminCreateRequest request);
        void DeleteAdmin(int id);
        void UpdateAdmin(int id, AdminUpdateRequest request);
    }
}
