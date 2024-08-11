using System;
using HtmlAgilityPack;
namespace AIProject;

public static class GetImageController
{
   

    public async static void GetImage(string url){
        //gelen resimlerin ürün resmi olmasını ayıklamasını yap
        
        HttpClient client = new HttpClient();
        string html = await client.GetStringAsync(url);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        
        var imgTags = doc.DocumentNode.SelectNodes("//img");
        if (imgTags != null)
        {
            foreach (var img in imgTags)
            {
                string src = img.GetAttributeValue("src", string.Empty);
                Console.WriteLine(src);
            }
        }
    }
}
