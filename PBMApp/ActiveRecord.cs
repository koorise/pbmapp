


//-----------------------------------------------------------------------------
// <copyright file="ActiveRecord.cs" company="WheelMUD Development Team">
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
	using System.Collections.Generic;
	using System.Linq;
	using System.Data;
	using SubSonic.DataProviders;
	using SubSonic.Extensions;
	using System.Linq.Expressions;
	using SubSonic.Schema;
	using SubSonic.Repository;
	using System.Data.Common;

	#region WH_Relation_Cook_PLU Class
	   
    /// <summary>
    /// A class which represents the WH_Relation_Cook_PLU table in the PBM Database.
    /// </summary>
    public partial class WH_Relation_Cook_PLU: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<WH_Relation_Cook_PLU> TestItems;
        static TestRepository<WH_Relation_Cook_PLU> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<WH_Relation_Cook_PLU>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<WH_Relation_Cook_PLU> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(WH_Relation_Cook_PLU item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                WH_Relation_Cook_PLU item=new WH_Relation_Cook_PLU();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<WH_Relation_Cook_PLU> _repo;
        ITable tbl;
        bool _isNew;
        
        public bool IsNew()
        {
            return _isNew;
        }
        
        public void SetIsNew(bool isNew)
        {
            _isNew=isNew;
        }
        
        bool _isLoaded;
        public bool IsLoaded()
        {
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty()
        {
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns ()
        {
            return _dirtyColumns;
        }

        PBM.DAL.PBMDB _db;
        public WH_Relation_Cook_PLU(string connectionString, string providerName) 
        {

            _db=new PBM.DAL.PBMDB(connectionString, providerName);
            Init();            
         }
         
        void Init()
        {
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode)
            {
                WH_Relation_Cook_PLU.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Relation_Cook_PLU>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public WH_Relation_Cook_PLU()
        {
             _db=new PBM.DAL.PBMDB();
            Init();            
        }        
       
        partial void OnCreated();            
        partial void OnLoaded();        
        partial void OnSaved();        
        partial void OnChanged();
        
        public IList<IColumn> Columns
        {
            get
            {
                return tbl.Columns;
            }
        }

        public WH_Relation_Cook_PLU(Expression<Func<WH_Relation_Cook_PLU, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<WH_Relation_Cook_PLU> GetRepo(string connectionString, string providerName)
        {
            PBM.DAL.PBMDB db;
            if(String.IsNullOrEmpty(connectionString))
            {
                db=new PBM.DAL.PBMDB();
            }
            else
            {
                db=new PBM.DAL.PBMDB(connectionString, providerName);
            }
            
            IRepository<WH_Relation_Cook_PLU> _repo;
            
            if(db.TestMode)
            {
                WH_Relation_Cook_PLU.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Relation_Cook_PLU>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<WH_Relation_Cook_PLU> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static WH_Relation_Cook_PLU SingleOrDefault(Expression<Func<WH_Relation_Cook_PLU, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<WH_Relation_Cook_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Relation_Cook_PLU>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static WH_Relation_Cook_PLU SingleOrDefault(Expression<Func<WH_Relation_Cook_PLU, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Relation_Cook_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Relation_Cook_PLU>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<WH_Relation_Cook_PLU, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<WH_Relation_Cook_PLU, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<WH_Relation_Cook_PLU> Find(Expression<Func<WH_Relation_Cook_PLU, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<WH_Relation_Cook_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Relation_Cook_PLU>();
        }
        
        public static IList<WH_Relation_Cook_PLU> Find(Expression<Func<WH_Relation_Cook_PLU, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Relation_Cook_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Relation_Cook_PLU>();
        }
        
        public static IQueryable<WH_Relation_Cook_PLU> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<WH_Relation_Cook_PLU> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WH_Relation_Cook_PLU> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WH_Relation_Cook_PLU> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WH_Relation_Cook_PLU> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<WH_Relation_Cook_PLU> GetPaged(int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(pageIndex, pageSize);            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value)
        {
            if (value != null)
             {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString()
        {
            return this.CookID.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(WH_Relation_Cook_PLU))
            {
                WH_Relation_Cook_PLU compare=(WH_Relation_Cook_PLU)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.CookID.ToString();
        }

        public string DescriptorColumn() 
        {
            return "CookID";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "CookID";
        }
        
        #region ' Foreign Keys '
        #endregion     

        long _ID;
        public long ID
        {
            get 
            { 
				return _ID; 
            }
            
            set
            {                
                _ID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _CookID;
        public long? CookID
        {
            get 
            { 
				return _CookID; 
            }
            
            set
            {                
                _CookID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CookID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _PLUID;
        public long? PLUID
        {
            get 
            { 
				return _PLUID; 
            }
            
            set
            {                
                _PLUID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PLUID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        public DbCommand GetUpdateCommand() 
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();            
        }
        
        public DbCommand GetInsertCommand()
        { 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand()
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        //persistence
        public void Save()
        {
            Save("");
        }
        
        public void Update(string userName)
        {
            _repo.Update(this);
            OnSaved();
       }
        
        public void Add(string userName)
        {
            this.SetKeyValue(_repo.Add(this));
            OnSaved();
        }
        
        public void Save(string userName) 
        {
            if (_isNew) 
            {
                Add(userName);                
            }
            else 
            {
                Update(userName);
            }            
        }

        public void Delete()
        {
            _repo.Delete(KeyValue());
						
        }

        public static void Delete(object key) 
        {        
            var repo = new SubSonicRepository<WH_Relation_Cook_PLU>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<WH_Relation_Cook_PLU, bool>> expression)
        {
            var repo = GetRepo();            
  
            repo.DeleteMany(expression);            
        }
        
        public void Load(IDataReader rdr)
        {
            Load(rdr, true);
        }
        
        public void Load(IDataReader rdr, bool closeReader)
        {
            if (rdr.Read())
             {
                try
                {
                    rdr.Load(this);
                    _isNew = false;
                    _isLoaded = true;
                } 
                catch 
                {
                    _isLoaded = false;
                    throw;
                }
            }
            else
            {
                _isLoaded = false;
            }

            if (closeReader)
                rdr.Dispose();
        }
    }

	#endregion 

	#region WH_PLU Class
	   
    /// <summary>
    /// A class which represents the WH_PLU table in the PBM Database.
    /// </summary>
    public partial class WH_PLU: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<WH_PLU> TestItems;
        static TestRepository<WH_PLU> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<WH_PLU>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<WH_PLU> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(WH_PLU item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                WH_PLU item=new WH_PLU();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<WH_PLU> _repo;
        ITable tbl;
        bool _isNew;
        
        public bool IsNew()
        {
            return _isNew;
        }
        
        public void SetIsNew(bool isNew)
        {
            _isNew=isNew;
        }
        
        bool _isLoaded;
        public bool IsLoaded()
        {
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty()
        {
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns ()
        {
            return _dirtyColumns;
        }

        PBM.DAL.PBMDB _db;
        public WH_PLU(string connectionString, string providerName) 
        {

            _db=new PBM.DAL.PBMDB(connectionString, providerName);
            Init();            
         }
         
        void Init()
        {
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode)
            {
                WH_PLU.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_PLU>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public WH_PLU()
        {
             _db=new PBM.DAL.PBMDB();
            Init();            
        }        
       
        partial void OnCreated();            
        partial void OnLoaded();        
        partial void OnSaved();        
        partial void OnChanged();
        
        public IList<IColumn> Columns
        {
            get
            {
                return tbl.Columns;
            }
        }

        public WH_PLU(Expression<Func<WH_PLU, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<WH_PLU> GetRepo(string connectionString, string providerName)
        {
            PBM.DAL.PBMDB db;
            if(String.IsNullOrEmpty(connectionString))
            {
                db=new PBM.DAL.PBMDB();
            }
            else
            {
                db=new PBM.DAL.PBMDB(connectionString, providerName);
            }
            
            IRepository<WH_PLU> _repo;
            
            if(db.TestMode)
            {
                WH_PLU.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_PLU>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<WH_PLU> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static WH_PLU SingleOrDefault(Expression<Func<WH_PLU, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<WH_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_PLU>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static WH_PLU SingleOrDefault(Expression<Func<WH_PLU, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_PLU>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<WH_PLU, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<WH_PLU, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<WH_PLU> Find(Expression<Func<WH_PLU, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<WH_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_PLU>();
        }
        
        public static IList<WH_PLU> Find(Expression<Func<WH_PLU, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_PLU>();
        }
        
        public static IQueryable<WH_PLU> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<WH_PLU> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WH_PLU> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WH_PLU> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WH_PLU> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<WH_PLU> GetPaged(int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(pageIndex, pageSize);            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value)
        {
            if (value != null)
             {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString()
        {
            return this.ID.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(WH_PLU))
            {
                WH_PLU compare=(WH_PLU)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.ID.ToString();
        }

        public string DescriptorColumn() 
        {
            return "ID";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "ID";
        }
        
        #region ' Foreign Keys '
        #endregion     

        string _ID;
        public string ID
        {
            get 
            { 
				return _ID; 
            }
            
            set
            {                
                _ID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Bar_Code;
        public string Bar_Code
        {
            get 
            { 
				return _Bar_Code; 
            }
            
            set
            {                
                _Bar_Code=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Bar_Code");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Description;
        public string Description
        {
            get 
            { 
				return _Description; 
            }
            
            set
            {                
                _Description=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Dept_No;
        public string Dept_No
        {
            get 
            { 
				return _Dept_No; 
            }
            
            set
            {                
                _Dept_No=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Dept_No");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        decimal? _Price1;
        public decimal? Price1
        {
            get 
            { 
				return _Price1; 
            }
            
            set
            {                
                _Price1=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Price1");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        decimal? _Price2;
        public decimal? Price2
        {
            get 
            { 
				return _Price2; 
            }
            
            set
            {                
                _Price2=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Price2");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        decimal? _Price3;
        public decimal? Price3
        {
            get 
            { 
				return _Price3; 
            }
            
            set
            {                
                _Price3=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Price3");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _PriceMat;
        public long? PriceMat
        {
            get 
            { 
				return _PriceMat; 
            }
            
            set
            {                
                _PriceMat=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PriceMat");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isMode;
        public long? isMode
        {
            get 
            { 
				return _isMode; 
            }
            
            set
            {                
                _isMode=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isMode");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _Inventory;
        public long? Inventory
        {
            get 
            { 
				return _Inventory; 
            }
            
            set
            {                
                _Inventory=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Inventory");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _Inventory_safty;
        public long? Inventory_safty
        {
            get 
            { 
				return _Inventory_safty; 
            }
            
            set
            {                
                _Inventory_safty=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Inventory_safty");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _menu_flag;
        public long? menu_flag
        {
            get 
            { 
				return _menu_flag; 
            }
            
            set
            {                
                _menu_flag=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="menu_flag");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isCondiment;
        public long? isCondiment
        {
            get 
            { 
				return _isCondiment; 
            }
            
            set
            {                
                _isCondiment=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isCondiment");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _Modifier;
        public long? Modifier
        {
            get 
            { 
				return _Modifier; 
            }
            
            set
            {                
                _Modifier=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Modifier_description;
        public string Modifier_description
        {
            get 
            { 
				return _Modifier_description; 
            }
            
            set
            {                
                _Modifier_description=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier_description");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Modifier_Unity_Quantity;
        public string Modifier_Unity_Quantity
        {
            get 
            { 
				return _Modifier_Unity_Quantity; 
            }
            
            set
            {                
                _Modifier_Unity_Quantity=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier_Unity_Quantity");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _Modifier_Price;
        public long? Modifier_Price
        {
            get 
            { 
				return _Modifier_Price; 
            }
            
            set
            {                
                _Modifier_Price=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Modifier_Price");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        public DbCommand GetUpdateCommand() 
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();            
        }
        
        public DbCommand GetInsertCommand()
        { 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand()
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        //persistence
        public void Save()
        {
            Save("");
        }
        
        public void Update(string userName)
        {
            _repo.Update(this);
            OnSaved();
       }
        
        public void Add(string userName)
        {
            this.SetKeyValue(_repo.Add(this));
            OnSaved();
        }
        
        public void Save(string userName) 
        {
            if (_isNew) 
            {
                Add(userName);                
            }
            else 
            {
                Update(userName);
            }            
        }

        public void Delete()
        {
            _repo.Delete(KeyValue());
						
        }

        public static void Delete(object key) 
        {        
            var repo = new SubSonicRepository<WH_PLU>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<WH_PLU, bool>> expression)
        {
            var repo = GetRepo();            
  
            repo.DeleteMany(expression);            
        }
        
        public void Load(IDataReader rdr)
        {
            Load(rdr, true);
        }
        
        public void Load(IDataReader rdr, bool closeReader)
        {
            if (rdr.Read())
             {
                try
                {
                    rdr.Load(this);
                    _isNew = false;
                    _isLoaded = true;
                } 
                catch 
                {
                    _isLoaded = false;
                    throw;
                }
            }
            else
            {
                _isLoaded = false;
            }

            if (closeReader)
                rdr.Dispose();
        }
    }

	#endregion 

	#region WH_Department Class
	   
    /// <summary>
    /// A class which represents the WH_Department table in the PBM Database.
    /// </summary>
    public partial class WH_Department: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<WH_Department> TestItems;
        static TestRepository<WH_Department> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<WH_Department>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<WH_Department> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(WH_Department item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                WH_Department item=new WH_Department();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<WH_Department> _repo;
        ITable tbl;
        bool _isNew;
        
        public bool IsNew()
        {
            return _isNew;
        }
        
        public void SetIsNew(bool isNew)
        {
            _isNew=isNew;
        }
        
        bool _isLoaded;
        public bool IsLoaded()
        {
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty()
        {
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns ()
        {
            return _dirtyColumns;
        }

        PBM.DAL.PBMDB _db;
        public WH_Department(string connectionString, string providerName) 
        {

            _db=new PBM.DAL.PBMDB(connectionString, providerName);
            Init();            
         }
         
        void Init()
        {
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode)
            {
                WH_Department.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Department>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public WH_Department()
        {
             _db=new PBM.DAL.PBMDB();
            Init();            
        }        
       
        partial void OnCreated();            
        partial void OnLoaded();        
        partial void OnSaved();        
        partial void OnChanged();
        
        public IList<IColumn> Columns
        {
            get
            {
                return tbl.Columns;
            }
        }

        public WH_Department(Expression<Func<WH_Department, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<WH_Department> GetRepo(string connectionString, string providerName)
        {
            PBM.DAL.PBMDB db;
            if(String.IsNullOrEmpty(connectionString))
            {
                db=new PBM.DAL.PBMDB();
            }
            else
            {
                db=new PBM.DAL.PBMDB(connectionString, providerName);
            }
            
            IRepository<WH_Department> _repo;
            
            if(db.TestMode)
            {
                WH_Department.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Department>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<WH_Department> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static WH_Department SingleOrDefault(Expression<Func<WH_Department, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<WH_Department>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Department>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static WH_Department SingleOrDefault(Expression<Func<WH_Department, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Department>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Department>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<WH_Department, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<WH_Department, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<WH_Department> Find(Expression<Func<WH_Department, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<WH_Department>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Department>();
        }
        
        public static IList<WH_Department> Find(Expression<Func<WH_Department, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Department>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Department>();
        }
        
        public static IQueryable<WH_Department> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<WH_Department> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WH_Department> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WH_Department> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WH_Department> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<WH_Department> GetPaged(int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(pageIndex, pageSize);            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value)
        {
            if (value != null)
             {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString()
        {
            return this.Description.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(WH_Department))
            {
                WH_Department compare=(WH_Department)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Description.ToString();
        }

        public string DescriptorColumn() 
        {
            return "Description";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "Description";
        }
        
        #region ' Foreign Keys '
        #endregion     

        long _ID;
        public long ID
        {
            get 
            { 
				return _ID; 
            }
            
            set
            {                
                _ID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Description;
        public string Description
        {
            get 
            { 
				return _Description; 
            }
            
            set
            {                
                _Description=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _High_Digit_LockOut;
        public long? High_Digit_LockOut
        {
            get 
            { 
				return _High_Digit_LockOut; 
            }
            
            set
            {                
                _High_Digit_LockOut=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="High_Digit_LockOut");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isDirectSale;
        public long? isDirectSale
        {
            get 
            { 
				return _isDirectSale; 
            }
            
            set
            {                
                _isDirectSale=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDirectSale");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isAge;
        public long? isAge
        {
            get 
            { 
				return _isAge; 
            }
            
            set
            {                
                _isAge=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isAge");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isPrice;
        public long? isPrice
        {
            get 
            { 
				return _isPrice; 
            }
            
            set
            {                
                _isPrice=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isPrice");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _DepartmentGroup;
        public long? DepartmentGroup
        {
            get 
            { 
				return _DepartmentGroup; 
            }
            
            set
            {                
                _DepartmentGroup=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DepartmentGroup");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _KP;
        public long? KP
        {
            get 
            { 
				return _KP; 
            }
            
            set
            {                
                _KP=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="KP");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isMode;
        public long? isMode
        {
            get 
            { 
				return _isMode; 
            }
            
            set
            {                
                _isMode=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isMode");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isPriceFormat;
        public long? isPriceFormat
        {
            get 
            { 
				return _isPriceFormat; 
            }
            
            set
            {                
                _isPriceFormat=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isPriceFormat");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isType;
        public long? isType
        {
            get 
            { 
				return _isType; 
            }
            
            set
            {                
                _isType=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isType");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isVat_Tax_GST;
        public long? isVat_Tax_GST
        {
            get 
            { 
				return _isVat_Tax_GST; 
            }
            
            set
            {                
                _isVat_Tax_GST=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isVat_Tax_GST");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _str_Vat_Tax_GST;
        public string str_Vat_Tax_GST
        {
            get 
            { 
				return _str_Vat_Tax_GST; 
            }
            
            set
            {                
                _str_Vat_Tax_GST=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="str_Vat_Tax_GST");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        public DbCommand GetUpdateCommand() 
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();            
        }
        
        public DbCommand GetInsertCommand()
        { 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand()
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        //persistence
        public void Save()
        {
            Save("");
        }
        
        public void Update(string userName)
        {
            _repo.Update(this);
            OnSaved();
       }
        
        public void Add(string userName)
        {
            this.SetKeyValue(_repo.Add(this));
            OnSaved();
        }
        
        public void Save(string userName) 
        {
            if (_isNew) 
            {
                Add(userName);                
            }
            else 
            {
                Update(userName);
            }            
        }

        public void Delete()
        {
            _repo.Delete(KeyValue());
						
        }

        public static void Delete(object key) 
        {        
            var repo = new SubSonicRepository<WH_Department>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<WH_Department, bool>> expression)
        {
            var repo = GetRepo();            
  
            repo.DeleteMany(expression);            
        }
        
        public void Load(IDataReader rdr)
        {
            Load(rdr, true);
        }
        
        public void Load(IDataReader rdr, bool closeReader)
        {
            if (rdr.Read())
             {
                try
                {
                    rdr.Load(this);
                    _isNew = false;
                    _isLoaded = true;
                } 
                catch 
                {
                    _isLoaded = false;
                    throw;
                }
            }
            else
            {
                _isLoaded = false;
            }

            if (closeReader)
                rdr.Dispose();
        }
    }

	#endregion 

	#region WH_Clerk Class
	   
    /// <summary>
    /// A class which represents the WH_Clerk table in the PBM Database.
    /// </summary>
    public partial class WH_Clerk: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<WH_Clerk> TestItems;
        static TestRepository<WH_Clerk> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<WH_Clerk>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<WH_Clerk> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(WH_Clerk item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                WH_Clerk item=new WH_Clerk();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<WH_Clerk> _repo;
        ITable tbl;
        bool _isNew;
        
        public bool IsNew()
        {
            return _isNew;
        }
        
        public void SetIsNew(bool isNew)
        {
            _isNew=isNew;
        }
        
        bool _isLoaded;
        public bool IsLoaded()
        {
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty()
        {
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns ()
        {
            return _dirtyColumns;
        }

        PBM.DAL.PBMDB _db;
        public WH_Clerk(string connectionString, string providerName) 
        {

            _db=new PBM.DAL.PBMDB(connectionString, providerName);
            Init();            
         }
         
        void Init()
        {
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode)
            {
                WH_Clerk.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Clerk>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public WH_Clerk()
        {
             _db=new PBM.DAL.PBMDB();
            Init();            
        }        
       
        partial void OnCreated();            
        partial void OnLoaded();        
        partial void OnSaved();        
        partial void OnChanged();
        
        public IList<IColumn> Columns
        {
            get
            {
                return tbl.Columns;
            }
        }

        public WH_Clerk(Expression<Func<WH_Clerk, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<WH_Clerk> GetRepo(string connectionString, string providerName)
        {
            PBM.DAL.PBMDB db;
            if(String.IsNullOrEmpty(connectionString))
            {
                db=new PBM.DAL.PBMDB();
            }
            else
            {
                db=new PBM.DAL.PBMDB(connectionString, providerName);
            }
            
            IRepository<WH_Clerk> _repo;
            
            if(db.TestMode)
            {
                WH_Clerk.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Clerk>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<WH_Clerk> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static WH_Clerk SingleOrDefault(Expression<Func<WH_Clerk, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<WH_Clerk>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Clerk>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static WH_Clerk SingleOrDefault(Expression<Func<WH_Clerk, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Clerk>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Clerk>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<WH_Clerk, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<WH_Clerk, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<WH_Clerk> Find(Expression<Func<WH_Clerk, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<WH_Clerk>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Clerk>();
        }
        
        public static IList<WH_Clerk> Find(Expression<Func<WH_Clerk, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Clerk>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Clerk>();
        }
        
        public static IQueryable<WH_Clerk> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<WH_Clerk> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WH_Clerk> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WH_Clerk> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WH_Clerk> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<WH_Clerk> GetPaged(int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(pageIndex, pageSize);            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value)
        {
            if (value != null)
             {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString()
        {
            return this.SecretCode.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(WH_Clerk))
            {
                WH_Clerk compare=(WH_Clerk)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.SecretCode.ToString();
        }

        public string DescriptorColumn() 
        {
            return "SecretCode";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "SecretCode";
        }
        
        #region ' Foreign Keys '
        #endregion     

        long _ID;
        public long ID
        {
            get 
            { 
				return _ID; 
            }
            
            set
            {                
                _ID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _isNum;
        public long? isNum
        {
            get 
            { 
				return _isNum; 
            }
            
            set
            {                
                _isNum=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isNum");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _SecretCode;
        public string SecretCode
        {
            get 
            { 
				return _SecretCode; 
            }
            
            set
            {                
                _SecretCode=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SecretCode");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Description;
        public string Description
        {
            get 
            { 
				return _Description; 
            }
            
            set
            {                
                _Description=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Limitaions;
        public string Limitaions
        {
            get 
            { 
				return _Limitaions; 
            }
            
            set
            {                
                _Limitaions=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Limitaions");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        public DbCommand GetUpdateCommand() 
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();            
        }
        
        public DbCommand GetInsertCommand()
        { 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand()
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        //persistence
        public void Save()
        {
            Save("");
        }
        
        public void Update(string userName)
        {
            _repo.Update(this);
            OnSaved();
       }
        
        public void Add(string userName)
        {
            this.SetKeyValue(_repo.Add(this));
            OnSaved();
        }
        
        public void Save(string userName) 
        {
            if (_isNew) 
            {
                Add(userName);                
            }
            else 
            {
                Update(userName);
            }            
        }

        public void Delete()
        {
            _repo.Delete(KeyValue());
						
        }

        public static void Delete(object key) 
        {        
            var repo = new SubSonicRepository<WH_Clerk>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<WH_Clerk, bool>> expression)
        {
            var repo = GetRepo();            
  
            repo.DeleteMany(expression);            
        }
        
        public void Load(IDataReader rdr)
        {
            Load(rdr, true);
        }
        
        public void Load(IDataReader rdr, bool closeReader)
        {
            if (rdr.Read())
             {
                try
                {
                    rdr.Load(this);
                    _isNew = false;
                    _isLoaded = true;
                } 
                catch 
                {
                    _isLoaded = false;
                    throw;
                }
            }
            else
            {
                _isLoaded = false;
            }

            if (closeReader)
                rdr.Dispose();
        }
    }

	#endregion 

	#region WH_CookInformation Class
	   
    /// <summary>
    /// A class which represents the WH_CookInformation table in the PBM Database.
    /// </summary>
    public partial class WH_CookInformation: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<WH_CookInformation> TestItems;
        static TestRepository<WH_CookInformation> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<WH_CookInformation>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<WH_CookInformation> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(WH_CookInformation item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                WH_CookInformation item=new WH_CookInformation();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<WH_CookInformation> _repo;
        ITable tbl;
        bool _isNew;
        
        public bool IsNew()
        {
            return _isNew;
        }
        
        public void SetIsNew(bool isNew)
        {
            _isNew=isNew;
        }
        
        bool _isLoaded;
        public bool IsLoaded()
        {
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty()
        {
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns ()
        {
            return _dirtyColumns;
        }

        PBM.DAL.PBMDB _db;
        public WH_CookInformation(string connectionString, string providerName) 
        {

            _db=new PBM.DAL.PBMDB(connectionString, providerName);
            Init();            
         }
         
        void Init()
        {
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode)
            {
                WH_CookInformation.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_CookInformation>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public WH_CookInformation()
        {
             _db=new PBM.DAL.PBMDB();
            Init();            
        }        
       
        partial void OnCreated();            
        partial void OnLoaded();        
        partial void OnSaved();        
        partial void OnChanged();
        
        public IList<IColumn> Columns
        {
            get
            {
                return tbl.Columns;
            }
        }

        public WH_CookInformation(Expression<Func<WH_CookInformation, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<WH_CookInformation> GetRepo(string connectionString, string providerName)
        {
            PBM.DAL.PBMDB db;
            if(String.IsNullOrEmpty(connectionString))
            {
                db=new PBM.DAL.PBMDB();
            }
            else
            {
                db=new PBM.DAL.PBMDB(connectionString, providerName);
            }
            
            IRepository<WH_CookInformation> _repo;
            
            if(db.TestMode)
            {
                WH_CookInformation.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_CookInformation>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<WH_CookInformation> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static WH_CookInformation SingleOrDefault(Expression<Func<WH_CookInformation, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<WH_CookInformation>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_CookInformation>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static WH_CookInformation SingleOrDefault(Expression<Func<WH_CookInformation, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_CookInformation>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_CookInformation>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<WH_CookInformation, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<WH_CookInformation, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<WH_CookInformation> Find(Expression<Func<WH_CookInformation, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<WH_CookInformation>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_CookInformation>();
        }
        
        public static IList<WH_CookInformation> Find(Expression<Func<WH_CookInformation, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_CookInformation>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_CookInformation>();
        }
        
        public static IQueryable<WH_CookInformation> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<WH_CookInformation> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WH_CookInformation> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WH_CookInformation> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WH_CookInformation> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<WH_CookInformation> GetPaged(int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(pageIndex, pageSize);            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value)
        {
            if (value != null)
             {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString()
        {
            return this.Description.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(WH_CookInformation))
            {
                WH_CookInformation compare=(WH_CookInformation)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.Description.ToString();
        }

        public string DescriptorColumn() 
        {
            return "Description";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "Description";
        }
        
        #region ' Foreign Keys '
        #endregion     

        long _ID;
        public long ID
        {
            get 
            { 
				return _ID; 
            }
            
            set
            {                
                _ID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _Num;
        public long? Num
        {
            get 
            { 
				return _Num; 
            }
            
            set
            {                
                _Num=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Num");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        string _Description;
        public string Description
        {
            get 
            { 
				return _Description; 
            }
            
            set
            {                
                _Description=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _price;
        public long? price
        {
            get 
            { 
				return _price; 
            }
            
            set
            {                
                _price=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="price");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        public DbCommand GetUpdateCommand() 
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();            
        }
        
        public DbCommand GetInsertCommand()
        { 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand()
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        //persistence
        public void Save()
        {
            Save("");
        }
        
        public void Update(string userName)
        {
            _repo.Update(this);
            OnSaved();
       }
        
        public void Add(string userName)
        {
            this.SetKeyValue(_repo.Add(this));
            OnSaved();
        }
        
        public void Save(string userName) 
        {
            if (_isNew) 
            {
                Add(userName);                
            }
            else 
            {
                Update(userName);
            }            
        }

        public void Delete()
        {
            _repo.Delete(KeyValue());
						
        }

        public static void Delete(object key) 
        {        
            var repo = new SubSonicRepository<WH_CookInformation>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<WH_CookInformation, bool>> expression)
        {
            var repo = GetRepo();            
  
            repo.DeleteMany(expression);            
        }
        
        public void Load(IDataReader rdr)
        {
            Load(rdr, true);
        }
        
        public void Load(IDataReader rdr, bool closeReader)
        {
            if (rdr.Read())
             {
                try
                {
                    rdr.Load(this);
                    _isNew = false;
                    _isLoaded = true;
                } 
                catch 
                {
                    _isLoaded = false;
                    throw;
                }
            }
            else
            {
                _isLoaded = false;
            }

            if (closeReader)
                rdr.Dispose();
        }
    }

	#endregion 

	#region WH_Relation_PLU_Condiment Class
	   
    /// <summary>
    /// A class which represents the WH_Relation_PLU_Condiment table in the PBM Database.
    /// </summary>
    public partial class WH_Relation_PLU_Condiment: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<WH_Relation_PLU_Condiment> TestItems;
        static TestRepository<WH_Relation_PLU_Condiment> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<WH_Relation_PLU_Condiment>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<WH_Relation_PLU_Condiment> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(WH_Relation_PLU_Condiment item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                WH_Relation_PLU_Condiment item=new WH_Relation_PLU_Condiment();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<WH_Relation_PLU_Condiment> _repo;
        ITable tbl;
        bool _isNew;
        
        public bool IsNew()
        {
            return _isNew;
        }
        
        public void SetIsNew(bool isNew)
        {
            _isNew=isNew;
        }
        
        bool _isLoaded;
        public bool IsLoaded()
        {
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty()
        {
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns ()
        {
            return _dirtyColumns;
        }

        PBM.DAL.PBMDB _db;
        public WH_Relation_PLU_Condiment(string connectionString, string providerName) 
        {

            _db=new PBM.DAL.PBMDB(connectionString, providerName);
            Init();            
         }
         
        void Init()
        {
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode)
            {
                WH_Relation_PLU_Condiment.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Relation_PLU_Condiment>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public WH_Relation_PLU_Condiment()
        {
             _db=new PBM.DAL.PBMDB();
            Init();            
        }        
       
        partial void OnCreated();            
        partial void OnLoaded();        
        partial void OnSaved();        
        partial void OnChanged();
        
        public IList<IColumn> Columns
        {
            get
            {
                return tbl.Columns;
            }
        }

        public WH_Relation_PLU_Condiment(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<WH_Relation_PLU_Condiment> GetRepo(string connectionString, string providerName)
        {
            PBM.DAL.PBMDB db;
            if(String.IsNullOrEmpty(connectionString))
            {
                db=new PBM.DAL.PBMDB();
            }
            else
            {
                db=new PBM.DAL.PBMDB(connectionString, providerName);
            }
            
            IRepository<WH_Relation_PLU_Condiment> _repo;
            
            if(db.TestMode)
            {
                WH_Relation_PLU_Condiment.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<WH_Relation_PLU_Condiment>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<WH_Relation_PLU_Condiment> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static WH_Relation_PLU_Condiment SingleOrDefault(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<WH_Relation_PLU_Condiment>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Relation_PLU_Condiment>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static WH_Relation_PLU_Condiment SingleOrDefault(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Relation_PLU_Condiment>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<WH_Relation_PLU_Condiment>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<WH_Relation_PLU_Condiment> Find(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<WH_Relation_PLU_Condiment>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Relation_PLU_Condiment>();
        }
        
        public static IList<WH_Relation_PLU_Condiment> Find(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<WH_Relation_PLU_Condiment>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<WH_Relation_PLU_Condiment>();
        }
        
        public static IQueryable<WH_Relation_PLU_Condiment> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<WH_Relation_PLU_Condiment> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WH_Relation_PLU_Condiment> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WH_Relation_PLU_Condiment> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WH_Relation_PLU_Condiment> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<WH_Relation_PLU_Condiment> GetPaged(int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(pageIndex, pageSize);            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value)
        {
            if (value != null)
             {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString()
        {
            return this.PLUID.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(WH_Relation_PLU_Condiment))
            {
                WH_Relation_PLU_Condiment compare=(WH_Relation_PLU_Condiment)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.PLUID.ToString();
        }

        public string DescriptorColumn() 
        {
            return "PLUID";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "PLUID";
        }
        
        #region ' Foreign Keys '
        #endregion     

        long _ID;
        public long ID
        {
            get 
            { 
				return _ID; 
            }
            
            set
            {                
                _ID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _PLUID;
        public long? PLUID
        {
            get 
            { 
				return _PLUID; 
            }
            
            set
            {                
                _PLUID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PLUID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        long? _condimentPLUID;
        public long? condimentPLUID
        {
            get 
            { 
				return _condimentPLUID; 
            }
            
            set
            {                
                _condimentPLUID=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="condimentPLUID");
                if(col!=null)
                {
                    if(!_dirtyColumns.Contains(col) && _isLoaded)
                    {
                        _dirtyColumns.Add(col);
                    }
                }
                
                OnChanged();
            }
        }
        
        public DbCommand GetUpdateCommand() 
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();            
        }
        
        public DbCommand GetInsertCommand()
        { 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand()
        {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        //persistence
        public void Save()
        {
            Save("");
        }
        
        public void Update(string userName)
        {
            _repo.Update(this);
            OnSaved();
       }
        
        public void Add(string userName)
        {
            this.SetKeyValue(_repo.Add(this));
            OnSaved();
        }
        
        public void Save(string userName) 
        {
            if (_isNew) 
            {
                Add(userName);                
            }
            else 
            {
                Update(userName);
            }            
        }

        public void Delete()
        {
            _repo.Delete(KeyValue());
						
        }

        public static void Delete(object key) 
        {        
            var repo = new SubSonicRepository<WH_Relation_PLU_Condiment>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<WH_Relation_PLU_Condiment, bool>> expression)
        {
            var repo = GetRepo();            
  
            repo.DeleteMany(expression);            
        }
        
        public void Load(IDataReader rdr)
        {
            Load(rdr, true);
        }
        
        public void Load(IDataReader rdr, bool closeReader)
        {
            if (rdr.Read())
             {
                try
                {
                    rdr.Load(this);
                    _isNew = false;
                    _isLoaded = true;
                } 
                catch 
                {
                    _isLoaded = false;
                    throw;
                }
            }
            else
            {
                _isLoaded = false;
            }

            if (closeReader)
                rdr.Dispose();
        }
    }

	#endregion 
}
