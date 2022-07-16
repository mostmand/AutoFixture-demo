using AutoFixtureDemo.Data.Abstraction;
using AutoFixtureDemo.Entities;

namespace AutoFixtureDemo.Data;

public static class DbInitializer
    {
        public static async Task InitializeAsync(IPeopleContext context)
        {
            await context.Database.EnsureCreatedAsync();
            
            if (context.People.Any())
            {
                return;
            }

            var people = new Person[]
            {
                new("1", "Asghar", "Asghari"),
                new("2", "Akbar", "Akbari")
            };
            foreach (var person in people)
            {
                context.People.Add(person);
            }
            await context.SaveChangesAsync(CancellationToken.None);
        }
    }