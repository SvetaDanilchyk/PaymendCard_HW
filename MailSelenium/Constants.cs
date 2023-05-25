using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSelenium
{
    internal class Constants
    {

        public const string LOGIN_IN_XPATH = "//a[@data-label='header' and text()='Войти']";

        //logIn
        public const string INPUT_EMAIL_XPATH = "//input[@type='email']";
        public const string BUTTON_NEXT_XPATH = "//button[.//text()='Далее']";
        public const string INPUT_PASSWORD_XPATH = "//input[@type='password']";

        //Write
        public const string BUTTON_WRITE_XPATH = "//div[@class='z0']";
        public const string INPUT_EMAIL_USER_XPATH = "//input[@role = 'combobox']"; // //input[@id=':ew' ] 
        public const string INPUT_THEME_XPATH = "//input[@name='subjectbox']";
        public const string INPUT_MESSAGE_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
        public const string SUBMIT_FORM_LATTER_XPATH = "//div[@class='dC']";

        //logout
        public const string AKAUNT_GOOGLE_XPATH = "//a[@class = 'gb_d gb_3a gb_v']";
        public const string LOGOUT_XPATH = "//a[contains(@href,'Logout')]";// "//span[@data-et='10']/child::a"; // "//div[@class = 'SedFmc' and text()='Выйти']";

        
        //Read
        public const string OPEN_MESSAGE_XPATH = "tr[@class = 'zA zE x7']";//

        //Reply
        public const string BUTTON_REPLY_XPATH = "//span[@role = 'link' and text() = 'Ответить']";
        public const string INPUT_MESSAGE_TO_REPLY = "//div[@class = 'Am aO9 Al editable LW-avf tS-tW']";

        public static string message = "Hello!" + DateTime.Now;
    }
}
