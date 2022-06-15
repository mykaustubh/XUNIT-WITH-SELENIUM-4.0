using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Xunit.Abstractions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
/* For using Remote Selenium WebDriver */
using OpenQA.Selenium.Remote;

[assembly: CollectionBehavior(MaxParallelThreads = 4)]

namespace ParallelLTSelenium
{
    public class GlobalVar
    {
        static int _globalValue;
        public static int GlobalValue
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }

        public static String username = "shubhamr";
        public static String accesskey = "";
        public static String gridURL = "@hub.lambdatest.com/wd/hub";
        [Obsolete]
        
        public static IWebDriver driver1;
    }

    public class ParallelLTTests : IDisposable
    {
        public ParallelLTTests()
        {
           
        }

        public void Dispose()
        {
            // Closure handled in each test case
        }
    }

    public class UnitTest_1 : IClassFixture<ParallelLTTests>

    {
        public readonly ITestOutputHelper output;

        public UnitTest_1(ITestOutputHelper output)
        {
            this.output = output;
        }



        [Theory]
        [InlineData("chrome", "72.0", "Windows 10")]

        [InlineData("MicrosoftEdge", "18.0", "Windows 10")]
        [InlineData("Firefox", "70.0", "Windows 10")]
        [InlineData("Safari", "12.0", "macOS Mojave")]
















        public void LT_ToDo_Test(String browser, String version, String os)
        {
            String itemName = "Yey, Let's add it to list";
            IWebDriver driver;

            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("build", "your build name");
            ltOptions.Add("name", "your test name");
            ltOptions.Add("platformName", os);
            ltOptions.Add("browserName", browser);
            ltOptions.Add("browserVersion",version);

            RemoteSessionSettings options = new RemoteSessionSettings();
            options.AddMetadataSetting("LT:Options", ltOptions);


             driver = new RemoteWebDriver(new Uri("https://" + GlobalVar.username + ":" + GlobalVar.accesskey + "@hub.lambdatest.com/wd/hub"), options);











            
            driver.Url = "https://lambdatest.github.io/sample-todo-app/";

            Console.WriteLine("Sample");
                

            Assert.Equal("Sample page - lambdatest.com", driver.Title);
            // Click on First Check box
            IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
            firstCheckBox.Click();

            // Click on Second Check box
            IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();

            // Enter Item name
            IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys(itemName);

            // Click on Add button
            IWebElement addButton = driver.FindElement(By.Id("addbutton"));
            addButton.Click();

            // Verified Added Item name
            IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
            String getText = itemtext.Text;
            Assert.True(itemName.Contains(getText));

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("LT_ToDo_Test Passed");
            Console.Out.WriteLine("-----------");

            var temp = "ahhsa";

            output.WriteLine("this the sthe output {0}", temp);


            
            


           driver.Close();
            driver.Quit();
        }



        



    }
    
}