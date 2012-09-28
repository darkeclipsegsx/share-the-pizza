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

        [WebMethod]
        public bool ChangeTitle(string id, string newTitle)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newTitleUpdate= Update.Set("title",newTitle);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("title"),newTitleUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }

        [WebMethod]
        public bool ChangeDescription(string id, string newDescription)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newDescriptionUpdate = Update.Set("description", newDescription);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("description"), newDescriptionUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }

        [WebMethod]
        public bool ChangeIngredients(string id, string newIngredients)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newIngredientsUpdate = Update.Set("ingredients", newIngredients);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("_id"), newIngredientsUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }

        [WebMethod]
        public bool ChangeCooktime(string id, int newCooktime)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newCooktimeUpdate = Update.Set("cooktime", newCooktime);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("cooktime"), newCooktimeUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }

        [WebMethod]
        public bool ChangeInstructions(string id, string newInstructions)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newInstructionsUpdate = Update.Set("instructions", newInstructions);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("title"), newInstructionsUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }

        [WebMethod]
        public bool ChangeBackgroundTag(string id, string newBackgroundTag)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newBackgroundTagUpdate = Update.Set("backgroundTag", newBackgroundTag);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("title"), newBackgroundTagUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }

        [WebMethod]
        public bool ChangeTags(string id, string newTags)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newTagsUpdate = Update.Set("tags", newTags);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("title"), newTagsUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }
        [WebMethod]
        public bool ChangeRating(string id, double newRating)
        {
            try
            {
                MongoCollection<Recipe> recipes = connectRecipe();
                IMongoQuery recipeToFind = Query.EQ("_id", id);
                var newRatingUpdate = Update.Set("rating", newRating);
                FindAndModifyResult recipeChanged = recipes.FindAndModify(recipeToFind, SortBy.Descending("title"), newRatingUpdate);
                if (recipeChanged.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception m)
            {
                return false;
            }
        }


        //TODO
        [WebMethod]
        public double FindNewAvgRating(string id, double newRatingToAvg)
        {
            MongoCollection<Recipe> recipes = connectRecipe();
            IMongoQuery recipeToFind = Query.EQ("_id", id);
            Recipe recipeToUpdate = recipes.FindOne(recipeToFind);
            double nothing = 0;

            return 0;
        }


        //Default 5
        [WebMethod]
        public List<Recipe> GetRecentlyAdded()
        {
            List<Recipe> current5 = new List<Recipe>();
            MongoCollection<Recipe> recipes = connectRecipe();
            MongoCursor<Recipe> mc = recipes.FindAll();
            mc = mc.SetSortOrder(SortBy.Descending("dateAdded"));
            int increment = 0;
            foreach (Recipe r in mc)
            {
                if (increment < 5)
                {
                    current5.Add(r);
                    increment++;
                }
                else break;
            }
            if (mc.Count() < 5)
            {
                while (mc.Count() < 5)
                {
                    current5.Add(null);
                }
            }

            return current5;
        }


        [WebMethod]
        public List<Recipe> GetRecentlyAdded(int numberOfRecipesToFetch)
        {
            List<Recipe> current = new List<Recipe>();
            MongoCollection<Recipe> recipes = connectRecipe();
            MongoCursor<Recipe> mc = recipes.FindAll();
            mc = mc.SetSortOrder(SortBy.Descending("dateAdded"));
            int increment = 0;
            foreach (Recipe r in mc)
            {
                if (increment < numberOfRecipesToFetch)
                {
                    current.Add(r);
                    increment++;
                }
                else break;
            }
            if (mc.Count() < numberOfRecipesToFetch)
            {
                while (mc.Count() < numberOfRecipesToFetch)
                {
                    current.Add(null);
                }
            }

            return current;
        }

        

       
    }
}
