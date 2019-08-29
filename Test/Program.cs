using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using unirest_net.http;

namespace Test
{
	public class GetResponse
	{

		public GetResponse()
		{
			
		}

		static void Main()
		{
			var getResponse = new GetResponse();
			Print_(getResponse);
		}


		public string GetQuote()
		{
			var country = "canada";
			var city = "port+coquitlam";
			 HttpResponse<string>jsonResponse = Unirest.get("https://community-open-weather-map.p.rapidapi.com/weather?callback=test&id=2172797&units=%22metric%22+or+%22imperial%22&mode=xml%2C+html&q=london%2C+uk")
			.header("X-RapidAPI-Host", "community-open-weather-map.p.rapidapi.com")
			.header("X-RapidAPI-Key", "baa31766f0mshf8829a0c8da5dd9p1a932ajsn480bfe440f3b")
			.asJson<string>();

			var myBody = jsonResponse.Body;

			return myBody.ToString();

		}

		public string GetValue()
		{
			var item = GetQuote();
			int pFrom = item.IndexOf("lat\":") + ("lat\":".Length); //gives starting position
			int pTo = item.IndexOf(",", pFrom);

			var result = item.Substring(pFrom, pTo - pFrom - 1);

			return result;
		}

		public string GetValue1()
		{
			var item = GetQuote();
			int pFrom = item.IndexOf("lon\":") + ("lon\":".Length); //gives starting position
			int pTo = item.IndexOf(",", pFrom);

			var result = item.Substring(pFrom, pTo - pFrom);

			return result;
		}

		private static void Print_(GetResponse response)
		{
			if (response != null)
			{
				Console.WriteLine(string.Format("{0}", response.GetQuote()));
			}
		}
	}
}
