// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    [Index("RoleId", Name = "tb_map_role_power_ibfk_1")]
    [Index("PowerId", Name = "tb_map_role_power_ibfk_2")]
    [Index("StatusId", Name = "tb_map_role_power_ibfk_3")]
    public partial class tb_map_role_power
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int? PowerId { get; set; }
        public int? StatusId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        public int? CreateUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyAt { get; set; }
        public int? ModifyUserId { get; set; }

        [ForeignKey("PowerId")]
        [InverseProperty("tb_map_role_power")]
        public virtual tb_info_power? Power { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("tb_map_role_power")]
        public virtual tb_info_roles? Role { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("tb_map_role_power")]
        public virtual tb_info_status? Status { get; set; }
    }
}