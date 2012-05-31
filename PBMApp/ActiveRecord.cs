


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

	#region PLU Class
	   
    /// <summary>
    /// A class which represents the PLU table in the PBM Database.
    /// </summary>
    public partial class PLU: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<PLU> TestItems;
        static TestRepository<PLU> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<PLU>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<PLU> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(PLU item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                PLU item=new PLU();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<PLU> _repo;
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
        public PLU(string connectionString, string providerName) 
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
                PLU.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<PLU>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public PLU()
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

        public PLU(Expression<Func<PLU, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<PLU> GetRepo(string connectionString, string providerName)
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
            
            IRepository<PLU> _repo;
            
            if(db.TestMode)
            {
                PLU.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<PLU>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<PLU> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static PLU SingleOrDefault(Expression<Func<PLU, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<PLU>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static PLU SingleOrDefault(Expression<Func<PLU, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<PLU>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<PLU, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<PLU, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<PLU> Find(Expression<Func<PLU, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<PLU>();
        }
        
        public static IList<PLU> Find(Expression<Func<PLU, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<PLU>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<PLU>();
        }
        
        public static IQueryable<PLU> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<PLU> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PLU> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PLU> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PLU> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<PLU> GetPaged(int pageIndex, int pageSize) 
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
            if(obj.GetType()==typeof(PLU))
            {
                PLU compare=(PLU)obj;
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
        
        string _detail;
        public string detail
        {
            get 
            { 
				return _detail; 
            }
            
            set
            {                
                _detail=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="detail");
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
        
        string _PriceMat;
        public string PriceMat
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
        
        long? _eable;
        public long? eable
        {
            get 
            { 
				return _eable; 
            }
            
            set
            {                
                _eable=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eable");
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
        
        long? _disp_flag;
        public long? disp_flag
        {
            get 
            { 
				return _disp_flag; 
            }
            
            set
            {                
                _disp_flag=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="disp_flag");
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
        
        long? _plu_group;
        public long? plu_group
        {
            get 
            { 
				return _plu_group; 
            }
            
            set
            {                
                _plu_group=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="plu_group");
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
            var repo = new SubSonicRepository<PLU>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<PLU, bool>> expression)
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

	#region CookInfo Class
	   
    /// <summary>
    /// A class which represents the CookInfo table in the PBM Database.
    /// </summary>
    public partial class CookInfo: IActiveRecord
    {    
        #region Built-in testing
        
        static IList<CookInfo> TestItems;
        static TestRepository<CookInfo> _testRepo;
        
        public void SetIsLoaded(bool isLoaded)
        {
            _isLoaded=isLoaded;
        }
        
        static void SetTestRepo()
        {
            _testRepo  =  _testRepo ?? new TestRepository<CookInfo>(new PBM.DAL.PBMDB());
        }
        
        public static void ResetTestRepo()
        {
            _testRepo = null;
            SetTestRepo();
        }
        
        public static void Setup(List<CookInfo> testlist)
        {
            SetTestRepo();
            _testRepo._items = testlist;
        }
        
        public static void Setup(CookInfo item) 
        {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        
        public static void Setup(int testItems) 
        {
            SetTestRepo();
            for(int i=0;i<testItems;i++)
            {
                CookInfo item=new CookInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;

        #endregion

        IRepository<CookInfo> _repo;
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
        public CookInfo(string connectionString, string providerName) 
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
                CookInfo.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<CookInfo>(_db);
            }
            
            tbl=_repo.GetTable();
            _isNew = true;
            OnCreated();
        }
        
        public CookInfo()
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

        public CookInfo(Expression<Func<CookInfo, bool>> expression):this() 
        {
            _isLoaded=_repo.Load(this,expression);
            if(_isLoaded)
                OnLoaded();
        }
        
        internal static IRepository<CookInfo> GetRepo(string connectionString, string providerName)
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
            
            IRepository<CookInfo> _repo;
            
            if(db.TestMode)
            {
                CookInfo.SetTestRepo();
                _repo=_testRepo;
            }
            else
            {
                _repo = new SubSonicRepository<CookInfo>(db);
            }
            
            return _repo;        
        }       
        
        internal static IRepository<CookInfo> GetRepo()
        {
            return GetRepo("","");
        }
        
        public static CookInfo SingleOrDefault(Expression<Func<CookInfo, bool>> expression)
        {           
            var qry=new SubSonic.Query.Select().From<CookInfo>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<CookInfo>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }
              
        public static CookInfo SingleOrDefault(Expression<Func<CookInfo, bool>> expression,string connectionString, string providerName)
        {            
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<CookInfo>();
            qry.Constraints=expression.ParseConstraints().ToList();
            var single=qry.ExecuteSingle<CookInfo>();
            
            if (single != null)
                single.OnLoaded();
                
            return single;
        }        
        
        public static bool Exists(Expression<Func<CookInfo, bool>> expression,string connectionString, string providerName)
        {           
            return All(connectionString,providerName).Any(expression);
        }
                
        public static bool Exists(Expression<Func<CookInfo, bool>> expression) 
        {
           
            return All().Any(expression);
        }        

        public static IList<CookInfo> Find(Expression<Func<CookInfo, bool>> expression)
        {            
            var qry=new SubSonic.Query.Select().From<CookInfo>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<CookInfo>();
        }
        
        public static IList<CookInfo> Find(Expression<Func<CookInfo, bool>> expression,string connectionString, string providerName) 
        {
            var provider=ProviderFactory.GetProvider(connectionString,providerName);
            var qry=new SubSonic.Query.Select(provider).From<CookInfo>();
            qry.Constraints=expression.ParseConstraints().ToList();
            
            return qry.ToList<CookInfo>();
        }
        
        public static IQueryable<CookInfo> All(string connectionString, string providerName) 
        {
            return GetRepo(connectionString,providerName).GetAll();
        }
        
        public static IQueryable<CookInfo> All() 
        {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CookInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CookInfo> GetPaged(string sortBy, int pageIndex, int pageSize) 
        {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CookInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName)
        {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);            
        }

        public static PagedList<CookInfo> GetPaged(int pageIndex, int pageSize) 
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
            return this.cookName.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType()==typeof(CookInfo))
            {
                CookInfo compare=(CookInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.cookName.ToString();
        }

        public string DescriptorColumn() 
        {
            return "cookName";
        }
        
        public static string GetKeyColumn()
        {
            return "ID";
        }  
              
        public static string GetDescriptorColumn()
        {
            return "cookName";
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
        
        string _cookName;
        public string cookName
        {
            get 
            { 
				return _cookName; 
            }
            
            set
            {                
                _cookName=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="cookName");
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
        
        decimal? _price;
        public decimal? price
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
        
        string _description;
        public string description
        {
            get 
            { 
				return _description; 
            }
            
            set
            {                
                _description=value;
                var col=tbl.Columns.SingleOrDefault(x=>x.Name=="description");
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
            var repo = new SubSonicRepository<CookInfo>(new PBM.DAL.PBMDB());
             
            repo.Delete(key);            
        }

        public static void DeleteMany(Expression<Func<CookInfo, bool>> expression)
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
