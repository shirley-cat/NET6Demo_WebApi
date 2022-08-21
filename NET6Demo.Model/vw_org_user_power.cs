﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET6Demo.Model
{
    [Keyless]
    public partial class vw_org_user_power
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 用户名称（昵称）
        /// </summary>
        [StringLength(255)]
        public string? UserName { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        [StringLength(100)]
        public string? UserCode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? UserStatus { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        public int? OrgId { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        [StringLength(255)]
        public string? OrgName { get; set; }
        /// <summary>
        /// 组织编码
        /// </summary>
        [StringLength(100)]
        public string? OrgCode { get; set; }
        /// <summary>
        /// 状态ID
        /// </summary>
        public int? OrgStatus { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int? PowerId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [StringLength(255)]
        public string? PowerName { get; set; }
        /// <summary>
        /// 权限说明
        /// </summary>
        [StringLength(1000)]
        public string? Note { get; set; }
        /// <summary>
        /// 授权页面
        /// </summary>
        [StringLength(3000)]
        public string? Url { get; set; }
        /// <summary>
        /// 权限code
        /// </summary>
        [StringLength(100)]
        public string? PowerCode { get; set; }
        /// <summary>
        /// 权限模块
        /// </summary>
        [StringLength(255)]
        public string? PowerModule { get; set; }
        /// <summary>
        /// 权限方法
        /// </summary>
        [StringLength(255)]
        public string? FuncName { get; set; }
        /// <summary>
        /// 状态Id
        /// </summary>
        public int? PowerStatus { get; set; }
        public int? UserPowerStatus { get; set; }
    }
}