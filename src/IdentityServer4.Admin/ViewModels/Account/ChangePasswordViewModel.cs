using System.ComponentModel.DataAnnotations;

namespace IdentityServer4.Admin.ViewModels.Account
{
    /// <summary>
    /// 修改密码 DTO
    /// </summary>
    public class ChangePasswordViewModel
    {
        [Required]
        [StringLength(24, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "重复密码")]
        [Compare("NewPassword", ErrorMessage = "两次密码不一致")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        [Required]
        public string OldPassword { get; set; }
    }
}