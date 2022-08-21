﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    [Index("OrgId", Name = "tb_map_user_org_ibfk_1")]
    [Index("UserId", Name = "tb_map_user_org_ibfk_2")]
    [Index("StatusId", Name = "tb_map_user_org_ibfk_3")]
    public partial class tb_map_user_org
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        public int? OrgId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        public int? CreateUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyAt { get; set; }
        public int? ModifyUserId { get; set; }

        [ForeignKey("OrgId")]
        [InverseProperty("tb_map_user_org")]
        public virtual tb_info_org? Org { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("tb_map_user_org")]
        public virtual tb_info_status? Status { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("tb_map_user_org")]
        public virtual tb_info_user? User { get; set; }
    }
}