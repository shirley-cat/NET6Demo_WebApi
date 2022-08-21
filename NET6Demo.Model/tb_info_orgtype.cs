﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    public partial class tb_info_orgtype
    {
        public tb_info_orgtype()
        {
            tb_info_org = new HashSet<tb_info_org>();
        }

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 组织类型名称
        /// </summary>
        [StringLength(255)]
        public string? OrgTypeName { get; set; }
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

        [InverseProperty("OrgType")]
        public virtual ICollection<tb_info_org> tb_info_org { get; set; }
    }
}