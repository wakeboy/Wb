using System;
using Wb.Persistence;
using Wb.PersistenceExample.Entities;

namespace Wb.PersistenceExample
{
    public class Application : IApplication
    {
        private readonly IRepository<Product> productRepository;
        private readonly IReadRepository<Contact> contactRepository;

        public Application(IRepository<Product> repository, IReadRepository<Contact> contactRepository)
        {
            this.productRepository = repository;
            this.contactRepository = contactRepository;
        }

        public void Start()
        {
            productRepository.Insert(new Product { Id = 1, Name = "Product" });
            productRepository.Save();

            var contacts = contactRepository.GetAll();
            
            foreach(var c in contacts)
            {
                Console.WriteLine(c.FirstName);
            }
            
            Console.WriteLine(productRepository == null);
            Console.WriteLine("Starting Application");
        }
    }
}
