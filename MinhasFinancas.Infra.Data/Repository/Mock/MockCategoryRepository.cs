using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Data.Repository.Mock
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private static List<Category> MockList { get; set; }

        public MockCategoryRepository(List<Category> list)
        {
            MockList = list;
        }

        public async Task Add(Category obj)
        {
            MockList.Add(obj);
        }
        public async Task Update(Category obj)
        {
            var atual = MockList.FirstOrDefault(x => x.Id == obj.Id);

            if (atual != null)
            {
                var index = MockList.IndexOf(atual);
                MockList.Remove(atual);
                MockList.Insert(index, obj);
            }
        }
        public async Task Delete(int Id)
        {
            var atual = MockList.FirstOrDefault(x => x.Id == Id);
            if (atual != null)
            {
                MockList.Remove(atual);
            }
        }

        public async Task<Category?> GetById(int Id)
        {
            var atual = MockList.FirstOrDefault(x => x.Id == Id);
            if(atual != null)
            {
                return atual;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> List()
        {
            return MockList; 
        }

        public async Task<IEnumerable<Category>> ListCategoryByType(bool type)
        {
            return MockList.Where(c => c.Type == type);
        }
    }
}
