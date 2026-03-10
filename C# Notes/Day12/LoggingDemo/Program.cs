namespace LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddEventLog();
            // Register PersonService as singleton (to preserve data)
            builder.Services.AddSingleton<PersonService>();


            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");
            app.Logger.LogDebug("debug-message");
            app.Logger.LogInformation("info-message");
            app.Logger.LogWarning("warn-message");
            app.Logger.LogError("error-message");
            app.Logger.LogCritical("critical-message");




            // Get logger and service instances
            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            var personService = app.Services.GetRequiredService<PersonService>();

            // === DEMONSTRATE PersonService METHODS ===
            logger.LogInformation("=== Starting PersonService Demo ===");

            // 1. Get All Persons
            logger.LogInformation("1. Calling GetAllPersons()");
            var allPersons = personService.GetAllPersons();
            foreach (var person in allPersons)
            {
                logger.LogInformation($"Found person: ID={person.Id}, Name={person.Name}");
            }

            // 2. Get Person by ID
            logger.LogInformation("2. Calling GetPersonById(2)");
            var person2 = personService.GetPersonById(2);
            if (person2 != null)
                logger.LogInformation($"Person found: ID={person2.Id}, Name={person2.Name}");
            else
                logger.LogWarning("Person with ID 2 not found!");

            // 3. Add New Person
            logger.LogInformation("3. Calling AddPerson()");
            var newPerson = new Person { Id = 4, Name = "David" };
            personService.AddPerson(newPerson);
            logger.LogInformation($"Added new person: ID={newPerson.Id}, Name={newPerson.Name}");

            // Verify addition
            var updatedList = personService.GetAllPersons();
            logger.LogInformation($"Total persons now: {updatedList.Count()}");

            // Test non-existent ID
            logger.LogInformation("4. Testing GetPersonById(999)");
            var missingPerson = personService.GetPersonById(999);
            if (missingPerson == null)
                logger.LogWarning("Person ID 999 not found (expected)");

            logger.LogInformation("=== Demo Complete ===");

            // Minimal HTTP endpoint to test service (optional)
            app.MapGet("/", () => "PersonService Demo - Check console logs!");

            app.Run();


        }
    }
}
