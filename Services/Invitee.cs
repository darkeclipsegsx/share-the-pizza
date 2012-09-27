using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace ShareThePizza.Services
{
    public class Invitee
    {
        public BsonObjectId _id { get; set; }
        public BsonString email { get; set; }
        public BsonDateTime creationDate { get; set; }
        public BsonDateTime expirationDate { get; set; }
        public BsonString token { get; set; }

        public Invitee(string email, DateTime creationDate, DateTime expirationDate, string token)
        {
            this.email = email;
            this.creationDate = creationDate;
            this.expirationDate = expirationDate;
            this.token = token;            
        }
    }
}