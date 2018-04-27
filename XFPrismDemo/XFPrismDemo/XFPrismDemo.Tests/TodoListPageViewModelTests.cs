using System;
using Moq;
using NUnit.Framework;
using XFPrismDemo.Services;
using XFPrismDemo.ViewModels;

namespace XFPrismDemo.Tests
{
    [TestFixture]
    public class TodoListPageViewModelTests
    {
        TodoListPageViewModel _vm;

        [SetUp]
        public void Setup()
        {
            var mockDbSrv = new Mock<IDatabaseService>();
            _vm = new TodoListPageViewModel(mockDbSrv.Object);
        }

        [Test]
        public void AddNewItem_InCollection_Test()
        {
            _vm.TodoItems.Clear();
            _vm.NewItemDescription = "Task1";

            _vm.CreateItemCommand.Execute();

            Assert.AreEqual(1, _vm.TodoItems.Count);
        }
    }
}
