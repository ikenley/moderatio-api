
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Amazon.DynamoDBv2.DataModel;

namespace ModaratioApi.Models
{
    [DynamoDBTable("Recipe")]
    public class Recipe
    {
        private const int MaxKeyNameLength = 100;

        [DynamoDBHashKey]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string ImageSource { get; set; }

        public string AuthorId { get; set; }

        public Recipe() { }

        public Recipe(string name, string description, string url, string imageSource, string authorId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Url = url;
            ImageSource = imageSource;
            AuthorId = authorId;
        }
    }
}