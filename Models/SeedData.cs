

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RazorSecond.Data;

namespace RazorSecond.Models
{
    public static class SeedData
    {
        public class Stuff1
        {

            public string Name { get; set; }

            public string Gender { get; set; }

            public string Title { get; set; }

            public string Department { get; set; }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new HosDbContext(serviceProvider.GetRequiredService<DbContextOptions<HosDbContext>>()))
            {
                if (context.Stuff.Any())
                {
                }
                else
                {
                    using (StreamReader r = new StreamReader("Models/stuff.json"))
                    {
                        string json = r.ReadToEnd();
                        IList<Stuff1> array = JsonConvert.DeserializeObject<IList<Stuff1>>(json);

                        foreach (var item in array)
                        {
                            context.Stuff.Add(new Stuff
                            {
                                Name = item.Name,
                                Gender = (Gender)Enum.Parse(typeof(Gender), item.Gender),
                                Title = (Title)Enum.Parse<Title>(item.Title),
                                Department = (Department)Enum.Parse<Department>(item.Department),
                            });
                        }
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}