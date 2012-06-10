using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.Model.Order;
using System.Data;
using System.Data.SqlClient;
using ShowShop.Model;
using ShowShop.IDAL.Order;

namespace ShowShop.SQLServerDAL.Order
{
    public class YXShopProfileProvider : IYXShopProfileProvider
    {

        private const int AUTH_ANONYMOUS = 0;

        private const int AUTH_AUTHENTICATED = 1;

        private const int AUTH_ALL = 2;


        /// <summary>
        /// Retrieve collection of shopping cart items
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="appName">Application Name</param>
        /// <param name="isShoppingCart">Shopping cart flag</param>
        /// <returns>Collection of shopping cart items</returns>
        public IList<CartItemInfo> GetCartItems(string userName, string appName, bool isShoppingCart)
        {
            string sqlSelect = "SELECT yxs_cart.cartkey,yxs_cart.productid, yxs_cart.quantity, yxs_cart.specification, yxs_cart.fittingsProductId,yxs_cart.fittingsProductCount,yxs_cart.sparepartId FROM yxs_profiles INNER JOIN yxs_cart ON yxs_profiles.uniqueid = yxs_cart.uniqueid WHERE yxs_profiles.username = @Username AND yxs_profiles.applicationname = @ApplicationName AND IsShoppingCart = @IsShoppingCart;";

            SqlParameter[] parms = {						   
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@IsShoppingCart", SqlDbType.Bit)};
            parms[0].Value = userName;
            parms[1].Value = appName;
            parms[2].Value = isShoppingCart;

            SqlDataReader dr =ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sqlSelect, parms);

            IList<CartItemInfo> cartItems = new List<CartItemInfo>();

            while (dr.Read())
            {
                CartItemInfo cartItem = new CartItemInfo(Convert.ToString(dr["cartkey"]), Convert.ToString(dr["productid"]), Convert.ToInt32(dr["quantity"]), dr["specification"].ToString(), dr["fittingsProductId"].ToString(), dr["fittingsProductCount"].ToString(), dr["sparepartId"].ToString());
                cartItems.Add(cartItem);
            }
            dr.Close();
            return cartItems;
        }

        /// <summary>
        /// Update shopping cart for current user
        /// </summary>
        /// <param name="uniqueID">User id</param>
        /// <param name="cartItems">Collection of shopping cart items</param>
        /// <param name="isShoppingCart">Shopping cart flag</param>
        public void SetCartItems(int uniqueID, ICollection<CartItemInfo> cartItems, bool isShoppingCart)
        {
            string sqlDelete = "DELETE FROM yxs_cart WHERE uniqueid = @UniqueID AND isShoppingCart = @IsShoppingCart;";

            SqlParameter[] parms1 = {				   
				new SqlParameter("@UniqueID", SqlDbType.Int),
				new SqlParameter("@IsShoppingCart", SqlDbType.Bit)};
            parms1[0].Value = uniqueID;
            parms1[1].Value = isShoppingCart;
            
            if (cartItems.Count > 0)
            {

                // update cart using SqlTransaction
                string sqlInsert = "INSERT INTO yxs_cart ([cartkey],[uniqueid], [productid], [quantity], [specification], [fittingsProductId], [fittingsProductCount], [isShoppingCart],[sparepartId]) VALUES (@cartkey,@uniqueid,@productid, @quantity, @specification, @fittingsProductId, @fittingsProductCount,@isShoppingCart,@sparepartId);";

                SqlParameter[] parms2 = {
                			   
				new SqlParameter("@uniqueid", SqlDbType.Int),	
				new SqlParameter("@isShoppingCart", SqlDbType.Int),
                new SqlParameter("@cartkey", SqlDbType.VarChar, 50),
				new SqlParameter("@productid", SqlDbType.VarChar, 50),
				new SqlParameter("@quantity", SqlDbType.Int, 4),
				new SqlParameter("@specification", SqlDbType.VarChar, 500),
				new SqlParameter("@fittingsProductId", SqlDbType.VarChar, 200),
				new SqlParameter("@fittingsProductCount", SqlDbType.VarChar,200),
                new SqlParameter("@sparepartId",SqlDbType.Int)
                                        };
                parms2[0].Value = uniqueID;
                parms2[1].Value = isShoppingCart;
               SqlConnection conn = ChangeHope.DataBase.SQLServerHelper.Connection;
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    ChangeHope.DataBase.SQLServerHelper.ExecuteNonQuery(trans, sqlDelete, parms1);
                    foreach (CartItemInfo cartItem in cartItems)
                    {
                        parms2[2].Value = cartItem.CartKey;
                        parms2[3].Value = cartItem.ProductId;
                        parms2[4].Value = cartItem.Quantity;
                        parms2[5].Value = cartItem.Specification;
                        parms2[6].Value = cartItem.FittingsProductId;
                        parms2[7].Value = cartItem.FittingsProductCount;
                        parms2[8].Value = !string.IsNullOrEmpty(cartItem.SparepartId.Trim())?Convert.ToInt32(cartItem.SparepartId):0;
                        
                       ChangeHope.DataBase.SQLServerHelper.ExecuteNonQuery(trans, sqlInsert, parms2);
                    }
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw new ApplicationException(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                // delete cart
                ChangeHope.DataBase.SQLServerHelper.GetSingle(sqlDelete, parms1);
        }

        /// <summary>
        /// Update activity dates for current user and application
        /// </summary>
        /// <param name="userName">USer name</param>
        /// <param name="activityOnly">Activity only flag</param>
        /// <param name="appName">Application Name</param>
        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            DateTime activityDate = DateTime.Now;

            string sqlUpdate;
            SqlParameter[] parms;

            if (activityOnly)
            {
                sqlUpdate = "UPDATE yxs_profiles Set lastactivitydate = @LastActivityDate WHERE username = @Username AND applicationname = @ApplicationName;";
                parms = new SqlParameter[]{						   
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = userName;
                parms[2].Value = appName;

            }
            else
            {
                sqlUpdate = "UPDATE yxs_profiles Set lastactivitydate = @LastActivityDate, lastupdateddate = @LastUpdatedDate WHERE username = @Username AND applicationname = @ApplicationName;";
                parms = new SqlParameter[]{
					new SqlParameter("@LastActivityDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.VarChar, 256),
					new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};

                parms[0].Value = activityDate;
                parms[1].Value = activityDate;
                parms[2].Value = userName;
                parms[3].Value = appName;
            }
            ChangeHope.DataBase.SQLServerHelper.GetSingle(sqlUpdate, parms);
        }

        /// <summary>
        /// Retrive unique id for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="ignoreAuthenticationType">Ignore authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Unique id for current user</returns>
        public int GetUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            string sqlSelect = "SELECT uniqueid FROM yxs_profiles WHERE username = @Username AND applicationname = @ApplicationName";

            SqlParameter[] parms = {
				new SqlParameter("@Username", SqlDbType.VarChar, 256),
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms[0].Value = userName;
            parms[1].Value = appName;

            if (!ignoreAuthenticationType)
            {
                sqlSelect += " AND isanonymous = @IsAnonymous";
                Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                parms[2].Value = !isAuthenticated;
            }

            int uniqueID = 0;

            object retVal = null;
            retVal = ChangeHope.DataBase.SQLServerHelper.GetSingle(sqlSelect, parms);

            if (retVal == null)
                uniqueID = CreateProfileForUser(userName, isAuthenticated, appName);
            else
                uniqueID = Convert.ToInt32(retVal);
            return uniqueID;
        }

        /// <summary>
        /// Create profile record for current user
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="isAuthenticated">Authentication flag</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Number of records created</returns>
        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {
            string sqlInsert = "INSERT INTO yxs_profiles ([username], [applicationname], [isanonymous], [lastactivitydate], [lastupdateddate] ) Values(@username, @applicationname, @isanonymous, @lastactivitydate, @lastupdateddate); SELECT @@IDENTITY;";

            SqlParameter[] parms = {
				new SqlParameter("@username", SqlDbType.VarChar, 256),
				new SqlParameter("@applicationname", SqlDbType.VarChar, 256),
				new SqlParameter("@isanonymous", SqlDbType.Bit),
				new SqlParameter("@lastactivitydate", SqlDbType.DateTime),
				new SqlParameter("@lastupdateddate", SqlDbType.DateTime)};

            parms[0].Value = userName;
            parms[1].Value = appName;
            parms[2].Value = !isAuthenticated;
            parms[3].Value = DateTime.Now;
            parms[4].Value = DateTime.Now;

            //int uniqueID = 0;
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(sqlInsert, parms);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            //int.TryParse(ChangeHope.DataBase.SQLServerHelper.GetSingle(sqlInsert, parms).ToString(), out uniqueID);

            //return uniqueID;
        }

        /// <summary>
        /// Retrieve colection of inactive user id's
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <returns>Collection of inactive profile id's</returns>
        public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {

            StringBuilder sqlSelect = new StringBuilder("SELECT username FROM yxs_profiles WHERE applicationname = @ApplicationName AND lastactivitydate <= @LastActivityDate");

            SqlParameter[] parms = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256),
				new SqlParameter("@LastActivityDate", SqlDbType.DateTime)};
            parms[0].Value = appName;
            parms[1].Value = userInactiveSinceDate;

            switch (authenticationOption)
            {
                case AUTH_ANONYMOUS:
                    sqlSelect.Append(" AND isanonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = true;
                    break;
                case AUTH_AUTHENTICATED:
                    sqlSelect.Append(" AND isanonymous = @IsAnonymous");
                    Array.Resize<SqlParameter>(ref parms, parms.Length + 1);
                    parms[2] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);
                    parms[2].Value = false;
                    break;
                default:
                    break;
            }

            IList<string> usernames = new List<string>();

            SqlDataReader dr =ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sqlSelect.ToString(), parms);
            while (dr.Read())
            {
                usernames.Add(dr.GetString(0));
            }

            dr.Close();
            return usernames;
        }

        /// <summary>
        /// Delete user's profile
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="appName">Application Name</param>
        /// <returns>True, if profile successfully deleted</returns>
        public bool DeleteProfile(string userName, string appName)
        {

            int uniqueID = GetUniqueID(userName, false, true, appName);
            string sqlDelete = "DELETE FROM yxs_profiles WHERE uniqueid = @UniqueID;";
            SqlParameter param = new SqlParameter("@UniqueId", SqlDbType.Int, 4);
            param.Value = uniqueID;

            int numDeleted = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sqlDelete, param);

            if (numDeleted <= 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Retrieve profile information
        /// </summary>
        /// <param name="authenticationOption">Authentication option</param>
        /// <param name="usernameToMatch">User name</param>
        /// <param name="userInactiveSinceDate">Date to start search from</param>
        /// <param name="appName">Application Name</param>
        /// <param name="totalRecords">Number of records to return</param>
        /// <returns>Collection of profiles</returns>
        public IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        {

            // Retrieve the total count.
            StringBuilder sqlSelect1 = new StringBuilder("SELECT COUNT(*) FROM yxs_profiles WHERE applicationname = @ApplicationName");
            SqlParameter[] parms1 = {
				new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256)};
            parms1[0].Value = appName;

            // Retrieve the profile data.
            StringBuilder sqlSelect2 = new StringBuilder("SELECT username, lastactivitydate, lastupdateddate, isanonymous FROM yxs_profiles WHERE applicationname = @ApplicationName");
            SqlParameter[] parms2 = { new SqlParameter("@ApplicationName", SqlDbType.VarChar, 256) };
            parms2[0].Value = appName;

            int arraySize;

            // If searching for a user name to match, add the command text and parameters.
            if (usernameToMatch != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms1[arraySize].Value = usernameToMatch;

                sqlSelect2.Append(" AND username LIKE @Username ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@Username", SqlDbType.VarChar, 256);
                parms2[arraySize].Value = usernameToMatch;
            }


            // If searching for inactive profiles, 
            // add the command text and parameters.
            if (userInactiveSinceDate != null)
            {
                arraySize = parms1.Length;

                sqlSelect1.Append(" AND lastactivitydate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                parms1[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms1[arraySize].Value = (DateTime)userInactiveSinceDate;

                sqlSelect2.Append(" AND lastactivitydate >= @LastActivityDate ");
                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                parms2[arraySize] = new SqlParameter("@LastActivityDate", SqlDbType.DateTime);
                parms2[arraySize].Value = (DateTime)userInactiveSinceDate;
            }


            // If searching for a anonymous or authenticated profiles,    
            // add the command text and parameters.	
            if (authenticationOption != AUTH_ALL)
            {
                arraySize = parms1.Length;

                Array.Resize<SqlParameter>(ref parms1, arraySize + 1);
                sqlSelect1.Append(" AND isanonymous = @IsAnonymous");
                parms1[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                Array.Resize<SqlParameter>(ref parms2, arraySize + 1);
                sqlSelect2.Append(" AND isanonymous = @IsAnonymous");
                parms2[arraySize] = new SqlParameter("@IsAnonymous", SqlDbType.Bit);

                switch (authenticationOption)
                {
                    case AUTH_ANONYMOUS:
                        parms1[arraySize].Value = true;
                        parms2[arraySize].Value = true;
                        break;
                    case AUTH_AUTHENTICATED:
                        parms1[arraySize].Value = false;
                        parms2[arraySize].Value = false;
                        break;
                    default:
                        break;
                }
            }

            IList<CustomProfileInfo> profiles = new List<CustomProfileInfo>();

            // Get the profile count.
            totalRecords = (int)ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sqlSelect1.ToString(), parms1);

            // No profiles found.
            if (totalRecords <= 0)
                return profiles;

            SqlDataReader dr;
            dr =ChangeHope.DataBase.SQLServerHelper.ExecuteReader (sqlSelect2.ToString(), parms2);
            while (dr.Read())
            {
                CustomProfileInfo profile = new CustomProfileInfo(dr.GetString(0), dr.GetDateTime(1), dr.GetDateTime(2), dr.GetBoolean(3));
                profiles.Add(profile);
            }
            dr.Close();

            return profiles;
        }
        public void UpdateProfile(string Username, string UsernameMember)
        {
            int Record = 0;
            string sqlSelectM = "Select uniqueid,username from yxs_profiles where username=@UsernameM";
            SqlParameter[] parmsM = {					   
                new SqlParameter("@UsernameM", SqlDbType.VarChar, 256)};
            parmsM[0].Value = UsernameMember;

            SqlDataReader drM =ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sqlSelectM, parmsM);
            while (drM.Read())
            {
                string sqlSelect = "Select uniqueid,username from yxs_profiles where username=@Username";
                SqlParameter[] parms = {					   
                new SqlParameter("@Username", SqlDbType.VarChar, 256)};
                parms[0].Value = Username;

                SqlDataReader dr = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sqlSelect, parms);
                while (dr.Read())
                {

                    string sqlUpdate = "UPDATE yxs_cart Set uniqueid = @UniqueIDM WHERE uniqueid = @UniqueID";
                    SqlParameter[] parmsu = new SqlParameter[]{
					new SqlParameter("@UniqueID", SqlDbType.Int),new SqlParameter("@UniqueIDM", SqlDbType.Int)};
                    parmsu[0].Value = dr.GetInt32(0);
                    parmsu[1].Value = drM.GetInt32(0);

                    Record +=ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sqlUpdate, parmsu);
                    if (Record > 0)
                    {
                        string sqlDelete = "DELETE FROM yxs_profiles WHERE uniqueid = @UniqueID;";
                        SqlParameter paramp = new SqlParameter("@UniqueId", SqlDbType.Int, 4);
                        paramp.Value = dr.GetInt32(0);
                        ChangeHope.DataBase.SQLServerHelper.GetSingle(sqlDelete, paramp);
                    }
                }
            }
        }

    }
}

