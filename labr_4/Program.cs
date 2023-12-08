using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LibDB;

IWebDriver driver = new ChromeDriver();
driver.Url = @"https://mama.ru/forums/theme/kakuu-kliniku-vybrat/";

var id = driver.FindElements(By.ClassName("bbp-reply-permalink"));
var names = driver.FindElements(By.ClassName("bbp-author-name"));
var messages = driver.FindElements(By.ClassName("bbp-reply-content"));

List<string> listId = new List<string>();
List<string> listNames = new List<string>();
List<string> listMessages = new List<string>();

foreach (var item in id)
    listId.Add(item.Text);
foreach (var item in names)
    listNames.Add(item.Text);
foreach (var item in messages)
    listMessages.Add(item.Text);


DB db = new DB();

db.OpenConnection();
for (int i = 0; i < listId.Count; i++)
{
    listId[i].Split('#');
    db.Add(Convert.ToInt32(listId[i].Substring(1)), listNames[i], listMessages[i]);
}
db.CloseConnection();
Thread.Sleep(2000);

driver.Quit();
