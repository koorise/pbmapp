


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
			
        public Query<WH_Relation_Cook_PLU> WH_Relation_Cook_PLUs{ get; set; }
        public Query<WH_PLU> WH_PLUS{ get; set; }
        public Query<WH_Department> WH_Departments{ get; set; }
        public Query<WH_CookInformation> WH_CookInformations{ get; set; }
        public Query<WH_Relation_PLU_Condiment> WH_Relation_PLU_Condiments{ get; set; }
        public Query<WH_Clerk> WH_Clerks{ get; set; }

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
            
            this.WH_Relation_Cook_PLUs = new Query<WH_Relation_Cook_PLU>(this.provider);
            this.WH_PLUS = new Query<WH_PLU>(this.provider);
            this.WH_Departments = new Query<WH_Department>(this.provider);
            this.WH_CookInformations = new Query<WH_CookInformation>(this.provider);
            this.WH_Relation_PLU_Condiments = new Query<WH_Relation_PLU_Condiment>(this.provider);
            this.WH_Clerks = new Query<WH_Clerk>(this.provider);

            #endregion           

			#region Schemas
	        
			if(DataProvider.Schema.Tables.Count == 0)
			{
            // Table: WH_Relation_Cook_PLU
            // Primary Key: ID
            ITable WH_Relation_Cook_PLUSchema = new DatabaseTable("WH_Relation_Cook_PLU", DataProvider);
            WH_Relation_Cook_PLUSchema.ClassName = "WH_Relation_Cook_PLU";
            			IColumn WH_Relation_Cook_PLU_ID = new DatabaseColumn("ID",WH_Relation_Cook_PLUSchema);
            WH_Relation_Cook_PLU_ID.IsPrimaryKey = true;
            WH_Relation_Cook_PLU_ID.DataType=DbType.Int64;
            WH_Relation_Cook_PLU_ID.IsNullable = false;
            WH_Relation_Cook_PLU_ID.AutoIncrement = true;
            WH_Relation_Cook_PLU_ID.IsForeignKey = false;
            WH_Relation_Cook_PLUSchema.Columns.Add(WH_Relation_Cook_PLU_ID);
			IColumn WH_Relation_Cook_PLU_CookID = new DatabaseColumn("CookID",WH_Relation_Cook_PLUSchema);
            WH_Relation_Cook_PLU_CookID.DataType=DbType.Int64;
            WH_Relation_Cook_PLU_CookID.IsNullable = true;
            WH_Relation_Cook_PLU_CookID.AutoIncrement = false;
            WH_Relation_Cook_PLU_CookID.IsForeignKey = false;
            WH_Relation_Cook_PLUSchema.Columns.Add(WH_Relation_Cook_PLU_CookID);
			IColumn WH_Relation_Cook_PLU_PLUID = new DatabaseColumn("PLUID",WH_Relation_Cook_PLUSchema);
            WH_Relation_Cook_PLU_PLUID.DataType=DbType.Int64;
            WH_Relation_Cook_PLU_PLUID.IsNullable = true;
            WH_Relation_Cook_PLU_PLUID.AutoIncrement = false;
            WH_Relation_Cook_PLU_PLUID.IsForeignKey = false;
            WH_Relation_Cook_PLUSchema.Columns.Add(WH_Relation_Cook_PLU_PLUID);
            DataProvider.Schema.Tables.Add(WH_Relation_Cook_PLUSchema);
            // Table: WH_PLU
            // Primary Key: 
            ITable WH_PLUSchema = new DatabaseTable("WH_PLU", DataProvider);
            WH_PLUSchema.ClassName = "WH_PLU";
            			IColumn WH_PLU_ID = new DatabaseColumn("ID",WH_PLUSchema);
            WH_PLU_ID.DataType=DbType.AnsiString;
            WH_PLU_ID.IsNullable = true;
            WH_PLU_ID.AutoIncrement = false;
            WH_PLU_ID.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_ID);
			IColumn WH_PLU_Bar_Code = new DatabaseColumn("Bar_Code",WH_PLUSchema);
            WH_PLU_Bar_Code.DataType=DbType.AnsiString;
            WH_PLU_Bar_Code.IsNullable = true;
            WH_PLU_Bar_Code.AutoIncrement = false;
            WH_PLU_Bar_Code.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Bar_Code);
			IColumn WH_PLU_Description = new DatabaseColumn("Description",WH_PLUSchema);
            WH_PLU_Description.DataType=DbType.AnsiString;
            WH_PLU_Description.IsNullable = true;
            WH_PLU_Description.AutoIncrement = false;
            WH_PLU_Description.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Description);
			IColumn WH_PLU_Dept_No = new DatabaseColumn("Dept_No",WH_PLUSchema);
            WH_PLU_Dept_No.DataType=DbType.AnsiString;
            WH_PLU_Dept_No.IsNullable = true;
            WH_PLU_Dept_No.AutoIncrement = false;
            WH_PLU_Dept_No.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Dept_No);
			IColumn WH_PLU_Price1 = new DatabaseColumn("Price1",WH_PLUSchema);
            WH_PLU_Price1.DataType=DbType.Decimal;
            WH_PLU_Price1.IsNullable = true;
            WH_PLU_Price1.AutoIncrement = false;
            WH_PLU_Price1.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Price1);
			IColumn WH_PLU_Price2 = new DatabaseColumn("Price2",WH_PLUSchema);
            WH_PLU_Price2.DataType=DbType.Decimal;
            WH_PLU_Price2.IsNullable = true;
            WH_PLU_Price2.AutoIncrement = false;
            WH_PLU_Price2.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Price2);
			IColumn WH_PLU_Price3 = new DatabaseColumn("Price3",WH_PLUSchema);
            WH_PLU_Price3.DataType=DbType.Decimal;
            WH_PLU_Price3.IsNullable = true;
            WH_PLU_Price3.AutoIncrement = false;
            WH_PLU_Price3.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Price3);
			IColumn WH_PLU_PriceMat = new DatabaseColumn("PriceMat",WH_PLUSchema);
            WH_PLU_PriceMat.DataType=DbType.Int64;
            WH_PLU_PriceMat.IsNullable = true;
            WH_PLU_PriceMat.AutoIncrement = false;
            WH_PLU_PriceMat.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_PriceMat);
			IColumn WH_PLU_isMode = new DatabaseColumn("isMode",WH_PLUSchema);
            WH_PLU_isMode.DataType=DbType.Int64;
            WH_PLU_isMode.IsNullable = true;
            WH_PLU_isMode.AutoIncrement = false;
            WH_PLU_isMode.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_isMode);
			IColumn WH_PLU_Inventory = new DatabaseColumn("Inventory",WH_PLUSchema);
            WH_PLU_Inventory.DataType=DbType.Int64;
            WH_PLU_Inventory.IsNullable = true;
            WH_PLU_Inventory.AutoIncrement = false;
            WH_PLU_Inventory.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Inventory);
			IColumn WH_PLU_Inventory_safty = new DatabaseColumn("Inventory_safty",WH_PLUSchema);
            WH_PLU_Inventory_safty.DataType=DbType.Int64;
            WH_PLU_Inventory_safty.IsNullable = true;
            WH_PLU_Inventory_safty.AutoIncrement = false;
            WH_PLU_Inventory_safty.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Inventory_safty);
			IColumn WH_PLU_menu_flag = new DatabaseColumn("menu_flag",WH_PLUSchema);
            WH_PLU_menu_flag.DataType=DbType.Int64;
            WH_PLU_menu_flag.IsNullable = true;
            WH_PLU_menu_flag.AutoIncrement = false;
            WH_PLU_menu_flag.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_menu_flag);
			IColumn WH_PLU_isCondiment = new DatabaseColumn("isCondiment",WH_PLUSchema);
            WH_PLU_isCondiment.DataType=DbType.Int64;
            WH_PLU_isCondiment.IsNullable = true;
            WH_PLU_isCondiment.AutoIncrement = false;
            WH_PLU_isCondiment.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_isCondiment);
			IColumn WH_PLU_Modifier = new DatabaseColumn("Modifier",WH_PLUSchema);
            WH_PLU_Modifier.DataType=DbType.Int64;
            WH_PLU_Modifier.IsNullable = true;
            WH_PLU_Modifier.AutoIncrement = false;
            WH_PLU_Modifier.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Modifier);
			IColumn WH_PLU_Modifier_description = new DatabaseColumn("Modifier_description",WH_PLUSchema);
            WH_PLU_Modifier_description.DataType=DbType.AnsiString;
            WH_PLU_Modifier_description.IsNullable = true;
            WH_PLU_Modifier_description.AutoIncrement = false;
            WH_PLU_Modifier_description.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Modifier_description);
			IColumn WH_PLU_Modifier_Unity_Quantity = new DatabaseColumn("Modifier_Unity_Quantity",WH_PLUSchema);
            WH_PLU_Modifier_Unity_Quantity.DataType=DbType.AnsiString;
            WH_PLU_Modifier_Unity_Quantity.IsNullable = true;
            WH_PLU_Modifier_Unity_Quantity.AutoIncrement = false;
            WH_PLU_Modifier_Unity_Quantity.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Modifier_Unity_Quantity);
			IColumn WH_PLU_Modifier_Price = new DatabaseColumn("Modifier_Price",WH_PLUSchema);
            WH_PLU_Modifier_Price.DataType=DbType.Int64;
            WH_PLU_Modifier_Price.IsNullable = true;
            WH_PLU_Modifier_Price.AutoIncrement = false;
            WH_PLU_Modifier_Price.IsForeignKey = false;
            WH_PLUSchema.Columns.Add(WH_PLU_Modifier_Price);
            DataProvider.Schema.Tables.Add(WH_PLUSchema);
            // Table: WH_Department
            // Primary Key: ID
            ITable WH_DepartmentSchema = new DatabaseTable("WH_Department", DataProvider);
            WH_DepartmentSchema.ClassName = "WH_Department";
            			IColumn WH_Department_ID = new DatabaseColumn("ID",WH_DepartmentSchema);
            WH_Department_ID.IsPrimaryKey = true;
            WH_Department_ID.DataType=DbType.Int64;
            WH_Department_ID.IsNullable = false;
            WH_Department_ID.AutoIncrement = true;
            WH_Department_ID.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_ID);
			IColumn WH_Department_Description = new DatabaseColumn("Description",WH_DepartmentSchema);
            WH_Department_Description.DataType=DbType.AnsiString;
            WH_Department_Description.IsNullable = true;
            WH_Department_Description.AutoIncrement = false;
            WH_Department_Description.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_Description);
			IColumn WH_Department_High_Digit_LockOut = new DatabaseColumn("High_Digit_LockOut",WH_DepartmentSchema);
            WH_Department_High_Digit_LockOut.DataType=DbType.Int64;
            WH_Department_High_Digit_LockOut.IsNullable = true;
            WH_Department_High_Digit_LockOut.AutoIncrement = false;
            WH_Department_High_Digit_LockOut.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_High_Digit_LockOut);
			IColumn WH_Department_isDirectSale = new DatabaseColumn("isDirectSale",WH_DepartmentSchema);
            WH_Department_isDirectSale.DataType=DbType.Int64;
            WH_Department_isDirectSale.IsNullable = true;
            WH_Department_isDirectSale.AutoIncrement = false;
            WH_Department_isDirectSale.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isDirectSale);
			IColumn WH_Department_isAge = new DatabaseColumn("isAge",WH_DepartmentSchema);
            WH_Department_isAge.DataType=DbType.Int64;
            WH_Department_isAge.IsNullable = true;
            WH_Department_isAge.AutoIncrement = false;
            WH_Department_isAge.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isAge);
			IColumn WH_Department_isPrice = new DatabaseColumn("isPrice",WH_DepartmentSchema);
            WH_Department_isPrice.DataType=DbType.Int64;
            WH_Department_isPrice.IsNullable = true;
            WH_Department_isPrice.AutoIncrement = false;
            WH_Department_isPrice.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isPrice);
			IColumn WH_Department_DepartmentGroup = new DatabaseColumn("DepartmentGroup",WH_DepartmentSchema);
            WH_Department_DepartmentGroup.DataType=DbType.Int64;
            WH_Department_DepartmentGroup.IsNullable = true;
            WH_Department_DepartmentGroup.AutoIncrement = false;
            WH_Department_DepartmentGroup.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_DepartmentGroup);
			IColumn WH_Department_KP = new DatabaseColumn("KP",WH_DepartmentSchema);
            WH_Department_KP.DataType=DbType.Int64;
            WH_Department_KP.IsNullable = true;
            WH_Department_KP.AutoIncrement = false;
            WH_Department_KP.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_KP);
			IColumn WH_Department_isMode = new DatabaseColumn("isMode",WH_DepartmentSchema);
            WH_Department_isMode.DataType=DbType.Int64;
            WH_Department_isMode.IsNullable = true;
            WH_Department_isMode.AutoIncrement = false;
            WH_Department_isMode.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isMode);
			IColumn WH_Department_isPriceFormat = new DatabaseColumn("isPriceFormat",WH_DepartmentSchema);
            WH_Department_isPriceFormat.DataType=DbType.Int64;
            WH_Department_isPriceFormat.IsNullable = true;
            WH_Department_isPriceFormat.AutoIncrement = false;
            WH_Department_isPriceFormat.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isPriceFormat);
			IColumn WH_Department_isType = new DatabaseColumn("isType",WH_DepartmentSchema);
            WH_Department_isType.DataType=DbType.Int64;
            WH_Department_isType.IsNullable = true;
            WH_Department_isType.AutoIncrement = false;
            WH_Department_isType.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isType);
			IColumn WH_Department_isVat_Tax_GST = new DatabaseColumn("isVat_Tax_GST",WH_DepartmentSchema);
            WH_Department_isVat_Tax_GST.DataType=DbType.Int64;
            WH_Department_isVat_Tax_GST.IsNullable = true;
            WH_Department_isVat_Tax_GST.AutoIncrement = false;
            WH_Department_isVat_Tax_GST.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_isVat_Tax_GST);
			IColumn WH_Department_str_Vat_Tax_GST = new DatabaseColumn("str_Vat_Tax_GST",WH_DepartmentSchema);
            WH_Department_str_Vat_Tax_GST.DataType=DbType.AnsiString;
            WH_Department_str_Vat_Tax_GST.IsNullable = true;
            WH_Department_str_Vat_Tax_GST.AutoIncrement = false;
            WH_Department_str_Vat_Tax_GST.IsForeignKey = false;
            WH_DepartmentSchema.Columns.Add(WH_Department_str_Vat_Tax_GST);
            DataProvider.Schema.Tables.Add(WH_DepartmentSchema);
            // Table: WH_CookInformation
            // Primary Key: ID
            ITable WH_CookInformationSchema = new DatabaseTable("WH_CookInformation", DataProvider);
            WH_CookInformationSchema.ClassName = "WH_CookInformation";
            			IColumn WH_CookInformation_ID = new DatabaseColumn("ID",WH_CookInformationSchema);
            WH_CookInformation_ID.IsPrimaryKey = true;
            WH_CookInformation_ID.DataType=DbType.Int64;
            WH_CookInformation_ID.IsNullable = false;
            WH_CookInformation_ID.AutoIncrement = true;
            WH_CookInformation_ID.IsForeignKey = false;
            WH_CookInformationSchema.Columns.Add(WH_CookInformation_ID);
			IColumn WH_CookInformation_Num = new DatabaseColumn("Num",WH_CookInformationSchema);
            WH_CookInformation_Num.DataType=DbType.Int64;
            WH_CookInformation_Num.IsNullable = true;
            WH_CookInformation_Num.AutoIncrement = false;
            WH_CookInformation_Num.IsForeignKey = false;
            WH_CookInformationSchema.Columns.Add(WH_CookInformation_Num);
			IColumn WH_CookInformation_Description = new DatabaseColumn("Description",WH_CookInformationSchema);
            WH_CookInformation_Description.DataType=DbType.AnsiString;
            WH_CookInformation_Description.IsNullable = true;
            WH_CookInformation_Description.AutoIncrement = false;
            WH_CookInformation_Description.IsForeignKey = false;
            WH_CookInformationSchema.Columns.Add(WH_CookInformation_Description);
			IColumn WH_CookInformation_price = new DatabaseColumn("price",WH_CookInformationSchema);
            WH_CookInformation_price.DataType=DbType.Int64;
            WH_CookInformation_price.IsNullable = true;
            WH_CookInformation_price.AutoIncrement = false;
            WH_CookInformation_price.IsForeignKey = false;
            WH_CookInformationSchema.Columns.Add(WH_CookInformation_price);
            DataProvider.Schema.Tables.Add(WH_CookInformationSchema);
            // Table: WH_Relation_PLU_Condiment
            // Primary Key: ID
            ITable WH_Relation_PLU_CondimentSchema = new DatabaseTable("WH_Relation_PLU_Condiment", DataProvider);
            WH_Relation_PLU_CondimentSchema.ClassName = "WH_Relation_PLU_Condiment";
            			IColumn WH_Relation_PLU_Condiment_ID = new DatabaseColumn("ID",WH_Relation_PLU_CondimentSchema);
            WH_Relation_PLU_Condiment_ID.IsPrimaryKey = true;
            WH_Relation_PLU_Condiment_ID.DataType=DbType.Int64;
            WH_Relation_PLU_Condiment_ID.IsNullable = false;
            WH_Relation_PLU_Condiment_ID.AutoIncrement = true;
            WH_Relation_PLU_Condiment_ID.IsForeignKey = false;
            WH_Relation_PLU_CondimentSchema.Columns.Add(WH_Relation_PLU_Condiment_ID);
			IColumn WH_Relation_PLU_Condiment_PLUID = new DatabaseColumn("PLUID",WH_Relation_PLU_CondimentSchema);
            WH_Relation_PLU_Condiment_PLUID.DataType=DbType.Int64;
            WH_Relation_PLU_Condiment_PLUID.IsNullable = true;
            WH_Relation_PLU_Condiment_PLUID.AutoIncrement = false;
            WH_Relation_PLU_Condiment_PLUID.IsForeignKey = false;
            WH_Relation_PLU_CondimentSchema.Columns.Add(WH_Relation_PLU_Condiment_PLUID);
			IColumn WH_Relation_PLU_Condiment_condimentPLUID = new DatabaseColumn("condimentPLUID",WH_Relation_PLU_CondimentSchema);
            WH_Relation_PLU_Condiment_condimentPLUID.DataType=DbType.Int64;
            WH_Relation_PLU_Condiment_condimentPLUID.IsNullable = true;
            WH_Relation_PLU_Condiment_condimentPLUID.AutoIncrement = false;
            WH_Relation_PLU_Condiment_condimentPLUID.IsForeignKey = false;
            WH_Relation_PLU_CondimentSchema.Columns.Add(WH_Relation_PLU_Condiment_condimentPLUID);
            DataProvider.Schema.Tables.Add(WH_Relation_PLU_CondimentSchema);
            // Table: WH_Clerk
            // Primary Key: ID
            ITable WH_ClerkSchema = new DatabaseTable("WH_Clerk", DataProvider);
            WH_ClerkSchema.ClassName = "WH_Clerk";
            			IColumn WH_Clerk_ID = new DatabaseColumn("ID",WH_ClerkSchema);
            WH_Clerk_ID.IsPrimaryKey = true;
            WH_Clerk_ID.DataType=DbType.Int64;
            WH_Clerk_ID.IsNullable = false;
            WH_Clerk_ID.AutoIncrement = true;
            WH_Clerk_ID.IsForeignKey = false;
            WH_ClerkSchema.Columns.Add(WH_Clerk_ID);
			IColumn WH_Clerk_isNum = new DatabaseColumn("isNum",WH_ClerkSchema);
            WH_Clerk_isNum.DataType=DbType.AnsiString;
            WH_Clerk_isNum.IsNullable = true;
            WH_Clerk_isNum.AutoIncrement = false;
            WH_Clerk_isNum.IsForeignKey = false;
            WH_ClerkSchema.Columns.Add(WH_Clerk_isNum);
			IColumn WH_Clerk_SecretCode = new DatabaseColumn("SecretCode",WH_ClerkSchema);
            WH_Clerk_SecretCode.DataType=DbType.AnsiString;
            WH_Clerk_SecretCode.IsNullable = true;
            WH_Clerk_SecretCode.AutoIncrement = false;
            WH_Clerk_SecretCode.IsForeignKey = false;
            WH_ClerkSchema.Columns.Add(WH_Clerk_SecretCode);
			IColumn WH_Clerk_Description = new DatabaseColumn("Description",WH_ClerkSchema);
            WH_Clerk_Description.DataType=DbType.AnsiString;
            WH_Clerk_Description.IsNullable = true;
            WH_Clerk_Description.AutoIncrement = false;
            WH_Clerk_Description.IsForeignKey = false;
            WH_ClerkSchema.Columns.Add(WH_Clerk_Description);
			IColumn WH_Clerk_Limitaions = new DatabaseColumn("Limitaions",WH_ClerkSchema);
            WH_Clerk_Limitaions.DataType=DbType.AnsiString;
            WH_Clerk_Limitaions.IsNullable = true;
            WH_Clerk_Limitaions.AutoIncrement = false;
            WH_Clerk_Limitaions.IsForeignKey = false;
            WH_ClerkSchema.Columns.Add(WH_Clerk_Limitaions);
			IColumn WH_Clerk_InterruptNo = new DatabaseColumn("InterruptNo",WH_ClerkSchema);
            WH_Clerk_InterruptNo.DataType=DbType.AnsiString;
            WH_Clerk_InterruptNo.IsNullable = true;
            WH_Clerk_InterruptNo.AutoIncrement = false;
            WH_Clerk_InterruptNo.IsForeignKey = false;
            WH_ClerkSchema.Columns.Add(WH_Clerk_InterruptNo);
            DataProvider.Schema.Tables.Add(WH_ClerkSchema);
            }
            
            #endregion            
        }
    }
}