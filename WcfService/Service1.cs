using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static WcfService.IService1;

namespace WcfService {

    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1 {
        public List<string[]> GetAdvert(int value) {
            List<string[]> adverts = new List<string[]>();
            switch (value) {
                case 1:
                    adverts.Add(new string[] { "http://programistka.ninja/", "programistka.ninja" });
                    adverts.Add(new string[] { "http://eksperci.polsl.pl/eksperci/szczegoly.php?scbpos=&eid=922&", "Dariusz Myszor" });
                    break;
                case 2:
                    adverts.Add(new string[] { "https://pl.wikipedia.org/wiki/Pizza", "pizza" });
                    adverts.Add(new string[] { "https://pl.wikipedia.org/wiki/Sa%C5%82atka", "sałatka" });
                    adverts.Add(new string[] { "https://pl.wikipedia.org/wiki/Zupa", "zupy" });
                    adverts.Add(new string[] { "https://pl.wikipedia.org/wiki/Obiad", "obiady" });
                    break;
                case 3:
                    adverts.Add(new string[] { "https://www.polsl.pl/Strony/Witamy.aspx", "Politechnika Śląska" });
                    adverts.Add(new string[] { "https://www.agh.edu.pl/", "Akademia Górniczo-Hutnicza" });
                    adverts.Add(new string[] { "https://www.uw.edu.pl/", "Uniwersytet Warszawski" });
                    break;
                case 4:
                    adverts.Add(new string[] { "https://pixels.com/", "darmowe zdjęcia" });
                    adverts.Add(new string[] { "https://docs.microsoft.com/pl-pl/dotnet/csharp/language-reference/keywords/switch", "ukończony kurs .NET" });
                    break;
                default:
                    break;
            }
            return adverts;
        }
    }
}

