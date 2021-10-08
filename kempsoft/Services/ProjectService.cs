using kempsoft.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services
{
    public class ProjectService : IProjectService
    {
        private readonly softkempContext db;

        public ProjectService(softkempContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Получить проект из бд по номеру
        /// </summary>
        /// <param name="id">Номер проекта в бд</param>
        /// <returns>Данные проекта</returns>
        public async Task<ReadyProject> getProject(int id)
        {
            ReadyProject project = await db.ReadyProjects.FirstOrDefaultAsync(i => i.Id == id);

            return project;
        }


        /// <summary>
        /// Получить весь список готовых проектов
        /// </summary>
        /// <returns>Список проектов</returns>
        public async Task<IEnumerable<ReadyProject>> getAllProjects()
        {
            IEnumerable<ReadyProject> projects = await db.ReadyProjects.ToListAsync();


            return projects;
        }
    }
}
