using System;
using System.Collections;
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
        public BsonDocument ingredients { get; set; }
        public BsonInt32 cooktime { get; set; }//stores in minutes
        public BsonDocument instructions { get; set; }//may change to BsonString
        public BsonString backgroundTag { get; set; }
        public BsonArray tags { get; set; }
        public BsonDouble rating { get; set; }
        public BsonDocument comments { get; set; }//in progress should not be depended on

        public Recipe(string submittedBy, DateTime creationDate, string description, Array ingredients, TimeSpan cooktime, string[] instructions, BsonString backgroundTag, BsonArray tags, float rating)
        {
            this.submittedBy = submittedBy;
            this.creationDate = creationDate;
            this.description = description;
            this.ingredients = ingredients.ToBsonDocument();
            this.cooktime = cooktime.Minutes;
            this.instructions = instructions.ToBsonDocument();
            this.backgroundTag = backgroundTag;
            this.tags = tags;
            this.rating = rating;
        }

				///// <summary>
				///// Potentially deprecated....
				///// </summary>
				///// <param name="list"></param>
				///// <returns></returns>
				//public  BsonArray ToBsonDocumentArray(this IEnumerable list)
				//{
				//		var array = new BsonArray();
				//		foreach (var item in list)
				//		{
				//				array.Add(item.ToBson());
				//		}
				//		return array;
				//}
    }
}