using Moq;
using RenoExpress.Purchasing.Core.Interfaces;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using RenoExpress.Purchasing.Core.Services;
using System.Threading.Tasks;
using Xunit;

namespace RenoExpress.Purchasing.UnitTest.Core.Services
{
    public class PurchaseServiesTest
    {
        #region Atributes
        private readonly PurchaseService _purchaseServies;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IPurchaseDetailService> _purchaseDetailServiceMock = new Mock<IPurchaseDetailService>();
        #endregion
        #region Constructor
        public PurchaseServiesTest()
        {
            _purchaseServies = new PurchaseService(_unitOfWorkMock.Object, _purchaseDetailServiceMock.Object);
        }
        #endregion
        #region Methods
        [Fact]
        public async Task DeletePurchaseAsync_ShouldReturntrue_WhenSaveItem()
        {
            // Arrange
            var id = "12356789";
            _unitOfWorkMock.Setup(x => x.purchaseRepository.DeleteAsync(id));
            _unitOfWorkMock.Setup(x => x.SaveChangeAsync()).ReturnsAsync(1);
            // Act
            var expect = await _purchaseServies.DeletePurchaseAsync(id);
            // Assert
            Assert.True(expect);
        }
        public async Task DeletePurchaseAsync_ShouldReturnFalse_WhenSaveItem()
        {
            // Arrange
            var id = "12356789";
            _unitOfWorkMock.Setup(x => x.purchaseRepository.DeleteAsync(id));
            _unitOfWorkMock.Setup(x => x.SaveChangeAsync()).ReturnsAsync(0);
            // Act
            var expect = await _purchaseServies.DeletePurchaseAsync(id);
            // Assert
            Assert.False(expect);
        }
        #endregion
    }
}
