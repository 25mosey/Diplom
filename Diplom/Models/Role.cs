using System;
using System.Collections.Generic;

namespace Diplom.Models;

public partial class Role
{
    public string RoleName { get; set; } = null!;

    public string? RoleAccess { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
