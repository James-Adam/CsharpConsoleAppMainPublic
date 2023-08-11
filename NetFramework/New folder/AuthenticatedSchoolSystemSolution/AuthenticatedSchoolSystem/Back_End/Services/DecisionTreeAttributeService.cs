using AuthenticatedSchoolSystem.Models.Back_End;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using WebGrease;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public class DecisionTreeAttributeService : IDecisionTreeAttributeService
    {
        private readonly IRepository<AdvItemServiceDependency> _advItemServiceDependencyRepository;
        private readonly IRepository<AdvItemServiceMultiplier> _advItemServiceMultiplierRepository;
        private readonly IRepository<AdvItemService> _advItemServiceRepository;
        private readonly IRepository<Assumption> _assumptionRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IDataProvider _dataProvider;

        private readonly IDbContext _dbContext;

        //fields
        private readonly IRepository<DecisionTreeAttribute> _decisionTreeAttributeRepository;

        private readonly IRepository<DecisionTreeAttributeValue> _decisionTreeAttributeValueRepository;
        private readonly IRepository<DecisionTreeGridResult> _decisionTreeGridResultRepository;
        private readonly IRepository<DecisionTree> _decisionTreeRepository;
        private readonly IRepository<Dependancy> _dependancyRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<ItemMaster> _itemMasterRepository;
        private readonly IRepository<JWO> _jwoRepository;

        public DecisionTreeAttributeService(
            IRepository<DecisionTreeAttribute> decisionTreeAttributeRepository,
            IRepository<DecisionTreeAttributeValue> decisionTreeAttributeValueRepository,
            IRepository<Assumption> assumptionRepository,
            IRepository<Dependancy> dependancyRepository,
            IRepository<ItemMaster> itemMasterRepository,
            IEventPublisher eventPublisher,
            ICacheManager cacheManager,
            IRepository<DecisionTree> decisionTreeRepository,
            IRepository<JWO> jwoRepository,
            IRepository<AdvItemService> advItemServiceRepository,
            IRepository<AdvItemServiceDependency> advItemServiceDependencyRepository,
            IRepository<DecisionTreeGridResult> decisionTreeGridResultRepository,
            IRepository<AdvItemServiceMultiplier> advItemServiceMultiplierRepository,
            IDbContext dbContext,
            IDataProvider dataProvider
        )
        {
            _cacheManager = cacheManager;
            _decisionTreeAttributeRepository = decisionTreeAttributeRepository;
            _decisionTreeAttributeValueRepository = decisionTreeAttributeValueRepository;
            _assumptionRepository = assumptionRepository;
            _dependancyRepository = dependancyRepository;
            _itemMasterRepository = itemMasterRepository;
            _eventPublisher = eventPublisher;
            _decisionTreeRepository = decisionTreeRepository;
            _jwoRepository = jwoRepository;
            _advItemServiceRepository = advItemServiceRepository;
            _advItemServiceDependencyRepository = advItemServiceDependencyRepository;
            _decisionTreeGridResultRepository = decisionTreeGridResultRepository;
            _advItemServiceMultiplierRepository = advItemServiceMultiplierRepository;
            _dbContext = dbContext;
            _dataProvider = dataProvider;
        }

        public string DECISIONTREEATTRUBUTES_BY_ID_KEY { get; }
        public object DECISIONTREEATTRIBUTES_PATTERN_KEY { get; }
        public object DECISIONTREEATTRIBUTEVALUES_PATTERN_KEY { get; }
        public string DECISIONTREEATTRIBUTES_ALL_KEY { get; }

        //public virtual DecisionTreeAttribute GetDecisionTreeAttributesById(int decisionTreeAttributeId)
        //{
        //    if (decisionTreeAttributeId == 0)
        //        return null;
        //    string key = string.Format(DECISIONTREEATTRUBUTES_BY_ID_KEY, decisionTreeAttributeId);
        //    return _cacheManager.Get(key, () => _decisionTreeAttributeRepository.GetById(decisionTreeAttributeId));
        //}

        public virtual void DeleteDecisionTreeAttribute(DecisionTreeAttribute decisionTreeAttribute)
        {
            if (decisionTreeAttribute == null)
            {
                throw new ArgumentNullException(nameof(decisionTreeAttribute));
            }

            _decisionTreeAttributeRepository.Delete(decisionTreeAttribute);

            //_cacheManager.RemoveByPattern(DECISIONTREEATTRIBUTES_PATTERN_KEY);
            //_cacheManager.RemoveByPattern(DECISIONTREEATTRIBUTEVALUES_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(decisionTreeAttribute);
        }

        //public static void GetAllDecisionTreeAttributes()
        //{
        //}

        //public virtual IList<DecisionTreeAttribute> GetAllDecisionTreeAttributes()
        //{
        //    string key = DECISIONTREEATTRIBUTES_ALL_KEY;
        //    return _cacheManager.Get(key, () =>
        //    {
        //        CacheResult query = from ca in _decisioNTreeAttributeRepository.Table
        //                            orderby ca.DisplayOrder
        //                            select ca;
        //        return query.ToList();
        //    });
        //}

        //public ItemMaster GetDefaultRatesForGrid(string description)
        //{
        //    var defaultRate = from x in _itemMasterRepository.Table
        //        where x.Description.Contains(description)
        //        select x;

        //    return defaultRate.FirstOrDefault();
        //}

        public virtual byte[] ExportDecisionTreeAttributesToXlsx(
            IEnumerable<DecisionTreeAttribute> decisionTreeAttributes)
        {
            //var properties = new[]
            //{
            //    new PropertyByName<DecisionTreeAttribute>("Id", p => p.Id),
            //    new PropertyByName<DecisionTreeAttribute>("Name", p => p.Name),
            //    new PropertyByName<DecisionTreeAttribute>("Statement", p => p.Statement),

            //};

            return null;
        }

        public virtual string ExportDecisionTreeAttributesToXml(IList<DecisionTreeAttribute> decisionTreeAttributes)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("DecisionTreeAttributes");
            xmlWriter.WriteAttributeString("Version", AcfVersion.CurrentVersion);

            foreach (DecisionTreeAttribute decisionTreeAttribute in decisionTreeAttributes)
            {
                xmlWriter.WriteStartElement("DecisionTreeAttribute");

                xmlWriter.WriteString(decisionTreeAttribute.Name); //name
                xmlWriter.WriteString(decisionTreeAttribute.Statement); //'Statement", , CapsAllText(a => a.Statement)

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            return stringWriter.ToString();
        }

        public virtual void DeleteAdvItemServiceMultiplier(AdvItemServiceMultiplier itemServiceMultiplier)
        {
            if (itemServiceMultiplier == null)
            {
                throw new ArgumentException("itemServiceMultiplier");
            }
        }

        //public IPagedList<AdvItemServiceMultiplier> GetAdvItemServiceMultipliers(int pageIndex, int pageSize, int ItemServiceId)
        //{
        //    var query = from x in _advItemServiceMultiplierRepository.Table
        //                where x.AdvItemServiceId == ItemServiceId
        //                select x;

        // query = query.where(c => c.AdvItemServiceId == ItemServiceId); query = query.OrderBy(c => c.Id);

        //    var multipliers = new PagedList<AdvItemServiceMultiplier>(query, pageIndex, pageSize);
        //    return multipliers;
        //}

        //public IPagedList<ItemMaster> GetItemMaster(int pageIndex, int pageSize, Filter filter)
        //{
        //    var query = _itemMasterRepository.Table;
        //    if(filter != null)
        //    {
        //        Dictionary<string, string>  filters = new Dictionary<string, string>();
        //        foreach (var f in filter.filters)

        // { filters.Add(f.Field.ToLowerInvariant(), ((string[])f.Value).FirstOrDefailt()); } var
        // filteredList = query.ToList();

        // string categoryTerms = string.Empty; string level1Terms = string.Empty; string
        // level2Terms = string.Empty; string descriptionTerms = string.Empty;

        // if (filters.ContainsKey("category")) { categoryTerms = filters["category"]; } if
        // (filters.ContainsKey("level1")) { categoryTerms = filters["level1"]; } if
        // (filters.ContainsKey("level2")) { categoryTerms = filters["level2"];

        // } if (filters.ContainsKey("description")) { categoryTerms = filters["description"]; }
        // query = query.Where(x => x.Category.Contains(categoryTerms)).Where(x =>
        // x.Level1.Contains(level1Terms)).Where(x => x.Level2.Contains(level2Terms));

        // } query = query.OrderBy(c => c.Id);

        // var items = new PagedList<ItemMaster>(query, pageIndex, pageSize); return items;

        //}

        //public virtual ItemMaster GetItemMasterEntrybyItemNumber(int itemNumber)
        //{
        //    var query = from cav in _itemMasterRepository.Table
        //                where cav.ItemNumber.Equals(itemNumber)
        //                select cav;
        //    return query.FirstOrDefault();
        //}

        //public virtual IList<ItemMaster> GetAvailableItemNumbers()
        //{
        //    var query = from cav in _itemMasterRepository.Table
        //                orderby cav.ItemNumber
        //                select cav;
        //    return query.ToList();
        //}

        //public virtual int GetCountSample()
        //{
        //    var query = _dbContext.ExecuteSqlCommand("Select count(*) id from ItemMaster");
        //    return query;
        //}

        //public virtual PagedList<DecisionTreeAttribute> StoredProcTest(int pageIndex, int pageSize, int criteria1, int criteria2)
        //{
        //    var pTotalRecords = _dataProvider.GetPerameter();
        //    pTotalRecords.ParameterName = "TotalRecords";
        //    pTotalRecords.Direction = ParameterDirection.Output;
        //    pTotalRecords.DbType = DbType.Int32;

        // var pCriteria1 = _dataProvider.GetParameter(); pCriteria1.ParameterName = "Criteria1";
        // pCriteria1.Value = criteria1; pCriteria1.DbType = DbType.Boolean;

        // var pCriteria2 = _dataProvider.GetParameter(); pCriteria1.ParameterName = "Criteria2";
        // pCriteria1.Value = criteria2; pCriteria1.DbType = DbType.Boolean;

        // var questions = _dbContext.ExecuteStoredProcedureList<DecisionTreeAttribute>(
        // "FilterTrees", pCriteria1, pCriteria2, pTotalRecords );

        //    int totalRecords = (pTotalRecords.Value != DBNull.Value) ? Convert.ToInt32(pTotalRecords.Value): 0;
        //    return new PagedList<DecisionTreeAttribute>(questions, pageIndex, pageSize, totalRecords);
        //}

        //public virtual void InsertDecisionTreeAttribute(DecisionTreeAttribute decisionTreeAttribute)
        //{
        //    if (decisionTreeAttribute == null)
        //        throw new ArgumentNullException("decisionTreeAttribute");

        // _decisionTreeAttributeRepository.Insert(decisionTreeAttribute);

        // _cacheManager.RemoveByPattern(DECISIONTREEATTRIBUTES_PATTERN_KEY); _cacheManager.RemoveByPattern(DECISIONTREEATTRIBUTEVALUES_PATTERN_KEY);

        // //event notification _eventPublisher.EntityInserted(decisionTreeAttribute);

        //}

        //public virtual IList<DecisionTreeAttribute> GetAllQuestionsForTemplateFromDisplayIndex(int templateId, int decisionTreeId, int fromDisplayOrder)
        //{
        //    var query = from ca in _decisionTreeAttributeRepository.TableNoTracking
        //                where ca.ProductId == templateId & ca.DecisionTreeId == decisionTreeId
        //                select ca;

        // query = query.Where(x => x.DisplayOrder >= fromDisplayOrder);

        //    return query.ByOrder(x => x.DisplayOrder).ToList();
        //}

        //public virtual DecisionTree GetDecisionTreeById(int decisionTreeId)
        //{
        //    var query = from ca in _decisionTreeRepository.Table
        //                where ca.Id == decisionTreeId
        //                select ca;

        //    return query.FirstOrDefault();
        //}

        //public virtual void TransactionSample()
        //{
        //    using (var dBContext = _dbContext.BeginTransaction())
        //    {
        //        try
        //        {
        //            _dbContext.ExecuteSqlCommand(@"Update DecisioNTreeAttribute set as Statement='New Statement' Where Id=5");
        //            var query = from x in _decisionTreeAttributeRepository.Table
        //                        select x;
        //            foreach (var q in query)
        //            {
        //                q.Name = q.Name + "Copy";
        //            }

        // DbContext.Commit();

        //        }
        //        catch
        //        {
        //            DbContext.RollBack();
        //        }
        //    }
        //}

        public void DeleteItemMaster(ItemMaster itemMaster)
        {
            if (itemMaster == null)
            {
                throw new ArgumentNullException("ItemMaster");
            }

            _itemMasterRepository.Delete(itemMaster);

            //event Notification
            _eventPublisher.EntityDeleted(itemMaster);
        }

        public void UpdateItemMaster(ItemMaster itemMaster)
        {
            if (itemMaster == null)
            {
                throw new ArgumentNullException("ItemMaster");
            }

            _itemMasterRepository.Update(itemMaster);

            //event Notification
            _eventPublisher.EntityUpdated(itemMaster);
        }

        public void InsertItemMaster(ItemMaster itemMaster)
        {
            _itemMasterRepository.Insert(itemMaster);

            //event Notification
            _eventPublisher.EntityInserted(itemMaster);

            if (itemMaster == null)
            {
                throw new ArgumentNullException("ItemMaster");
            }
        }
    }
}