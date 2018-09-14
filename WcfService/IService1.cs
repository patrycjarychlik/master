using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService {
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IService1 {
        [OperationContract]
        List<string[]> GetAdvert(int value);
  
    }

        // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
        // Możesz dodać pliki XSD do projektu. Po skompilowaniu projektu możesz bezpośrednio użyć zdefiniowanych w nim typów danych w przestrzeni nazw „WcfService.ContractType”.
        [DataContract]
        public class CompositeType {
            bool boolValue = true;
            string stringValue = "Hello ";

            [DataMember]
            public bool BoolValue {
                get { return boolValue; }
                set { boolValue = value; }
            }

            [DataMember]
            public string StringValue {
                get { return stringValue; }
                set { stringValue = value; }
        }
    }
}
