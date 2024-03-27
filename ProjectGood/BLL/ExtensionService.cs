using BLL.InterfacesBLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DTO;


namespace BLL
{
    public static class ExtensionBLL
    {
        public static void AddInjectionBLL(this IServiceCollection services) {
            services.AddAutoMapper(typeof(mapper));
        }
    }
}
