using CFOS.DataAccessLayer.Abstractions;
using CFOS.DataAccessLayer.Conretes;
using CFOS.EntityLayer.Concretes;
using CFOS.Helpers.Concretes.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFOS.DataAccessLayer.Conretes.OtherCRUD;

namespace CFOS.ViewModelLayer.Concretes
{
    public class OtherVM
    {
        public Materials MaterialAdd(Materials materials)
        {
            try
            {
                Materials materials1 = new Materials();
                using (var repository = new OtherCRUD())
                {
                    materials1 = repository.materialAdd(materials);
                }
                return materials1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Materials> ListMaterials()
        {
            try
            {
                List<Materials> materials = new List<Materials>();

                using (var repository = new OtherCRUD())
                {
                    materials = repository.materialList();
                }
                return materials;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteMaterial(int id)
        {
            try
            {             
                using (var repository = new OtherCRUD())
                {
                   repository.materialDelete(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public RawMaterial RawMaterialAdd(RawMaterial rm)
        {
            try
            {
                RawMaterial RawMaterials1 = new RawMaterial();
                using (var repository = new OtherCRUD())
                {
                    RawMaterials1 = repository.rawMaterialAdd(rm);
                }
                return RawMaterials1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<RawMaterial> ListRawMaterial()
        {
            try
            {
                List<RawMaterial> Rawmaterials = new List<RawMaterial>();

                using (var repository = new OtherCRUD())
                {
                    Rawmaterials = repository.rawMaterialList();
                }
                return Rawmaterials;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteRawMaterial(int id)
        {
            try
            {
                using (var repository = new OtherCRUD())
                {
                    repository.rawMaterialDelete(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Machine AddMachine(Machine machine)
        {
            try
            {
                Machine machine1 = new Machine();
                using (var repository = new OtherCRUD())
                {
                    machine1 = repository.MachineAdd(machine);
                }
                return machine1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Machine> ListMachine()
        {
            try
            {
                List<Machine> Machine = new List<Machine>();

                using (var repository = new OtherCRUD())
                {
                    Machine = repository.MachineList();
                }
                return Machine;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteMachine(int id)
        {
            try
            {
                using (var repository = new OtherCRUD())
                {
                    repository.MachineDelete(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CoatingInfo CoatingInfolAdd(CoatingInfo CI)
        {
            try
            {
                CoatingInfo coatingInfo = new CoatingInfo();
                using (var repository = new OtherCRUD())
                {
                    coatingInfo = repository.CoatingInfoAdd(CI);
                }
                return coatingInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CoatingInfo> ListCoatingInfo()
        {
            try
            {
                List<CoatingInfo> CI = new List<CoatingInfo>();

                using (var repository = new OtherCRUD())
                {
                    CI = repository.CoaingInfoListAll();
                }
                return CI;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteCoatingInfo(int id)
        {
            try
            {
                using (var repository = new OtherCRUD())
                {
                    repository.CoatingInfoDelete(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string GetCoatingInfoNameById(int id)
        {
            try
            {
              string coatingInfoName = string.Empty;
                using (var repository = new OtherCRUD())
                {
                    coatingInfoName = repository.FindCoatingInfoById(id);
                }

                return coatingInfoName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string GetRawMaterialNameById(int id)
        {
            try
            {
                string RawMaterialName = string.Empty;
                using (var repository = new OtherCRUD())
                {
                    RawMaterialName = repository.FindRawMaterialById(id);
                }
                return RawMaterialName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string GetMachineNameById(int id)
        {
            try
            {
                string MachineName = string.Empty;
                using (var repository = new OtherCRUD())
                {
                    MachineName = repository.FindMachineById(id);
                }
                return MachineName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CoatingInfo UpdateCoatingInfo(int id,CoatingInfo entity)
        {
            try
            {
                CoatingInfo product = new CoatingInfo();
                using (var repository = new OtherCRUD())
                {
                    product = repository.CoatingInfoUpdate(id,entity);
                }
                return product;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
