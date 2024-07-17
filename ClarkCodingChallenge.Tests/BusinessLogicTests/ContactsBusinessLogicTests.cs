using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.DataAccess.Interface;
using ClarkCodingChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        private IContactService _contactService;
        private IRepository<Contact> _contactRepository;

        [TestInitialize]
        public void Setup()
        {
            _contactRepository = new ContactsDataAccess();
            _contactService = new ContactsService(_contactRepository);
        }
        [TestMethod]
        public void Add_ShouldAddContact()
        {
            //arrange
            var testData = new Contact { Email = "test@gmail.com", FirstName = "Justin", LastName = "Vocke" };

            //act
            _contactService.AddContact(testData);
            var contacts = _contactService.GetContacts();

            //assert
            Assert.AreEqual(1, contacts.Count());
            Assert.AreEqual(testData, contacts.First());
        }

        [TestMethod]
        public void GetContacts_ShouldReturnAllContacts_ByAscendingLastName_ThenAscendingFirstName()
        {
            //arrange
            var testData = new Contact { Email = "test@gmail.com", FirstName = "Justin", LastName = "Vocke" };
            var testData2 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Vocke" };
            var testData3 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Thomas" };
            var testData4 = new Contact { Email = "test@gmail.com", FirstName = "Butch", LastName = "Thomas" };
            _contactService.AddContact(testData);
            _contactService.AddContact(testData2);
            _contactService.AddContact(testData3);
            _contactService.AddContact(testData4);

            //act
            
            var contacts = _contactService.GetContacts();

            //assert
            Assert.AreEqual(4, contacts.Count());
            Assert.AreEqual(testData3, contacts.First());
        }

        [TestMethod]
        public void GetContacts_ShouldReturnAllContacts_ByDescendingLastName_ThenDescendingFirstName()
        {
            //arrange
            var testData = new Contact { Email = "test@gmail.com", FirstName = "Justin", LastName = "Vocke" };
            var testData2 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Vocke" };
            var testData3 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Thomas" };
            var testData4 = new Contact { Email = "test@gmail.com", FirstName = "Butch", LastName = "Thomas" };
            _contactService.AddContact(testData);
            _contactService.AddContact(testData2);
            _contactService.AddContact(testData3);
            _contactService.AddContact(testData4);

            //act

            var contacts = _contactService.GetContacts("", false);

            //assert
            Assert.AreEqual(4, contacts.Count());
            Assert.AreEqual(testData, contacts.First());
        }

        [TestMethod]
        public void GetContacts_ShouldReturnAllContacts_MatchingLastNameArgument()
        {
            //arrange
            var testData = new Contact { Email = "test@gmail.com", FirstName = "Justin", LastName = "Vocke" };
            var testData2 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Vocke" };
            var testData3 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Thomas" };
            var testData4 = new Contact { Email = "test@gmail.com", FirstName = "Butch", LastName = "Thomas" };
            _contactService.AddContact(testData);
            _contactService.AddContact(testData2);
            _contactService.AddContact(testData3);
            _contactService.AddContact(testData4);

            //act

            var contacts = _contactService.GetContacts("Vocke");

            //assert
            Assert.AreEqual(2, contacts.Count());
            Assert.AreEqual(testData2, contacts.First());
        }

        [TestMethod]
        public void GetContacts_ShouldReturnAllContactsMatchingLastnameArgument_ByDescendingLastName_ThenDescendingFirstName()
        {
            //arrange
            var testData = new Contact { Email = "test@gmail.com", FirstName = "Justin", LastName = "Vocke" };
            var testData2 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Vocke" };
            var testData3 = new Contact { Email = "test@gmail.com", FirstName = "Abner", LastName = "Thomas" };
            var testData4 = new Contact { Email = "test@gmail.com", FirstName = "Butch", LastName = "Thomas" };
            _contactService.AddContact(testData);
            _contactService.AddContact(testData2);
            _contactService.AddContact(testData3);
            _contactService.AddContact(testData4);

            //act

            var contacts = _contactService.GetContacts("Vocke", false);

            //assert
            Assert.AreEqual(2, contacts.Count());
            Assert.AreEqual(testData, contacts.First());
        }
    }
}
