using System.ComponentModel.DataAnnotations;
using IdentityServer4.Admin.Infrastructure;

namespace IdentityServer4.Admin.ViewModels.Account
{
    /// <summary>
    /// 更新用户 DTO
    /// </summary>
    public class UpdateProfileViewModel
    {
        /// <summary>
        /// 邮件
        /// </summary>
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength(24)]
        public string NickName { get; set; }

        /// <summary>
        /// 个人网址
        /// </summary>
        [StringLength(500)]
        [Url]
        public string WebSite { get; set; }

        /// <summary>
        /// 所在地
        /// </summary>
        [StringLength(256)]
        public string Location { get; set; }

        /// <summary>
        /// 标语
        /// </summary>
        [StringLength(100)]
        public string Slogan { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        [StringLength(50)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [StringLength(100)]
        public string Title { get; set; }
    }
}