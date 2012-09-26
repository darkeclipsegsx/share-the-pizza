using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace ShareThePizza.Services
{
    public class Recipe
    {
        public BsonObjectId _id { get; set; }
        public BsonString submittedBy { get; set; }
        public BsonDateTime creationDate { get; set; }
        public BsonString description { get; set; }
        public BsonArray ingredients { get; set; }
        public BsonInt32 cooktime { get; set; }//stores in minutes
        public BsonArray instructions { get; set; }//may change to BsonString
        public BsonArray tags { get; set; }
        public BsonDouble rating { get; set; }
        public BsonDocument comments { get; set; }//in progress should not be depended on

        public Recipe(string submittedBy, DateTime creationDate, string description, BsonArray ingredients, TimeSpan cooktime, BsonArray instructions, BsonArray tags, float rating)
        {
            this.submittedBy = submittedBy;
            this.creationDate = creationDate;
            this.description = description;
            this.ingredients = ingredients;
            this.cooktime = cooktime.Minutes;
            this.instructions = instructions;
            this.tags = tags;
            this.rating = rating;


        }
    }
}