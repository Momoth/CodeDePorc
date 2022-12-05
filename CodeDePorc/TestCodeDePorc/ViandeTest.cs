using CodeDePorc.Api;
using CodeDePorc.Api.Business;

namespace TestCodeDePorc
{
    [TestClass]
    public class ViandeTest
    {
        private readonly ViandeManager _viandeManager;

        public ViandeTest()
        {
            _viandeManager = new ViandeManager();
        }

        [TestMethod]
        public void TestPurgeViandeHalam()
        {
            IEnumerable<Viande> result = _viandeManager.PurgeViandeHalam();
            Assert.IsInstanceOfType(_viandeManager, typeof(ViandeManager));
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }
    }
}