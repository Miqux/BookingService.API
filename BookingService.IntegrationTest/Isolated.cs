using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Transactions;
#nullable disable
namespace BookingService.IntegrationTest
{
    public class Isolated : Attribute, ITestAction
    {
        private TransactionScope transactionScope;
        public ActionTargets Targets => ActionTargets.Test;

        public void AfterTest(ITest test)
        {
            transactionScope.Dispose();
        }

        public void BeforeTest(ITest test)
        {
            transactionScope = new TransactionScope();
        }
    }
}
