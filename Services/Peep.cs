using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
namespace ShareThePizza
{
    class Peep
    {
        public BsonObjectId _id { get; set; }
        public BsonString username { get; set; }
        public BsonString hashedUsername { get; set; }
        public BsonString password { get; set; }
        public BsonString email { get; set; }
        public BsonDateTime dateJoined { get; set; }
        public BsonString salt { get; set; }
        public BsonBoolean currentlyLoggedIn { get; set; }
        public BsonInt32 loginAttempts { get; set; }
        public BsonDateTime expirationDate { get; set; }

        public Peep(string username, string hashedUsername, string password, string email, DateTime dateJoined, string salt, bool currentlyLoggedIn, int loginAttempts, DateTime expirationDate)
        {
            this.username = username;
            this.hashedUsername = hashedUsername;
            this.password = password;
            this.email = email;
            this.dateJoined = dateJoined;
            this.salt = salt;
            this.currentlyLoggedIn = currentlyLoggedIn;
            this.loginAttempts = loginAttempts;
            this.expirationDate = expirationDate;
        }
    }
}
