using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models
{
    public class SuperHero
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key] This means, that you can’t specify the Id value for the property yourself. You’ll need to use whatever the database gives you, and if you try to specify the value on insert , you’ll get the error
        // to avoid such error , and use your own Id and save it as a property on creating a data, use the above []. for example if you need to use the Universal Id(UUID) ...
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;
    }
}
