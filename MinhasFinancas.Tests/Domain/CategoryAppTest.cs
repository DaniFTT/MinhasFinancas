using MinhasFinancas.Infra.Data.Repository.Mock;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Validators;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System;

namespace MinhasFinancas.Tests.Domaind
{
    public class CategoryAppTest
    {
        CategoryValidator _validationRules;

        public CategoryAppTest()
        {
            _validationRules = new CategoryValidator();
        }

        [Fact]
        public void Should_Return_All_Categories()
        {
            //Arrange
            var repo = new MockCategoryRepository(CreateCategories(50));
           
            //Act
            var categories = repo.List().Result.ToList();

            //Assert
            Assert.Equal(50, categories.Count);
        }

        [Fact]
        public void Should_Return_Ouput_Categories()
        {
            //Arrange
            var repo = new MockCategoryRepository(CreateCategories(55, false));

            //Act
            var categories = repo.ListCategoryByType(false).Result.ToList();

            //Assert
            Assert.Equal(55, categories.Count);
        }

        [Fact]
        public void Should_Return_Entry_Categories()
        {
            //Arrange
            var repo = new MockCategoryRepository(CreateCategories(60));

            //Act
            var categories = repo.ListCategoryByType(true).Result.ToList();

            //Assert
            Assert.Equal(60, categories.Count);
        }

        [Fact]
        public void Should_Return_Error_When_Inserting_Category_Without_Name()
        {
            //Arrange
            var repo = new MockCategoryRepository(CreateCategories(50));
            var categoryTeste = new Category(45, "", true);
            //Act
            bool valid = true;
            try
            {
                Validate(categoryTeste, _validationRules);
                var categories = repo.Add(categoryTeste);
            }
            catch (Exception e)
            {
                valid = false;
            }

            //Assert
            Assert.False(valid);
        }

        [Fact]
        public void Should_Insert_Category_Without_Errors()
        {
            //Arrange
            var repo = new MockCategoryRepository(CreateCategories(50));
            var categoryTeste = new Category(46, "Teste", true);
            //Act
            bool valid = true;
            try
            {
                Validate(categoryTeste, _validationRules);
                var categories = repo.Add(categoryTeste);
            }
            catch (Exception)
            {
                valid = false;
            }

            //Assert
            Assert.True(valid);
        }
        public List<Category> CreateCategories(int count, bool type = true)
        {
            List<Category> categories = new List<Category>();

            for (int i = 1; i <= count; i++)
            {
                var category = new Category(i, $"Categoria teste{i}", type);
                categories.Add(category); 
            }

            return categories;
        }

        private void Validate(Category obj, AbstractValidator<Category> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
