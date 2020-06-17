

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorSecond.Data;

namespace RazorSecond.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HosDbContext(serviceProvider.GetRequiredService<DbContextOptions<HosDbContext>>()))
            {
                if (context.Stuff.Any())
                {
                    return;
                }
                context.Stuff.AddRange(
                    new Stuff()
                    {
                        Name = "刘增业",
                        Gender = Gender.male,
                        Title = Title.主任医师,
                        Department = Department.口腔科,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}