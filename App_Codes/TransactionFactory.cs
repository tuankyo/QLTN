using System;
using Gnt.Data.Meta;
using Gnt.Transaction;
using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Collections;

namespace Man
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class TransactionFactory {

        #region Fields
        private static TransactionFactory transactionFactory;
        private DBCommandFactory factory;
        #endregion Fields
		
        public TransactionFactory() {
            factory = new DBCommandFactory();
        }
		
        #region Properties 
		
        public static TransactionFactory Factory {
            get { return transactionFactory; }
        }

        public DBCommandFactory DBCommand {
            get { return factory; }
        }

        #endregion Properties 

        #region Methods
        public static void SetFactory(TransactionFactory factory) {
			
            transactionFactory = factory;
        }
        #endregion
		
        public ITransaction GetInsertObject(DataObject objectData) { 
            return new InsertTransaction(objectData, factory);
        }

        public ITransaction GetInsertObject(DataObject objectData, bool childAffect) { 
            return new InsertTransaction(objectData, factory, childAffect);
        }

        public ITransaction GetInsertObject(IList objectDatas) { 
            return new InsertTransaction(objectDatas, factory);
        }

        public ITransaction GetInsertObject(IList objectDatas, bool childAffect) { 
            return new InsertTransaction(objectDatas, factory, childAffect);
        }

        public ITransaction GetUpdateObject(DataObject objectData) { 
            return new UpdateTransaction(objectData, factory);
        }

        public ITransaction GetUpdateObject(DataObject objectData, bool childAffect) { 
            return new UpdateTransaction(objectData, factory, childAffect);
        }

        public ITransaction GetUpdateObject(IList objectDatas) { 
            return new UpdateTransaction(objectDatas, factory);
        }

        public ITransaction GetUpdateObject(IList objectDatas, bool childAffect) { 
            return new UpdateTransaction(objectDatas, factory, childAffect);
        }

        public IDeleteTransaction GetDeleteObject(DataObject objectData) { 
            return new DeleteTransaction(objectData, factory);
        }

        public IDeleteTransaction GetDeleteObject(DataObject objectData, bool isChildAffect) { 
            return new DeleteTransaction(objectData, factory, isChildAffect);
        }

        public IDeleteTransaction GetDeleteObject(IList objectDatas) { 
            return new DeleteTransaction(objectDatas, factory);
        }

        public IDeleteTransaction GetDeleteObject(IList objectDatas, bool isChildAffect) { 
            return new DeleteTransaction(objectDatas, factory, isChildAffect);
        }


        public IListTransaction GetListObject(DataObject obj) { 
            return new ListTransaction(obj, factory);
        }

        public ISearchTransaction GetSearchObject(DataObject obj, string where) { 
            return new SearchTransaction(obj, where, factory, 0, -1);
        }

        public ISearchTransaction GetSearchObject(DataObject obj) { 
            return new SearchTransaction(obj, factory);
        }

        public ISearchTransaction GetSearchObject(DataObject obj, bool checkDelFlag)
        {
            return new SearchTransaction(obj, factory, checkDelFlag);
        }

        public ISearchTransaction GetSearchObject(DataObject obj, Criteria criteria) { 
            return new SearchTransaction(obj, criteria, factory);
        }

        public ISearchTransaction GetSearchObject(DataObject obj, string where, int begin, int count) { 
            return new SearchTransaction(obj, where, factory, begin, count);
        }
        
        public ISearchTransaction GetSearchObject(DataObject obj, int begin, int count) { 
            return new SearchTransaction(obj, "", factory, begin, count);
        }

        public ISearchTransaction GetSearchObject(DataObject obj, Criteria criteria, int begin, int limit) { 
            return new SearchTransaction(obj, criteria, factory, begin, limit);
        }

        public ITransaction GetLoadObject(DataObject obj, string id) { 
            return new LoadTransaction(obj, id, factory);
        }
    }
}
