using System;
using System.Text.RegularExpressions;
namespace RegexUtils
{
	public static class RegexUtils
	{
		public static bool IsMatch(string pattern, string str)
		{
			Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(str);
			return match.Success;
		}
		
		/// Является ли строка Ipv6 
		public static bool IsIPAddressV6(string str)
		{
			return IsMatch(@"(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))", str);
		}
		
		/// Является ли строка Ipv4 
		public static bool IsIPAddressV4(string str)
		{
			return IsMatch(@"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)", str);
		}
		
		public static bool IsValidEmail(string str) {
			return IsMatch(@"[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}", str);
		}
		
		/// Совпадает ли строка с шаблоном шестнадцатеричного кода
		public static bool IsColorHex(string str)
		{
			return IsMatch(@"#([a-fA-F0-9]{3,6})", str);
		}
		
		/// Указан ли в адресе url протокол
		// Например: http://yandex.ru
		public static bool IsExistProtocol(string str)
		{
			return IsMatch(@"[a-zA-Z]+:\/\/", str);
		}
		
		/// Является ли номер телефона российским
		public static bool IsRussianNumberPhone(string str)
		{
			return IsMatch(@"((\+?7|8)[ \-] ?)?((\(\d{3}\))|(\d{3}))?([ \-])?(\d{3}[\- ]?\d{2}[\- ]?\d{2})", str);
		}
		
		/// Проверка для любого номера, прежде всего американского
		public static bool IsNumberPhone(string str)
		{
			return IsMatch(@"\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d", str);
		}
		/// Для проверки американских почтовых индексов
		public static bool IsAmericanZipCode(string str)
		{
			return IsMatch(@"\d{5}(?:[-\s]\d{4})?", str);
		}
		/// Для проверки российских почтовых индексов 
		public static bool IsRussianZipCode(string str)
		{
			return IsMatch(@"\d{6}", str);
		}
		/// Является ли строка именем пользователя Twitter
		public static bool IsValidTwitterName(string str)
		{
			return IsMatch(@"@([A-Za-z0-9_]{1,15})", str);
		}
		/// Является ли строка комментарием html
		public static bool IsHtmlComment(string str)
		{
			return IsMatch(@"<!--(.*?)-->", str);
		}
		 
		/// Является ли строка ценой товара
		public static bool IsPrice(string str)
		{
			return IsMatch(@"(\$[0-9,]+(\.[0-9]{2})?)", str);
		}
		/// Проверяем дату на соответствие формату DD/MM/YYYY
		public static bool IsValidDate(string str)
		{
			return IsMatch(@"(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})", str);
		}
		
		public static bool IsValidCard(string str)
		{
			return IsMatch(@"(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})", str);
		}
		
		// Следующие ниже функции проверяют является ли строка номером указанной кредитной карты
		
		// Amex Card
		public static bool IsValidAmexCard(string str)
		{
			return IsMatch(@"3[47][0-9]{13}", str);
		}
		// BCGlobal
		public static bool IsValidBCGlobal(string str)
		{
			return IsMatch(@"(6541|6556)[0-9]{12}", str);
		}
		// Carte Blanche Card
		public static bool IsValidCarteBlancheCard(string str)
		{
			return IsMatch(@"389[0-9]{11}", str);
		}
		// Diners Club Card
		public static bool IsValidDinersClubCard(string str)
		{
			return IsMatch(@"3(?:0[0-5]|[68][0-9])[0-9]{11}", str);
		}
		
		// Discover Card
		public static bool IsValidDiscoverCard(string str)
		{
			return IsMatch(@"65[4-9][0-9]{13}|64[4-9][0-9]{13}|6011[0-9]{12}|(622(?:12[6-9]|1[3-9][0-9]|[2-8][0-9][0-9]|9[01][0-9]|92[0-5])[0-9]{10})", str);
		}
		
		// Insta Payment Card
		public static bool IsValidInstaPaymentCard(string str)
		{
			return IsMatch(@"63[7-9][0-9]{13}", str);
		}
		
		// JCB Card
		public static bool IsValidJCBCard(string str)
		{
			return IsMatch(@"(?:2131|1800|35\d{3})\d{11}", str);
		}
		
		// KoreanLocalCard
		public static bool IsValidKoreanLocalCard(string str)
		{
			return IsMatch(@"9[0-9]{15}", str);
		}
		
		// Laser Card
		public static bool IsValidLaserCard(string str)
		{
			return IsMatch(@"(6304|6706|6709|6771)[0-9]{12,15}", str);
		}
		
		// Maestro Card
		public static bool IsValidMaestroCard(string str)
		{
			return IsMatch(@"(5018|5020|5038|6304|6759|6761|6763)[0-9]{8,15}", str);
		}
		
		// Mastercard
		public static bool IsValidMastercard(string str)
		{
			return IsMatch(@"(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))", str);
		}
		
		// Solo Card
		public static bool IsValidSoloCard(string str)
		{
			return IsMatch(@"(6334|6767)[0-9]{12}|(6334|6767)[0-9]{14}|(6334|6767)[0-9]{15}", str);
		}
		
		// Switch Card
		public static bool IsValidSwitchCard(string str)
		{
			return IsMatch(@"(4903|4905|4911|4936|6333|6759)[0-9]{12}|(4903|4905|4911|4936|6333|6759)[0-9]{14}|(4903|4905|4911|4936|6333|6759)[0-9]{15}|564182[0-9]{10}|564182[0-9]{12}|564182[0-9]{13}|633110[0-9]{10}|633110[0-9]{12}|633110[0-9]{13}", str);
		}
		
		// Union Pay Card
		public static bool IsValidUnionPayCard(string str)
		{
			return IsMatch(@"(62[0-9]{14,17})", str);
		}
		
		// Visa Card
		public static bool IsValidVisaCard(string str)
		{
			return IsMatch(@"4[0-9]{12}(?:[0-9]{3})?", str);
		}
		
		// Visa Master Card
		public static bool IsValidVisaMasterCard(string str)
		{
			return IsMatch(@"(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14})", str);
		}
		
		// Electron
		public static bool IsValidElectron(string str)
		{
			return IsMatch(@"(4026|417500|4405|4508|4844|4913|4917)\d+", str);
		}
		
		// Dankort
		public static bool IsValidDankort(string str)
		{
			return IsMatch(@"(5019|4571)\d+", str);
		}
		
		// Interpay
		public static bool IsValidInterpay(string str)
		{
			return IsMatch(@"(636)\d+", str);
		}
		
		// Mir
		public static bool IsValidMir(string str)
		{
			return IsMatch(@"(?:220[0-4])\d+", str);
		}
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
//			Console.WriteLine(RegexUtils.IsIPAddressV6("2001:0DB8:3C4D:7777:0260:3EFF:FE15:9501 /64"));
//			Console.WriteLine(RegexUtils.IsIPAddressV4("127.0.0.0"));
//			Console.WriteLine(RegexUtils.IsValidEmail("amadon666nachtstern@bk.ru"));
//			Console.WriteLine(RegexUtils.IsColorHex("#FF0000"));
//			Console.WriteLine(RegexUtils.IsExistProtocol("yandex.ru"));
//			Console.WriteLine(RegexUtils.IsRussianNumberPhone("79880711972"));
			//Console.WriteLine(RegexUtils.IsNumberPhone("79880711972"));
//			Console.WriteLine(RegexUtils.IsAmericanZipCode("79880"));
//			Console.WriteLine(RegexUtils.IsValidTwitterName("@name"));
//			Console.WriteLine(RegexUtils.IsHtmlComment("<!-- comment 123 -->"));
			//Console.WriteLine(RegexUtils.IsPrice("$345.23"));
			//Console.WriteLine(RegexUtils.IsValidCard("4000001234567899"));
			//Console.WriteLine(RegexUtils.IsValidDate("12/12/2020"));
			
			// TEST CARDS SUCCESS
			//Console.WriteLine(RegexUtils.IsValidAmexCard("3435781426854254"));
			//Console.WriteLine(RegexUtils.IsValidBCGlobal("6541123467239807"));
			//Console.WriteLine(RegexUtils.IsValidCarteBlancheCard("3890123465775676"));
			//Console.WriteLine(RegexUtils.IsValidDinersClubCard("36348499688894"));
			//Console.WriteLine(RegexUtils.IsValidDiscoverCard("6566345612320989"));
			//Console.WriteLine(RegexUtils.IsValidInstaPaymentCard("6370123465775676"));
			// Console.WriteLine(RegexUtils.IsValidKoreanLocalCard("9890123465775676"));
			//Console.WriteLine(RegexUtils.IsValidLaserCard("6304123465775676"));
			//Console.WriteLine(RegexUtils.IsValidElectron("4026123465775676"));
			//Console.WriteLine(RegexUtils.IsValidDankort("5019123465775676"));
			//Console.WriteLine(RegexUtils.IsValidInterpay("6360123465775676"));
			
			Console.ReadKey(true);
		}
	}
}
