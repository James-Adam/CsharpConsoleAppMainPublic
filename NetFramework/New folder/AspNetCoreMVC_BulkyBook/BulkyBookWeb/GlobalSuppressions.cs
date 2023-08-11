// This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to
// this project. Project-level suppressions either have no target or are given a specific target and
// scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out",
        Justification = "<Pending>")]
[assembly:
    SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out",
        Justification = "<Pending>", Scope = "member",
        Target =
            "~M:BulkyBookWeb.Controllers.CategoryController.Delete(System.Nullable{System.Int32})~Microsoft.AspNetCore.Mvc.IActionResult")]
[assembly:
    SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out",
        Justification = "<Pending>", Scope = "member",
        Target =
            "~M:BulkyBookWeb.Controllers.CategoryController.Edit(System.Nullable{System.Int32})~Microsoft.AspNetCore.Mvc.IActionResult")]
[assembly:
    SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations",
        Justification = "<Pending>", Scope = "member",
        Target =
            "~M:BulkyBookWeb.Controllers.CategoriesTempController.Delete(System.Nullable{System.Int32})~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly:
    SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations",
        Justification = "<Pending>", Scope = "member",
        Target =
            "~M:BulkyBookWeb.Controllers.CategoryController.Delete(System.Nullable{System.Int32})~Microsoft.AspNetCore.Mvc.IActionResult")]