using System;
using System.Collections.Generic;

namespace mAUI.Models;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public DateTime? RegistrationDate { get; set; }
}
