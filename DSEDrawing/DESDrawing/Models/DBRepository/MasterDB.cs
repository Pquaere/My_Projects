using Dapper;
using DESDrawing.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESDrawing.Models.DBRepository
{
    public class MasterDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();

        #region CITY MASTER
        public List<SelectListItem> stateList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = _dapper.GetAll<SelectListItem>("proc_bindstate", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public City SaveCity(City model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@City_Name", model.CityName);
                Parametor.Add("@StateID", model.StateID);
                Parametor.Add("@Created_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", 0);
                City CityList = _dapper.Execute<City>("Insert_Update_City", Parametor);
                return CityList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public City UpdateCity(City model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@City_Name", model.CityName);
                Parametor.Add("@StateID", model.StateID);
                Parametor.Add("@Upadated_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", model.ID);
                City CityList = _dapper.Execute<City>("Insert_Update_City", Parametor);
                return CityList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<City> Citylist()
        {
            try
            {
                var query = new DynamicParameters();
                List<City> objlist = _dapper.GetAll<City>("Fetch_Cities", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public City GetCityDetails(int? ID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_Id", ID);
                City details = _dapper.Execute<City>("Fetch_Cities", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public City changecitystatus(City model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.Isactive);
                City DelCity = _dapper.Execute<City>("SetStatus_City", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Zone MASTER
        public List<SelectListItem> RegionList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = _dapper.GetAll<SelectListItem>("proc_bindregion", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Zone SaveZone(Zone model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Zone_Name", model.ZoneName);
                Parametor.Add("@RegionID", model.RegionId);
                Parametor.Add("@Created_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", 0);
                Zone ZoneList = _dapper.Execute<Zone>("Insert_Update_Zone", Parametor);
                return ZoneList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Zone UpdateZone(Zone model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Zone_Name", model.ZoneName);
                Parametor.Add("@RegionID", model.RegionId);
                Parametor.Add("@Updated_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", model.ID);
                Zone ZoneList = _dapper.Execute<Zone>("Insert_Update_Zone", Parametor);
                return ZoneList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Zone> ZoneList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Zone> objlist = _dapper.GetAll<Zone>("Fetch_Zones", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Zone GetZoneDetails(int? ID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_Id", ID);
                Zone details = _dapper.Execute<Zone>("Fetch_Zones", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Zone changezonestatus(Zone model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.Isactive);
                Zone DelCity = _dapper.Execute<Zone>("SetStatus_Zone", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
        #region Region MASTER
        public List<SelectListItem> Discomofficesdrop()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = _dapper.GetAll<SelectListItem>("proc_binddescomoffice", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Region SaveRegion(Region model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Region_Name", model.RegionName);
                Parametor.Add("@DisComID", model.DiscomofficeName);
                Parametor.Add("@Created_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", 0);
                Region _iresult = _dapper.Execute<Region>("[Insert_Update_Region]", Parametor);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Region EditRegion(Region model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Region_Name", model.RegionName);
                Parametor.Add("@DisComID", model.DiscomofficeName);
                Parametor.Add("@Updated_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", model.Id);
                Region _iresult = _dapper.Execute<Region>("[Insert_Update_Region]", Parametor);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Region> ResionList()
        {
            try
            {
                var query = new DynamicParameters();

                List<Region> objlist = _dapper.GetAll<Region>("[Fetch_Regions]", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Region ResionListById(int? ID)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@PK_Id", ID);
                Region objlist = _dapper.Execute<Region>("[Fetch_Regions]", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Region changeRegionstatus(Region model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.Id);
                Parametor.Add("@IsActive", model.Isactive);
                Region DelCity = _dapper.Execute<Region>("SetStatus_Region", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
        #region State MASTER
        public List<SelectListItem> BindZoneList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = _dapper.GetAll<SelectListItem>("proc_bindzones", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static State AddState(State model)
        {
            State _iresult = new State();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@State_Name", model.StateName);
                queryParameters.Add("@Created_By", SessionManager.UserId);
                queryParameters.Add("@Pk_Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_State", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static State GetStateByID(State model)
        {
            State _iresult = new State();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<State>("Fetch_States", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static State ListState(State model)
        {
            State _iresult = new State();

            try
            {
                var queryParameters = new DynamicParameters();
                List<State> list = DBHelperDapper.DAAddAndReturnModelList<State>("Fetch_States", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static State UpdateState(State model)
        {
            State _iresult = new State();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@State_Name", model.StateName);
                queryParameters.Add("@Updated_By", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_State", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static State changeStatestatus(State model)
        {
            State _iresult = new State();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.Isactive);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_State", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
        #region District MASTER
        public static District GetDistrictByID(District model)
        {
            District _iresult = new District();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<District>("Fetch_Districts", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static District AddDistrict(District model)
        {
            District _iresult = new District();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@District_Name", model.DistrictName);
                queryParameters.Add("@ZoneID", model.ZoneID);
                queryParameters.Add("@Created_By", SessionManager.UserId);
                queryParameters.Add("@Pk_Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_District", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static District ListDistrict(District model)
        {
            District _iresult = new District();

            try
            {
                var queryParameters = new DynamicParameters();
                List<District> list = DBHelperDapper.DAAddAndReturnModelList<District>("Fetch_Districts", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static District UpdateDistrict(District model)
        {
            District _iresult = new District();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@District_Name", model.DistrictName);
                queryParameters.Add("@ZoneID", model.ZoneID);
                queryParameters.Add("@Updated_By", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_District", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static District changeDistrictstatus(District model)
        {
            District _iresult = new District();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.Isactive);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_District", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
        #region DiscomOffice MASTER
        public DiscomOffice SaveDiscomOffice(DiscomOffice model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Discomoffice_Name", model.OfficeName.Trim());
                Parametor.Add("@Created_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", 0);
                DiscomOffice DiscomOfficeList = _dapper.Execute<DiscomOffice>("Insert_Update_DiscomOffice", Parametor);
                return DiscomOfficeList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DiscomOffice UpdateDiscomOffice(DiscomOffice model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Discomoffice_Name", model.OfficeName);
                Parametor.Add("@Updated_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", model.ID);
                DiscomOffice DiscomOfficeList = _dapper.Execute<DiscomOffice>("Insert_Update_DiscomOffice", Parametor);
                return DiscomOfficeList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<DiscomOffice> DiscomOfficelist()
        {
            try
            {
                var query = new DynamicParameters();
                List<DiscomOffice> objlist = _dapper.GetAll<DiscomOffice>("Fetch_DiscomOffice", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DiscomOffice GetDiscomOfficeDetails(int? ID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@PK_Id", ID);
                DiscomOffice details = _dapper.Execute<DiscomOffice>("Fetch_DiscomOffice", Parametor);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DiscomOffice ChangeDiscomOfficestatus(DiscomOffice model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.Isactive);
                DiscomOffice DelCity = _dapper.Execute<DiscomOffice>("SetStatus_DiscomOffice", Parametor);
                return DelCity;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion
        #region Load Master
        public List<SelectListItem> BindRoleList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();
                obj = _dapper.GetAll<SelectListItem>("proc_bindrole", param);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Load GetLoadByID(Load model)
        {
            Load _iresult = new Load();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Load>("Fetch_Loads", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Load UpdateLoad(Load model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Loadfrom", model.LoadFrom);
                Parametor.Add("@Loadto", model.Loadto);
                Parametor.Add("@RoleID", model.FK_RoleId);
                Parametor.Add("@Updated_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", model.ID);
                Load loadlist = _dapper.Execute<Load>("Insert_Update_Load", Parametor);
                return loadlist;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Load SaveLoad(Load model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Loadfrom", model.LoadFrom);
                Parametor.Add("@Loadto", model.Loadto);
                Parametor.Add("@RoleID", model.FK_RoleId);
                Parametor.Add("@Created_By", SessionManager.UserId);
                Parametor.Add("@Pk_Id", 0);
                Load loadlist = _dapper.Execute<Load>("Insert_Update_Load", Parametor);
                return loadlist;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Load> Loadlist()
        {
            try
            {
                var query = new DynamicParameters();
                List<Load> objlist = _dapper.GetAll<Load>("Fetch_Loads", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}