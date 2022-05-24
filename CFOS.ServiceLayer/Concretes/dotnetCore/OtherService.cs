using CFOS.DataAccessLayer.Conretes;
using CFOS.EntityLayer.Concretes;
using CFOS.ViewModelLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFOS.DataAccessLayer.Conretes.OtherCRUD;


namespace CFOS.ServiceLayer.Concretes.dotnetCore
{
    public class OtherService : IDisposable
    {
        OtherVM OtherVM = new OtherVM();
        public void MaterialAdd(Materials materials)
        {
            try
            {
                OtherVM.MaterialAdd(materials);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string GetCoationgInfoNameById(int id)
        {
            try
            {
              return OtherVM.GetCoatingInfoNameById(id);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string GetMachineNameById(int id)
        {
            try
            {
                return OtherVM.GetMachineNameById(id);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string GetRawMaterialNameById(int id)
        {
            try
            {
                return OtherVM.GetRawMaterialNameById(id);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Materials> MaterialList()
        {
            try
            {
                List<Materials > materials = new List<Materials>();
                materials = OtherVM.ListMaterials();
                return materials;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void DeleteMaterial(int id)
        {
            try
            {
                OtherVM.DeleteMaterial(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void rawMaterialAdd(RawMaterial RawMaterials)
        {
            try
            {
                OtherVM.RawMaterialAdd(RawMaterials);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<RawMaterial> rawMaterialList()
        {
            try
            {
                List<RawMaterial> RawMaterials = new List<RawMaterial>();
                RawMaterials = OtherVM.ListRawMaterial();
                return RawMaterials;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void rawMaterialDelete(int id)
        {
            try
            {
                OtherVM.DeleteRawMaterial(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void MachinelAdd(Machine Machine)
        {
            try
            {
                OtherVM.AddMachine(Machine);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Machine> MachineList()
        {
            try
            {
                List<Machine> Machine = new List<Machine>();
                Machine = OtherVM.ListMachine();
                return Machine;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void MachinelDelete(int id)
        {
            try
            {
                OtherVM.DeleteMachine(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void CoatingInfoAdd(CoatingInfo CoatingInfo)
        {
            try
            {
                OtherVM.CoatingInfolAdd(CoatingInfo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<CoatingInfo> CoatingInfoList()
        {
            try
            {
                List<CoatingInfo> CoatingInfo = new List<CoatingInfo>();
                CoatingInfo = OtherVM.ListCoatingInfo();
                return CoatingInfo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void CoatingInfoDelete(int id)
        {
            try
            {
                OtherVM.DeleteCoatingInfo(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void Update(CoatingInfo coatingInfo,int id)
        {
            try
            {
                OtherVM.UpdateCoatingInfo(id, coatingInfo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
