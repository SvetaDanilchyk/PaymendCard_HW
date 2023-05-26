namespace MailSelenium;

public class Constants
{
    //response message 
    public static string responseMessage = "Hi!" + DateTime.Now;

    public const string LOGIN_IN_XPATH = "//a[@data-label='header' and text()='Войти']";

    //logIn
    public const string INPUT_EMAIL_XPATH = "//input[@type='email']";
    public const string BUTTON_NEXT_LOGIN_XPATH = "//*[@id='identifierNext']/div/button"; //*[@id="passwordNext"]/div/button "//button[.//text()='Далее']" //*[@id="passwordNext"]/div/button
    public const string BUTTON_NEXT_PASSWORD_XPATH = "//*[@id='passwordNext']/div/button";
    public const string INPUT_PASSWORD_XPATH = "//input[@name='Passwd']"; //"//input[@type='password']";

    //Write
    public const string BUTTON_WRITE_XPATH = "//div[@class='z0']"; // /html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div/div
    public const string INPUT_EMAIL_USER_XPATH = "//div[@aria-label='Строка поиска']/div/input"; //input[@role = 'combobox']   
    public const string INPUT_THEME_XPATH = "//input[@name='subjectbox']";
    public const string INPUT_MESSAGE_XPATH = "//div[@class='Am Al editable LW-avf tS-tW']";
    public const string SUBMIT_FORM_LATTER_XPATH = "//div[@class='dC']";
    public const string SEND_MESSAG_XPATH = "//*[text()='Сообщение отправлено.']";

    //logout
    public const string AKAUNT_GOOGLE_XPATH = "//a[@class = 'gb_d gb_3a gb_v']";
    public const string LOGOUT_XPATH = "//a[contains(@href,'Logout')]";// "//span[@data-et='10']/child::a"; // "//div[@class = 'SedFmc' and text()='Выйти']";

    
    //Read
    public const string OPEN_MESSAGE_XPATH = "tr[@class = 'zA zE x7']";//

    //Reply
    public const string BUTTON_REPLY_XPATH = "//span[@role = 'link' and text() = 'Ответить']"; 
    public const string INPUT_MESSAGE_TO_REPLY = "//div[@class = 'Am aO9 Al editable LW-avf tS-tW']";

    // message
    public static string message = "Hello!" + DateTime.Now;

    

    //update
    public const string UPDATE_XPATH = "//*[@id=':4']/div/div[1]/div[1]/div/div/div[5]/div/div";
    //*[@id="yDmH0d"]/c-wiz/div/div/div/div[2]/div[4]/div[1]/button  --- не сейчас
}
