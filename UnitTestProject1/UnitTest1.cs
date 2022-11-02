using System.Diagnostics;
using NNTPProject.Model;
using NNTPProject.View;

namespace UnitTestProject1;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void DataBaseConnectionTest()
    {
        DatabaseHandler databaseHandler = new DatabaseHandler();
        Assert.IsNotNull(databaseHandler.MyConnection);
    }
    [TestMethod]
    public void EncoderTest()
    {
        string password = "5156c1";
        string ExpectedEncodedPassword = "NTE1NmMx";
        string ActualEncodedPassword = LoginView.EncodePasswordToBase64(password);
        
        Assert.AreEqual(ExpectedEncodedPassword, ActualEncodedPassword);
    }

    [TestMethod]
    public void DecoderTest()
    {
        string EncodedPassword = "NTE1NmMx";
        string ExpectedPassword = "5156c1";
        string ActualPassword = LoginView.DecodeFrom64(EncodedPassword);
        Assert.AreEqual(ExpectedPassword, ActualPassword);
    }
}