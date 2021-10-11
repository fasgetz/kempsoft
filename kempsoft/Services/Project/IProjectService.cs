using kempsoft.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services
{
    public interface IProjectService
    {


        /// <summary>
        /// Получить проект из бд по номеру
        /// </summary>
        /// <param name="id">Номер проекта в бд</param>
        /// <returns>Данные проекта</returns>
        public Task<ReadyProject> getProject(int id);

        /// <summary>
        /// Получить весь список готовых проектов
        /// </summary>
        /// <returns>Список проектов</returns>
        public Task<IEnumerable<ReadyProject>> getAllProjects();


    }
}
