using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{

    [TestFixture]
    public class UnitTest
    {
        private IWebDriver driver;
        private GoogleHomePage homePage;
        private GoogleResultsPage resultsPage;
        //public GoogleSearchTest() { }
        public static IEnumerable<TestData> TestCases => XmlDataReader.ReadTestData("C:\\Users\\user1\\Desktop\\TestProject1\\TestProject1\\XMLFile1.xml");
       // public static IEnumerable<TestData> TestCases => XmlDataReader.ReadTestData("C:\\Users\\user1\\תרגול\\פיתוח אוטומציה\\TestProject1\\XMLFile1.xml");

        [SetUp]

        //SETUP ירוץ רק פעם ראשונה
        public void Setup()
        {
       
          //string path = "C:\\Users\\user1\\תרגול\\פיתוח אוטומציה\\TestProject1\\driver";
            //string path = " C: \\Users\\user1\\תרגול\\פיתוח אוטומציה\\TestProject1\\driver";
            string path = " C:\\Users\\user1\\Desktop\\TestProject1\\TestProject1\\driver";


            driver = new ChromeDriver(path);
            //driver.Manage().Window.Maximize();
            homePage=new GoogleHomePage(driver);
            resultsPage = new GoogleResultsPage(driver);

        }
        //הפעלת כל הפונקציות TEST
        [Test, TestCaseSource(nameof(TestCases))]
        public void TestGoogleSearce(TestData testData)
        {
            homePage.NavigateTo();
            Assert.AreEqual("Google", driver.Title);
            homePage.Search("selenium webDriver");//חיפוש המילים הספציפיות
            //חיפוש מXML
            homePage.Search(testData.SearchTerm);


            Assert.IsTrue(resultsPage.ResultsDisplayed());

            string firstaraesultTitle=resultsPage.GetFirstResultTitle();
            resultsPage.ClickFirstResult();

            Assert.IsTrue(driver.Title.Contains(firstaraesultTitle));

            driver.Navigate().Back();
            Assert.AreEqual("selenium webDriver",driver.FindElement(By.Name("q")).GetAttribute("value"));
            //IWebElement webElemenBox = driver.FindElement(By.Name("q"));
            //webElemenBox.SendKeys("https://www.meuhedet.co.il/");
            //webElemenBox.Submit();


        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();   
        }
    }

}
