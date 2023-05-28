namespace MailSelenium;

public class Constants
{
    public const string LOGIN_IN_XPATH = "//a[@data-label='header' and text()='Войти']";

    //logIn
    public const string INPUT_EMAIL_XPATH = "//input[@id='identifierId']";
    public const string BUTTON_NEXT_LOGIN_XPATH = "//*[@id='identifierNext']/div/button"; //*[@id="passwordNext"]/div/button "//button[.//text()='Далее']" //*[@id="passwordNext"]/div/button
    public const string INPUT_PASSWORD_XPATH = "//input[@name='Passwd']"; //"//input[@type='password']";
    public const string BUTTON_NEXT_PASSWORD_XPATH = "//*[@id='passwordNext']/div/button";

    //Write
    public const string BUTTON_WRITE_XPATH = "//div[text() = 'Написать' or text() = 'Compose']"; // //div[@class='z0']
    public const string INPUT_EMAIL_USER_XPATH = "//div[@aria-label='Строка поиска' or @aria-label='Search Field']/div/input"; //input[@role = 'combobox']   
    public const string INPUT_THEME_XPATH = "//input[@name='subjectbox']";
    public const string INPUT_MESSAGE_XPATH = "//div[@aria-label='Текст письма' or @aria-label='Message Body']"; // //div[@class='Am Al editable LW-avf tS-tW']
    public const string SUBMIT_FORM_LATTER_XPATH = "//div[text() = 'Отправить' or text() = 'Send']";
    public const string SEND_MESSAG_XPATH = "//*[text()='Сообщение отправлено.' or text() = 'Message sent']";

    //logout
    public const string AKAUNT_GOOGLE_XPATH = "//a[@class = 'gb_d gb_3a gb_v']";
    public const string LOGOUT_XPATH = "//a[contains(@href,'Logout')]";// "//span[@data-et='10']/child::a"; // "//div[@class = 'SedFmc' and text()='Выйти']";

    
    //Read
    public const string LIST_OF_UNREAD_MESSAGES = "//tr[@class='zA zE x7' or @class='zA zE' ]";

    //Reply
    public const string BUTTON_REPLY_XPATH = "//span[@role = 'link' or text() = 'Ответить']"; 
    public const string INPUT_MESSAGE_TO_REPLY = "//div[@class = 'Am aO9 Al editable LW-avf tS-tW']";

    //return to Inbox tab
    public const string RETURN_TO_INBOX_TAB = "//div[@data-tooltip='Входящие' or @data-tooltip='Inbox']";

    //// message
    //public static string message = "Hello!" + DateTime.Now;

    ////response message 
    //public static string responseMessage = "Hi!" + DateTime.Now;

}
