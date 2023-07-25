using OpenQA.Selenium;
using DemoUnitFW.Library;
namespace DemoUnitFW.Pages
{
    public class GitPocketGuideBookPage : BasePage
    {
        private WebObject btnAddToCollection = new WebObject(By.CssSelector(".fullButtonWrap > div:nth-child(2) > button"), "Add To Collection button");
        public GitPocketGuideBookPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCollection() {
            ClickAddToCollectionJs();
        }

        public void AcceptGitPocketGuidePageAlert() {
            AcceptAlert();
        }

        

       
    }
}