using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Mac;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Drawing;

namespace TexnomartTask
{
    public class Tests
    {
        private AppiumDriver<AndroidElement> _driver;

        [SetUp]
        public void Setup()
        {
            int startX = 0, startY = 0, endX = 0, endY = 0;

            #region AppiumSettings
            var appPath = @"D:\Code\C#\QA\APKs\Texnomart_3.0.4.apk";
            string serverUri = "http://localhost:4723/wd/hub";

            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android 33");
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, appPath);

            driverOption.AddAdditionalCapability("chromedriverAutoDownload", true);

            _driver = new AndroidDriver<AndroidElement>(new Uri(serverUri), driverOption);
            #endregion

            string uzbLangResource_Id = "com.texnomart.app:id/cv_language";
            string backButton_ReosurceId = "com.texnomart.app:id/ivBack";
            string catalogButton_ResourceId = "com.texnomart.app:id/navigation_catalog";
            string card_ResourceId = "com.texnomart.app:id/btnAddToCart";
            #region SelectLang
            var selectUzbLang = _driver.FindElementById(uzbLangResource_Id);
            selectUzbLang.Click();
            #endregion

            #region Uploading_MainUI
            string mainUI_Container_ResourceId = "com.texnomart.app:id/rv";
            var waitUpload = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            By uploadElementLocator = By.Id(mainUI_Container_ResourceId);
            waitUpload.Until(ExpectedConditions.ElementIsVisible(uploadElementLocator));
            #endregion

            string recyclerView_ClassName = "androidx.recyclerview.widget.RecyclerView";
            string cardView_ClassName = "androidx.cardview.widget.CardView";
            IReadOnlyCollection<AndroidElement> recyclerViews = _driver.FindElementsByClassName(recyclerView_ClassName);

            /*
            AppiumWebElement recycleView_Brend = recyclerViews.ElementAt(1);
            IReadOnlyCollection<AppiumWebElement> cardView_Brends = recycleView_Brend.FindElementsByClassName(cardView_ClassName);
            Debug.WriteLine("CardViews.Count: " + cardView_Brends.Count);
            
            #region Swipe_Brend
            Slide(_driver, cardView_Brends.ElementAt(3), cardView_Brends.ElementAt(0)); // Chapga
            #endregion
            */

            /*
            IReadOnlyCollection<AppiumWebElement> carView_Catigories = recyclerViews.ElementAt(2).FindElementsByClassName(cardView_ClassName);
            #region Swipe_Categories
            Slide(_driver, carView_Catigories.ElementAt(3), carView_Catigories.ElementAt(0)); // Chapga
            #endregion
            */

            string search_ResourceId = "com.texnomart.app:id/tvSearch";
            string searchTextBox_ResourceId = "com.texnomart.app:id/search_src_text";
            string main_ResourceId = "com.texnomart.app:id/navigation_home";
            string profile_ResourceId = "com.texnomart.app:id/navigation_profile";
            string detail_ResourceId = "com.texnomart.app:id/container_product_horizontal";
            /*
            #region EnterToProduct   
            var detailElement = _driver.FindElementById(detail_ResourceId);
            detailElement.Click();
            #endregion

            #region SwipeToDetails
            startY = _driver.FindElementById("com.texnomart.app:id/haveCache").Location.Y;
            startX = _driver.Manage().Window.Size.Width / 2;
            endX = _driver.Manage().Window.Size.Width / 2;
            endY = 100;
            Slide(_driver, startX, startY, endX, endY);
            #endregion
            
            #region ToBack
            _driver.FindElementById(backButton_ReosurceId).Click();
            #endregion
            
            #region 15Scroll            
            endX = _driver.Manage().Window.Size.Width / 2;
            startX = endX;
            var searchElement = _driver.FindElementById(search_ResourceId);
            var mainELement = _driver.FindElementById(main_ResourceId);
            endY = searchElement.Location.Y + searchElement.Size.Height + 50;
            startY = mainELement.Location.Y - 50;
            for (int i = 0; i < 15; i++)
            {
                Slide(_driver, startX, startY, endX, endY);
            }
            #endregion
            //1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
            */
            /*
            #region SearchProduct
            var mainELement = _driver.FindElementById(main_ResourceId);
            startX = _driver.Manage().Window.Size.Width - 30;
            startY = mainELement.Location.Y - 50;
            endX = startX - 2;
            endY = startY - 2;

            _driver.FindElementById(search_ResourceId).Click();
            var searchTextBoxElement = _driver.FindElementById(searchTextBox_ResourceId);
            searchTextBoxElement.SendKeys("Blender");

            Thread.Sleep(300);
            new TouchAction((IPerformsTouchActions)_driver)
                .Press(startX, startY)
                .Wait(10)
                .MoveTo(endX, endY)
                .Release()
                .Perform();
            #endregion
            
            string searchProduct_ResourceId = "com.texnomart.app:id/cl_product";
            waitUpload = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            uploadElementLocator = By.Id(searchProduct_ResourceId);
            waitUpload.Until(ExpectedConditions.ElementIsVisible(uploadElementLocator));

            _driver.FindElementById(searchProduct_ResourceId).Click();
            Thread.Sleep(1000);

            #region ToBack
            _driver.FindElementById(backButton_ReosurceId).Click();
            #endregion
            Debug.WriteLine("Debug: ToBack");
            */
            /*
            #region MoveToCatalogPage
            string smartPhoneAndGadget_ResourceId = "com.texnomart.app:id/catalog_item";
            string smartPhone_ResourceId = "com.texnomart.app:id/container";
            string filterButton_ResourceId = "com.texnomart.app:id/pt_filter";
            string recyclerViewFilter_ResourceId = "com.texnomart.app:id/recyclerview";
            string brendFilter_ResourceId = "com.texnomart.app:id/container";
            string modelFilter_ResourceId = "";

            // Catalog page ga o'tish
            _driver.FindElementById(catalogButton_ResourceId).Click();
            Debug.WriteLine("Debug: CatalogPage");

            waitUpload = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            uploadElementLocator = By.Id(smartPhoneAndGadget_ResourceId);
            waitUpload.Until(ExpectedConditions.ElementIsVisible(uploadElementLocator));

            _driver.FindElementById(smartPhoneAndGadget_ResourceId).Click();
            _driver.FindElementById(smartPhone_ResourceId).Click();
            _driver.FindElementById(filterButton_ResourceId).Click();
            
            waitUpload = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            uploadElementLocator = By.Id(recyclerViewFilter_ResourceId);
            waitUpload.Until(ExpectedConditions.ElementIsVisible(uploadElementLocator));

            string confirmButtonFilter_ResourceId = "com.texnomart.app:id/btnConfirm";
            
            AndroidElement recyclerViewFilter = _driver.FindElementById(recyclerViewFilter_ResourceId);
            IReadOnlyCollection<AppiumWebElement> viewGroup_Filters = recyclerViewFilter.FindElementsByClassName("android.view.ViewGroup");
            Debug.WriteLine("Debug: viewGroup_Filters Count: " + viewGroup_Filters.Count);
            viewGroup_Filters.ElementAt(1).Click();
            IReadOnlyCollection<AppiumWebElement> selectItemELements = _driver.FindElementsByClassName("androidx.recyclerview.widget.RecyclerView");
            Debug.WriteLine("Debug: selectItemELements Count: " + selectItemELements.Count);
            selectItemELements.First().Click();
            //Debug.WriteLine("Debug: selectItemELement: " + selectItemELements.ElementAt(1).GetAttribute("checkable"));

            _driver.FindElementById(confirmButtonFilter_ResourceId).Click();
            
            recyclerViewFilter = _driver.FindElementById(recyclerViewFilter_ResourceId);
            viewGroup_Filters = recyclerViewFilter.FindElementsByClassName("android.view.ViewGroup");
            viewGroup_Filters.ElementAt(4).Click();
            selectItemELements = _driver.FindElementsByClassName("androidx.recyclerview.widget.RecyclerView");
            Debug.WriteLine("Debug: selectItemELements Count: " + selectItemELements.Count);
            selectItemELements.First().Click();

            _driver.FindElementById(confirmButtonFilter_ResourceId).Click();

            recyclerViewFilter = _driver.FindElementById(recyclerViewFilter_ResourceId);
            viewGroup_Filters = recyclerViewFilter.FindElementsByClassName("android.view.ViewGroup");
            viewGroup_Filters.ElementAt(3).Click();
            selectItemELements = _driver.FindElementsByClassName("androidx.recyclerview.widget.RecyclerView");
            Debug.WriteLine("Debug: selectItemELements Count: " + selectItemELements.Count);
            selectItemELements.First().Click();

            _driver.FindElementById(confirmButtonFilter_ResourceId).Click();
            _driver.FindElementById(confirmButtonFilter_ResourceId).Click();

            #endregion
            */
            /*
            #region ViewProfiles
            string recyclerViewProfile_ResourceId = "com.texnomart.app:id/recyclerview";
            string viewGroupProfile_ClassName = "android.view.ViewGroup";
            
            _driver.FindElementById(profile_ResourceId).Click();
            waitUpload = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            uploadElementLocator = By.Id(recyclerViewProfile_ResourceId);
            waitUpload.Until(ExpectedConditions.ElementIsVisible(uploadElementLocator));

            
            AndroidElement recyclerViewProfile = _driver.FindElementById(recyclerViewProfile_ResourceId);
            IReadOnlyCollection<AppiumWebElement> viewGroupProfileItems = recyclerViewProfile.FindElementsByClassName(viewGroupProfile_ClassName);
            Debug.WriteLine("Debug: recycleViewProfile Count: " + viewGroupProfileItems.Count);
            for (int i = 0; i < 9; i++)
            {                
                recyclerViewProfile = _driver.FindElementById(recyclerViewProfile_ResourceId);
                viewGroupProfileItems = recyclerViewProfile.FindElementsByClassName(viewGroupProfile_ClassName);
                viewGroupProfileItems.ElementAt(i).Click();
                Thread.Sleep(1500);
                if (i == 7)
                {
                    _driver.FindElementById("com.texnomart.app:id/iv_exit").Click();
                }
                else
                {
                    #region ToBack
                    _driver.FindElementById(backButton_ReosurceId).Click();
                    #endregion
                }
            }
            #endregion
            */


            string installmentPay_ResourceId = "com.texnomart.app:id/tvrassrochka";
            string continueBtn_ResourceId = "com.texnomart.app:id/btnContinue";
            string numberEditText_ResourceId = "com.texnomart.app:id/et_login_number";
            string enterBtn_ResourceId = "com.texnomart.app:id/btn_login_enter";
            string confirmBtn_ResourceId = "com.texnomart.app:id/btn_confirm_otp";
            string setAddress_ResourceId = "com.texnomart.app:id/setAddress";
            string saveAddressBtn_ResourceId = "com.texnomart.app:id/btnSaveAddress";
            string cityAddressBtn_ResourceId = "com.texnomart.app:id/auto_tv_city";
            string subAddressEditText_ResourceId = "com.texnomart.app:id/et_address";
            string floorAddressEditText_ResourceId = "com.texnomart.app:id/et_floor";
            string applyBtn_ResourceId = "com.texnomart.app:id/btnApply";
            _driver.FindElementById(detail_ResourceId).Click();
            Thread.Sleep(2000);
            _driver.FindElementById(card_ResourceId).Click();
            _driver.FindElementById("com.texnomart.app:id/btnItemInCart").Click();
            Thread.Sleep(500);
            _driver.FindElementById(installmentPay_ResourceId).Click();
            Thread.Sleep(500);
            _driver.FindElementById(continueBtn_ResourceId).Click();
            _driver.FindElementById(numberEditText_ResourceId).SendKeys("906384606");
            _driver.FindElementById(enterBtn_ResourceId).Click();
            Thread.Sleep(15000);
            //_driver.FindElementById(confirmBtn_ResourceId).Click();
            _driver.FindElementById(setAddress_ResourceId).Click();
            Thread.Sleep(500);
            _driver.FindElementById(cityAddressBtn_ResourceId).Click();
            _driver.FindElementById("com.texnomart.app:id/til_floor").Click();
            _driver.FindElementById(subAddressEditText_ResourceId).SendKeys("Yuburobod");
            _driver.FindElementById(floorAddressEditText_ResourceId).SendKeys("1");
            _driver.FindElementById(saveAddressBtn_ResourceId).Click();
            Slide(_driver,
                _driver.Manage().Window.Size.Width / 2, (_driver.Manage().Window.Size.Height - 200),
                _driver.Manage().Window.Size.Width / 2, 200);

            _driver.FindElementById(applyBtn_ResourceId).Click();
            Thread.Sleep(1000);
            string onlyThisTimeBtn_ResourceId = "com.android.permissioncontroller:id/permission_allow_one_time_button";
            string allowAllBtn_ResourceId = "com.android.permissioncontroller:id/permission_allow_all_button";
            string setPhotoBtn_ResourceId = "com.texnomart.app:id/btn_set_photo";
            string selectCameraBtn_ResourceId = "android:id/text1";

            for (int i = 0; i < 3; i++)
            {
                IReadOnlyCollection<AndroidElement> cameraBtnList = _driver.FindElementsById(setPhotoBtn_ResourceId);
                Debug.WriteLine("Debug: selectItemELements Count: " + cameraBtnList.Count);
                cameraBtnList.ElementAt(i).Click();
                if (i == 0)
                {
                    _driver.FindElementById(onlyThisTimeBtn_ResourceId).Click();
                    _driver.FindElementById(allowAllBtn_ResourceId).Click();
                }

                _driver.FindElementById(selectCameraBtn_ResourceId).Click();

                string captureBtn_ResourceId = "com.texnomart.app:id/ib_capture";
                string saveBtn_ResourceId = "com.texnomart.app:id/btn_save";

                _driver.FindElementById(captureBtn_ResourceId).Click();
                _driver.FindElementById(saveBtn_ResourceId).Click();
            }

            Slide(_driver,
                _driver.Manage().Window.Size.Width / 2, (_driver.Manage().Window.Size.Height - 200),
                _driver.Manage().Window.Size.Width / 2, 200);
            
            _driver.FindElementById(applyBtn_ResourceId).Click();

            string jshshirEditText_ResourceId = "com.texnomart.app:id/et_pinfl";
            string passportSerialEditText_ResourceId = "com.texnomart.app:id/et_passport_series";
            string passportValidityEditText_ResourceId = "com.texnomart.app:id/et_passport_validity";

            _driver.FindElementById(jshshirEditText_ResourceId).SendKeys("01234567890123");
            _driver.FindElementById(passportSerialEditText_ResourceId).SendKeys("AA7374035");
            _driver.FindElementById(passportValidityEditText_ResourceId).SendKeys("21122023");

            Slide(_driver,
                _driver.Manage().Window.Size.Width / 2, (_driver.Manage().Window.Size.Height / 2),
                _driver.Manage().Window.Size.Width / 2, (_driver.Manage().Window.Size.Height / 4));

            string truste1NameEditText_ResourceId = "com.texnomart.app:id/et_trustee_1_name";
            string truste1NumberEditText_ResourceId = "com.texnomart.app:id/et_trustee_1_number";
            string truste2NameEditText_ResourceId = "com.texnomart.app:id/et_trustee_2_name";
            string truste2NumberEditText_ResourceId = "com.texnomart.app:id/et_trustee_2_number";

            _driver.FindElementById(truste1NameEditText_ResourceId).SendKeys("Bahodir");
            _driver.FindElementById(truste1NumberEditText_ResourceId).SendKeys("906384606");
            _driver.FindElementById(truste2NameEditText_ResourceId).SendKeys("Bahrom");
            _driver.FindElementById(truste2NumberEditText_ResourceId).SendKeys("973129662");

            Slide(_driver,
                _driver.Manage().Window.Size.Width / 2, (_driver.Manage().Window.Size.Height / 2),
                _driver.Manage().Window.Size.Width / 2, (_driver.Manage().Window.Size.Height / 5));

            string cardNumEditText_ResourceId = "com.texnomart.app:id/et_card_number";
            string cardDateEditText_ResourceId = "com.texnomart.app:id/et_card_date";
            string confirmBtnEditText_ResourceId = "com.texnomart.app:id/btn_confirm";

            _driver.FindElementById(cardNumEditText_ResourceId).SendKeys("1234567890123456");
            _driver.FindElementById(cardDateEditText_ResourceId).SendKeys("1223");
            //_driver.FindElementById(confirmBtnEditText_ResourceId).Click(); Order Confirm button

            // Confirm qilmasdan ortga qaytish
            #region BackToMainPage
            _driver.FindElementByClassName("android.widget.ImageButton").Click();
            _driver.FindElementById("android:id/button1").Click();
            _driver.FindElementById("com.texnomart.app:id/ivBack").Click();
            _driver.FindElementById("com.texnomart.app:id/ivBack").Click();
            _driver.FindElementById(main_ResourceId).Click();
            #endregion
            /*
             * Oxirgi Buyurtma berish qismi uchun code yozmadim, video juda uzun bo'lib ketdi.
             * Bundan oldingi qism oxirgi taskdan 4 5 marta katta shuni o'zi yetarli menimcha
             */
        }
        static void Slide(IWebDriver driver, int startX, int startY, int endX, int endY)
        {
            var touchAction = new TouchAction((IPerformsTouchActions)driver);
            /*
            int startX = elementStart.Location.X + (elementStart.Size.Width / 2);
            int startY = elementStart.Location.Y + (elementStart.Size.Height / 2);
            */


            touchAction
                .Press(startX, startY)
                .Wait(800)
                .MoveTo(endX, endY)
                .Release()
                .Perform();
        }
        static void Slide(IWebDriver driver, AppiumWebElement elementStart, AppiumWebElement elementEnd)
        {
            var touchAction = new TouchAction((IPerformsTouchActions)driver);
            int startX = elementStart.Location.X + (elementStart.Size.Width / 2);
            int startY = elementStart.Location.Y + (elementStart.Size.Height / 2);
            int endX = elementEnd.Location.X + (elementEnd.Size.Width / 2);
            int endY = elementEnd.Location.Y + (elementEnd.Size.Height / 2);

            touchAction
                .Press(startX, startY)
                .Wait(800)
                .MoveTo(endX, endY)
                .Release()
                .Perform();
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}