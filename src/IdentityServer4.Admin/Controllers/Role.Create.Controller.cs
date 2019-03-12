using System;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.Admin.Entities;
using IdentityServer4.Admin.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.Admin.Controllers
{
    public partial class RoleController
    {
        [HttpGet("create")]
        public Task<IActionResult> CreateAsync(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return Task.FromResult<IActionResult>(View("Create", new CreateRoleViewModel()));
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <param name="dto">角色 DTO</param>
        /// <returns>创建结果</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(string returnUrl, CreateRoleViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", dto);
            }

            var role = Mapper.Map<Role>(dto);
            string normalizedName = _roleManager.NormalizeKey(role.Name);
            if (await _roleManager.Roles.AnyAsync(u => u.NormalizedName == normalizedName))
            {
                ModelState.AddModelError("Name", $"Name already exits");
                return View("Create", dto);
            }

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                AddErrors(result);
                return View("Create", dto);
            }
        }
    }
}