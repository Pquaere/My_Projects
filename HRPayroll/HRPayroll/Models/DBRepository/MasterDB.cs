using Dapper;
using HRPayroll.Models.Manager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Models.DBRepository
{
    public class MasterDB
    {
        DBHelperDapper _dapper = new DBHelperDapper();

        #region Role Master
        public Role SaveRole(Role model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@RoleName", model.RoleName);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Role>("Insert_Update_Role", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Role UpdateRole(Role model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@RoleName", model.RoleName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Role>("Insert_Update_Role", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Role GetRoleDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Role details = DBHelperDapper.DAAddAndReturnModel<Role>("Fetch_Role", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Role> RoleList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Role> objlist = DBHelperDapper.DAAddAndReturnModelList<Role>("Fetch_Role", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Role ChangeRolestatus(Role model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Role>("SetStatus_Role", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region FormType Master
        public FormType SaveFormType(FormType model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@FormTypeName", model.FormTypeName);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<FormType>("Insert_Update_FormType", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormType UpdateFormType(FormType model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@FormTypeName", model.FormTypeName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<FormType>("Insert_Update_FormType", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public FormType GetFormTypeDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                FormType details = DBHelperDapper.DAAddAndReturnModel<FormType>("Fetch_FormType", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<FormType> FormTypeList()
        {
            try
            {
                var query = new DynamicParameters();
                List<FormType> objlist = DBHelperDapper.DAAddAndReturnModelList<FormType>("Fetch_FormType", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FormType ChangeFormTypestatus(FormType model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<FormType>("SetStatus_FormType", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Form Master
        public List<SelectListItem> BindFormTypeDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_bindformtype", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Form GetFormByID(Form model)
        {
            Form _iresult = new Form();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Form>("Fetch_Form", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Form AddForm(Form model)
        {
            Form _iresult = new Form();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@FormName", model.FormName);
                queryParameters.Add("@FormTypeID", model.FK_FormTypeId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Pk_Id", 0);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Form>("Insert_Update_Form", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Form UpdateForm(Form model)
        {
            Form _iresult = new Form();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@FormName", model.FormName);
                queryParameters.Add("@FormTypeID", model.FK_FormTypeId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Form>("Insert_Update_Form", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Form FormList(Form model)
        {
            Form _iresult = new Form();
            try
            {
                var queryParameters = new DynamicParameters();
                List<Form> list = DBHelperDapper.DAAddAndReturnModelList<Form>("Fetch_Form", queryParameters);
                _iresult.formlist = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Form ChangeFormstatus(Form model)
        {
            Form _iresult = new Form();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Form>("SetStatus_Form", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Bind Dropdowns

        public List<SelectListItem> LevelList()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            try
            {
                var param = new DynamicParameters();

                obj = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("LevelDropdown", param);
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> BindBankDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();

                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_bindBank", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SelectListItem> BindStateDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_bindstate", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> BindDistrictDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_binddistrict", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetDistricts(int StateId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@StateId", StateId);
                List<SelectListItem> ProductList = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_binddistrict", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<SelectListItem> GetSubDepartment(int DepartmentId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@DepartmentId", DepartmentId);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("proc_bindSubDepartment", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetEmpCategory(int empCategory)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@WtfId", empCategory);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("getEmpType", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetEmployee(int TypeId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@WTypeId", TypeId);
                Parametor.Add("@officeid", SessionManager.OfficeID);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("[Bind_Emp]", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetInrementDetail(int LevelID)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@LevelID", LevelID);
                List<SelectListItem> ProductList = _dapper.GetAll<SelectListItem>("Proc_bindIncrement", Parametor);
                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetEmpSalDetail(int SubDeptId, string DptEpCode,string PFMSCODE, string EmpName)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("SubDeptId", SubDeptId);
                query.Add("DptEmpCode", DptEpCode);
                query.Add("PFMSCODE", PFMSCODE);
                query.Add("EmpName", EmpName);
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Bind_Emp_Detail", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ServiceBook GetEmpServiceDetail(ServiceBook model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("EmpId", model.Fk_EmpId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<ServiceBook>("GetServiceBook", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static EmployeePF GetEmpDetail(EmployeePF model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("EmpId", model.Fk_EmpId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeePF>("Bind_EmpDetail", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static EmployeePF GetEmpSalDetail(EmployeePF model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("EmpId", model.Fk_EmpId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeePF>("Fetch_EmpSalaryDetail", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static EmployeePF GetEmpLeaveDetail(EmployeePF model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("EmpId", model.Fk_EmpId);
                query.Add("DptEmpCode", model.DptEmpCode);
                query.Add("PFMSCODE", model.PFMSCODE);
                query.Add("EmpName", model.EmpName);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<EmployeePF>("Bind_EmpLeave_Detail", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<SelectListItem> Dropdown(int ProcId, int value)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ProcId", ProcId);
                queryParameters.Add("@Value", value);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Proc_bindDropdown", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<SelectListItem> Dropdown1(int SubDeptId, int WTypeId)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@SubDeptID", SubDeptId);
                //queryParameters.Add("@Value", value);
                queryParameters.Add("@WTypeId", WTypeId);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("GetEmpName", queryParameters);
                return _Iresult;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<SelectListItem> BindDropdownForLic(int WTypeId, int DepartmentId, int SubDeptId, string PFMSCode, string DeptEmpCode, string EmpName)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WTypeId", WTypeId);
                queryParameters.Add("@DepartmentId", DepartmentId);
                queryParameters.Add("@SubDeptId", SubDeptId);
                queryParameters.Add("@PFMSCode", PFMSCode);
                queryParameters.Add("@DeptEmpCode", DeptEmpCode);
                queryParameters.Add("@EmpName", EmpName);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("Bind_EmpFroLic", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<SelectListItem> ContracturalEmployeeBind(int SubDeptId, int dept)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@subdeptId", SubDeptId);
                queryParameters.Add("@departmentId", dept);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("ContracturalEmployeeBind", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  List<SelectListItem> PaymentHeadDropdown()
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@officeId", SessionManager.OfficeID);

                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("bind_PaymentHead", queryParameters);
                return _Iresult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Bonus
        public static Bonus AddBonus(Bonus model)
        {
            Bonus _iresult = new Bonus();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@LevelId", model.LevelId);
                queryParameters.Add("@EffectiveDate", model.EffectiveDate);
                queryParameters.Add("@BonusAmt", model.BonusAmt);
                queryParameters.Add("@CashPer", model.CashPer);
                queryParameters.Add("@PFPer", model.PFPer);
                queryParameters.Add("@UserId", SessionManager.UserId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Bonus", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bonus GetBonusByID(Bonus model)
        {
            Bonus _iresult = new Bonus();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Bonus>("Fetch_Bonus", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bonus ListBonus(Bonus model)
        {
            Bonus _iresult = new Bonus();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Bonus> list = DBHelperDapper.DAAddAndReturnModelList<Bonus>("Fetch_Bonus", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bonus UpdateBonus(Bonus model)
        {
            Bonus _iresult = new Bonus();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@LevelId", model.LevelId);
                queryParameters.Add("@EffectiveDate", model.EffectiveDate);
                queryParameters.Add("@BonusAmt", model.BonusAmt);
                queryParameters.Add("@CashPer", model.CashPer);
                queryParameters.Add("@PFPer", model.PFPer);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Bonus", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bonus changeBonustatus(Bonus model)
        {
            Bonus _iresult = new Bonus();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Bonus", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Bank
        public static Bank AddBank(Bank model)
        {
            Bank _iresult = new Bank();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@BankName", model.BankName);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Bank", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bank GetBankByID(Bank model)
        {
            Bank _iresult = new Bank();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Bank>("Fetch_Bank", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bank ListBank(Bank model)
        {
            Bank _iresult = new Bank();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Bank> list = DBHelperDapper.DAAddAndReturnModelList<Bank>("Fetch_Bank", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bank UpdateBank(Bank model)
        {
            Bank _iresult = new Bank();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@BankName", model.BankName);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Bank", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bank changeBanktatus(Bank model)
        {
            Bank _iresult = new Bank();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Bank", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Brand
        public static Brands AddBrand(Brands model)
        {
            Brands _iresult = new Brands();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@BrandName", model.BrandName);
                queryParameters.Add("@Fk_CategoryId", model.Fk_CategoryId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Brand", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Brands GetBrandByID(Brands model)
        {
            Brands _iresult = new Brands();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Brands>("Fetch_Brand", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Brands ListBrand(Brands model)
        {
            Brands _iresult = new Brands();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Brands> list = DBHelperDapper.DAAddAndReturnModelList<Brands>("Fetch_Brand", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Brands UpdateBrand(Brands model)
        {
            Brands _iresult = new Brands();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@BrandName", model.BrandName);
                queryParameters.Add("@Fk_CategoryId", model.Fk_CategoryId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Brand", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Brands changeBrandtatus(Brands model)
        {
            Brands _iresult = new Brands();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsDeleted);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Brand", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Category
        public static CategoryModel AddCategory(CategoryModel model)
        {
            CategoryModel _iresult = new CategoryModel();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@CategoryName", model.CategoryName);
                queryParameters.Add("@Images", model.Images);
                queryParameters.Add("@PreferenceOrder", model.PreferenceOrder);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Category", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CategoryModel GetCategoryByID(CategoryModel model)
        {
            CategoryModel _iresult = new CategoryModel();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<CategoryModel>("Fetch_Category", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CategoryModel ListCategory(CategoryModel model)
        {
            CategoryModel _iresult = new CategoryModel();

            try
            {
                var queryParameters = new DynamicParameters();
                List<CategoryModel> list = DBHelperDapper.DAAddAndReturnModelList<CategoryModel>("Fetch_Category", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CategoryModel UpdateCategory(CategoryModel model)
        {
            CategoryModel _iresult = new CategoryModel();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@CategoryName", model.CategoryName);
                queryParameters.Add("@Images", model.Images);
                queryParameters.Add("@PreferenceOrder", model.PreferenceOrder);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Category", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CategoryModel changeCategoryStatus(CategoryModel model)
        {
            CategoryModel _iresult = new CategoryModel();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsDeleted);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Category", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region HolidayType

        public static HolidayTypes AddHolidayType(HolidayTypes model)
        {
            HolidayTypes _iresult = new HolidayTypes();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@HolidayType", model.HolidayType);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_HolidayType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static HolidayTypes GetHolidayTypeByID(HolidayTypes model)
        {
            HolidayTypes _iresult = new HolidayTypes();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<HolidayTypes>("Fetch_HolidayType", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static HolidayTypes ListHolidayType(HolidayTypes model)
        {
            HolidayTypes _iresult = new HolidayTypes();

            try
            {
                var queryParameters = new DynamicParameters();
                List<HolidayTypes> list = DBHelperDapper.DAAddAndReturnModelList<HolidayTypes>("Fetch_HolidayType", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static HolidayTypes UpdateHolidayType(HolidayTypes model)
        {
            HolidayTypes _iresult = new HolidayTypes();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@HolidayType", model.HolidayType);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_HolidayType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static HolidayTypes ChangeHolidayTypestatus(HolidayTypes model)
        {
            HolidayTypes _iresult = new HolidayTypes();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_HolidayType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        #endregion

        #region LeaveType

        public static LeaveTypes AddLeaveType(LeaveTypes model)
        {
            LeaveTypes _iresult = new LeaveTypes();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@LeaveType", model.LeaveType);
                queryParameters.Add("@LeaveDesc", model.LeaveDesc);
                queryParameters.Add("@Payable", model.Payable);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_LeaveType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static LeaveTypes GetLeaveTypeByID(LeaveTypes model)
        {
            LeaveTypes _iresult = new LeaveTypes();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<LeaveTypes>("Fetch_LeaveType", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static LeaveTypes ListLeaveType(LeaveTypes model)
        {
            LeaveTypes _iresult = new LeaveTypes();

            try
            {
                var queryParameters = new DynamicParameters();
                List<LeaveTypes> list = DBHelperDapper.DAAddAndReturnModelList<LeaveTypes>("Fetch_LeaveType", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static LeaveTypes UpdateLeaveType(LeaveTypes model)
        {
            LeaveTypes _iresult = new LeaveTypes();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@LeaveType", model.LeaveType);
                queryParameters.Add("@LeaveDesc", model.LeaveDesc);
                queryParameters.Add("@Payable", model.Payable);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_LeaveType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LeaveTypes ChangeLeaveTypestatus(LeaveTypes model)
        {
            LeaveTypes _iresult = new LeaveTypes();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_LeaveType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region BankBranch

        public static Branch AddBranch(Branch model)
        {
            Branch _iresult = new Branch();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Fk_BankId", model.Fk_BankId);
                queryParameters.Add("@Fk_DistrictId", model.Fk_DistrictId);
                queryParameters.Add("@Fk_StateId", model.Fk_StateId);
                queryParameters.Add("@BranchName", model.BranchName);
                queryParameters.Add("@BranchAddr", model.BranchAddr);
                queryParameters.Add("@RTGSCode", model.RTGSCode);
                queryParameters.Add("@Contactno", model.Contactno);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_BankBranch", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Branch GetBranchByID(Branch model)
        {
            Branch _iresult = new Branch();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Branch>("Fetch_BankBranch", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Branch ListBranch(Branch model)
        {
            Branch _iresult = new Branch();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Branch> list = DBHelperDapper.DAAddAndReturnModelList<Branch>("Fetch_BankBranch", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Branch UpdateBranch(Branch model)
        {
            Branch _iresult = new Branch();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@Fk_BankId", model.Fk_BankId);
                queryParameters.Add("@Fk_DistrictId", model.Fk_DistrictId);
                queryParameters.Add("@Fk_StateId", model.Fk_StateId);
                queryParameters.Add("@BranchName", model.BranchName);
                queryParameters.Add("@BranchAddr", model.BranchAddr);
                queryParameters.Add("@RTGSCode", model.RTGSCode);
                queryParameters.Add("@Contactno", model.Contactno);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_BankBranch", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Branch changeBranchtatus(Branch model)
        {
            Branch _iresult = new Branch();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_BankBranch", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Department

        public static Department AddDepartment(Department model)
        {
            Department _iresult = new Department();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DepartmentHead", model.DepartmentHead);
                queryParameters.Add("@Code", model.Code);
                queryParameters.Add("@UserTypeId", model.UserTypeId);
                queryParameters.Add("@WorkTypeId", model.WorkTypeId);
                queryParameters.Add("@OfficeId", model.OfficeId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Department", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Department GetDepartmentByID(Department model)
        {
            Department _iresult = new Department();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Department>("Fetch_Department", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Department ListDepartment(Department model)
        {
            Department _iresult = new Department();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Department> list = DBHelperDapper.DAAddAndReturnModelList<Department>("Fetch_Department", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Department UpdateDepartment(Department model)
        {
            Department _iresult = new Department();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@DepartmentHead", model.DepartmentHead);
                queryParameters.Add("@Code", model.Code);
                queryParameters.Add("@UserTypeId", model.UserTypeId);
                queryParameters.Add("@WorkTypeId", model.WorkTypeId);
                queryParameters.Add("@OfficeId", model.OfficeId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Department", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Department changeDepartmenttatus(Department model)
        {
            Department _iresult = new Department();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Department", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region SubDepartment

        public static SubDepartment AddSubDepartment(SubDepartment model)
        {
            SubDepartment _iresult = new SubDepartment();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@SubDeptName", model.SubDeptName);
                queryParameters.Add("@Code", model.Code);
                queryParameters.Add("@Fk_DepartmentId", model.Fk_DepartmentId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_SubDepartment", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubDepartment GetSubDepartmentByID(SubDepartment model)
        {
            SubDepartment _iresult = new SubDepartment();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<SubDepartment>("Fetch_SubDepartment", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubDepartment ListSubDepartment(SubDepartment model)
        {
            SubDepartment _iresult = new SubDepartment();

            try
            {
                var queryParameters = new DynamicParameters();
                List<SubDepartment> list = DBHelperDapper.DAAddAndReturnModelList<SubDepartment>("Fetch_SubDepartment", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubDepartment UpdateSubDepartment(SubDepartment model)
        {
            SubDepartment _iresult = new SubDepartment();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@SubDeptName", model.SubDeptName);
                queryParameters.Add("@Code", model.Code);
                queryParameters.Add("@Fk_DepartmentId", model.Fk_DepartmentId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_SubDepartment", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubDepartment changeSubDepartmenttatus(SubDepartment model)
        {
            SubDepartment _iresult = new SubDepartment();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_SubDepartment", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region EmployeeType

        public static Employements AddEmployeeType(Employements model)
        {
            Employements _iresult = new Employements();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@WTypeId", model.WTypeId);
                queryParameters.Add("@Employement", model.Employement);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Employement", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Employements GetEmployeeTypeByID(Employements model)
        {
            Employements _iresult = new Employements();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Employements>("Fetch_Employement", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Employements ListEmployeeType(Employements model)
        {
            Employements _iresult = new Employements();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Employements> list = DBHelperDapper.DAAddAndReturnModelList<Employements>("Fetch_Employement", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Employements UpdateEmployeeType(Employements model)
        {
            Employements _iresult = new Employements();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@WTypeId", model.WTypeId);
                queryParameters.Add("@Employement", model.Employement);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_Employement", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Employements changeEmployeeTypeStatus(Employements model)
        {
            Employements _iresult = new Employements();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Employement", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Activities

        public static Activitie AddActivities(Activitie model)
        {
            Activitie _iresult = new Activitie();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Subject", model.Tittle);
                queryParameters.Add("@Mobile", model.Mobile);
                queryParameters.Add("@DueDate", model.DueDate);
                queryParameters.Add("@ActivityType", model.ActivityType);
                queryParameters.Add("@Status", model.Status);
                queryParameters.Add("@Priority", model.Priority);
                queryParameters.Add("@AssignTo", model.AssignTo);
                queryParameters.Add("@contactperson", model.ContactPerson);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@ProcId", 1);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Proc_NotificationMaster", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Activitie GetActivitiesByID(Activitie model)
        {
            Activitie _iresult = new Activitie();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Activitie>("Fetch_ActivitesDetail", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Activitie ListActivities(Activitie model)
        {
            Activitie _iresult = new Activitie();
            try
            {
                var queryParameters = new DynamicParameters();
                List<Activitie> list = DBHelperDapper.DAAddAndReturnModelList<Activitie>("Fetch_ActivitesDetail", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Activitie UpdateActivities(Activitie model)
        {
            Activitie _iresult = new Activitie();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@NotificationId", model.ID);
                queryParameters.Add("@Subject", model.Tittle);
                queryParameters.Add("@Mobile", model.Mobile);
                queryParameters.Add("@DueDate", model.DueDate);
                queryParameters.Add("@ActivityType", model.ActivityType);
                queryParameters.Add("@Status", model.Status);
                queryParameters.Add("@Priority", model.Priority);
                queryParameters.Add("@AssignTo", model.AssignTo);
                queryParameters.Add("@contactperson", model.ContactPerson);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@ProcId", 2);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Proc_NotificationMaster", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Activitie changeActivieStatus(Activitie model)
        {
            Activitie _iresult = new Activitie();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActivity", model.IsActivity);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_Activity", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region State Master
        public State SaveState(State model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@StateName", model.StateName.Trim());
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<State>("Insert_Update_State", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public State UpdateState(State model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@StateName", model.StateName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<State>("Insert_Update_State", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public State GetStateDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                State details = DBHelperDapper.DAAddAndReturnModel<State>("Fetch_State", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<State> StateList()
        {
            try
            {
                var query = new DynamicParameters();
                List<State> objlist = DBHelperDapper.DAAddAndReturnModelList<State>("Fetch_State", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public State ChangeStatestatus(State model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<State>("SetStatus_State", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region District Master
        public District GetDistrictByID(District model)
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
                throw ex;
            }
        }
        public static District AddDistrict(District model)
        {
            District _iresult = new District();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DistrictName", model.DistrictName);
                queryParameters.Add("@StateID", model.FK_StateId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Pk_Id", 0);
                _iresult = DBHelperDapper.DAAddAndReturnModel<District>("Insert_Update_District", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static District UpdateDistrict(District model)
        {
            District _iresult = new District();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@DistrictName", model.DistrictName);
                queryParameters.Add("@StateID", model.FK_StateId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                _iresult = DBHelperDapper.DAAddAndReturnModel<District>("Insert_Update_District", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static District DistrictList(District model)
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
                throw ex;
            }
        }
        public static District ChangeDistrictstatus(District model)
        {
            District _iresult = new District();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<District>("SetStatus_District", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Office Master
        public Office GetOfficeByID(Office model)
        {
            Office _iresult = new Office();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Office>("Fetch_Office", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Office AddOffice(Office model)
        {
            Office _iresult = new Office();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@OfficeName", model.OfficeName);
                queryParameters.Add("@DistrictID", model.FK_DistrictId);
                queryParameters.Add("@AgencyTypeID", model.FK_AgencyTypeID);
                queryParameters.Add("@AgencyCode", model.AgencyCode);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Pk_Id", 0);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Office>("Insert_Update_Office", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Office UpdateOffice(Office model)
        {
            Office _iresult = new Office();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@OfficeName", model.OfficeName);
                queryParameters.Add("@DistrictID", model.FK_DistrictId);
                queryParameters.Add("@AgencyTypeID", model.FK_AgencyTypeID);
                queryParameters.Add("@AgencyCode", model.AgencyCode);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Office>("Insert_Update_Office", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Office OfficeList(Office model)
        {
            Office _iresult = new Office();
            try
            {
                var queryParameters = new DynamicParameters();
                List<Office> list = DBHelperDapper.DAAddAndReturnModelList<Office>("Fetch_Office", queryParameters);
                _iresult.officeList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Office ChangeOfficestatus(Office model)
        {
            Office _iresult = new Office();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Office>("SetStatus_Office", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Circle Master
        public Circle SaveCircle(Circle model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@CircleName", model.CircleName.Trim());
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Circle>("Insert_Update_Circle", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Circle UpdateCircle(Circle model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@CircleName", model.CircleName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Circle>("Insert_Update_Circle", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Circle GetCircleDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Circle details = DBHelperDapper.DAAddAndReturnModel<Circle>("Fetch_Circle", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Circle> CircleList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Circle> objlist = DBHelperDapper.DAAddAndReturnModelList<Circle>("Fetch_Circle", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Circle ChangeCirclestatus(Circle model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Circle>("SetStatus_Circle", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Desigation
        public Desigation InsertDesigation(Desigation model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("DesignationName", model.DesignationName);
                queryParameter.Add("Code", model.Code);
                queryParameter.Add("CreatedBy", SessionManager.UserId);
                queryParameter.Add("CompanyId", SessionManager.CompanyId);
                queryParameter.Add("DesignationId", model.DesignationId);
                ;
                model = DBHelperDapper.DAAddAndReturnModel<Desigation>("Insert_Update_Desigation", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Desigation UpdateDesigation(Desigation model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("DesignationName", model.DesignationName);
                queryParameter.Add("Code", model.Code);
                queryParameter.Add("updatedBy", SessionManager.UserId);
                queryParameter.Add("CompanyId", SessionManager.CompanyId);
                queryParameter.Add("DesignationId", model.DesignationId);
                ;
                model = DBHelperDapper.DAAddAndReturnModel<Desigation>("Insert_Update_Desigation", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Desigation GetDesignationById(int ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@DesignationId", ID);
                Desigation details = DBHelperDapper.DAAddAndReturnModel<Desigation>("Fetch_Designation", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Desigation> DesignationList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Desigation> objlist = DBHelperDapper.DAAddAndReturnModelList<Desigation>("Fetch_Designation", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Desigation ChangeDesignationstatus(Desigation model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.DesignationId);
                Parametor.Add("@IsActive", model.IsActive);
                Parametor.Add("@UserId", model.UserId);
                model = DBHelperDapper.DAAddAndReturnModel<Desigation>("SEt_Status_Designation", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region DA_Percent & fixallowance 

        public List<SelectListItem> BindPaycommissionDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_Paycommission", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DAPercent AddDAPercent(DAPercent model)
        {
            DAPercent _iresult = new DAPercent();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PayComId", model.PayComId);
                queryParameters.Add("@DAPercent", model.DA_Percent);
                queryParameters.Add("@EffectiveFromDate", model.Date);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@WtypeId", model.EmpCategory);
                queryParameters.Add("@ActionType", "insert");
                _iresult = DBHelperDapper.DAAddAndReturnModel<DAPercent>("Insert_Update_DAPercent", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DAPercent UpdateDAPercent(DAPercent model)
        {
            DAPercent _iresult = new DAPercent();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@PayComId", model.PayComId);
                queryParameters.Add("@DAPercent", model.DA_Percent);
                queryParameters.Add("@EffectiveFromDate", model.Date);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                queryParameters.Add("@WtypeId", model.EmpCategory);
                queryParameters.Add("@ActionType", "Update");
                _iresult = DBHelperDapper.DAAddAndReturnModel<DAPercent>("Insert_Update_DAPercent", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DAPercent DAPercentList(DAPercent model)
        {
            DAPercent _iresult = new DAPercent();
            try
            {
                var queryParameters = new DynamicParameters();
                List<DAPercent> list = DBHelperDapper.DAAddAndReturnModelList<DAPercent>("Fetch_DAPercent", queryParameters);
                _iresult.DAPercent_List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DAPercent ChangeDAPercentstatus(DAPercent model)
        {
            DAPercent _iresult = new DAPercent();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<DAPercent>("SetStatus_DAPercent", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DAPercent GetDA_PercentByID(DAPercent model)
        {
            DAPercent _iresult = new DAPercent();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<DAPercent>("Fetch_DAPercent", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static fixallowance Addfixallowance(fixallowance model)
        {
            fixallowance _iresult = new fixallowance();
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@PayComId", model.PayComId);
                queryParameters.Add("@GradePayId", model.GradepayId);
                queryParameters.Add("@CircleId", model.CircleId);
                queryParameters.Add("@MA", model.MA);
                queryParameters.Add("@WA", model.WA);
                queryParameters.Add("@HRA", model.HRA);
                queryParameters.Add("@EffectiveDate", model.EffectivFromDate);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@ActionType", "insert");
                _iresult = DBHelperDapper.DAAddAndReturnModel<fixallowance>("Insert_Update_fixallowance", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static fixallowance Updatefixallowance(fixallowance model)
        {
            fixallowance _iresult = new fixallowance();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@PayComId", model.PayComId);
                queryParameters.Add("@GradePayId", model.GradepayId);
                queryParameters.Add("@CircleId", model.CircleId);
                queryParameters.Add("@MA", model.MA);
                queryParameters.Add("@WA", model.@WA);
                queryParameters.Add("@HRA", model.HRA);
                queryParameters.Add("@EffectiveDate", model.EffectivFromDate);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                queryParameters.Add("@ActionType", "Update");
                _iresult = DBHelperDapper.DAAddAndReturnModel<fixallowance>("Insert_Update_fixallowance", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static fixallowance fixallowanceList(fixallowance model)
        {
            fixallowance _iresult = new fixallowance();
            try
            {
                var queryParameters = new DynamicParameters();
                List<fixallowance> list = DBHelperDapper.DAAddAndReturnModelList<fixallowance>("Fetch_fixallowance", queryParameters);
                _iresult.fixallowance_List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static fixallowance Changefixallowancestatus(fixallowance model)
        {
            fixallowance _iresult = new fixallowance();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<fixallowance>("SetStatus_fixallowance", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public fixallowance GetfixallowanceByID(fixallowance model)
        {
            fixallowance _iresult = new fixallowance();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<fixallowance>("Fetch_fixallowance", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Holidays
            public List<officelist1> Office()
            {
                List<officelist1> obj = new List<officelist1>();
                try
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    obj = _dapper.GetAll<officelist1>("GetofficeList", dynamicParameters);
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public static Holiday AddHoliday(Holiday model)
            {
                Holiday _iresult = new Holiday();
                try
                {
                    string hids = "";
                    foreach (var x in model.OfficeList.Where(x => x.Checked == true))
                    {
                        if (hids.Trim().Length > 0)
                        { hids = hids + ","; }
                        hids = hids + x.OfficeID;
                    }
                    var queryParameters = new DynamicParameters();

                    queryParameters.Add("@HolidayType", model.HolidayTypeId);
                    queryParameters.Add("@title", model.Title);
                    queryParameters.Add("@holidayDate", model.HolidayDate);
                    queryParameters.Add("@Image", model.HolidayImage);
                    queryParameters.Add("@offileids", hids + ",");
                    queryParameters.Add("@CreatedBy", SessionManager.UserId);
                    queryParameters.Add("@CompanyId", SessionManager.CompanyId);

                    _iresult = DBHelperDapper.DAAddAndReturnModel<Holiday>("Insert_Update_Holidays", queryParameters);
                    return _iresult;
                }
                catch (Exception ex)
                {
                throw ex;
                }
            }
            public static Holiday UpdateHoliday(Holiday model)
            {
                Holiday _iresult = new Holiday();
                try
                {
                    string hids = "";
                    foreach (var x in model.OfficeList.Where(x => x.Checked == true))
                    {
                        if (hids.Trim().Length > 0)
                        { hids = hids + ","; }
                        hids = hids + x.OfficeID;
                    }
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@Pk_Id", model.ID);
                    queryParameters.Add("@HolidayType", model.HolidayTypeId);
                    queryParameters.Add("@title", model.Title);
                    queryParameters.Add("@holidayDate", model.HolidayDate);
                    queryParameters.Add("@offileids", hids + ",");
                    queryParameters.Add("@Image", model.HolidayImage);
                    queryParameters.Add("@UpdatedBy", SessionManager.UserId);

                    _iresult = DBHelperDapper.DAAddAndReturnModel<Holiday>("Insert_Update_Holidays", queryParameters);
                    return _iresult;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public static Holiday HolidayList(Holiday model)
            {
                Holiday _iresult = new Holiday();
                try
                {
                    var queryParameters = new DynamicParameters();
                    List<Holiday> list = DBHelperDapper.DAAddAndReturnModelList<Holiday>("Fetch_Holiday", queryParameters);
                    _iresult.HolidayList = list;
                    return _iresult;
                }
                catch (Exception ex)
                {
                throw ex;
                }
            }

            public static Holiday ChangeHolidayStatus(Holiday model)
            {
                Holiday _iresult = new Holiday();
                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@Pk_Id", model.ID);
                    queryParameters.Add("@IsActive", model.IsActive);
                    _iresult = DBHelperDapper.DAAddAndReturnModel<Holiday>("SetStatus_Holiday", queryParameters);
                    return _iresult;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
            public dynamic GetHolidayByID(int ID)
            {
                Holiday obj = new Holiday();
                using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
                {

                    try
                    {
                        var queryParameters = new DynamicParameters();
                        queryParameters.Add("@PK_Id", ID);
                        var redar = con.QueryMultiple("Fetch_Holiday", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                        var Vm = redar.Read<Holiday>().FirstOrDefault();
                        var Vl = redar.Read<officelist1>().ToList();
                        obj = Vm;
                        obj.OfficeList = Vl;
                        return obj;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        #endregion

        #region Leave Request
        public static LeaveRequest LeaveType()
        {
            LeaveRequest _iresult = new LeaveRequest();
            try
            {
                var queryParameters = new DynamicParameters();
                List<LeaveTypes> list = DBHelperDapper.DAAddAndReturnModelList<LeaveTypes>("Fetch_LeaveTypes", queryParameters);
                _iresult.LeaveTypes = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static LeaveRequest AddLeaveRequest(LeaveRequest model)
        {
            LeaveRequest _iresult = new LeaveRequest();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmployeeId", model.FK_EmployeeType);
                queryParameters.Add("@Pk_LeaveId", model.LeaveCategory);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@FinYear", model.Year);
                queryParameters.Add("@Leavedetal", model.xmlData);
                queryParameters.Add("@LeaveCategory", model.LeaveCategory);
                queryParameters.Add("@Designation", model.Designation);
                queryParameters.Add("@Fk_CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Loginid", SessionManager.LoginId);
                queryParameters.Add("@name", SessionManager.Name);
                queryParameters.Add("@EditLeaveId", model.ID);
                queryParameters.Add("@procid", "1");                
                _iresult = DBHelperDapper.DAAddAndReturnModel<LeaveRequest>("Proc_InsertLeave", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public List<LeaveRequest> AssignLeaveList()
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@procid" , "2");
                query.Add("@Fk_CompanyId", SessionManager.CompanyId);
                List<LeaveRequest> objlist = DBHelperDapper.DAAddAndReturnModelList<LeaveRequest>("Proc_InsertLeave", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LeaveRequest DeleteAssignedLeave(int ID)
        {
            LeaveRequest _iresult = new LeaveRequest();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Fk_CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@EditLeaveId", ID);
                queryParameters.Add("@procid", "4");
                _iresult = DBHelperDapper.DAAddAndReturnModel<LeaveRequest>("Proc_InsertLeave", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public dynamic GetAssignLeaveByID(int ID)
        {
            LeaveRequest obj = new LeaveRequest();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {

                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@Fk_CompanyId", SessionManager.CompanyId);
                    queryParameters.Add("@EditLeaveId", ID);
                    queryParameters.Add("@procid", "3");
                    var redar = con.QueryMultiple("Proc_InsertLeave", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var Vm = redar.Read<LeaveRequest>().FirstOrDefault();
                    var Vl = redar.Read<LeaveTypes>().ToList();
                    obj = Vm;
                    obj.LeaveTypes = Vl;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Salary Stop And Suspend
        public static Employee EmployeeListForSalarySuspendStop(Employee model)
        {
            Employee _iresult = new Employee();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ProcId", "1");
                queryParameters.Add("@EmpTypeId", model.FK_EmployeeType);
                queryParameters.Add("@DesigId", model.Designation);
                queryParameters.Add("@DepartId", model.Department);
                queryParameters.Add("@OfficeId", SessionManager.OfficeID);
                queryParameters.Add("@MonthId", model.monthId);
                queryParameters.Add("@YearId", model.Year);
                queryParameters.Add("@pfmscode", model.PFMSCode);
                queryParameters.Add("@dptempcode", model.DepEMPCode);
                List<Employee> list = DBHelperDapper.DAAddAndReturnModelList<Employee>("GetEmpSalDetails", queryParameters);
                _iresult.EmployeeList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Employee StopAndSuspendSalary(int id , string status)
        {
            Employee _iresult = new Employee();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@EmployeeId", id);     
                queryParameters.Add("@status", status);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Employee>("StopAndSuspendSalary", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SubCategory Master
        public SubCategory GetSubcategoryByID(SubCategory model)
        {
            SubCategory _iresult = new SubCategory();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<SubCategory>("Fetch_SubCategory", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubCategory AddSubcategory(SubCategory model)
        {
            SubCategory _iresult = new SubCategory();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@SubCategoryName", model.SubCategoryName);
                queryParameters.Add("@CategoryID", model.FK_CategoryId);
                queryParameters.Add("@Description", model.Description);
                queryParameters.Add("@AddedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Pk_Id", 0);
                _iresult = DBHelperDapper.DAAddAndReturnModel<SubCategory>("Insert_Update_SubCategory", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubCategory UpdateSubcategory(SubCategory model)
        {
            SubCategory _iresult = new SubCategory();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@SubCategoryName", model.SubCategoryName);
                queryParameters.Add("@CategoryID", model.FK_CategoryId);
                queryParameters.Add("@Description", model.Description);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                _iresult = DBHelperDapper.DAAddAndReturnModel<SubCategory>("Insert_Update_SubCategory", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubCategory SubCategorylist(SubCategory model)
        {
            SubCategory _iresult = new SubCategory();
            try
            {
                var queryParameters = new DynamicParameters();
                List<SubCategory> list = DBHelperDapper.DAAddAndReturnModelList<SubCategory>("Fetch_SubCategory", queryParameters);
                _iresult.clist = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SubCategory ChangeSubCategorystatus(SubCategory model)
        {
            SubCategory _iresult = new SubCategory();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsDeleted", model.IsDeleted);
                _iresult = DBHelperDapper.DAAddAndReturnModel<SubCategory>("SetStatus_SubCategory", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Unit Master
        public Unit SaveUnit(Unit model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@UnitName", model.UnitName);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Unit>("Insert_Update_Unit", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Unit UpdateUnit(Unit model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@UnitName", model.UnitName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Unit>("Insert_Update_Unit", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Unit GetUnitDetail(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Unit details = DBHelperDapper.DAAddAndReturnModel<Unit>("Fetch_Unit", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Unit> Unitlist()
        {
            try
            {
                var query = new DynamicParameters();
                List<Unit> objlist = DBHelperDapper.DAAddAndReturnModelList<Unit>("Fetch_Unit", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Unit ChangeUnitstatus(Unit model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsDeleted", model.IsDeleted);
                model = DBHelperDapper.DAAddAndReturnModel<Unit>("SetStatus_Unit", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Size Master
        public Size SaveSize(Size model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@SizeName", model.SizeName);
                queryParameter.Add("@FK_UNITID", model.FK_UnitID);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Size>("Insert_Update_Size", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Size UpdateSize(Size model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@SizeName", model.SizeName);
                queryParameter.Add("@FK_UNITID", model.FK_UnitID);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Size>("Insert_Update_Size", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Size GetSizeDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Size details = DBHelperDapper.DAAddAndReturnModel<Size>("Fetch_Size", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Size> SizeList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Size> objlist = DBHelperDapper.DAAddAndReturnModelList<Size>("Fetch_Size", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Size ChangeSizestatus(Size model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Size>("SetStatus_Size", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Product Master
        public Product SaveProduct(Product model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@ProductName", model.ProductName);
                queryParameter.Add("@ProductCode", model.ProductCode);
                queryParameter.Add("@@Image", model.ProductImage);
                queryParameter.Add("@Description", model.Description);
                queryParameter.Add("@MetaTitle", model.MetaTitle);
                queryParameter.Add("@MinimumQuantity", model.MinimumQuantity);
                queryParameter.Add("@MetaDescription", model.MetaDescription);
                queryParameter.Add("@MetaKeyword", model.MetaKeyword);
                queryParameter.Add("@SGST", model.SGST);
                queryParameter.Add("@CGST", model.CGST);
                queryParameter.Add("@IGST", model.IGST);
                queryParameter.Add("@SalePrice", model.SalePrice);
                queryParameter.Add("@MRP", model.MRP);
                queryParameter.Add("@HSNCode", model.HSNCode);
                queryParameter.Add("@ProductFeature", model.ProductFeature);
                queryParameter.Add("@FK_BrandID", model.FK_BrandId);
                queryParameter.Add("@FK_UnitID", model.FK_UnitID);
                queryParameter.Add("@FK_CategoryID", model.FK_CategoryID);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@Pk_Id",0);                
                model = DBHelperDapper.DAAddAndReturnModel<Product>("Insert_Update_Product", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Product UpdateProduct(Product model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@ProductName", model.ProductName);
                queryParameter.Add("@ProductCode", model.ProductCode);
                queryParameter.Add("@@Image", model.ProductImage);
                queryParameter.Add("@Description", model.Description);
                queryParameter.Add("@MetaTitle", model.MetaTitle);
                queryParameter.Add("@MinimumQuantity", model.MinimumQuantity);
                queryParameter.Add("@MetaDescription", model.MetaDescription);
                queryParameter.Add("@MetaKeyword", model.MetaKeyword);
                queryParameter.Add("@SGST", model.SGST);
                queryParameter.Add("@CGST", model.CGST);
                queryParameter.Add("@IGST", model.IGST);
                queryParameter.Add("@SalePrice", model.SalePrice);
                queryParameter.Add("@MRP", model.MRP);
                queryParameter.Add("@HSNCode", model.HSNCode);
                queryParameter.Add("@ProductFeature", model.ProductFeature);
                queryParameter.Add("@FK_BrandID", model.FK_BrandId);
                queryParameter.Add("@FK_UnitID", model.FK_UnitID);
                queryParameter.Add("@FK_CategoryID", model.FK_CategoryID);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Product>("Insert_Update_Product", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Product GetProductDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Product details = DBHelperDapper.DAAddAndReturnModel<Product>("Fetch_Product", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Product> ProductList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Product> objlist = DBHelperDapper.DAAddAndReturnModelList<Product>("Fetch_Product", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product ChangeProductstatus(Product model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Product>("SetStatus_Product", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Priyanshu(GetEmpSalDetailPFMSCode)

        public List<SelectListItem> GetEmpSalDetailPFMSCode(string DptEpCode)
        {
            try
            {
                var query = new DynamicParameters();

                query.Add("@DptEmpCode", DptEpCode);

                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Bind_Emp_Detail", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region ServiceType
        public ServiceType GetServiceTypeById(int Id)
        {
            ServiceType model = new ServiceType();
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("Id", Id);
                model = DBHelperDapper.DAAddAndReturnModel<ServiceType>("GetServiceType", parameter);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public ServiceType UpdateServiceType(ServiceType model)
        {
            ServiceType obj = new ServiceType();

            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ServiceTypeId", model.Id);
                parameter.Add("@OfficeId", model.OfficeName);
                parameter.Add("@PPenCont", model.PPenCont);
                parameter.Add("@PPPFCont", model.PPPFCont);
                parameter.Add("@PNPSEmployer", model.PNPSEmployer);
                parameter.Add("@PNPSEmployee", model.PNPSEmployee);
                parameter.Add("@SEPFEmployee", model.SEPFEmployee);
                parameter.Add("@SEPFEmployer", model.SEPFEmployer);
                parameter.Add("@SESICEmployee", model.SESICEmployee);
                parameter.Add("@SESICEmployer", model.SESICEmployer);
                parameter.Add("@SPPFPercent", model.SPPFCont);
                parameter.Add("@SDAPercent", model.SDAPercent);
                parameter.Add("@SPFPercent", model.SPFPercent);
                parameter.Add("@PayComId", model.PayComId);

                parameter.Add("@ActiveDate", model.ActiveDate);
                parameter.Add("@CompanyId", SessionManager.CompanyId);
                parameter.Add("@Action", "update");
                model = DBHelperDapper.DAAddAndReturnModel<ServiceType>("sp_servicetype", parameter);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ServiceType InsertServiceType(ServiceType model)
        {
            ServiceType obj = new ServiceType();

            try
            {
                var parameter = new DynamicParameters();
                //parameter.Add("@ServiceTypeId", model.Id);
                //parameter.Add("@OfficeId", model.OfficeName);
                //parameter.Add("@PPenCont", model.PPenCont);
                //parameter.Add("@PPPFCont", model.PPPFCont);
                //parameter.Add("@PNPSEmployer", model.PNPSEmployer);
                //parameter.Add("@PNPSEmployee", model.PNPSEmployee);
                //parameter.Add("@SEPFEmployee", model.SEPFEmployee);
                //parameter.Add("@SESICEmployee", model.SESICEmployee);
                ////parameter.Add("@SESICEmployer", model.SESICEmployer);
                //parameter.Add("@SPPFPercent", model.SPPFCont);
                //parameter.Add("@SDAPercent", model.SDAPercent);
                //parameter.Add("@SPFPercent", model.SPFPercent);
                //parameter.Add("@PayComId", model.PayComId);

                //parameter.Add("@ActiveDate", model.ActiveDate);
                //parameter.Add("@CompanyId", SessionManager.CompanyId);

                parameter.Add("@ServiceTypeId", model.Id);
                parameter.Add("@OfficeId", model.OfficeName);
                parameter.Add("@PPenCont", model.PPenCont);
                parameter.Add("@PPPFCont", model.PPPFCont);
                parameter.Add("@PNPSEmployer", model.PNPSEmployer);
                parameter.Add("@PNPSEmployee", model.PNPSEmployee);
                parameter.Add("@SEPFEmployee", model.SEPFEmployee);
                parameter.Add("@SEPFEmployer", model.SEPFEmployer);
                parameter.Add("@SESICEmployee", model.SESICEmployee);
                parameter.Add("@SESICEmployer", model.SESICEmployer);
                parameter.Add("@SPPFPercent", model.SPPFCont);
                parameter.Add("@SDAPercent", model.SDAPercent);
                parameter.Add("@SPFPercent", model.SPFPercent);
                parameter.Add("@PayComId", model.PayComId);

                parameter.Add("@ActiveDate", model.ActiveDate);
                parameter.Add("@CompanyId", SessionManager.CompanyId);
                parameter.Add("@Action", "save");
                model = DBHelperDapper.DAAddAndReturnModel<ServiceType>("sp_servicetype", parameter);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> GetOfficeName(int districtId, int AgencyTypeId)
        {
            try
            {

                var queryParameter = new DynamicParameters();
                queryParameter.Add("@FK_districtId", districtId);
                queryParameter.Add("@FK_AgencyTypeId", AgencyTypeId);
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("OfficeNameDropdown", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetAgencyType()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("agencyTypeDropdown", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> GetPayCommisionDropDown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("PayCommision_DropDown", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ServiceType ChangeServiceTypetatus(ServiceType model)
        {
            ServiceType obj = new ServiceType();

            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", model.Id);
                parameter.Add("@Isactive", model.IsActive);
                parameter.Add("@updatedBy", SessionManager.UserId);

                model = DBHelperDapper.DAAddAndReturnModel<ServiceType>("chanegeServiceType_Status", parameter);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ServiceType> ServiceTypeList()
        {
            try
            {
                var query = new DynamicParameters();
                List<ServiceType> objlist = DBHelperDapper.DAAddAndReturnModelList<ServiceType>("GetServiceType", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region OfficeTime Master
        public OfficeTime GetOfficeTimeDetail(OfficeTime model)
        {
            OfficeTime _iresult = new OfficeTime();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<OfficeTime>("Fetch_OfficeTime", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static OfficeTime AddOfficeTime(OfficeTime model)
        {
            OfficeTime _iresult = new OfficeTime();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@InTime", model.InTime);
                queryParameters.Add("@OutTime", model.OutTime);
                queryParameters.Add("@LunchTime", model.LunchTime);
                queryParameters.Add("@OfficeID", model.Fk_OfficeId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Pk_Id", 0);
                _iresult = DBHelperDapper.DAAddAndReturnModel<OfficeTime>("Insert_Update_OfficeTime", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static OfficeTime UpdateOfficeTime(OfficeTime model)
        {
            OfficeTime _iresult = new OfficeTime();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@InTime", model.InTime);
                queryParameters.Add("@OutTime", model.OutTime);
                queryParameters.Add("@LunchTime", model.LunchTime);
                queryParameters.Add("@OfficeID", model.Fk_OfficeId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                queryParameters.Add("@Pk_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<OfficeTime>("Insert_Update_OfficeTime", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static OfficeTime Officetimelist(OfficeTime model)
        {
            OfficeTime _iresult = new OfficeTime();
            try
            {
                var queryParameters = new DynamicParameters();
                List<OfficeTime> list = DBHelperDapper.DAAddAndReturnModelList<OfficeTime>("Fetch_OfficeTime", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Company Master
        public Company SaveCompany(Company model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@CompanyName", model.CompanyName);
                queryParameter.Add("@Address", model.Address);
                queryParameter.Add("@CompanyLogo", model.CompanyLogo);
                queryParameter.Add("@CompanyAppLogo", model.CompanyAppLogo);
                queryParameter.Add("@OwnerName", model.OwnerName);
                queryParameter.Add("@OwnerMobileNo", model.OwnerMobileNo);
                queryParameter.Add("@TelephoneNo", model.TelephoneNo);
                queryParameter.Add("@EmailId", model.EmailId);
                queryParameter.Add("@GSTNo", model.GSTNo);
                queryParameter.Add("@PanNumber", model.PanNumber);
                queryParameter.Add("@Password", model.Password);
                queryParameter.Add("@AlternateMobile", model.AlternateMobile);
                queryParameter.Add("@TanNumber", model.TanNumber);
                queryParameter.Add("@StateId", model.StateId);
                queryParameter.Add("@DistrictId", model.DistrictId);
                queryParameter.Add("@PinCode", model.PinCode);
                queryParameter.Add("@checkday", model.checkday + ",");
                queryParameter.Add("@HrEmailId", model.HrEmailId);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Company>("Insert_Update_Company", queryParameter);
                return model;
            }
            catch (Exception ex) 
            {
                throw ex;

            }
        }
        public Company UpdateCompany(Company model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@CompanyName", model.CompanyName);
                queryParameter.Add("@Address", model.Address);
                queryParameter.Add("@CompanyLogo", model.CompanyLogo);
                queryParameter.Add("@CompanyAppLogo", model.CompanyAppLogo);
                queryParameter.Add("@OwnerName", model.OwnerName);
                queryParameter.Add("@OwnerMobileNo", model.OwnerMobileNo);
                queryParameter.Add("@TelephoneNo", model.TelephoneNo);
                queryParameter.Add("@EmailId", model.EmailId);
                queryParameter.Add("@GSTNo", model.GSTNo);
                queryParameter.Add("@PanNumber", model.PanNumber);
                queryParameter.Add("@Password", model.Password);
                queryParameter.Add("@AlternateMobile", model.AlternateMobile);
                queryParameter.Add("@TanNumber", model.TanNumber);
                queryParameter.Add("@StateId", model.StateId);
                queryParameter.Add("@DistrictId", model.DistrictId);
                queryParameter.Add("@PinCode", model.PinCode);
                queryParameter.Add("@HrEmailId", model.HrEmailId);
                queryParameter.Add("@checkday", model.checkday + ",");
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@Pk_Id", model.CompanyId);
                model = DBHelperDapper.DAAddAndReturnModel<Company>("Insert_Update_Company", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static Company CompanyList(Company model)
        {
            Company _iresult = new Company();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Company> list = DBHelperDapper.DAAddAndReturnModelList<Company>("Fetch_Company", queryParameters);
                _iresult.CompanyList = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Company ChangeCompanyStatus(Company model)
        {
            Company _iresult = new Company();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.CompanyId);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Company>("SetStatus_Company", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public dynamic GetCompanyDetails(int ID)
        {
            Company obj = new Company();
            using (SqlConnection con = new SqlConnection(DBHelperDapper.connection()))
            {
                try
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@PK_Id", ID);
                    var redar = con.QueryMultiple("Fetch_Company", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                    var Vm = redar.Read<Company>().FirstOrDefault();
                    var Vl = redar.Read<string>().ToList();
                    obj = Vm;
                    obj.WeekoffDay = Vl;
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<SelectListItem> GetDistric(int StateId)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@StateId", StateId);
                List<SelectListItem> PList = _dapper.GetAll<SelectListItem>("proc_binddistric", Parametor);
                return PList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> GetEmpbyDptEpCode(string DptEpCode)
        {
            try
            {
                var query = new DynamicParameters();

                query.Add("@DptEmpCode", DptEpCode);

                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Bind_Emp_DetailForPermanent", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<SelectListItem> GetEmpbyDptEpCodeAndPFMSCode(int WTypeId, int subDeptId,string EmpName,string DptEpCode,string PFMSCode)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@WTypeId", WTypeId);
                query.Add("@SubDeptID", subDeptId);
                query.Add("@EmpName", EmpName);
                query.Add("@DptEmpCode", DptEpCode);
                query.Add("@PFMSCODE", PFMSCode);

                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Bind_Emp_Detail", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion



        #region Grade-Pay Master
        public Gradepay SaveGradePay(Gradepay model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@GradePay", model.GradePay);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Gradepay>("Insert_Update_GradePay", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Gradepay UpdateGradePay(Gradepay model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@GradePay", model.GradePay);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Gradepay>("Insert_Update_GradePay", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Gradepay GetGradePayDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Gradepay details = DBHelperDapper.DAAddAndReturnModel<Gradepay>("Fetch_GradePay", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Gradepay> GradePayList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Gradepay> objlist = DBHelperDapper.DAAddAndReturnModelList<Gradepay>("Fetch_GradePay", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Gradepay ChangeGradePaystatus(Gradepay model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Gradepay>("SetStatus_GradePay", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Head-Code Master
        public List<SelectListItem> BindOfficeDropdown()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                List<SelectListItem> _iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("proc_bindoffice", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Headcode SaveHeadCode(Headcode model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@HeadCode", model.HeadCode);
                queryParameter.Add("@HeadName", model.HeadName);
                queryParameter.Add("@OfficeId", model.FK_OfficeId);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Headcode>("Insert_Update_HeadCode", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Headcode UpdateHeadCode(Headcode model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@HeadCode", model.HeadCode);
                queryParameter.Add("@HeadName", model.HeadName);
                queryParameter.Add("@OfficeId", model.FK_OfficeId);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Headcode>("Insert_Update_HeadCode", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Headcode GetHeadCodeDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Headcode details = DBHelperDapper.DAAddAndReturnModel<Headcode>("Fetch_HeadCode", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Headcode> HeadCodeList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Headcode> objlist = DBHelperDapper.DAAddAndReturnModelList<Headcode>("Fetch_HeadCode", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Headcode ChangeHeadCodestatus(Headcode model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Headcode>("SetStatus_HeadCode", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region EmpCategory Master
        public EmpCategory SaveEmpCategory(EmpCategory model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@Category", model.Category);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<EmpCategory>("Insert_Update_EmpCategory", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public EmpCategory UpdateEmpCategory(EmpCategory model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@Category", model.Category);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<EmpCategory>("Insert_Update_EmpCategory", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public EmpCategory GetEmpCategoryDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                EmpCategory details = DBHelperDapper.DAAddAndReturnModel<EmpCategory>("Fetch_EmpCategory", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<EmpCategory> EmpCategoryList()
        {
            try
            {
                var query = new DynamicParameters();
                List<EmpCategory> objlist = DBHelperDapper.DAAddAndReturnModelList<EmpCategory>("Fetch_EmpCategory", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpCategory ChangeEmpCategorystatus(EmpCategory model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<EmpCategory>("SetStatus_EmpCategory", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region AgencyType
        public static Agency AddAgencyType(Agency model)
        {
            Agency _iresult = new Agency();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@AgencyType", model.AgencyType);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Id", 0);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_AgencyType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Agency GetAgencyTypeByID(Agency model)
        {
            Agency _iresult = new Agency();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);

                _iresult = DBHelperDapper.DAAddAndReturnModel<Agency>("Fetch_AgencyType", queryParameters);


                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Agency ListAgencyType(Agency model)
        {
            Agency _iresult = new Agency();

            try
            {
                var queryParameters = new DynamicParameters();
                List<Agency> list = DBHelperDapper.DAAddAndReturnModelList<Agency>("Fetch_AgencyType", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Agency UpdateAgencyType(Agency model)
        {
            Agency _iresult = new Agency();
            Response resp = new Response();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@AgencyType", model.AgencyType);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("Insert_Update_AgencyType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Agency changeAgencyTypeStatus(Agency model)
        {
            Agency _iresult = new Agency();
            Response resp = new Response();

            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                queryParameters.Add("@DeletedBy", SessionManager.UserId);
                resp = DBHelperDapper.DAAddAndReturnModel<Response>("SetStatus_AgencyType", queryParameters);
                _iresult.response = resp;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region ServiceQuota Master
        public ServiceQuota SaveServiceQuota(ServiceQuota model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@QuotaName", model.QuotaName);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<ServiceQuota>("Insert_Update_ServiceQuota", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public ServiceQuota UpdateServiceQuota(ServiceQuota model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@QuotaName", model.QuotaName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<ServiceQuota>("Insert_Update_ServiceQuota", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public ServiceQuota GetServiceQuotaDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                ServiceQuota details = DBHelperDapper.DAAddAndReturnModel<ServiceQuota>("Fetch_ServiceQuota", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<ServiceQuota> ServiceQuotaList()
        {
            try
            {
                var query = new DynamicParameters();
                List<ServiceQuota> objlist = DBHelperDapper.DAAddAndReturnModelList<ServiceQuota>("Fetch_ServiceQuota", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ServiceQuota ChangeServiceQuotastatus(ServiceQuota model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<ServiceQuota>("SetStatus_ServiceQuota", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Mandal Master
        public Mandal SaveMandal(Mandal model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@Mandal", model.MandalName);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Mandal>("Insert_Update_Mandal", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Mandal UpdateMandal(Mandal model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@Mandal", model.MandalName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Mandal>("Insert_Update_Mandal", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Mandal GetMandalDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Mandal details = DBHelperDapper.DAAddAndReturnModel<Mandal>("Fetch_Mandal", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<Mandal> MandalList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Mandal> objlist = DBHelperDapper.DAAddAndReturnModelList<Mandal>("Fetch_Mandal", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Mandal ChangeMandalstatus(Mandal model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Mandal>("SetStatus_Mandal", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Division Master
        public Division GetDivisionByID(Division model)
        {
            Division _iresult = new Division();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PK_Id", model.ID);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Division>("Fetch_Division", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Division AddDivision(Division model)
        {
            Division _iresult = new Division();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DivisionName", model.DivisionName);
                queryParameters.Add("@MandalID", model.FK_MandalId);
                queryParameters.Add("@CreatedBy", SessionManager.UserId);
                queryParameters.Add("@CompanyId", SessionManager.CompanyId);
                queryParameters.Add("@Pk_Id", 0);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Division>("Insert_Update_Division", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Division UpdateDivision(Division model)
        {
            Division _iresult = new Division();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@DivisionName", model.DivisionName);
                queryParameters.Add("@MandalID", model.FK_MandalId);
                queryParameters.Add("@UpdatedBy", SessionManager.UserId);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Division>("Insert_Update_Division", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Division DivisionList(Division model)
        {
            Division _iresult = new Division();
            try
            {
                var queryParameters = new DynamicParameters();
                List<Division> list = DBHelperDapper.DAAddAndReturnModelList<Division>("Fetch_Division", queryParameters);
                _iresult.List = list;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Division ChangeDivisionstatus(Division model)
        {
            Division _iresult = new Division();
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Pk_Id", model.ID);
                queryParameters.Add("@IsActive", model.IsActive);
                _iresult = DBHelperDapper.DAAddAndReturnModel<Division>("SetStatus_Division", queryParameters);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region Comission Master
        public Comission SaveComission(Comission model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@ComissionName", model.ComissionName);
                queryParameter.Add("@CreatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", 0);
                model = DBHelperDapper.DAAddAndReturnModel<Comission>("Insert_Update_Comission", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public Comission UpdateComission(Comission model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@ComissionName", model.ComissionName);
                queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                model = DBHelperDapper.DAAddAndReturnModel<Comission>("Insert_Update_Comission", queryParameter);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Comission GetComissionDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                Comission details = DBHelperDapper.DAAddAndReturnModel<Comission>("Fetch_Comission", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }



        public List<Comission> ComissionList()
        {
            try
            {
                var query = new DynamicParameters();
                List<Comission> objlist = DBHelperDapper.DAAddAndReturnModelList<Comission>("Fetch_Comission", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Comission ChangeComissionstatus(Comission model)
        {
            try
            {
                var Parametor = new DynamicParameters();
                Parametor.Add("@Pk_Id", model.ID);
                Parametor.Add("@IsActive", model.IsActive);
                model = DBHelperDapper.DAAddAndReturnModel<Comission>("SetStatus_Comission", Parametor);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        #region Pay-Comission Master
        public PayComission SavePayComission(PayComission model)
        {
            PayComission _iresult = new PayComission();
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PayCommission", model.PayComissionName);
                queryParameter.Add("@GradePay", model.GradePay);
                queryParameter.Add("@PayComlevel", model.LevelId);
                queryParameter.Add("@Increment", model.Increment);
                queryParameter.Add("@Basic", model.Basic);
                queryParameter.Add("@Pk_Id", 0);
                queryParameter.Add("@Action", "save");
                _iresult = DBHelperDapper.DAAddAndReturnModel<PayComission>("SP_paycomission", queryParameter);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public PayComission UpdatePayComission(PayComission model)
        {
            PayComission _iresult = new PayComission();
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PayCommission", model.PayComissionName);
                queryParameter.Add("@GradePay", model.GradePay);
                queryParameter.Add("@PayComlevel", model.LevelId);
                queryParameter.Add("@Increment", model.Increment);
                queryParameter.Add("@Basic", model.Basic);
                // queryParameter.Add("@UpdatedBy", SessionManager.UserId);
                // queryParameter.Add("@CompanyId", SessionManager.CompanyId);
                queryParameter.Add("@Pk_Id", model.ID);
                queryParameter.Add("@Action", "update");
                var iresult = DBHelperDapper.DAAddAndReturnModel<PayComission>("SP_paycomission", queryParameter);
                _iresult = iresult;
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public PayComission GetPayComissionDetails(int? ID)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@PK_Id", ID);
                PayComission details = DBHelperDapper.DAAddAndReturnModel<PayComission>("Fetch_PayComission", queryParameter);
                return details;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<PayComission> PayComissionList()
        {
            try
            {
                var query = new DynamicParameters();
                List<PayComission> objlist = DBHelperDapper.DAAddAndReturnModelList<PayComission>("Fetch_PayComission", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion        
        #region DAArrear
        public DAArrear GetDataForDAArrear()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                DAArrear obj = DBHelperDapper.DAAddAndReturnModel<DAArrear>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<DAArrear> GetDAArrearList(DAArrear model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@DateStart", model.FRYear);
                query.Add("@DateEnd", model.TYear);
                query.Add("@Empid", model.EmployeeName);
                query.Add("@DrawDa", model.DueDA);
                List<DAArrear> objlist = DBHelperDapper.DAAddAndReturnModelList<DAArrear>("sp_getDAArrearList", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DAArrear GenerateDAArrear(DAArrear model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EMPid);
                queryParameter.Add("@Month", model.Month);
                queryParameter.Add("@Year", model.Year);
                queryParameter.Add("@BasicSal", model.BasicSal);
                queryParameter.Add("@Dueda", model.DueDA);
                queryParameter.Add("@DrawDa", model.DrawDA);
                queryParameter.Add("@workdays", model.WorkDays);
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                var obj = DBHelperDapper.DAAddAndReturnModel<DAArrear>("Proc_InsertDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DAArrear GetDataForManageDAArrear(DAArrear model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmployeeName);
                queryParameter.Add("@Month", model.Month);
                queryParameter.Add("@Year", model.Year);                
                var obj = DBHelperDapper.DAAddAndReturnModel<DAArrear>("GetDataDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DAArrear ManageDAArrear(DAArrear model)
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@EmpId", model.EmployeeName);
                queryParameter.Add("@Month", model.Month);
                queryParameter.Add("@Year", model.Year);
                queryParameter.Add("@BasicSal", model.BasicSal);
                queryParameter.Add("@Dueda", model.DueDA);
                queryParameter.Add("@DrawDa", model.DrawDA);
                queryParameter.Add("@workdays", model.WorkDays);
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                DAArrear obj = DBHelperDapper.DAAddAndReturnModel<DAArrear>("Proc_InsertDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<DAArrear> GetDAArrearReport(DAArrear model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@EmpId", model.EmployeeName);
                query.Add("@SubDeptId", model.SubDepartment);
                query.Add("@DepartmentId", model.Department);
                query.Add("@WTypeId", model.WorkingType);
                query.Add("@ToYear", "2000");
                query.Add("@ToMonth", "2");
                query.Add("@FromYear", model.Year);
                query.Add("@FromMonth", model.Month);
                query.Add("@OfficeId", SessionManager.OfficeID);
                List<DAArrear> objlist = DBHelperDapper.DAAddAndReturnModelList<DAArrear>("Proc_DAArrear1", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region VariationReport
        public VariationReport GetDataForVariationReport()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                VariationReport obj = DBHelperDapper.DAAddAndReturnModel<VariationReport>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<VariationReport> GetVariationReport(VariationReport model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@ProcId", 1);
                query.Add("@OfficeId", SessionManager.OfficeID);
                query.Add("@PayMonth", model.Month);
                query.Add("@PayYear", model.Year);
                query.Add("@Wtypeid", model.WorkingType);
                query.Add("@Deptid", 0);
                query.Add("@SubDeptid", 0);
                List<VariationReport> objlist = DBHelperDapper.DAAddAndReturnModelList<VariationReport>("GetVaration", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VariationReport> DeptWiseVariationReport(string eid, string fmid, string fyid)
        {
            try
            {

                var query = new DynamicParameters();
                int yid = 0;
                try
                {
                    yid= Convert.ToInt32(fyid);
                }
                catch {; }      

                int mid = 0;
                try
                {
                    mid = Convert.ToInt32(fmid);
                }
                catch {; }
                   
                query.Add("@ProcId", 2);
                query.Add("@SubDeptid", 0);
                query.Add("@Deptid", 0);
                query.Add("@Wtypeid", 0);
                query.Add("@PayYear", yid);
                query.Add("@PayMonth", mid);
                query.Add("@OfficeId", SessionManager.OfficeID);
                List<VariationReport> objlist = DBHelperDapper.DAAddAndReturnModelList<VariationReport>("GetVaration", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VariationReport> SubDeptWiseVariationReport(string eid, string fmid, string fyid , string WTypeId)
        {
            try
            {
                var query = new DynamicParameters();
                int yid = 0;
                try
                {
                    yid = Convert.ToInt32(fyid);
                }
                catch {; }
                int mid = 0;
                try
                {
                    mid = Convert.ToInt32(fmid);
                }
                catch {; }
                int Empid = 0;
                try
                {
                    Empid = Convert.ToInt32(eid);
                }
                catch {; }
                int workid = 0;
                try
                {
                    workid = Convert.ToInt32(WTypeId);
                }
                catch {; }
                query.Add("@ProcId", 3);
                query.Add("@SubDeptid", 0);
                query.Add("@Deptid", Empid);
                query.Add("@Wtypeid", workid);
                query.Add("@PayYear", yid);
                query.Add("@PayMonth", mid);
                query.Add("@OfficeId", SessionManager.OfficeID);
                List<VariationReport> objlist = DBHelperDapper.DAAddAndReturnModelList<VariationReport>("GetVaration", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public static List<SelectListItem> BindLoanType()
        {
            try
            {
                var queryParameters = new DynamicParameters();

                List<SelectListItem> _Iresult = DBHelperDapper.DAAddAndReturnModelList<SelectListItem>("BindLoanType", queryParameters);
                return _Iresult;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public LeaveDedReport GetLeaveDedReport()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                LeaveDedReport obj = DBHelperDapper.DAAddAndReturnModel<LeaveDedReport>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public RptSubDepWiseSummaryCustom GetSummaryCustom()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                RptSubDepWiseSummaryCustom obj = DBHelperDapper.DAAddAndReturnModel<RptSubDepWiseSummaryCustom>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<Financial> DedList(Financial model)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("@OfficeId", SessionManager.OfficeID);
                query.Add("@DepartmentId", model.Fk_DepartmentId);
                query.Add("@DedType", model.LoanType);
                query.Add("@FinYear", model.Year);
                query.Add("@SubDeptId", model.Fk_SubDeptId);
                query.Add("@WtypeId", model.WTypeId);
                query.Add("@EmployementId", model.EId);
                query.Add("@SalaryType", model.SalaryType);
                List<Financial> objlist = DBHelperDapper.DAAddAndReturnModelList<Financial>("GetDPDeductionDet", query);
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RptDepWiseSummaryCustom GetDepWiseSummaryCustom()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                RptDepWiseSummaryCustom obj = DBHelperDapper.DAAddAndReturnModel<RptDepWiseSummaryCustom>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public DesigWiseSummery GetDegWiseSummaryCustom()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                DesigWiseSummery obj = DBHelperDapper.DAAddAndReturnModel<DesigWiseSummery>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public SupplementaryReport GetSupplementaryReport()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                SupplementaryReport obj = DBHelperDapper.DAAddAndReturnModel<SupplementaryReport>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public SalaryReport GetSalaryBillReport()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                SalaryReport obj = DBHelperDapper.DAAddAndReturnModel<SalaryReport>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #region
        public List<SelectListItem> GetEmployeeForParmanent(int SubDeptId, string DptEpCode, string PFMSCODE, string EmpName)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("SubDeptId", SubDeptId);
                query.Add("DptEmpCode", DptEpCode);
                query.Add("PFMSCODE", PFMSCODE);
                query.Add("EmpName", EmpName);
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Bind_Emp_DetailForPermanent", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> GetEmployeeForDW(int SubDeptId, string DptEpCode, string PFMSCODE, string EmpName)
        {
            try
            {
                var query = new DynamicParameters();
                query.Add("SubDeptId", SubDeptId);
                query.Add("DptEmpCode", DptEpCode);
                query.Add("PFMSCODE", PFMSCODE);
                query.Add("EmpName", EmpName);
                List<SelectListItem> _iresult = _dapper.GetAll<SelectListItem>("Bind_Emp_DetailForDW", query);
                return _iresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
       
        public FrmFinalizeData GetFrmFinalizeData()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID);
                // queryParameter.Add("@OfficeId", 2);
                FrmFinalizeData obj = DBHelperDapper.DAAddAndReturnModel<FrmFinalizeData>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public FrmUnsettleData GetFrmUnsettleData()
        {
            try
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@OfficeId", SessionManager.OfficeID); 
                FrmUnsettleData obj = DBHelperDapper.DAAddAndReturnModel<FrmUnsettleData>("Fetch_DataForDAArrear", queryParameter);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


    }

}

