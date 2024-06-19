using JediApi.Models;
using JediApi.Repositories;
using JediApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JediApi.Tests.Services
{
    public class JediServiceTests
    {
        // não mexer
        private readonly JediService _service;
        private readonly Mock<IJediRepository> _repositoryMock;

        public JediServiceTests()
        {
            // não mexer
            _repositoryMock = new Mock<IJediRepository>();
            _service = new JediService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetById_Success()
        {
            int jediId = 1;
            Jedi jedi = new Jedi { Id = jediId, Name = "Luke Skywalker", Strength = 90, Version = 1};
            
            _repositoryMock.Setup(r => r.GetByIdAsync(jediId)).ReturnsAsync(jedi);
            
            var result = await _service.GetByIdAsync(jediId);
            Console.WriteLine(result);

            Assert.Equal(jedi, result);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            int jediId = 1;

            _repositoryMock.Setup(r => r.GetByIdAsync(jediId)).ReturnsAsync((Jedi)null);

            await Assert.ThrowsAsync<Exception>(() => _service.GetByIdAsync(jediId));
        }

        [Fact]
        public async Task GetAll()
        {
            List<Jedi> jedis = new List<Jedi>()
            {
                new Jedi { Id = 1, Name = "Luke Skywalker", Strength = 90, Version = 1 },
                new Jedi { Id = 2, Name = "Anakin Skywalker", Strength = 100, Version = 1 }
            };

            _repositoryMock.Setup(repository => repository.GetAllAsync()).ReturnsAsync(jedis);

            List<Jedi> result = await _service.GetAllAsync();

            Assert.Equal(jedis, result);
        }
    }
}
