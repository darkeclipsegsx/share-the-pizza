using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ShareThePizza.Services
{
    /// <summary>
    /// Summary description for RecipeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RecipeService : System.Web.Services.WebService
    {
        [WebMethod]
        private MongoCollection<Recipe> connectRecipe()
        {
            try
            {
                //var connectionString = "mongodb://localhost/?safe=true";
                //var server = MongoServer.Create(connectionString);
                var connectionString = MongoUrl.Create("mongodb://admin:supermario@alex.mongohq.com:10071/ShareThePizza");
                var settings = connectionString.ToServerSettings();
                var server = MongoServer.Create(settings);
                //MongoServer server = MongoServer.Create();

                return server.GetDatabase("ShareThePizza", settings.DefaultCredentials, SafeMode.True).GetCollection<Recipe>("recipes");
            }
            catch (Exception m)
            {
                //write
                //Console.WriteLine(m.HelpLink);
                return null;
            }
        }

        [WebMethod]
        public Recipe GetRecipeById(string id)
        {
            Recipe recipe = null;
            MongoCollection<Recipe> recipes = connectRecipe();
            IMongoQuery idToFind = Query.EQ("_id", id);
            recipe = recipes.FindOne(idToFind);

            return recipe;
        }

        [WebMethod]
        public Recipe GetRecipeByTitle(string title)
        {
            MongoCollection<Recipe> recipeCollection = connectRecipe();
            IMongoQuery titleToFind = Query.EQ("title", title);
            Recipe recipe = recipeCollection.FindOne(titleToFind);
            return recipe;
        }




        //Potentially deprecated... will be determined later
        [WebMethod]
        public static BsonArray ToBsonDocumentArray(this IEnumerable list)
        {
            var array = new BsonArray();
            foreach (var item in list)
            {
                array.Add(item.ToBson());
            }
            return array;
        }
    }
}
