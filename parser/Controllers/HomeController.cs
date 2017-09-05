using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatiN.Core;

namespace parser.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

       // Объявляем структуру

       public struct Info
       {
          public string name;
          public string descr;
          public string image;
          
 
       }

        public Info inf = new Info();


        List<Info> List_Info = new List<Info>();



        public struct Data
        {
            public int a;
            public int b;
            public int c;

        }

        public Data data=new Data();
        

        public ActionResult Index()
        {
            //HtmlWeb web = new HtmlWeb();
            //// создали объект htmlDocument для хранения html страницы
            //// и загрузили туда страницу
            //HtmlDocument htmldoc = web.Load("http://kwazar.dp.ua/ru/sotrudnichestvo");

            //// выбирали div с классом item_page
            //HtmlNode node = htmldoc.DocumentNode.SelectSingleNode("//div[@class='item_page']");

            //// в этом div выбирали все тэги strong которые содержат текст
            //HtmlNode[] nodes = node.SelectNodes(".//strong").ToArray();



            //ViewBag.Spans = nodes;
            //////////foreach (HtmlNode item in nodes)
            //////////{
            //////////    Console.WriteLine(item.InnerHtml);// item.InnerHtml - это текст который содержится в сылке
            //////////}




            //HtmlDocument document2 = new HtmlDocument();
            //document2.Load(@"F:\ciklum\sample.txt");

            //HtmlNode node = document2.DocumentNode.SelectSingleNode("//div[@id='div2']");
            //HtmlNode[] aNodes = node.SelectNodes(@".//a").ToArray();

            //ViewBag.Spans = aNodes;



            // проверка из интернет-магазина   WORKING!!!!!

            //HtmlWeb web = new HtmlWeb();
            //// создали объект htmlDocument для хранения html страницы
            //// и загрузили туда страницу
            //HtmlDocument htmldoc = web.Load("https://zenit-profi.com.ua/elektroinstrument/shurupoverty.html");

            //// выбирали ul с классом products-grid......
            //HtmlNode node = htmldoc.DocumentNode.SelectSingleNode("//ul[@class='products-grid category-products-grid itemgrid itemgrid-adaptive itemgrid-4col centered hover-effect equal-height size-s']");

            //// в этом ul выбирали все тэги а с классом 
            ////HtmlNode[] nodes = htmldoc.DocumentNode.SelectNodes(".//a[@class='product-image']").ToArray();

            //HtmlNode[] nodes = node.SelectNodes(".//a[@class='product-image']").ToArray();


            //// выбирали из div с классом custom_home все span
            ////HtmlNode[] aNodes = node.SelectNodes(@"./span").ToArray();

            //ViewBag.Spans = nodes;


            //return View();

            // Конец проверки из интернет магазина





            // Для загрузки документа из файла используем
            //HtmlDocument document2 = new HtmlDocument();
            //document2.Load(@"C:\Temp\sample.txt");




            HtmlWeb web = new HtmlWeb();
                        // создали объект htmlDocument для хранения html страницы
                        // и загрузили туда страницу
                        HtmlDocument htmldoc = web.Load("https://zenit-profi.com.ua/elektroinstrument/shurupoverty/shurupoverty-akkumuljatornye.html");

            // выбирали ul с классом products-grid......
            //HtmlNode node = htmldoc.DocumentNode.SelectSingleNode("//ul[@class='products-grid category-products-grid itemgrid itemgrid-adaptive itemgrid-4col centered hover-effect equal-height size-s']");


            //  выбирали все тэги li с классом item. // означает, что поиск будет идти по всему документу от его начала
            //  если нам нужен любые элементы с классом item пишем так //*[@class='item']
            // https://msdn.microsoft.com/ru-ru/library/ms256199(v=vs.120).aspx

            // Извлекаем всё текстовое, что есть в теге <div> с классом bla1
            //HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//div[@class='bla1']");
            // Выводим на экран результат работы парсера
            //MessageBox.Show(bodyNode.InnerText);

            // Извлекаем значения
            //HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//div[@class='bla1']/img");
            // Выводим на экран значиение атрибута src
            // у изображения, которое находилось
            // в теге <div> в слассом bla
            //MessageBox.Show(bodyNode.Attributes["src"].Value);

            //pictureBox1.ImageLocation = bodyNode.Attributes["src"].Value;


            HtmlNode[] nodes = htmldoc.DocumentNode.SelectNodes("//li[@class='item']").ToArray();

            List<HtmlNode> node_a = new List<HtmlNode>();
            List<HtmlNode> node_img = new List<HtmlNode>();
            List<HtmlNode> node_price = new List<HtmlNode>();

            List<string> descript = new List<string>();

            // занесли в List-ы нужные нам тэги  .// означает, что поиск осуществляется от корневого элемента
            // в данном случае это элемент li c классом item li[@class='item']
            foreach (HtmlNode item in nodes)
                         { 
                           node_a.Add(item.SelectSingleNode(".//a[@class='product-image']")); // содержит тэг а с сыллкой на характеристики и название в title
                           node_img.Add(item.SelectSingleNode(".//img"));                       // содержит тэг img с сыллкой на фото
                           node_price.Add(item.SelectSingleNode(".//span[@class='price']"));     // содержит тэг span с ценой
            }


            //data.a = node_a.Count;
            //data.b = node_img.Count;
            //data.c = node_price.Count;

            // Сокращаем объем изображений
           // HtmlNode[] sample = new HtmlNode[10];

           //for(int count=0;count<10;count++)
           // {
           //     sample[count] = node_img[count];
           // }

            //ViewBag.a = data;
            //ViewBag.img = sample;
            //ViewBag.price = node_price;

            HtmlDocument htmldoc1;

             

            //Получение характеристик продукции
            //foreach (var a in node_a)
            //{

            //    htmldoc1 = web.Load(a.Attributes["href"].Value);

            //    HtmlNode nodes_descr = htmldoc1.DocumentNode.SelectSingleNode("//div[@class='std']");


            //    // Здесь осуществляется доступ к первому тэгу p расположенному в div с классом std
            //    HtmlNode second_p = nodes_descr.SelectSingleNode("./p[1]");
            //    //nodes_descr.Descendants("p").ElementAt(1);

            //    descript.Add(second_p.InnerText);

            //}


            //ViewBag.descr = descript;


            //Занесение информации в List структур


            for (int count = 0; count < node_img.Count; count++)
            {

                inf.image = node_img[count].Attributes["src"].Value; // записали ссылку на картинку

                inf.name = node_a[count].Attributes["title"].Value; // записали название

                             
                htmldoc1 = web.Load(node_a[count].Attributes["href"].Value);

                    HtmlNode nodes_descr = htmldoc1.DocumentNode.SelectSingleNode("//div[@class='std']");


                    // Здесь осуществляется доступ к первому тэгу p расположенному в div с классом std
                    HtmlNode second_p = nodes_descr.SelectSingleNode("./p[1]");
                    //nodes_descr.Descendants("p").ElementAt(1);

                    inf.descr = second_p.InnerText;
                

                List_Info.Add(inf);
            }


            //Info[] sample_list = new Info[10];

            //for (int count = 0; count < 10; count++)
            //{
            //    sample_list[count] = List_Info[count];
            //}

            ViewBag.list = List_Info;





            return View();

        }
    }
}