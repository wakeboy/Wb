using System;
using Wb.PersistenceCore;
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
            this.productRepository.Insert(new Product { Id = 1, Name = "Product" });
            this.productRepository.Save();

            var contacts = this.contactRepository.GetAll();
            
            foreach(var c in contacts)
            {
                Console.WriteLine(c.FirstName);
            }
            
            Console.WriteLine(this.productRepository == null);
            Console.WriteLine("Starting Application");
        }
    }
}
