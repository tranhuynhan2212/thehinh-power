using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Service.Interfaces
{
    public interface IFunctionService
    {
        void Add(FunctionViewModel function);

        Task<List<FunctionViewModel>> GetAll(string filter);

        Task<List<FunctionViewModel>> GetListFunctionWithRoleName(string[] roles);

        IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId);

        FunctionViewModel GetById(string id);

        void Update(FunctionViewModel function);

        void Delete(string id);

        void Save();

        bool CheckExistedId(string id);

        void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        void ReOrder(string sourceId, string targetId);
    }
}
