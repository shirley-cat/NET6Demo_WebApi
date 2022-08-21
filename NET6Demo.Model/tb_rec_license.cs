﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    [Index("OrgId", Name = "tb_rec_license_ibfk_1")]
    [Index("licensetype", Name = "tb_rec_license_ibfk_2")]
    public partial class tb_rec_license
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        public int? OrgId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 授权类型ID
        /// </summary>
        public int? licensetype { get; set; }
        public int? CreateUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyAt { get; set; }
        public int? ModifyUserId { get; set; }

        [ForeignKey("OrgId")]
        [InverseProperty("tb_rec_license")]
        public virtual tb_info_org? Org { get; set; }
        [ForeignKey("licensetype")]
        [InverseProperty("tb_rec_license")]
        public virtual tb_info_licesen? licensetypeNavigation { get; set; }
    }
}