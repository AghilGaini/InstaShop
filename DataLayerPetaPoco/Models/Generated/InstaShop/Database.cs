




















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `InstaShop`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=.;Initial Catalog=InstaShop;Integrated Security=False;User Id=sa;password=**zapped**;MultipleActiveResultSets=True`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Models.Generated.InstaShop
{

	public partial class InstaShopDB : Database
	{
		public InstaShopDB() 
			: base("InstaShop")
		{
			CommonConstruct();
		}

		public InstaShopDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			InstaShopDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static InstaShopDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new InstaShopDB();
        }

		[ThreadStatic] static InstaShopDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static InstaShopDB repo { get { return InstaShopDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    

	[TableName("[dbo].[BasicType]")]



	[PrimaryKey("ID", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class BasicType : InstaShopDB.Record<BasicType>  
    {

		public struct Columns
		{
			
				public static string ID = @"ID";

			
				public static string Title = @"Title";

			

		}





		[Column] public int ID { get; set; }





		[Column] public string Title { get; set; }



	}

    

	[TableName("[dbo].[BasicValue]")]



	[PrimaryKey("[ID]")]




	[ExplicitColumns]

    public partial class BasicValue : InstaShopDB.Record<BasicValue>  
    {

		public struct Columns
		{
			
				public static string ID = @"ID";

			
				public static string BasicType = @"BasicType";

			
				public static string Identifier = @"Identifier";

			
				public static string Description = @"Description";

			
				public static string Title = @"Title";

			
				public static string EnTitle = @"EnTitle";

			
				public static string IsActive = @"IsActive";

			
				public static string CreationDate = @"CreationDate";

			

		}





		[Column] public int ID { get; set; }





		[Column] public int BasicType { get; set; }





		[Column] public int Identifier { get; set; }





		[Column] public string Description { get; set; }





		[Column] public string Title { get; set; }





		[Column] public string EnTitle { get; set; }





		[Column] public bool IsActive { get; set; }





		[Column] public DateTime CreationDate { get; set; }



	}

    

	[TableName("[dbo].[Category]")]



	[PrimaryKey("[ID]")]




	[ExplicitColumns]

    public partial class Category : InstaShopDB.Record<Category>  
    {

		public struct Columns
		{
			
				public static string ID = @"ID";

			
				public static string TitleFa = @"TitleFa";

			
				public static string TitleEn = @"TitleEn";

			
				public static string CreationDate = @"CreationDate";

			
				public static string ParentID = @"ParentID";

			
				public static string Type = @"Type";

			
				public static string TypeName = @"TypeName";

			

		}





		[Column] public int ID { get; set; }





		[Column] public string TitleFa { get; set; }





		[Column] public string TitleEn { get; set; }





		[Column] public DateTime CreationDate { get; set; }





		[Column] public int? ParentID { get; set; }





		[Column] public int? Type { get; set; }





		[Column] public string TypeName { get; set; }



	}

    

	[TableName("[dbo].[Shop]")]



	[PrimaryKey("[ID]")]




	[ExplicitColumns]

    public partial class Shop : InstaShopDB.Record<Shop>  
    {

		public struct Columns
		{
			
				public static string ID = @"ID";

			
				public static string InstaID = @"InstaID";

			
				public static string PostsCount = @"PostsCount";

			
				public static string Followers = @"Followers";

			
				public static string Following = @"Following";

			
				public static string Bio = @"Bio";

			
				public static string CategoryID = @"CategoryID";

			
				public static string CityID = @"CityID";

			
				public static string MainProfilePicPath = @"MainProfilePicPath";

			
				public static string VirtualProfilePicPath = @"VirtualProfilePicPath";

			
				public static string PublicProfileURL = @"PublicProfileURL";

			
				public static string CreatedOn = @"CreatedOn";

			
				public static string CreatedBy = @"CreatedBy";

			
				public static string ModifiedOn = @"ModifiedOn";

			
				public static string ModifiedBy = @"ModifiedBy";

			
				public static string UserName = @"UserName";

			
				public static string FullName = @"FullName";

			

		}





		[Column] public long ID { get; set; }





		[Column] public long InstaID { get; set; }





		[Column] public int PostsCount { get; set; }





		[Column] public int Followers { get; set; }





		[Column] public int Following { get; set; }





		[Column] public string Bio { get; set; }





		[Column] public int? CategoryID { get; set; }





		[Column] public int? CityID { get; set; }





		[Column] public string MainProfilePicPath { get; set; }





		[Column] public string VirtualProfilePicPath { get; set; }





		[Column] public string PublicProfileURL { get; set; }





		[Column] public DateTime CreatedOn { get; set; }





		[Column] public string CreatedBy { get; set; }





		[Column] public DateTime? ModifiedOn { get; set; }





		[Column] public string ModifiedBy { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public string FullName { get; set; }



	}

    

	[TableName("[dbo].[ShopPost]")]



	[PrimaryKey("[ID]")]




	[ExplicitColumns]

    public partial class ShopPost : InstaShopDB.Record<ShopPost>  
    {

		public struct Columns
		{
			
				public static string ID = @"ID";

			
				public static string ShopID = @"ShopID";

			
				public static string PublicPictureURLs = @"PublicPictureURLs";

			
				public static string Hashtags = @"Hashtags";

			
				public static string Description = @"Description";

			
				public static string LikesCount = @"LikesCount";

			
				public static string CommentsCount = @"CommentsCount";

			
				public static string CreatedOn = @"CreatedOn";

			
				public static string CreatedBy = @"CreatedBy";

			
				public static string ModifiedOn = @"ModifiedOn";

			
				public static string ModifiedBy = @"ModifiedBy";

			

		}





		[Column] public long ID { get; set; }





		[Column] public long ShopID { get; set; }





		[Column] public string PublicPictureURLs { get; set; }





		[Column] public string Hashtags { get; set; }





		[Column] public string Description { get; set; }





		[Column] public int? LikesCount { get; set; }





		[Column] public int? CommentsCount { get; set; }





		[Column] public DateTime CreatedOn { get; set; }





		[Column] public string CreatedBy { get; set; }





		[Column] public DateTime ModifiedOn { get; set; }





		[Column] public string ModifiedBy { get; set; }



	}


}
