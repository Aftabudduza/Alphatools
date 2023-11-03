using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class CmsPageRefDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public CmsPageRefDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public CmsPageRefDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public CMSPageRef GetCmsPageRefbyPageName(string csmPage, int iVersion)
        {
            var empQuery = from b in _obAlphaToolEntities.CMSPageRef
                where b.CMSPage == csmPage && b.CMSVersion == iVersion
                select b;

            var objCmsPageRef = empQuery.ToList().FirstOrDefault();

            return objCmsPageRef;
        }

        public CMSPageRef GetCmsPageRefbyPageNameIslive(string csmPage, string live)
        {
            var empQuery = from b in _obAlphaToolEntities.CMSPageRef
                           where b.CMSPage == csmPage && b.Live == live
                           select b;

            var objCmsPageRef = empQuery.ToList().FirstOrDefault();

            if (objCmsPageRef == null)
            {
                CMSPageRef obj = new CMSPageRef();

                obj.CMSPage = csmPage;
                obj.CMSTitle = csmPage;
                obj.CMSContent = "Please Add Content";
                obj.DateCreated = DateTime.UtcNow;
                obj.DateModified = DateTime.UtcNow;
                obj.WebsiteID = 1;
                obj.AffiliateID = 0;
                obj.CustomerID = 0;
                obj.CMSCategoryId = 0;
                obj.CMSVersion = 1;
                obj.Live = "Y";

                objCmsPageRef = InsertNewCMS(obj);            
            }

            return objCmsPageRef;
        }

        public CMSPageRef InsertNewCMS(CMSPageRef obj)
        {
            _obAlphaToolEntities.CMSPageRef.Add(obj);
            _obAlphaToolEntities.SaveChanges();
            return obj;
        }

        public bool Insert(CMSPageRef obj)
        {
            _obAlphaToolEntities.CMSPageRef.Add(obj);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        public bool Update(CMSPageRef obj)
        {
            var existing = _obAlphaToolEntities.CMSPageRef.Find(obj.CMSPage, obj.CMSVersion);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool Update_MakeLive(CMSPageRef obj)
        {
            var existing = _obAlphaToolEntities.CMSPageRef.Find(obj.CMSPage);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(string csmPage, int iVersion)
        {
            var objToDelete = GetCmsPageRefbyPageName(csmPage, iVersion);
            _obAlphaToolEntities.CMSPageRef.Remove(objToDelete);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        public List<CMSPageRef> GetAllCmsPageRef()
        {
            var empQuery = from b in _obAlphaToolEntities.CMSPageRef
                select b;

            var listCmsPageRefs = empQuery.ToList();
            return listCmsPageRefs;
        }

        public List<CMSPageRef> GetSkusBySql(string sql)
        {
            List<CMSPageRef> skus = null;
            if (sql != "")
            {
                var empQuery = _obAlphaToolEntities.CMSPageRef.SqlQuery(sql).ToList();
                skus = empQuery;
            }
            return skus;
        }

        public List<CMSPageRef> GeneratePageNodes(int id)
        {
            List<CMSPageRef> listCmsPageRef;
            if (id > 0)
            {
                var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.Live == "Y" && x.CMSCategoryId == id).ToList();
                listCmsPageRef = list;
            }
            else
            {
                var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.Live == "Y" && x.CMSCategoryId <= 0).ToList();
                listCmsPageRef = list;
            }
            return listCmsPageRef;
        }

        public List<CMSPageRef> EditCmsPage(string pageTitle)
        {
            var listCmsPageRef = new List<CMSPageRef>();
            if (pageTitle != null)
            {
                var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.Live == "Y" && x.CMSPage == pageTitle.Replace("'", "''")).ToList();
                listCmsPageRef = list;
            }
            return listCmsPageRef;
        }

        public List<CMSPageRef> TotalCmsPage(string pageTitle)
        {
            var listCmsPageRef = new List<CMSPageRef>();
            if (pageTitle != null)
            {
                var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.CMSPage == pageTitle.Replace("'", "''")).ToList();
                listCmsPageRef = list;
            }
            return listCmsPageRef;
        }

        public int GetMaxVersion(string cmsPageName)
        {
            var p = 0;
            try
            {
                if (cmsPageName != null)
                {
                    var maxPages = (from c in _obAlphaToolEntities.CMSPageRef
                                    where c.CMSPage == cmsPageName
                                    select c).Count();
                    p = Convert.ToInt32(maxPages.ToString());
                }
            }
            catch
            {
                // ignored
            }
            return p;
        }

        public List<CMSPageRef> DisplayPageVersion(string sCmsPage, int iVersion)
        {
            var listCmsPageRefCmsVersion = new List<CMSPageRef>();
            try
            {
                if (sCmsPage != null && iVersion > 0)
                {
                    var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.CMSPage == sCmsPage.Replace("'", "''") && x.CMSVersion == iVersion).ToList();
                    listCmsPageRefCmsVersion = list;
                }
            }
            catch
            {
                // ignored
            }
            return listCmsPageRefCmsVersion;
        }

        public List<CMSPageRef> Fillcontaint(string sCmsPage, int iVersion)
        {
            var listPageContain = new List<CMSPageRef>(); 
            if (sCmsPage != null && iVersion > 0)
            {
                var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.Live == "Y" && x.CMSPage == sCmsPage.Replace("'", "''") && x.CMSVersion == iVersion).ToList();
                listPageContain = list;
            }
            return listPageContain;
        }

        public List<CMSPageRef> GetSameVersionList_ByPageTitle(string sCmsPage)
        {
            var listPageContain = new List<CMSPageRef>(); 
            if (sCmsPage != null)
            {
                var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.CMSPage == sCmsPage.Replace("'", "''")).ToList();
                listPageContain = list;
            }
            return listPageContain;
        }

        public List<CMSPageRef> GetFooterMenu()
        {
            var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.Live == "Y" && x.IsFooter != 0 && (x.IsFooter == 1 || x.IsLeftMenu == x.IsFooter)).OrderBy(x => x.FooterMenuOrder).ToList();
            var listoffootermenu = list;
            return listoffootermenu;
        }

        public List<CMSPageRef> GetHeaderMenu()
        {
            var list = _obAlphaToolEntities.CMSPageRef.Where(x => x.Live == "Y" && (x.IsLeftMenu == 1)).OrderBy(x => x.LeftMenuOrder).ToList();
            var listofheadermenu = list;
            return listofheadermenu;
        }
    }
}
