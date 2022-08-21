using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NET6Demo.Model;
using NET6Demo.Utility.ApiResult;
using NET6Demo.Utility.Authorize;
using NET6Demo.Utility.Autofac;
using NET6Demo.Utility.ErrorHandler;
using NET6Demo.Utility.Log;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var basePath = AppContext.BaseDirectory;
var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
// Add services to the container.

builder.Services.Configure<IConfiguration>(config);
builder.Services.AddSingleton(new CommonCode.Helper.AppsettingHelper(config));
builder.Services.AddControllers();

#region 添加Swagger注释

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for NE6Demo ToDo items",

    });

    var xmlPath = Path.Combine($"{basePath}/ApiDoc", "NET6Demo.xml");
    options.IncludeXmlComments(xmlPath);
    //开启swagger页面的Authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 在下方输入Bearer {token} 即可，注意两者之间有空格", 
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },Scheme = "oauth2",Name = "Bearer",In=ParameterLocation.Header,
            },new List<string>()
        }
    });



});

#endregion

#region 注入数据库

var conn = config.GetConnectionString("AuthDb");

builder.Services.AddEntityFrameworkMySql().AddDbContext<auth_dbContext>(options => options.UseMySql(conn, ServerVersion.Parse("8.0.29-mysql")));

#endregion

#region 添加Log4net

builder.Host.ConfigureLogging((context, loggingBuilder) =>
{
    Log4Extention.InitLog4(loggingBuilder);
});



#endregion

#region 添加Autofac

//替换内置的ServiceProviderFactory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{

    containerBuilder.RegisterModule<AutofacModule>();

});
#endregion

#region 添加身份验证JWT

builder.Services.AddSingleton<
    IAuthorizationMiddlewareResultHandler, Net6DemoAuthorizationMiddleware>();


//添加jwt验证：
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});
#endregion

#region 统一返回值
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ApiResultFilterAttribute>();
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region 启用swaggerUI

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
    c.RoutePrefix = String.Empty;
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
    c.DefaultModelExpandDepth(-1);
});
#endregion


#region 统一异常处理
app.UseMiddleware<ExceptionHandlingMiddleware>();
#endregion
app.UseHttpsRedirection();


#region 启用身份验证
//下面的app添加这个  和这个长得很像  app.UseAuthorization();
app.UseAuthentication();//在前
app.UseAuthorization();//在后
#endregion

app.MapControllers();

app.Run();
