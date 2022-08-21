﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    public partial class tb_info_status
    {
        public tb_info_status()
        {
            tb_info_licesen = new HashSet<tb_info_licesen>();
            tb_info_org = new HashSet<tb_info_org>();
            tb_info_power = new HashSet<tb_info_power>();
            tb_info_roles = new HashSet<tb_info_roles>();
            tb_info_user = new HashSet<tb_info_user>();
            tb_map_role_power = new HashSet<tb_map_role_power>();
            tb_map_user_org = new HashSet<tb_map_user_org>();
            tb_map_user_power = new HashSet<tb_map_user_power>();
            tb_map_user_roles = new HashSet<tb_map_user_roles>();
        }

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        [StringLength(255)]
        public string? StatusName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(1000)]
        public string? Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        public int? CreateUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyAt { get; set; }
        public int? ModifyUserId { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<tb_info_licesen> tb_info_licesen { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<tb_info_org> tb_info_org { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<tb_info_power> tb_info_power { get; set; }
        [InverseProperty("StatusNavigation")]
        public virtual ICollection<tb_info_roles> tb_info_roles { get; set; }
        [InverseProperty("StatusNavigation")]
        public virtual ICollection<tb_info_user> tb_info_user { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<tb_map_role_power> tb_map_role_power { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<tb_map_user_org> tb_map_user_org { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<tb_map_user_power> tb_map_user_power { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<tb_map_user_roles> tb_map_user_roles { get; set; }
    }
}