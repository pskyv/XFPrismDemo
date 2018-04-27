//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Prism.Navigation;
using XFPrismDemo.Models;
using XFPrismDemo.Services;
using XFPrismDemo.ViewModels;

namespace XFPrismDemo.Tests
{
    [TestFixture]
    public class NoteDetailsPageViewModelTest
    {
        NoteDetailsPageViewModel _vm;

        [SetUp]
        public void Setup()
        {
            var mockDbSrv = new Mock<IDatabaseService>();
            var mockNavSrv = new Mock<INavigationService>();

            _vm = new NoteDetailsPageViewModel(mockNavSrv.Object, mockDbSrv.Object);
        }

        [Test]
        public void CurrentNote_IsSet_WithNavParam_Test()
        {
            var mockNavParams = new Mock<NavigationParameters>().Object;
            mockNavParams.Add("currentNote", new Mock<Note>().Object);
            _vm.CurrentNote = null;

            _vm.OnNavigatingTo(mockNavParams);

            Assert.IsNotNull(_vm.CurrentNote, "CurrentNote is null after navigating to NoteDetailsPage");
        }
    }
}
