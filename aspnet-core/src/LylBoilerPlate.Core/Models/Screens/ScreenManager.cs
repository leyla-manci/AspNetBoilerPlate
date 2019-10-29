using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LylBoilerPlate.Models.Screens
{
   public class ScreenManager : DomainService, IScreenManager
    {

        private readonly IRepository<Screen> _repositoryScreen;
        public ScreenManager(IRepository<Screen> repositoryScreen)
        {
            _repositoryScreen = repositoryScreen;
        }
        public async Task<Screen> Create(Screen entity)
        {
            var screen = _repositoryScreen.FirstOrDefault(i => i.Id == entity.Id);
            if (screen != null)
            {
                throw new UserFriendlyException("Already Exist");

            }
            else
            {
                return await _repositoryScreen.InsertAsync(entity);

            }
        }

        public void Delete(int id)
        {
            var screen = _repositoryScreen.FirstOrDefault(i => i.Id == id);
            if (screen == null)
            {
                throw new UserFriendlyException("No Data Found");

            }
            else
            {
                _repositoryScreen.Delete(screen);

            }
        }

        public IEnumerable<Screen> GetAllList()
        {
            return _repositoryScreen.GetAll();
        }

        public Screen GetScreenByID(int id)
        {
            return _repositoryScreen.Get(id);
        }

        public Task<List<Screen>> GetScreens(string Keyword)
        {
            //return await _repositoryScreen.GetAllListAsync();
            Task<List<Screen>> scrn = Task.Run(() =>
            {
                List<Screen> scrn1;
                if (Keyword != null)
                {
                   scrn1 = _repositoryScreen.GetAllList().Where(i => i.Name.Contains(Keyword)).ToList();

                }
                else {
                    scrn1 = _repositoryScreen.GetAllList();

                }
                return scrn1;
            }); 

            return scrn;


        }


        public async Task<Screen> GetScreenByIdAsync(int id)
        {
            return await _repositoryScreen.GetAsync(id);
        }

        public void Update(Screen entity)
        {
            _repositoryScreen.Update(entity);
        }
    }
}
