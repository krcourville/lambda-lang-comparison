using System;
using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace Contacts.Infrastructure.Models
{
    [DynamoDBTable("contacts")]
    public class Contact
    {
        [DynamoDBHashKey(AttributeName = "id")]
        public string Id { get; set; }
        
        [Required]
        [DynamoDBProperty("firstName")]
        public string FirstName { get; set; }

        [Required]
        [DynamoDBProperty("lastName")]
        public string LastName { get; set; }

        [Required]
        [DynamoDBProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [DynamoDBProperty("birthMonth")]
        public int? BirthMonth { get; set; }

        [DynamoDBProperty("birthYear")]
        public int? BirthYear { get; set; }

        [Required]
        [DynamoDBProperty("contactPhone")]
        public string ContactPhone { get; set; }

        [DynamoDBProperty("isFollowupRequired")]
        public bool IsFollowupRequired { get; set; }

        [DynamoDBProperty("followupReason")]
        public string FollowupReason { get; set; }

    }
}