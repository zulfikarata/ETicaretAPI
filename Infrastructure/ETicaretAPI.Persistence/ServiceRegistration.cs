﻿using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Services.Authentications;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using ETicaretAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            

            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ETicaretAPIDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IFileReadRepository,FileReadRepository>();
            services.AddScoped<IFileWriteRepository,FileWriteRepository>();

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<ICompletedOrderReadRepository,CompletedOrderReadRepository>();
            services.AddScoped<ICompletedOrderWriteRepository,CompletedOrderWriteRepository>();
            services.AddScoped<IEndpointReadRepository,EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository,EndpointWriteRepoistory>();
            services.AddScoped<IMenuReadRepository,MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository,MenuWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication,AuthService>();
            services.AddScoped<IInternalAuthentication,AuthService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService,AuthorizationEndpointService>();
        }
    }
}
