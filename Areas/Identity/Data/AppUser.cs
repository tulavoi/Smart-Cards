using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SmartCards.Models;
using static NuGet.Packaging.PackagingConstants;

namespace SmartCards.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public string AvatarFileName { get; set; } = string.Empty;
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<Folder> Folders { get; set; } = new List<Folder>();
}

