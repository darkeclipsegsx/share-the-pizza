using System;
using System.Linq;
using System.Web.Services;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace DeliveryService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginService : System.Web.Services.WebService
    {
        /// <summary>
        /// Only a temporary connection change
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        [WebMethod]
        private bool Connect(String connectionString)
        {
            try
            {
                MongoServer server = MongoServer.Create(connectionString);
                return true;
            }
            catch (MongoConnectionException m)
            {
                Console.WriteLine(m);
                return false;
            }
        }

        /// <summary>
        /// Connects to default peeps db
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        private MongoCollection<Peep> connectUser()
        {
            try
            {
                //var connectionString = "mongodb://localhost/?safe=true";
                //MongoUrl  connectionString = "mongodb://nicole.reed88@gmail.com:iphone5what@alex.mongohq.com:10071/ShareThePizza";
                var connectionString = MongoUrl.Create("mongodb://admin:supermario@alex.mongohq.com:10071/ShareThePizza");
                var settings = connectionString.ToServerSettings();
                //var adminCredentials = new MongoCredentials("nicole.reed88@gmail.com", "supermario", true);
                //settings.CredentialsStore.AddCredentials(adminCredentials);
                //settings.CredentialsStore.AddCredentials("peeps", adminCredentials);
                var server = MongoServer.Create(settings);
                //MongoServer server = MongoServer.Create();

                return server.GetDatabase("ShareThePizza", settings.DefaultCredentials, SafeMode.True).GetCollection<Peep>("peeps");
            }
            catch (Exception m)
            {
                //write
                //Console.WriteLine(m.HelpLink);
                return null;
            }

        }
        [WebMethod]
        private MongoCollection<Peep> connectInvite()
        {
            try
            {
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                //MongoServer server = MongoServer.Create();

                return server.GetDatabase("invitees").GetCollection<Peep>("invitees", SafeMode.True);
            }
            catch (Exception m)
            {
                //write
                //Console.WriteLine(m.HelpLink);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod]
        public bool LoginUser(string username, string password)
        {
            try
            {
                MongoCollection<Peep> mongoPeeps = connectUser();
                IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, username);

                string hash = "";
                byte[] dbSalt = new byte[20];
                Peep p = mongoPeeps.FindOne(userToFind);
                if (p == null)
                {
                    throw new InvalidUserException("User not found in database");

                }
                dbSalt = Encoding.Unicode.GetBytes(p.salt.ToString());
                hash = p.password.ToString();


                string combined = Encoding.Unicode.GetString(dbSalt) + password;
                SHA256 sha = new SHA256Managed();
                byte[] newKey = sha.ComputeHash(Encoding.Unicode.GetBytes(combined));
                if (hash.Equals(Encoding.Unicode.GetString(newKey)))
                {
                    var updateLoggedIn = Update.Set("currentlyLoggedIn", true);
                    mongoPeeps.FindAndModify(userToFind, SortBy.Ascending(username), updateLoggedIn);
                    return true;
                }
                else return false;
            }
            catch (InvalidUserException iue)
            {
                return false;
            }

        }

        /// <summary>
        /// Returns true if successful, if false error will be written to log file (Errlog.txt)
        /// Will need a permanent file location.....
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [WebMethod]
        public bool AddNewUser(string username, string password, string email)
        {
            bool successful = false;
            try
            {
                if (validateInput(username) && validatePassword(password) && validateEmail(email) && UsernameAvailable(username))
                {
                    byte[] generatedSalt = salt();
                    string combined = Encoding.Unicode.GetString(generatedSalt) + password;
                    System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256Managed();
                    byte[] newKey = sha.ComputeHash(Encoding.Unicode.GetBytes(combined));

                    int loginAttempts = 0;
                    bool currentlyLoggedIn = true;
                    DateTime now = DateTime.Now;
                    DateTime expires = now.AddDays(5);
                    //write username, email, hash, salt to table, login attempts, joinDate
                    MongoCollection<Peep> peeps = connectUser();

                    Peep userToAdd = new Peep(username, Encoding.Unicode.GetString(newKey), email, now, Encoding.Unicode.GetString(generatedSalt), currentlyLoggedIn, loginAttempts, expires);
                    SafeModeResult success = peeps.Insert<Peep>(userToAdd);
                    if (!success.Ok)
                    {
                        throw new MongoException("Insertion failed");
                    }
                }
                if (!validatePassword(password))
                {
                    throw new InvalidPasswordException("Password does not meet requrements");
                }

            }
            catch (Exception ex)
            {
                //Perform a write
                return false;
            }

            return successful;
        }

        /// <summary>
        /// Returns whether a certain user is logged in
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod]
        public bool IsLoggedIn(string username)
        {
            MongoCollection<Peep> peeps = connectUser();
            IMongoQuery userToFind = Query.EQ("username", username);
            Peep p = peeps.FindOne(userToFind);
            if (p != null)
            {
                if (p.currentlyLoggedIn.Equals(true))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns 0 if successful, -1 for failure
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        [WebMethod]
        public int ChangeEmail(string username, string newEmail)
        {
            try
            {
                MongoCollection<Peep> peeps = connectUser();
                IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, username);
                var update = Update.Set("email", newEmail);
                FindAndModifyResult result = peeps.FindAndModify(userToFind, null, update);
                if (result.Ok)
                {
                    return 0;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns 0 for success, -1 general failure, -2 oldPassword does not match the current password
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [WebMethod]
        public int ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                //bool correctPassword = passwordCheck(oldPassword);
                bool correctNewPassword = validatePassword(newPassword);
                bool login = LoginUser(username, oldPassword);
                if (correctNewPassword && login)
                {

                    //update db
                    // MongoDatabase md = connectUser();
                    MongoCollection<Peep> peeps = connectUser();

                    byte[] generatedSalt = salt();
                    string combined = Encoding.Unicode.GetString(generatedSalt) + newPassword;
                    SHA256 sha = new SHA256Managed();
                    byte[] newKey = sha.ComputeHash(Encoding.Unicode.GetBytes(combined));

                    IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, username);
                    var update = Update.Set("password", Encoding.Unicode.GetString(newKey));
                    var saltUpdate = Update.Set("salt", Encoding.Unicode.GetString(generatedSalt));
                    FindAndModifyResult result = peeps.FindAndModify(userToFind, null, update);
                    if (result.Ok)
                    {
                        result = peeps.FindAndModify(userToFind, SortBy.Ascending(username), saltUpdate);
                        if (result.Ok)
                        {
                            return 0;
                        }
                        else return -1;
                    }
                    return -1;
                }
                else if (!correctNewPassword)
                {
                    throw new InvalidPasswordException("Incorrect password entered.");

                }
                else return -1;
            }
            catch (InvalidPasswordException ex)
            {
                return -2;
                //throw;// new InvalidPasswordException("Invalid Password", InvalidPasswordException);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// Sets currentlyLoggedIn to false
        /// </summary>
        /// <param name="username"></param>
        [WebMethod]
        public void Logout(string username)
        {
            //end current user session
            //MongoDatabase md = connectUser();
            MongoCollection<Peep> peeps = connectUser();
            IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, username);
            UpdateBuilder update = Update.Set("currentlyLoggedIn", false);
            FindAndModifyResult result = peeps.FindAndModify(userToFind, null, update);

        }

        /// <summary>
        /// Pass in username to be removed
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod]
        public bool RemoveUser(string username)
        {
            try
            {
                //delete username from db
                //MongoDatabase md = connectUser();
                MongoCollection<Peep> peeps = connectUser();
                IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, username);
                IMongoSortBy sortBy = SortBy<Peep>.Ascending(b => b.username);
                FindAndModifyResult fmr = peeps.FindAndRemove(userToFind, sortBy);
                if (fmr.Ok)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                //write issues out
                return false;
            }
        }


        /// <summary>
        /// Returns email of user to notify 
        /// </summary>
        /// <param name="usernameOrEmail"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ForgotPassword(string usernameOrEmail, out string email, out string outToken)
        {
            //MongoDatabase md = connectUser();
            MongoCollection<Peep> peeps = connectUser();
            IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, usernameOrEmail);
            if (validateEmail(usernameOrEmail))//regex!
            {
                email = usernameOrEmail;
            }
            else
            {
                //based on username get the email address
                email = "";
                Peep p = peeps.FindOne(userToFind);
                email = p.email.ToString();
            }
            outToken = salt().ToString().Substring(0, 5);
            System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256Managed();
            byte[] newKey = sha.ComputeHash(Encoding.Unicode.GetBytes(outToken));
            string outTokenHashed = Encoding.Unicode.GetString(newKey);
            IMongoUpdate update = Update.Set("password", outTokenHashed);
            SafeModeResult smr = peeps.Update(userToFind, update);
            if (smr.Ok)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Tests to see if a username exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod]
        public bool UsernameAvailable(string username)
        {
            //MongoDatabase md = connectUser();
            MongoCollection<Peep> peeps = connectUser();
            IMongoQuery userToFind = Query<Peep>.EQ(b => b.username, username);
            Peep p = peeps.FindOne(userToFind);
            if (p != null)
            {
                return false;
            }
            else return true;
        }


        /// <summary>
        /// Generates a random value
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        private byte[] salt()
        {
            System.Security.Cryptography.RandomNumberGenerator g = System.Security.Cryptography.RandomNumberGenerator.Create();
            byte[] b = new byte[20];
            g.GetBytes(b);
            return b;
        }

        /// <summary>
        /// Returns true if match
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod]
        private bool passwordCheck(string password)
        {
            try
            {
                if (validatePassword(password))
                {
                    //get salt and hash from table
                    //MongoDatabase md = connectUser();
                    MongoCollection<Peep> peeps = connectUser();


                    /*byte[] dbSalt;
                     * string dbHash;
                    string combined = Encoding.UTF8.GetString(dbSalt) + password;
                    SHA256 sha = new SHA256Managed();
                    byte[] newKey = sha.ComputeHash(Encoding.UTF8.GetBytes(combined));
                    if(dbHash.Equals(Encoding.UTF8.GetString(newKey){
                     * return true;
                     * }
                     * else return false;
                     * 
                     * */
                }
                bool match = false;
                return match;
            }
            catch (Exception ex)
            {
                //write to seclog.txt
                return false;
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [WebMethod]
        private bool validateEmail(string email)
        {
            Regex r = new Regex("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)$");
            if (r.IsMatch(email))//convert to regex
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ensures that the data is sanitized before going to db
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [WebMethod]
        private bool validateInput(string input)
        {
            Regex r = new Regex("([!\\.;,'\"\\{\\}\\[\\]@&\\\\+\\-_`#\\$%^\\*\\(\\)\\=\\|\\:\\<\\>\\?~/]+)");
            if (r.IsMatch(input))//convert over to regex
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Returns whether a password contains at least one (1) upper case, one (1) lower case, one (1) number, has a minimum length of 5, and contains no punctuation 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [WebMethod]
        private bool validatePassword(string input)
        {
            Regex r = new Regex("^\\w*(?=\\w*\\d)(?=\\w*[a-z])(?=\\w*[A-Z])\\w*$");
            if (input.Length >= 5 && r.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// [Deprecated] Transforms a string into an array of bytes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [WebMethod]
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// [Deprecated] Transforms byte array into string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [WebMethod]
        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// You know you want to...
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [WebMethod]
        public string superSecretSurprise(string input)
        {
            byte[] generatedSalt = salt();
            string combined = Encoding.Unicode.GetString(generatedSalt) + input;
            System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256Managed();
            byte[] newKey = sha.ComputeHash(Encoding.Unicode.GetBytes(combined));
            return "This what " + input + " looks like encyrpted :" + Encoding.Unicode.GetString(newKey);
        }
    }
}