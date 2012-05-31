


//-----------------------------------------------------------------------------
// <copyright file="Context.cs" company="WheelMUD Development Team">
//   Copyright (c) WheelMUD Development Team. See LICENSE.txt. This file is
//   subject to the Microsoft Permissive License. All other rights reserved.
// </copyright>
// <summary>
//   auto-generated
// </summary>
//-----------------------------------------------------------------------------

namespace PBM.DAL
{
	using System;
	using System.Data;
	using System.Linq;
	using System.Linq.Expressions;
	using SubSonic.DataProviders;
	using SubSonic.Extensions;
	using SubSonic.Linq.Structure;
	using SubSonic.Query;
	using SubSonic.Schema;
	using System.Data.Common;
	using System.Collections.Generic;
	
    public partial class PBMDB : IQuerySurface
    {
        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        public bool TestMode
        {
            get
            {
                return DataProvider.ConnectionString.Equals("test",StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public PBMDB() 
        { 
            DataProvider = ProviderFactory.GetProvider("PBMConn");
            Init();
        
        }

        public PBMDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);

            Init();

        }
        
        public PBMDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);

            Init();
        }
        
        public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        } 
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands) 
        {            
            if(!TestMode)
            {
                using(var connection = commands[0].Connection)
                {
                   
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
                   {
                        foreach (var cmd in commands)
                        {
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            else if(!TestMode)
                return _batch.ExecuteReader();
            else
                return null;
        }
			
        public Query<PLU> PLUS{ get; set; }
        public Query<CookInfo> CookInfos{ get; set; }

        #region Aggregates and SubSonic Queries
        
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(DataProvider); }
        }

        public Insert Insert {
            get { return new Insert(DataProvider); }
        }

        public Update<T> Update<T>() where T:new()
        {
            return new Update<T>(DataProvider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            SqlQuery result = new Delete<T>(DataProvider);
            result = result.From<T>();
            SubSonic.Query.Constraint c = lamda.ParseConstraint();
            result.Constraints.Add(c);
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName =typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            this.provider = new DbQueryProvider(DataProvider);
    
            #region Query Defs
            
            this.PLUS = new Query<PLU>(this.provider);
            this.CookInfos = new Query<CookInfo>(this.provider);

            #endregion           

			#region Schemas
	        
			if(DataProvider.Schema.Tables.Count == 0)
			{
            // Table: PLU
            // Primary Key: 
            ITable PLUSchema = new DatabaseTable("PLU", DataProvider);
            PLUSchema.ClassName = "PLU";
            			IColumn PLU_ID = new DatabaseColumn("ID",PLUSchema);
            PLU_ID.DataType=DbType.AnsiString;
            PLU_ID.IsNullable = true;
            PLU_ID.AutoIncrement = false;
            PLU_ID.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_ID);
			IColumn PLU_Bar_Code = new DatabaseColumn("Bar_Code",PLUSchema);
            PLU_Bar_Code.DataType=DbType.AnsiString;
            PLU_Bar_Code.IsNullable = true;
            PLU_Bar_Code.AutoIncrement = false;
            PLU_Bar_Code.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_Bar_Code);
			IColumn PLU_Description = new DatabaseColumn("Description",PLUSchema);
            PLU_Description.DataType=DbType.AnsiString;
            PLU_Description.IsNullable = true;
            PLU_Description.AutoIncrement = false;
            PLU_Description.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_Description);
			IColumn PLU_detail = new DatabaseColumn("detail",PLUSchema);
            PLU_detail.DataType=DbType.AnsiString;
            PLU_detail.IsNullable = true;
            PLU_detail.AutoIncrement = false;
            PLU_detail.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_detail);
			IColumn PLU_Dept_No = new DatabaseColumn("Dept_No",PLUSchema);
            PLU_Dept_No.DataType=DbType.AnsiString;
            PLU_Dept_No.IsNullable = true;
            PLU_Dept_No.AutoIncrement = false;
            PLU_Dept_No.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_Dept_No);
			IColumn PLU_Price1 = new DatabaseColumn("Price1",PLUSchema);
            PLU_Price1.DataType=DbType.Decimal;
            PLU_Price1.IsNullable = true;
            PLU_Price1.AutoIncrement = false;
            PLU_Price1.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_Price1);
			IColumn PLU_Price2 = new DatabaseColumn("Price2",PLUSchema);
            PLU_Price2.DataType=DbType.Decimal;
            PLU_Price2.IsNullable = true;
            PLU_Price2.AutoIncrement = false;
            PLU_Price2.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_Price2);
			IColumn PLU_Price3 = new DatabaseColumn("Price3",PLUSchema);
            PLU_Price3.DataType=DbType.Decimal;
            PLU_Price3.IsNullable = true;
            PLU_Price3.AutoIncrement = false;
            PLU_Price3.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_Price3);
			IColumn PLU_PriceMat = new DatabaseColumn("PriceMat",PLUSchema);
            PLU_PriceMat.DataType=DbType.AnsiString;
            PLU_PriceMat.IsNullable = true;
            PLU_PriceMat.AutoIncrement = false;
            PLU_PriceMat.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_PriceMat);
			IColumn PLU_eable = new DatabaseColumn("eable",PLUSchema);
            PLU_eable.DataType=DbType.Int64;
            PLU_eable.IsNullable = true;
            PLU_eable.AutoIncrement = false;
            PLU_eable.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_eable);
			IColumn PLU_disp_flag = new DatabaseColumn("disp_flag",PLUSchema);
            PLU_disp_flag.DataType=DbType.Int64;
            PLU_disp_flag.IsNullable = true;
            PLU_disp_flag.AutoIncrement = false;
            PLU_disp_flag.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_disp_flag);
			IColumn PLU_menu_flag = new DatabaseColumn("menu_flag",PLUSchema);
            PLU_menu_flag.DataType=DbType.Int64;
            PLU_menu_flag.IsNullable = true;
            PLU_menu_flag.AutoIncrement = false;
            PLU_menu_flag.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_menu_flag);
			IColumn PLU_plu_group = new DatabaseColumn("plu_group",PLUSchema);
            PLU_plu_group.DataType=DbType.Int64;
            PLU_plu_group.IsNullable = true;
            PLU_plu_group.AutoIncrement = false;
            PLU_plu_group.IsForeignKey = false;
            PLUSchema.Columns.Add(PLU_plu_group);
            DataProvider.Schema.Tables.Add(PLUSchema);
            // Table: CookInfo
            // Primary Key: ID
            ITable CookInfoSchema = new DatabaseTable("CookInfo", DataProvider);
            CookInfoSchema.ClassName = "CookInfo";
            			IColumn CookInfo_ID = new DatabaseColumn("ID",CookInfoSchema);
            CookInfo_ID.IsPrimaryKey = true;
            CookInfo_ID.DataType=DbType.Int64;
            CookInfo_ID.IsNullable = false;
            CookInfo_ID.AutoIncrement = true;
            CookInfo_ID.IsForeignKey = false;
            CookInfoSchema.Columns.Add(CookInfo_ID);
			IColumn CookInfo_cookName = new DatabaseColumn("cookName",CookInfoSchema);
            CookInfo_cookName.DataType=DbType.AnsiString;
            CookInfo_cookName.IsNullable = true;
            CookInfo_cookName.AutoIncrement = false;
            CookInfo_cookName.IsForeignKey = false;
            CookInfoSchema.Columns.Add(CookInfo_cookName);
			IColumn CookInfo_price = new DatabaseColumn("price",CookInfoSchema);
            CookInfo_price.DataType=DbType.Decimal;
            CookInfo_price.IsNullable = true;
            CookInfo_price.AutoIncrement = false;
            CookInfo_price.IsForeignKey = false;
            CookInfoSchema.Columns.Add(CookInfo_price);
			IColumn CookInfo_description = new DatabaseColumn("description",CookInfoSchema);
            CookInfo_description.DataType=DbType.AnsiString;
            CookInfo_description.IsNullable = true;
            CookInfo_description.AutoIncrement = false;
            CookInfo_description.IsForeignKey = false;
            CookInfoSchema.Columns.Add(CookInfo_description);
            DataProvider.Schema.Tables.Add(CookInfoSchema);
            }
            
            #endregion            
        }
    }
}