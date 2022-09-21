using PayCore.ProductCatalog.Data.Entities;
using System.ComponentModel;


namespace PayCore.ProductCatalog.Service.Enums
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.User)]
        User = 2
    }
}
