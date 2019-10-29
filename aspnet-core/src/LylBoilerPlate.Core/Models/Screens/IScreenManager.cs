using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LylBoilerPlate.Models.Screens
{
    public interface IScreenManager : IDomainService
    {
        IEnumerable<Screen> GetAllList();
        Screen GetScreenByID(int id);
        Task<Screen> Create(Screen entity);
        void Update(Screen entity);
        void Delete(int id);
        Task<List<Screen>> GetScreens(string Keyword);
        Task<Screen> GetScreenByIdAsync(int id);
    }
}
