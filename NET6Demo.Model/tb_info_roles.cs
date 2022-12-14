// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    [Index("Status", Name = "tb_info_roles_ibfk_1")]
    [Index("ParentId", Name = "tb_info_roles_ibfk_2")]
    public partial class tb_info_roles
    {
        public tb_info_roles()
        {
            InverseParent = new HashSet<tb_info_roles>();
            tb_map_role_power = new HashSet<tb_map_role_power>();
            tb_map_user_roles = new HashSet<tb_map_user_roles>();
        }

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [StringLength(255)]
        public string? RoleName { get; set; }
        /// <summary>
        /// 角色说明
        /// </summary>
        [StringLength(1000)]
        public string? Note { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyAt { get; set; }
        public int? ParentId { get; set; }
        /// <summary>
        /// 角色代码
        /// </summary>
        [StringLength(100)]
        public string? RoleCode { get; set; }
        public int? CreateUserId { get; set; }
        public int? ModifyUserId { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual tb_info_roles? Parent { get; set; }
        [ForeignKey("Status")]
        [InverseProperty("tb_info_roles")]
        public virtual tb_info_status? StatusNavigation { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<tb_info_roles> InverseParent { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<tb_map_role_power> tb_map_role_power { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<tb_map_user_roles> tb_map_user_roles { get; set; }
    }
}